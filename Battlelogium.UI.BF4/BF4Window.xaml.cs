using Battlelogium.Core;
using Battlelogium.Core.UI;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
using System.Windows;

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
            this.MainControl = this.mainControl;
            this.InitializeCore(new Battlefield4());
        }
    }
}
