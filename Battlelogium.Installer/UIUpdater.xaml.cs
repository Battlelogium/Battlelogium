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
    public partial class UIUpdater : Window
    {
        public string NewVersion { private get; set; }
        private string tempPath = Path.Combine(Path.GetTempPath(), "battlelogium_install");
        private string installPath;

        private WebClient downloader;

        public UIUpdater(string installPath)
        {
            InitializeComponent();
            this.installPath = installPath;
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            this.NewVersion = new WebClient().DownloadString("http://ron975.github.io/Battlelogium/releaseinfo/releaseversion");
            
            KillBattlelogium();
            DownloadBattlelogium();
        }

        public UIUpdater(int handle) : this()
        {
            try
            {
                var battlelogiumProc = Process.GetProcessById(handle);
                if (!battlelogiumProc.HasExited) battlelogiumProc.WaitForExit();
            }
            catch
            {
                
            }
        }

        public UIUpdater() : this(AppDomain.CurrentDomain.BaseDirectory) { }

        private void KillBattlelogium()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "taskkill",
                Arguments = "/im Battlelogium.UI.BF3.exe /f",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
            Process.Start(new ProcessStartInfo()
            {
                FileName = "taskkill",
                Arguments = "/im Battlelogium.UI.BF4.exe /f",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
        }
        private async Task DownloadBattlelogium()
        {
            this.downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;
            string battlelogiumDownload = await InstallerCommon.GetDownload("battlelogium");
            SetStatusLabelSync("Downloading Battlelogium...");
            this.Dispatcher.Invoke(() => this.urlLabel.Content = "From " + battlelogiumDownload);
            downloader.DownloadFileAsync(new Uri(battlelogiumDownload), Path.Combine(tempPath, "package.zip"));
        }

        public async Task InstallBattlelogium()
        {
            SetStatusLabelSync("Installing Battlelogium...");
            this.progressBar.IsIndeterminate = true;
            await ExtractBattlelogium(installPath);
            this.DialogResult = true;
            SetStatusLabelSync("Done. To uninstall simply delete the folder where Battlelogium is installed.");
            this.exitButton.Visibility = Visibility.Visible;
            this.progressBar.IsIndeterminate = false;
            this.progressBar.Value = 100;
        }
        private async void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            await InstallBattlelogium();
        }

        private async Task ExtractBattlelogium(string extractPath)
        {
            await Task.Run(() =>
            {
                using (ZipArchive package = ZipFile.OpenRead(Path.Combine(tempPath, "package.zip")))
                {
                    foreach (var entry in package.Entries)
                    {
                        string fullPath = Path.Combine(extractPath, entry.FullName);
                        if (String.IsNullOrEmpty(entry.Name))Directory.CreateDirectory(fullPath);
                        else entry.ExtractToFile(fullPath, true);
                    }
                }
            });
            
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
