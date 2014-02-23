using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public Battlelog battlelog;

        public UICore(UIWindow mainWindow)
        {

            this.mainWindow = mainWindow;
            this.battlelog = this.mainWindow.battlelog;
            this.battlelog.javascriptObject.InitJavascriptObject(this);
            this.config = this.mainWindow.config;
            this.mainWindow.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,/images/bg_icon.ico")); //Set runtime icon to Battlelogium badged icon
            this.mainWindow.versionLabel.Content = "Battlelogium " + Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.mainWindow.mainGrid.Children.Add(battlelog.battlelogWebview);
            this.mainWindow.Title = "Battlelogium - " + battlelog.battlefieldName;
            this.mainWindow.Closed += mainWindow_Closed;
            this.mainWindow.PreviewKeyDown += mainWindow_PreviewKeyDown;
            this.mainWindow.PreviewMouseDown += (s, e) => { if (e.ChangedButton == MouseButton.Middle) e.Handled = true; }; //Disable opening link in new window with middle click
            
            this.battlelog.battlelogWebview.PropertyChanged += battlelogWebview_IsLoading;
            

            this.managedOrigin = new Origin();

            if (config.ManageOrigin)
            {
                this.managedOrigin.StartOrigin();
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

            if (config.UseSoftwareRender)
            {
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
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
                        this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.loadingIcon.Visibility = Visibility.Visible; }));
                        break;
                    case false:
                        this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.loadingIcon.Visibility = Visibility.Collapsed; }));
                        break;
                }
            }
        }
    }
}
