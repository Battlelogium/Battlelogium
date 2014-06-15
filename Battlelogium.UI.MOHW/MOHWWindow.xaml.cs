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
using Battlelogium.Core.UI;

namespace Battlelogium.UI.MOHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MOHWWindow : UIWindow
    {
        public MOHWWindow()
        {
            InitializeComponent();
            this.MainControl = this.mainControl;
            this.InitializeCore(new MedalOfHonorWarfighter());
        }
    }
}
