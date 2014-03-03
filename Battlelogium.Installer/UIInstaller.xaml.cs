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
            SetInstallPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),"Battlelogium"));
        }

        private void installButton_Click(object sender, RoutedEventArgs e)
        {
            Install();
        }

        private void SetInstallPath(string path){
            this.installPath = path;
            this.Dispatcher.Invoke( () => {
                this.installLabel.Content = "Battlelogium will install to " + this.installPath;
            });
        }
        public async Task Install()
        {
            this.installButton.IsEnabled = false;
            this.browseButton.IsEnabled = false;
            this.dependencies = new DependencyCheck();
            this.downloader = new WebClient();
            progressBar.IsIndeterminate = true;
            if(!this.dependencies.IsOriginInstalled) await InstallOrigin();
            if (!this.dependencies.IsWebPluginInstalled) await InstallWebPlugins();
            if (!Directory.Exists(installPath)) Directory.CreateDirectory(installPath);
            File.Copy(Assembly.GetEntryAssembly().Location, Path.Combine(installPath, "Battlelogium.Installer.exe"), true);
            this.Hide();
            new UIUpdater(installPath).ShowDialog();
            MessageBoxResult steamShortcuts = MessageBox.Show("Add Battlelogium to Steam as a non-Steam game?", "Add Steam shortcuts", MessageBoxButton.OKCancel);
            if (steamShortcuts.Equals(MessageBoxResult.OK))
            {
                Process.Start("taskkill", "/im steam.exe /f").WaitForExit();
                Process.Start(Path.Combine(installPath, "Battlelogium.ExecUtils.exe"), "addsteam");
            }
            Process.Start(Path.Combine(installPath, "Battlelogium.ExecUtils.exe"), "removepar");
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
            this.SetStatusLabelSync("Downloading "+labelName+". Please wait...");
            await downloader.DownloadFileTaskAsync(originDownloadUrl, Path.Combine(this.tempPath, downloadKey+"_inst.exe"));
            this.SetStatusLabelSync("Installing " + labelName + ". Please wait...");
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
            SetInstallPath(dialog.SelectedPath);
        }

        public void SetStatusLabelSync(string content)
        {
            this.Dispatcher.Invoke(() => this.statusLabel.Content = content);
        }
    }
}
