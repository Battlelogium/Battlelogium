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

namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIInstaller : Window
    {
        DependencyCheck dependencies;
        WebClient downloader;
        string tempPath = Path.Combine(Path.GetTempPath(), "battlelogium_install");
        public UIInstaller()
        {
            InitializeComponent();
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
        }

        private void installButton_Click(object sender, RoutedEventArgs e)
        {
            Install();
        }

        public async Task Install()
        {
            this.installButton.IsEnabled = false;
            this.dependencies = new DependencyCheck();
            this.downloader = new WebClient();
            progressBar.IsIndeterminate = true;
            await InstallOrigin();
            await InstallWebPlugins();
            setStatusLabelSync("Done");
            progressBar.IsIndeterminate = false;
            progressBar.Value = 100;
        }

        public async Task InstallOrigin()
        {
            await InstallDependency("origin", "Origin");
        }

        public async Task InstallWebPlugins()
        {
            await InstallDependency("webplugin", "Battlelog Web Plugins");
        }

        public async Task InstallDependency(string downloadKey, string labelName)
        {
            string originDownloadUrl = await InstallerCommon.GetDownload(downloadKey);
            this.setStatusLabelSync("Downloading "+labelName+". Please wait...");
            await downloader.DownloadFileTaskAsync(originDownloadUrl, Path.Combine(this.tempPath, downloadKey+"_inst.exe"));
            this.setStatusLabelSync("Installing " + labelName + ". Please wait...");
            await Task.Run(() => Process.Start(Path.Combine(this.tempPath, downloadKey+"_inst.exe"), "/s").WaitForExit());
        }
       
        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void setStatusLabelSync(string content)
        {
            this.Dispatcher.Invoke(() => this.statusLabel.Content = content);
        }
    }
}
