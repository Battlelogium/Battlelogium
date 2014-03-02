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
        string installPath;
        public UIInstaller()
        {
            InitializeComponent();
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            setInstallPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),"Battlelogium"));
        }

        private void installButton_Click(object sender, RoutedEventArgs e)
        {
            Install();
        }

        private void setInstallPath(string path){
            this.installPath = path;
            this.Dispatcher.Invoke( () => {
                this.installLabel.Content = "Battlelogium will install to " + this.installPath;
            });
        }
        public async Task Install()
        {
            this.installButton.IsEnabled = false;
            this.dependencies = new DependencyCheck();
            this.downloader = new WebClient();
            progressBar.IsIndeterminate = true;
            await InstallOrigin();
            await InstallWebPlugins();
            new UIUpdater(installPath).Show();
            this.Close();
            
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
            await Task.Run(() => {
                try
                {
                    Process.Start(Path.Combine(this.tempPath, downloadKey + "_inst.exe"), "/s").WaitForExit();
                }
                catch
                {
                    return;
                }
            });
        }
       
        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog()
            {
                SelectedPath = this.installPath
            };
            dialog.ShowDialog();
            setInstallPath(dialog.SelectedPath);
        }

        public void setStatusLabelSync(string content)
        {
            this.Dispatcher.Invoke(() => this.statusLabel.Content = content);
        }
    }
}
