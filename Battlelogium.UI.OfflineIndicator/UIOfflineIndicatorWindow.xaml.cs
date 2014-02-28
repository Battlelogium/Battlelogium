using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Battlelogium.Core.Battlelog;

namespace Battlelogium.UI.OfflineIndicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIOfflineIndicator : Window
    {
        BattlelogBase battlelog;
        public UIOfflineIndicator()
        {
            InitializeComponent();
            this.battlelog = new Battlefield3(); //Just temp

        }
    }
}
