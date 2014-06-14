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
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Battlelogium.Utilities.Update
{
    /// <summary>
    /// Interaction logic for UIUpdater.xaml
    /// </summary>
    public partial class UIDownloader : Window
    {
        private string tempPath = Path.Combine(Path.GetTempPath(), "battlelogium_install");

        private WebClient downloader;

        public UIDownloader(string url, string fileName, string downloadName)
        {
            InitializeComponent();
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            
            DownloadBattlelogium(url, fileName, downloadName);
        }

        private async Task DownloadBattlelogium(string url, string fileName, string downloadName)
        {
            this.downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;
            
            SetStatusLabelSync("Downloading " + downloadName + "...");
            this.Dispatcher.Invoke(() => this.urlLabel.Content = "From " + url);
            downloader.DownloadFileAsync(new Uri(url), Path.Combine(tempPath, fileName));
        }

        private async void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

       
        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            this.Dispatcher.Invoke(()=>progressBar.Value = int.Parse(Math.Truncate(percentage).ToString()));
        }
        public void SetStatusLabelSync(string content)
        {
            this.Dispatcher.Invoke(() => this.statusLabel.Content = content);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
