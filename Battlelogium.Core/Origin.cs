namespace Battlelogium.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using System.Net;
    using System.Diagnostics;
    using System.IO;
    using Battlelogium.Core.Utilities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Origin
    {
        string originPath;
        string commandLineOptions;
        bool battlelogConnection;
        Process originProcess;
        public Origin(string originPath, string commandLineOptions)
        {
            this.originPath = originPath;
            this.commandLineOptions = commandLineOptions;
            this.battlelogConnection = CheckForBattlelogConnection();
        }

        public Origin(string commandLineOptions) : this(Origin.GetOriginPath(), commandLineOptions) { }


        #region Origin

        public void StartOrigin()
        {
           
            string originPath = GetOriginPath();
            var originProcessInfo = new ProcessStartInfo(this.originPath, this.commandLineOptions);
           
            ProcessTools.KillProcess("Origin", true, false);
            //We must relaunch Origin as a child process for Steam to properly apply the overlay hook.
          
            this.originProcess = Process.Start(originProcessInfo);

        }


        public static bool OriginRunning()
        {
            Process[] pname = Process.GetProcessesByName("Origin");
            if (pname.Length == 0)
            {
                return false;
            }
            else
            {
           
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
                    
                }
                else
                {
                    originPath =
                        Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Origin", "ClientPath", originDefaultPath).ToString();
                  
                }
                return originPath;
            }
            catch (Exception)
            {
                return originDefaultPath;
            }
        }

        public void KillOrigin()
        {
            ProcessTools.KillProcess(this.originProcess, true, false);
        }

        public static void CreateUnmanagedInstance()
        {
            ProcessTools.CreateOrphanedProcess(GetOriginPath(), "/StartClientMinimized");
        }
        #endregion
    }
}