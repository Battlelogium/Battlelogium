using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                new UIInstaller().Show();
                return;
            }
            if (args[1] == "update")
            {
                if (args.Length == 2) 
                {
                    MessageBox.Show("No update path provided");
                    this.Shutdown();
                }

                InstallerCommon.KillBattlelogium();
                string path = args[2];
                string url = await InstallerCommon.GetDownload("battlelogium");
                var updater = new Updater(url, path);
                updater.BeginUpdate();
                return;
            }
            if (args[1] == "uninstall")
            {
                if (File.Exists("filelist"))
                {
                    InstallerCommon.KillBattlelogium();
                    new UIUninstaller().Show();
                    return;
                }
                MessageBox.Show("filelist not found, Uninstall is unable to continue");
                this.Shutdown();
                return;
            }
            return;
        }
    }
}
