using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Windows.Threading;


namespace Battlelogium.Core
{
    public class UICore
    {
        Origin managedOrigin;
        Window mainWindow;
        public UICore(Battlelog battlelog, Window mainWindow, Grid mainGrid)
        {
            this.mainWindow = mainWindow;
            mainGrid.Children.Add(battlelog.battlelogWebview);
            this.managedOrigin = new Origin();
            this.managedOrigin.StartOrigin();
            mainWindow.Closed += mainWindow_Closed;
           
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            this.managedOrigin.KillOrigin(30000);
        }

    }
}
