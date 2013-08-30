// -----------------------------------------------------------------------
// <copyright file="UpdateNotifier.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Battlelogium
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Windows.Threading;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UpdateNotifier
    {
        private Version currentVersion;
        private BackgroundWorker updateWorker;
        private Dispatcher dispatcher;

        public UpdateNotifier(Version currentVersion, Dispatcher dispatcher)
        {
            this.currentVersion = currentVersion;
            this.dispatcher = dispatcher;
            this.updateWorker = new BackgroundWorker();
            this.updateWorker.DoWork += delegate { checkUpdates(); };
        }

        private void checkUpdates()
        {
            Utilities.Log("Checking for new version"); 
            WebClient updateChecker = new WebClient();
            try
            {
                Version newVersion = new Version(updateChecker.DownloadString(new Uri("https://raw.github.com/ron975/Battlelogium/master/currentreleaseversion")));
                Utilities.Log("Downloaded version number");
                if (newVersion > currentVersion)
                {
                    Utilities.Log(String.Format("currentVersion = {0}, newVersion = {1}",currentVersion.ToString(), newVersion.ToString()));
                    dispatcher.BeginInvoke(new Action(delegate{
                        if (Utilities.ShowChoiceDialog("There is a new version available. Open the thread on the Steam Users' Forums? You can disable version checking in config.ini", "New Version Available", "Open the thread", "Ignore"))
                        {
                            Process.Start("http://forums.steampowered.com/forums/showthread.php?t=3140249");
                        }
                    }));
                }
            }
            catch
            {
                Utilities.Log("Unable to get new version");
                return;
            }
        }

        public void run()
        {
            this.updateWorker.RunWorkerAsync();
        }
    }
}
