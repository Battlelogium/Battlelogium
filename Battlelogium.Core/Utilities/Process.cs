using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading.Tasks;


namespace Battlelogium.Core.Utilities
{
    public class ProcessTools
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int message, int wParam, IntPtr lParam);

        private const int WM_SETICON = 0x80;
        private const int ICON_SMALL = 0;
        private const int ICON_BIG = 1;

        public static void SetWindowIcon(IntPtr handle, Icon icon)
        {
            ProcessTools.SendMessage(handle, WM_SETICON, ICON_BIG, icon.Handle);
            ProcessTools.SendMessage(handle, WM_SETICON, ICON_SMALL, icon.Handle);
        }

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
                switch (closeMainWindow)
                {
                    case true:
                        process.CloseMainWindow();
                        break;
                    case false:
                        if (!process.HasExited) process.Kill();
                        break;
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

        public static bool IsProcessRunning(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);
            if (proc.Length.Equals(0)) return false;
            else return true;
        }
    }

    public class ProcessStartWaiter
    {
        public string processName;

        public delegate void ProcessStartEventHandler(object sender, ProcessStartEventArgs e);
        public event ProcessStartEventHandler ProcessStart;
       
        public ProcessStartWaiter(string processName)
        {
            this.processName = processName;
        }

        public void Listen()
        {
            string queryString =
            "SELECT TargetInstance" +
            "  FROM __InstanceCreationEvent " +
            "WITHIN  10 " +
            " WHERE TargetInstance ISA 'Win32_Process' " +
            "   AND TargetInstance.Name = '" + processName + "'";

            ManagementEventWatcher watcher = new ManagementEventWatcher(queryString);
            watcher.EventArrived += (s, e) =>
            {
                ManagementBaseObject targetInstance = (ManagementBaseObject) e.NewEvent["targetInstance"];
                int pid = Convert.ToInt32(targetInstance["processID"]);
                Process process = Process.GetProcessById(pid);
                OnProcessStart(new ProcessStartEventArgs(process, this.processName));
            };
            watcher.Start();
        }

        public void ListenAsync()
        {
            Task.Run(() => this.Listen());
        }

        private void OnProcessStart(ProcessStartEventArgs e)
        {
            if (ProcessStart != null)
                ProcessStart(this, e);
        }
    }

    public class ProcessStartEventArgs : EventArgs
    {
        public Process Process { get; private set; }
        public string ProcessName { get; private set; }

        public ProcessStartEventArgs(Process process, string processName)
        {
            Process = process;
            ProcessName = processName;
        }
    }

}
