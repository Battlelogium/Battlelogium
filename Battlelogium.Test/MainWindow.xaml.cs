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
namespace Battlelogium.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Test focuses on re-implementing features such as managed origin before porting to .Window
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Battlefield3 bf3blog = new Battlefield3(this, new List<string>());
            BattlelogiumProcess process = new BattlelogiumProcess(bf3blog, this, this.MainGrid);
            
            System.Threading.Thread.Sleep(10000);
           
        }
    }
}
