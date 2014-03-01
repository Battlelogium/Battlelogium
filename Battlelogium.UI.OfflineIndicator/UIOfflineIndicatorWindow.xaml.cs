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
using Battlelogium.Core.Battlelog;
using Battlelogium.Core.Utilities;
using Battlelogium.Core.ManagedOrigin;
using Battlelogium.Core.Configuration;
using System.Windows.Shell;

namespace Battlelogium.UI.OfflineIndicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIOfflineIndicator : Window
    {
        BattlelogBase battlelog;
        
        public UIOfflineIndicator()
        {
            InitializeComponent();
            this.battlelog = new Battlefield3(); //Just temp
            
            //{pack://application:,,,/Battlelogium.Core;component/logo.png}
            this.gameLabel.Content = "You are playing "+battlelog.battlefieldName+" Campaign. Press Enter to minimize Battlelogium";
            this.gameIcon.Source = new BitmapImage(new Uri("pack://application:,,/images/"+battlelog.battlefieldShortname+"/icon.png"));
            this.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,/images/"+battlelog.battlefieldShortname+"/icon.ico"));
            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter) this.WindowState = WindowState.Minimized;
            };
            this.SourceInitialized += (s, e) =>
            {
                this.HideWindowButtons();
                WindowChrome.SetWindowChrome(this, new WindowChrome()
                {
                    CaptionHeight = 14D,
                    ResizeBorderThickness = new Thickness(0)
                });
            };
            
            var origin = new OfflineOrigin(this.battlelog.gameId);
            this.battlelog.GameQuit += (s, e) =>
            {
                MessageBox.Show("bf3 quit");
            };
            this.battlelog.GameStart += (s, e) =>
            {
                MessageBox.Show("bf3 start");
            };
          //  origin.StartOrigin();
        }
    }
}
