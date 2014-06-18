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
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Reflection;

namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIUninstaller : Window
    {
        public UIUninstaller()
        {
            InitializeComponent();
        }

        private void uninstallButton_Click(object sender, RoutedEventArgs e)
        {
            Uninstall();
            ControlPanel.RemoveControlPanelProgram("Battlelogium");
            MessageBox.Show("Battlelogium has been uninstalled");
            this.Close();
        }

        private void Uninstall()
        {
            string installPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (string battlelogiumFile in File.ReadAllLines(Path.Combine(installPath, "filelist")))
            {
                try
                {
                    File.Delete(Path.Combine(installPath, battlelogiumFile));
                }
                catch { continue; }
            }
        }
       
    }
}
