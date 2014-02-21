using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Input;
using Battlelogium.ThirdParty.Animator;
using System.Windows.Media;



namespace Battlelogium.Core.UI
{
    public class UICore
    {

        Origin managedOrigin;
        UIWindow mainWindow;
        Config config;
        Battlelog battlelog;

        public UICore(UIWindow mainWindow)
        {
            this.battlelog = mainWindow.battlelog;
            this.config = mainWindow.config;
            this.mainWindow = mainWindow;
            this.mainWindow.mainGrid.Children.Add(battlelog.battlelogWebview);
            this.mainWindow.Title = "Battlelogium - " + battlelog.battlefieldName;
            this.managedOrigin = new Origin();
            //this.managedOrigin.StartOrigin();

            mainWindow.Closed += mainWindow_Closed;
            this.battlelog.battlelogWebview.PropertyChanged += battlelogWebview_PropertyChanged;
            switch (this.config.WindowedMode)
            {
                case true:
                    this.mainWindow.SetWindowed();
                    break;
                case false:
                    this.mainWindow.SetFullScreen();
                    break;
            }
        }
        

        private void battlelogWebview_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsLoading")) {
                if (this.battlelog.battlelogWebview.IsLoading) {
                    this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.loadingIcon.Visibility = Visibility.Visible; }));
                    
                }else{
                    this.mainWindow.Dispatcher.Invoke(new Action(delegate { this.mainWindow.loadingIcon.Visibility = Visibility.Collapsed; }));
                }

            }
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            this.managedOrigin.KillOrigin(config.WaitTimeToKillOrigin * 1000);
        }
    }
}
