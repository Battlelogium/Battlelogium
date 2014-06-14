using Battlelogium.Core;
using Battlelogium.Core.UI;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
using System.Diagnostics;
using System.Windows;

namespace Battlelogium.UI.BFH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BFHWindow : UIWindow
    {
        public BFHWindow()
        {
            InitializeComponent();
            this.MainControl = this.mainControl;
            this.InitializeCore(new BattlefieldHardline());
        }
    }
}
