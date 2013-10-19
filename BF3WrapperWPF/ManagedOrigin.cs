// -----------------------------------------------------------------------
// <copyright file="ManagedOrigin.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Battlelogium
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using System.Net;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ManagedOrigin
    {
        string originPath;
        string commandLineOptions;
        bool battlelogConnection;
        Process originProcess;
        public ManagedOrigin(string originPath, string commandLineOptions)
        {
            this.originPath = originPath;
            this.commandLineOptions = commandLineOptions;
            this.battlelogConnection = CheckForBattlelogConnection();
        }

        public ManagedOrigin(string commandLineOptions) : this(ManagedOrigin.GetOriginPath(), commandLineOptions) { }


        #region Origin

        public void StartOriginProcess()
        {
            Utilities.Log("GetOriginPath()");
            string originPath = GetOriginPath();
            var originProcessInfo = new ProcessStartInfo(this.originPath, this.commandLineOptions);
            Utilities.Log("KillProcess(Origin)");
            Utilities.KillProcess("Origin");
            //We must relaunch Origin as a child process for Steam to properly apply the overlay hook.
            Utilities.Log("Process.Start(originProcessInfo)");
            this.originProcess = Process.Start(originProcessInfo);
           
        }

        private bool CheckForBattlelogConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://battlelog.battlefield.com/"))
                {
                    Utilities.Log("Battlelog Accessible");
                    return true;
                }
            }
            catch
            {
                Utilities.Log("Battlelog Unaccessible");
                return false;
            }
        }

        public static bool CheckIfOriginIsRunning()
        {
            Process[] pname = Process.GetProcessesByName("Origin");
            if (pname.Length == 0)
            {
                Utilities.Log("Origin is not running");
                return false;
            }
            else
            {
                Utilities.Log("Origin is running");
                return true;
            }
        }

        private static string GetOriginPath()
        {
            string originDefaultPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Origin", "Origin.exe");
            string originPath;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    originPath =
                        Registry.GetValue(
                            @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Origin", "ClientPath", originDefaultPath).ToString();
                    Utilities.Log("Got " + originPath);
                }
                else
                {
                    originPath =
                        Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Origin", "ClientPath", originDefaultPath).ToString();
                    Utilities.Log("Got " + originPath);
                }
                return originPath;
            }
            catch (Exception)
            {
                return originDefaultPath;
            }
        }

        public void KillOriginProcess()
        {
            this.originProcess.Kill();
        }

        public static void CreateUnmanagedInstance()
        {
            Utilities.CreateOrphanedProcess(GetOriginPath(), "/StartClientMinimized");
        }
        #endregion
    }
}
