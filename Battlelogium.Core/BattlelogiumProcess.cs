using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Battlelogium.Core
{
    public class BattlelogiumProcess
    {
        public BattlelogiumProcess(Battlelog battlelog, Window mainWindow, Grid mainGrid)
        {
            mainGrid.Children.Add(battlelog.battlelogWebview);
            var managedOrigin = new Origin();
            managedOrigin.StartOrigin();
        }
    }
}
