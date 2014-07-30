using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using Microsoft.Win32;
using Battlelogium.Utilities;
using System.Security.Principal;
using System.Reflection;
using System.ComponentModel;
namespace Battlelogium.ExecUtils
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            if (args.Length <= 0 )
            {
                AddSteam();
                return;
            }
            switch (args[0])
            {
                case "clearcache":
                    ClearCache(int.Parse(args[1]));
                    break;
                case "addsteam":
                    AddSteam();
                    break;
                case "removepar":
                    RemovePar();
                    break;
                case "createunist":
                    
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                string fileName = Assembly.GetExecutingAssembly().Location;
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Arguments = "createuninst";
                processInfo.Verb = "runas";
                processInfo.FileName = fileName;
                try
                {
                    Process.Start(processInfo);
                }
                catch (Win32Exception)
                {
                    // This will be thrown if the user cancels the prompt
                }

                return;
            }
                    break;
            }
            return;
        }

        private static void ClearCache(int id)
        {
            var cachepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            try
            {
                Process.GetProcessById(id).WaitForExit();
            }
            catch (Exception) { }
            try
            {
                Directory.Delete(cachepath, true);
            }
            catch (Exception) { }
        }

        private static void AddSteam()
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                string fileName = Assembly.GetExecutingAssembly().Location;
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Arguments = "addsteam";
                processInfo.Verb = "runas";
                processInfo.FileName = fileName;

                try
                {
                    Process.Start(processInfo);
                }
                catch (Win32Exception)
                {
                    // This will be thrown if the user cancels the prompt
                }

                return;
            }
            string quote = "\"";
            string space = " ";
           // Process.Start("taskkill", "/im steam.exe /f").WaitForExit();
            
            if(ProcessTools.IsProcessRunning("steam")) MessageBox.Show("Please close Steam before continuing");
            if (ProcessTools.IsProcessRunning("steam"))
            {
                bool result = MessageBoxUtils.ShowChoiceDialog("Force close Steam? (Not recommended, close Steam manually if possible)", "Close Steam before adding shortcuts to Steam", "Force Close Steam", "I will close Steam manually");
                switch (result)
                {
                    case true:
                        ProcessTools.KillProcess("steam", true, false);
                        break;
                    case false:
                        ProcessTools.KillProcess("steam", true, true); //CloseMainWindow shouldn't close steam, use as a lazy shortcut to process.Wait()
                        break;
                }
            }
            Process.Start("steam_shortcut_manager_cli.exe", "all" + space + quote + "Medal of Honor Warfighter" + quote + space + quote + Path.GetFullPath("Battlelogium.UI.MOHW.exe") + quote).WaitForExit();
            Process.Start("steam_shortcut_manager_cli.exe", "all" + space + quote + "Battlefield 3" + quote + space + quote + Path.GetFullPath("Battlelogium.UI.BF3.exe") + quote).WaitForExit();
            Process.Start("steam_shortcut_manager_cli.exe", "all" + space + quote + "Battlefield 4" + quote + space + quote + Path.GetFullPath("Battlelogium.UI.BF4.exe") + quote).WaitForExit();
            Process.Start("steam_shortcut_manager_cli.exe", "all" + space + quote + "Battlefield Hardline Beta" + quote + space + quote + Path.GetFullPath("Battlelogium.UI.BFH.exe") + quote).WaitForExit();

        }

        private static void RemovePar()
        {
            string bf3Path;
            try
            {
                bf3Path = GetBF3Path();
            }
            catch
            {
                Environment.Exit(1);
                return;
            }
            if (!File.Exists(Path.Combine(bf3Path, "bf3.par.orig")))
            {
                Environment.Exit(1);
                return;
            }
            try
            {
                File.Delete(Path.Combine(bf3Path, "bf3.par"));
                File.Move(Path.Combine(bf3Path, "bf3.par.orig"), Path.Combine(bf3Path, "bf3.par"));
                Environment.Exit(0);
                return;
            }
            catch (Exception)
            {
                Environment.Exit(1);
                return;
            }
        }

        private static string GetBF3Path()
        {
            var regkey = Registry.LocalMachine.OpenSubKey(@"Software\EA Games\Battlefield 3");
            return regkey.GetValue("Install Dir").ToString();
        }
    }
}
