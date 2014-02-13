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
using Battlelogium.Core;
using CefSharp.Wpf;
using Battlelogium.Core.UI;
using Battlelogium.ThirdParty.WPFCustomMessageBox;

namespace Battlelogium.UI.BF3
{

    public partial class BF3Window : UIWindow
    {
        public BF3Window()
        {
            InitializeComponent();
            this.battlelog = new Battlefield3(this);
            this.config = new Config();
            this.mainGrid = this.MainGrid;
            this.process = new UICore(this);
            this.loadingIcon = this.LoadingIcon;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.Show("test");
        }
    }
}
