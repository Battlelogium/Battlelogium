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
        private double _spriteVerticalOffset;

        public double SpriteVerticalOffset
        {
            get { return _spriteVerticalOffset; }
            set { _spriteVerticalOffset = value; OnPropertyChanged("SpriteVerticalOffset"); }
        }

        private double _spriteHorizontalOffset;

        public double SpriteHorizontalOffset
        {
            get { return _spriteHorizontalOffset; }
            set {_spriteHorizontalOffset = value; OnPropertyChanged("SpriteHorizontalOffset"); }
        }
        public ImageSource BackgroundImage { private get; set; }

        private ImageSource _loadingSprite;
        public ImageSource LoadingSprite
        {
            get { return _loadingSprite; }
            set { _loadingSprite = value; OnPropertyChanged("LoadingSprite"); }
        }
        public Grid MainGrid { get { return this.mainGrid; } }
        public Animator LoadingIcon { get { return this.loadingIcon; } }

        public UIControl()
        {
            InitializeComponent();  
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
