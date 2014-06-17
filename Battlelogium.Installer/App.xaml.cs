using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            return;
        }
    }
}
