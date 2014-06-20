//#define NO_ORIGIN //I don't want Origin to start if I'm debugging and I have no need to.
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
using Battlelogium.Core.ManagedOrigin;
using Battlelogium.Utilities;
using System.Diagnostics;
using System.Net;
using Battlelogium.Core.Update;
using System.IO;

namespace Battlelogium.Core.UI
{

    /// <summary>
    /// Provides methods to interact with the User Interface
    /// </summary>
    public class UICore
    {
        public Origin managedOrigin;
        public UIWindow mainWindow;
        public Config config;
        public BattlelogBase battlelog;

        public bool IsInitialized { get; private set; }

        public UICore(UIWindow mainWindow, BattlelogBase battlelog, Config config)
        {
            this.mainWindow = mainWindow;
            this.battlelog = battlelog;
            this.config = config;
            this.managedOrigin = new Origin();
        }

        public async Task Initialize()
        {
            this.mainWindow.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,/images/bg_icon.ico")); //Set runtime icon to Battlelogium badged ico
            switch (this.config.FullscreenMode)
            {
                case true:
                    this.mainWindow.SetFullScreen();
                    break;
                case false:
                    this.mainWindow.SetWindowed();
                    break;
            }
            if (config.CheckUpdates) await this.CheckUpdate();
            bool isBattlelogAvailable = await BattlelogBase.CheckBattlelogConnectionAsync();
            if (!isBattlelogAvailable)
            {
                bool offlineMode = MessageBoxUtils.ShowChoiceDialog("Battlelog is unavailable. Would you like to start Offline Campaign?", "Battlelog unavailable", "Start Campaign", "Exit Battlelogium");
                switch (offlineMode)
                {
                    case true:
                        this.StartOfflineMode();
                        return;
                    case false:
                        this.mainWindow.Close();
                        return;
                }
            }
            this.battlelog.InitializeWebview();
            this.battlelog.javascriptObject.InitJavascriptObject(this);
            this.mainWindow.MainControl.VersionNumber = "Battlelogium " + Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.mainWindow.MainControl.MainGrid.Children.Add(battlelog.battlelogWebview);
            this.mainWindow.Title = "Battlelogium - " + battlelog.battlefieldName;
            this.mainWindow.Closed += (s, e) =>
            {
                if (config.ManageOrigin)
                {
                    this.managedOrigin.KillOrigin(config.WaitTimeToKillOrigin * 1000);
                }
            };
            this.mainWindow.PreviewKeyDown += mainWindow_PreviewKeyDown;
            this.mainWindow.PreviewMouseDown += (s, e) => { if (e.ChangedButton == MouseButton.Middle) e.Handled = true; }; //Disable opening link in new window with middle click
            this.battlelog.battlelogWebview.PropertyChanged += battlelogWebview_IsLoading;
            this.mainWindow.StateChanged += (s, e) => {
                try
                {
                    this.battlelog.battlelogWebview.ExecuteScript("windowbutton.updateMaximizeButton()");
                }catch{

                }
            };

            if (config.ManageOrigin)
            {
#if !NO_ORIGIN //ugly ifdefs are ugly. 
                this.managedOrigin.StartOrigin();
#endif 
            }
            if (config.DisableHardwareAccel)
            {
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
            }
            this.IsInitialized = true;
        }

        private async Task CheckUpdate()
        {
            Version currentVersion = Assembly.GetEntryAssembly().GetName().Version;
            
            Version newVersion = Version.Parse(await new WebClient().DownloadStringTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/releaseversion"));
            if (newVersion > currentVersion)
            {
                bool? updateStart = new UIUpdateNotifier().ShowDialog();
                switch (updateStart)
                {
                    case null:
                        return;
                    case false:
                        return;
                    case true:
                        await UpdateBattlelogium();
                        break;
                }
            }
        }

        internal async Task UpdateBattlelogium()
        {
                        string url = await new WebClient().DownloadStringTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/download/installer");
                        this.mainWindow.Dispatcher.Invoke(() => this.mainWindow.Hide());
                        string filename = Path.GetFileName(new Uri(url).LocalPath);
                        var dl = new UIDownloader(url, filename, "Updating Battlelogium...");
                        dl.DownloadComplete += (s, e) =>
                        {
                            dl.SyncCloseWindow();
                            Process.Start(e.completedFilePath, @"update "+"\""+Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\"");
                            this.mainWindow.Dispatcher.Invoke(() => this.mainWindow.Close());
                        };
                        dl.Show();
                        dl.Start();
        }
        private void StartOfflineMode()
        {
            Process.Start("Battlelogium.UI.OfflineIndicator.exe", this.battlelog.battlefieldShortname);
            this.mainWindow.Close();
        }

        #region Event Handlers
        private void mainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                this.battlelog.battlelogWebview.Reload();
                return;
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.Enter)
            {
                switch (this.mainWindow.IsFullscreen)
                {
                    case true:
                        this.mainWindow.SetWindowed();
                        break;
                    case false:
                        this.mainWindow.SetFullScreen();
                        break;
                }
                e.Handled = true;
            }
        }
        
        private void battlelogWebview_IsLoading(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsLoading"))
            {
                switch (this.battlelog.battlelogWebview.IsLoading)
                {
                    case true:
                        this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.MainControl.LoadingIcon.Visibility = Visibility.Visible; }));
                        break;
                    case false:
                        this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.MainControl.LoadingIcon.Visibility = Visibility.Collapsed; }));
                        break;
                }
            }
        }
        #endregion
    }
}
