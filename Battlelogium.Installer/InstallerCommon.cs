using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Battlelogium.Installer
{
    internal class InstallerCommon
    {
        public static async Task<string> GetDownload(string dependency)
        {
            string url = await new WebClient().DownloadStringTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/download/" + dependency);
            return url;
        }
    }
}
