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
using PropertyChanged;

namespace Battlelogium.Shell.Controls
{
    /// <summary>
    /// Interaction logic for BattlelogView.xaml
    /// </summary>
    [ImplementPropertyChanged]
    public partial class BattlelogView : UserControl
    {
        public double SpriteVerticalOffset { get; set; }
        public double SpriteHorizontalOffset { get; set; }
        public string Address { get; set; }
        public ImageSource BackgroundImage { get; set; }
        public ImageSource LoadingSprite { get; set; }
        public Animator LoadingIcon => this.loadingIcon;
        public JavascriptController Controller { get; set; }
        public BattlelogView()
        {
            InitializeComponent();
          
        }
    }
}
