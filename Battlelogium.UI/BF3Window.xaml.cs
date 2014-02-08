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
        public BF3Window()
        {
            InitializeComponent();
            Battlefield3 bf3blog = new Battlefield3(this);
            UICore process = new UICore(bf3blog, this, this.MainGrid);
        }
    }
}
