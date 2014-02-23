using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;


namespace Battlelogium.Core.Utilities
{
    public class ProcessTools
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

    public class ProcessStartWaiter
    {
        public string processName;

        private bool loop = true;
        public delegate void ProcessStartEventHandler(object sender, ProcessStartEventArgs e);
        public event ProcessStartEventHandler ProcessStart;
       
        // Adapted from http://stackoverflow.com/questions/6575117/
        public ProcessStartWaiter(string processName)
        {
            this.processName = processName;
        }

        public void Listen()
        {
            var query = new WqlEventQuery(
                "__InstanceCreationEvent",
                new TimeSpan(0, 0, 1),
                "TargetInstance isa \"Win32_Process\" and TargetInstance.Name = '" + processName + "'"
              );

            using (var watcher = new ManagementEventWatcher(query)){
                while (this.loop)
                {
                    ManagementBaseObject wmiEvent = watcher.WaitForNextEvent();
                    ManagementBaseObject targetInstance = (ManagementBaseObject)wmiEvent["targetInstance"];
                    int pid = Convert.ToInt32(targetInstance["processID"]);
                    Process process = Process.GetProcessById(pid);
                    if(this.loop) this.OnProcessStart(new ProcessStartEventArgs(process, this.processName)); //Don't trigger event if we want to stop sending them.
                    wmiEvent.Dispose();
                    targetInstance.Dispose();
                    process.Dispose();
                }
                watcher.Stop();
            }
        }

        public void StopListen()
        {
            this.loop = false;
        }

        public void ListenAsync()
        {
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += delegate { this.Listen(); };
                worker.RunWorkerAsync();
            }
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
