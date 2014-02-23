using Battlelogium.Core;
using Battlelogium.Core.UI;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Battlelogium.Core.Utilities;

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
            this.loadingIcon = this.LoadingIcon;
            this.uiCore = new UICore(this);

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.battlelog.battlelogWebview.ShowDevTools();


        }
    }
}
