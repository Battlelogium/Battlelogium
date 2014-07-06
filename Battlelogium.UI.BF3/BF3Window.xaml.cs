using Battlelogium.Core;
using Battlelogium.Core.UI;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
namespace Battlelogium.UI.BF3
{

    public partial class BF3Window : UIWindow
    {
        public BF3Window()
        {
            MessageBox.Show("BF3Window.Init \n Press OK");
            InitializeComponent();
            MessageBox.Show("BF3Window.InitControl \n Press OK");
            this.MainControl = this.mainControl;
            MessageBox.Show("BF3Window.InitCore \n Press OK");
            this.InitializeCore(new Battlefield3());
        }
    }
}
