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
using Battlelogium;
namespace Battlelogium.UI.BF3
{

    public partial class BF3Window : Window
    {
        Battlefield3 bf3blog;
        UICore process;
        public BF3Window()
        {
            InitializeComponent();
            this.bf3blog = new Battlefield3(this);
            this.process = new UICore(bf3blog, this, this.MainGrid);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.bf3blog.battlelogWebview.ShowDevTools();
        }
    }
}
