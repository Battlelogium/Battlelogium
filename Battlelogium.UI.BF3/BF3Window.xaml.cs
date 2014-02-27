using Battlelogium.Core;
using Battlelogium.Core.UI;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Battlelogium.Core.Utilities;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
namespace Battlelogium.UI.BF3
{

    public partial class BF3Window : UIWindow
    {
        public BF3Window()
        {
            InitializeComponent();
            this.battlelog = new Battlefield3();
            this.config = new Config();
            this.mainGrid = this.Control.MainGrid;
            this.loadingIcon = this.Control.LoadingIcon;
            this.versionLabel = this.Control.VersionLabel;
            this.uiCore = new UICore(this);
        }
    }
}
