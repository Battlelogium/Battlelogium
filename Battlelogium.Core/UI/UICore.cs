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
            //this.CheckBattlelogConnection();
            this.config = config;
            this.managedOrigin = new Origin();
        }

        public void Initialize()
        {
            this.battlelog.InitializeWebview();
            this.battlelog.javascriptObject.InitJavascriptObject(this);
            this.mainWindow.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,/images/bg_icon.ico")); //Set runtime icon to Battlelogium badged icon
            this.mainWindow.MainControl.VersionNumber = "Battlelogium " + Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.mainWindow.MainControl.MainGrid.Children.Add(battlelog.battlelogWebview);
            this.mainWindow.Title = "Battlelogium - " + battlelog.battlefieldName;
            this.mainWindow.Closed += mainWindow_Closed;
            this.mainWindow.PreviewKeyDown += mainWindow_PreviewKeyDown;
            this.mainWindow.PreviewMouseDown += (s, e) => { if (e.ChangedButton == MouseButton.Middle) e.Handled = true; }; //Disable opening link in new window with middle click

            this.battlelog.battlelogWebview.PropertyChanged += battlelogWebview_IsLoading;

            if (config.ManageOrigin)
            {
#if !NO_ORIGIN //ugly ifdefs are ugly. 
                this.managedOrigin.StartOrigin();
#endif 
            }

            switch (this.config.FullscreenMode)
            {
                case true:
                    this.mainWindow.SetFullScreen();
                    break;
                case false:
                    this.mainWindow.SetWindowed();
                    break;
            }

            if (config.DisableHardwareAccel)
            {
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
            }
            this.IsInitialized = true;
        }

        private async Task CheckBattlelogConnection()
        {
            bool connection = await BattlelogBase.CheckBattlelogConnectionAsync();
            switch (connection)
            {
                case true:
                    //Do something
                    break;
                case false:
                    //Do something
                    break;
            }
        }
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
        
        private void mainWindow_Closed(object sender, EventArgs e)
        {
            if (config.ManageOrigin)
            {
                this.managedOrigin.KillOrigin(config.WaitTimeToKillOrigin * 1000);
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
    }
}
