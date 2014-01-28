using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;


namespace Battlelogium.Core.Utilities
{
    class ProcessTools
    {

        public static void CreateOrphanedProcess(string path, string args)
        {
            string commandLine = @"""" + path + @""" " + args;
            using (var managementClass = new ManagementClass("Win32_Process"))
            {
                var processInfo = new ManagementClass("Win32_ProcessStartup");
                processInfo.Properties["CreateFlags"].Value = 0x00000008;

                var inParameters = managementClass.GetMethodParameters("Create");
                inParameters["CommandLine"] = commandLine;
                inParameters["ProcessStartupInformation"] = processInfo;

                var result = managementClass.InvokeMethod("Create", inParameters, null);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        public static void KillProcess(Process process, bool waitForExit, bool closeMainWindow)
        {
            try
            {
                if (closeMainWindow)
                {
                    process.CloseMainWindow();
                }
                else
                {
                    process.Kill();
                }
            }
            catch (Exception)
            {
                TerminateProcess(process.Handle, 0); //Forcibly kill the process
            }

            if (waitForExit) process.WaitForExit();
            process.Dispose();
        }

        public static void KillProcess(string processname, bool waitForExit, bool closeMainWindow)
        {
            Process[] processes = Process.GetProcessesByName(processname);
            foreach (Process p in processes)
            {
                KillProcess(p, waitForExit, closeMainWindow);
            }
        }


    }
}
