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
            this.battlelog = new Battlefield4(); 
            this.config = new Config();
            this.MainControl = this.mainControl;
            this.uiCore = new UICore(this);
        }
    }
}
