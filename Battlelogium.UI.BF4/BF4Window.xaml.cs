using Battlelogium.Core;
using Battlelogium.Core.UI;
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
            this.battlelog = new Battlefield4(this); //TODO Battlefield 4
            this.config = new Config();
            this.mainGrid = this.MainGrid;
            this.loadingIcon = this.LoadingIcon;
            this.versionLabel = this.VersionLabel;
            this.uiCore = new UICore(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.battlelog.battlelogWebview.ShowDevTools();
        }
    }
}
