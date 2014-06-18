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
using IWshRuntimeLibrary;

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
            try
            {
                if (!Directory.Exists(installPath)) Directory.CreateDirectory(installPath);

                try
                {
                    System.IO.File.Copy(Assembly.GetEntryAssembly().Location, Path.Combine(installPath, "Battlelogium.Installer.exe"), true);
                }
                catch { };
            }
            catch
            {
                MessageBox.Show("Failure occured regarding install directory, please try again");
                Environment.Exit(1);
            }
            this.Hide();
            string url = await InstallerCommon.GetDownload("battlelogium");
            var updater = new Updater(url, installPath);
            updater.DownloadComplete += (s, e) => { this.Close(); };
            updater.BeginUpdate();
        } 

        
        public void FinalizeInstall()
        {
            
            MessageBoxResult steamShortcuts = MessageBox.Show("Add Battlelogium to Steam as a non-Steam game?", "Add Steam shortcuts", MessageBoxButton.OKCancel);
            try
            {
                if (steamShortcuts.Equals(MessageBoxResult.OK))
                {
                    Process.Start("taskkill", "/im steam.exe /f").WaitForExit();
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = Path.Combine(installPath, "Battlelogium.ExecUtils.exe"),
                        Arguments = "addsteam",
                        WorkingDirectory = installPath,
                    });
                }

                Process.Start(Path.Combine(installPath, "Battlelogium.ExecUtils.exe"), "removepar");
            }
            catch
            {

            }
            this.Close();
        }
        public void CreateShortcut(string shortcutName, string description, string exePath)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddr = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddr);
            shortcut.Description = description;
            shortcut.TargetPath = exePath;
            shortcut.Save();
        }

        public async Task InstallOrigin()
        {
            await InstallDependency("origin", "Origin");
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
