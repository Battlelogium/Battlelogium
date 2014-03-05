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
            InitializeComponent();
            this.MainControl = this.mainControl;
            this.InitializeCore(new Battlefield3());
        }
    }
}
