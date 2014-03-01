using Battlelogium.Core.Utilities;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Drawing;
using Battlelogium.Core.Battlelog;
using System.Threading.Tasks;
namespace Battlelogium.Core.ManagedOrigin
{
    /// <summary>
    /// Represents an instance of the Origin process
    /// </summary>
    public class Origin
    {
        string originPath;
        string commandLineOptions;
        bool restartOrigin;
        bool closedSafely;

        public Process originProcess;

        public delegate void OriginCloseEvent(object sender, OriginCloseEventArgs e);
        public event OriginCloseEvent OriginClose;

        public delegate void OriginUnexpectedCloseEvent(object sender);
        public event OriginUnexpectedCloseEvent OriginUnexpectedClose;

        public Origin(string commandLineOptions)
        {
            this.commandLineOptions = commandLineOptions;
            this.OriginClose += Origin_OriginClose;
        }
        public Origin() : this("/StartClientMinimized") { } //Minimized Origin by default


        #region Origin
        private void Origin_OriginClose(object sender, OriginCloseEventArgs args)
        {
            if (args.restartOrigin) Origin.CreateUnmanagedInstance();
        }

        public void StartOrigin()
        {
            this.originPath = GetOriginPath();
            var originProcessInfo = new ProcessStartInfo(this.originPath, this.commandLineOptions);
            if (OriginRunning())  //We must relaunch Origin as a child process for Steam to properly apply the overlay hook.
            {
                ProcessTools.KillProcess("Origin", true, false);
                this.restartOrigin = true;
            }
            this.originProcess = Process.Start(originProcessInfo);
            this.ListenForUnexpectedClose();

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
            OriginClose(this, new OriginCloseEventArgs(this.restartOrigin));
            ProcessTools.KillProcess(this.originProcess, true, false);
            ProcessTools.KillProcess("sonarhost", false, false);
            this.closedSafely = true;
        }

        public void KillOrigin(int timeout)
        {
            Thread.Sleep(timeout);
            this.KillOrigin(); 
            
        }

        private async Task ListenForUnexpectedClose()
        {
            await Task.Run(() => this.originProcess.WaitForExit());
            if (!this.closedSafely && this.OriginUnexpectedClose != null) OriginUnexpectedClose(this);
        }
        public static void CreateUnmanagedInstance()
        {
            ProcessTools.CreateOrphanedProcess(GetOriginPath(), "/StartClientMinimized");
        }
        #endregion
    }

    public class OriginCloseEventArgs
    {
        public bool restartOrigin;
        public OriginCloseEventArgs(bool restartOrigin)
        {
            this.restartOrigin = restartOrigin;
        }
    }
}