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
using Battlelogium.Utilities;
using Battlelogium.Core.ManagedOrigin;
using Battlelogium.Core.Configuration;
using System.Windows.Shell;
using System.Diagnostics;

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
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length <= 1)
            {
                MessageBox.Show("Invalid Commandline Parameters - BF3 for Battlefield 3, BF4 for Battlefield 4");
                Environment.Exit(1);
            }
            Config config = new Config();
            switch(args[1]){
                
                case "BF3":
                    this.battlelog = new Battlefield3();
                    break;
                case "BF4":
                    this.battlelog = new Battlefield4();
                    break;
                case "MOHW":
                    this.battlelog = new MedalOfHonorWarfighter();
                    break;
                case "BFH":
                    this.battlelog = new BattlefieldHardline();
                    break;
                default:
                   MessageBox.Show("Invalid Commandline Parameters - bf3 for Battlefield 3, bf4 for Battlefield 4,,bfh for Hardline, mohw for Medal of Honor Warfighter");
                   Environment.Exit(1);
                   break;
            }
            InitializeComponent();            
            this.gameLabel.Content = "You are playing "+battlelog.battlefieldName+" Campaign. Please log in to Origin when prompted.";
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
            origin.OriginUnexpectedClose += (s) => this.Dispatcher.Invoke(() => this.Close());
            this.battlelog.GameQuit += (s, e) =>
            {
                origin.KillOrigin();
                this.Dispatcher.Invoke(() => this.Close());
            };
           
           origin.StartOrigin();
        }
    }
}
