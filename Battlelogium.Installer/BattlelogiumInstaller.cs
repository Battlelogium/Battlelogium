using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlelogium.Installer
{
    internal class BattlelogiumInstaller : UIDownloader
    {
        string installPath;
        internal BattlelogiumInstaller(string url, string installPath):base(url, "package.zip", "Downloading Battlelogium...")
        {
            this.installPath = installPath;
        }

        internal async Task BeginUpdate()
        {
            this.DownloadComplete += async (s, e) =>
            {
                await InstallerCommon.ExtractZipFile(e.completedFilePath, installPath);
                var completed = new UIComplete(installPath);
                completed.Show();
                completed.Activate();
                this.SyncCloseWindow();
            };
            this.Show();
            this.Start();
        }
    }
}
