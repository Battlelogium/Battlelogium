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
using System.ComponentModel;
using Battlelogium.ThirdParty.Animator;

namespace Battlelogium.Core.UI
{
    /// <summary>
    /// Interaction logic for UIWindowControl.xaml
    /// </summary>
    public partial class UIControl : UserControl, INotifyPropertyChanged
    {

        public string VersionNumber { private get; set; }
        public double SpriteVerticalOffset { get; set; }
        public double SpriteHortizontalOffset { get; set; }
        public ImageSource BackgroundImage { private get; set; }
        private ImageSource loadingSprite;
        public ImageSource LoadingSprite
        {
            get;
            set;
        }
        public Grid MainGrid { get { return this.mainGrid; } }
        public Animator LoadingIcon { get { return this.loadingIcon; } }

        public UIControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
