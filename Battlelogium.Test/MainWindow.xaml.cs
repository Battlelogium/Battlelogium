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
namespace Battlelogium.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Battlefield3 bf3blog = new Battlefield3(this, new List<string>());
            //bf3blog.battlelogWebview.Address = "http://punyman.com";
            //bf3blog.battlelogWebview.Address = "file:///C:/Users/RonnyAdmin/Documents/helloworld.html";
            this.MainGrid.Children.Add(bf3blog.battlelogWebview);
         
            
        }
    }
}
