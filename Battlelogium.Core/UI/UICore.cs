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
            this.mainWindow.RightClickDrag();
            this.mainWindow.mainGrid.Children.Add(battlelog.battlelogWebview);
            this.managedOrigin = new Origin();
            this.managedOrigin.StartOrigin();
            mainWindow.Closed += mainWindow_Closed;
            mainWindow.Height = config.WindowHeight;
            mainWindow.Width = config.WindowWidth;
            

        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            this.managedOrigin.KillOrigin(30000);
        }
    }
}
