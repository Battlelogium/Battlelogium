using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace Battlelogium.Core
{
    public class UICore
    {
        Origin managedOrigin;
        public UICore(Battlelog battlelog, Window mainWindow, Grid mainGrid)
        {
            mainGrid.Children.Add(battlelog.battlelogWebview);
            this.managedOrigin = new Origin();
            this.managedOrigin.StartOrigin();
            mainWindow.Closed += mainWindow_Closed;
           
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            this.managedOrigin.KillOrigin();
        }
    }
}
