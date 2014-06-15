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
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace Battlelogium.Core.Update
{
    /// <summary>
    /// Interaction logic for UIUpdateNotifier.xaml
    /// </summary>
    public partial class UIUpdateNotifier : Window
    {
        public UIUpdateNotifier()
        {
            InitializeComponent();
            LoadChangelog();
        }
        public async Task LoadChangelog()
        {
            var downloader = new WebClient();
            string version = await downloader.DownloadStringTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/releaseversion");
            MemoryStream changenotes = new MemoryStream(await downloader.DownloadDataTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/releasenotes.rtf"));
            this.Dispatcher.Invoke(() =>
            {
                new TextRange(changeLogBox.Document.ContentStart, changeLogBox.Document.ContentEnd).Load(changenotes, DataFormats.Rtf);
                this.versionLabel.Content = "Version " + version;
            });
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void ignoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
