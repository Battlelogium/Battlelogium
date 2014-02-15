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
using Battlelogium.Core.UI;
using Battlelogium.Core;

namespace Battlelogium.UI.BF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BF4Window : UIWindow
    {
        public BF4Window()
        {
            InitializeComponent();
            this.battlelog = new Battlefield4(this); //TODO Battlefield 4
            this.config = new Config();
            this.mainGrid = this.MainGrid;
            this.loadingIcon = this.LoadingIcon;
            this.process = new UICore(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.battlelog.battlelogWebview.ShowDevTools();
        }
    }
}
