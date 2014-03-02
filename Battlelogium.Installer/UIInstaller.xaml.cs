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
using System.Net;

namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIInstaller : Window
    {
        DependencyCheck dependencies;
        public UIInstaller()
        {
            InitializeComponent();
        }

        private void installButton_Click(object sender, RoutedEventArgs e)
        {
            Install();
        }

        public void Install()
        {
            this.dependencies = new DependencyCheck();
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;

        }

        private void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;

        this.progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());

        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
