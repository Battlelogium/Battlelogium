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
using Battlelogium.ThirdParty.Animator;

namespace Battlelogium.Core.UI
{
    /// <summary>
    /// Interaction logic for UIWindowControl.xaml
    /// </summary>
    public partial class UIWindowControl : UserControl
    {
        public ImageSource BackgroundImage { private get; set; }
        public ImageSource LoadingSprite { private get; set; }
        public Grid MainGrid { get { return this.mainGrid; } }
        public Animator LoadingIcon { get { return this.loadingIcon; } }
        public Label VersionLabel { get { return this.versionLabel; } }

        public UIWindowControl()
        {
            InitializeComponent();
        }
    }
}
