using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlelogium.Installer
{
    internal class Updater
    {
        string installPath;
        bool showUIComplete;
        internal Updater(string installPath, bool showUIComplete)
        {
            this.installPath = installPath;
            this.showUIComplete = showUIComplete;
        }

        internal async Task StartUpdate()
        {
            string url = await InstallerCommon.GetDownload("battlelogium");
            var dl = new UIDownloader(url, "package.zip", "Downloading Battlelogium ...");
            dl.DownloadComplete += async (s, e) =>
            {
                await InstallerCommon.ExtractZipFile(e.completedFilePath, this.installPath);
                dl.SyncCloseWindow();
                if (this.showUIComplete) new UIComplete(this.installPath).Show();
            };
            dl.Show();
            dl.Start();
        }
    }
}
