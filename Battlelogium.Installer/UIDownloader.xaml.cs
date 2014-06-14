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

namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for UIUpdater.xaml
    /// </summary>
    public partial class UIDownloader : Window
    {
        public delegate void DownloadCompleteEventHandler(object sender, DownloadArgs args);
        public event DownloadCompleteEventHandler DownloadComplete;

        private string tempPath = Path.Combine(Path.GetTempPath(), "battlelogium_install");

        private WebClient downloader;

        private string url;
        private string fileName;
        private string statusDescription;
        public UIDownloader(string url, string fileName, string statusDescription)
        {
            InitializeComponent();
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            this.Topmost = true;
            this.url = url;
            this.fileName = fileName;
            this.statusDescription = statusDescription;
        }

        public async Task Start()
        {
            this.downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            SetStatusLabelSync(this.statusDescription);
            this.Dispatcher.Invoke(() => this.urlLabel.Content = "From " + this.url);
            downloader.DownloadFileAsync(new Uri(this.url), Path.Combine(tempPath, this.fileName));
        }

        private async void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (this.DownloadComplete != null)
                this.DownloadComplete(this, new DownloadArgs(Path.Combine(tempPath, this.fileName)));

        }

        public void SyncCloseWindow()
        {
            this.Dispatcher.Invoke(() => this.Close());
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            this.Dispatcher.Invoke(() => progressBar.Value = int.Parse(Math.Truncate(percentage).ToString()));
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

    public class DownloadArgs
    {
        public string completedFilePath;
        public DownloadArgs(string completedFilePath)
        {
            this.completedFilePath = completedFilePath;
        }
    }
}
