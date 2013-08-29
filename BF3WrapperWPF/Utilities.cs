namespace Battlelogium
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Management;
    using System.Windows;
    using WPFCustomMessageBox;

    public static class Utilities
    {

        /// <summary> Extention method to return null if a key isn't found in the dictionary instead of KeyNotFoundException. </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue ret;
            // Ignore return value
            dictionary.TryGetValue(key, out ret);
            return ret;
        }

        [DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);

        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        public static void Log(string log)
        {
            Console.WriteLine(DateTime.Now.ToString() + " " + log);
        }

        public static void KillProcess(string processname)
        {
            Process[] processes = Process.GetProcessesByName(processname);
            foreach (Process p in processes)
            {
                p.Kill();
            }
        }


        /// <summary>
        /// Creates an process orphaned from parent. 
        /// Newly created process is a child of Windows Management Interface
        /// Code snippet adapted from
        /// http://stackoverflow.com/questions/12068647/
        /// </summary>
        /// <param name="path">Path to executable</param>
        /// <param name="args">Commandline arguments</param>
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

        public static bool ShowChoiceDialog(string messageBoxText, string caption, string okButtonText, string cancelButtonText)
        {
            MessageBoxResult messageBox = CustomMessageBox.ShowOKCancel(messageBoxText, caption, okButtonText, cancelButtonText);
            
            if (messageBox == MessageBoxResult.Cancel)
            {
                return false;
                
            }
            else
            {
                return true;
            }
        }

    }
}
