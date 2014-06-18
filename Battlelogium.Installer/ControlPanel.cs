using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
namespace Battlelogium.Installer
{
    public class ControlPanel
    {
        private static void RegisterControlPanelProgram(string appName, string installLocation, string displayicon, string uninstallString, string displayVersion, string publisherString, string helpUrl)
        {
            try
            {
                string Install_Reg_Loc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

                RegistryKey hKey = (Registry.LocalMachine).OpenSubKey(Install_Reg_Loc, true);

                RegistryKey appKey = hKey.CreateSubKey(appName);

                appKey.SetValue("DisplayName", (object)appName, RegistryValueKind.String);

                appKey.SetValue("Publisher", (object)publisherString, RegistryValueKind.String);

                appKey.SetValue("InstallLocation",
                         (object)installLocation, RegistryValueKind.ExpandString);

                appKey.SetValue("DisplayIcon", (object)displayicon, RegistryValueKind.String);

                appKey.SetValue("UninstallString",
                       (object)uninstallString, RegistryValueKind.ExpandString);

                appKey.SetValue("DisplayVersion", (object)displayVersion, RegistryValueKind.String);

                appKey.SetValue("URLInfoAbout", (object)helpUrl, RegistryValueKind.String);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void RemoveControlPanelProgram(string appName)
        {
            string InstallerRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey homeKey = (Registry.LocalMachine).OpenSubKey(InstallerRegLoc, true);
            RegistryKey appSubKey = homeKey.OpenSubKey(appName);
            if (null != appSubKey)
            {
                homeKey.DeleteSubKey(appName);
            }
        }
        public static void CreateBattlelogiumControlPanelEntry(string installDir)
        {
            ControlPanel.RegisterControlPanelProgram("Battlelogium", installDir, 
                Path.Combine(installDir,"bg_generic.ico"),
                Path.Combine(installDir,"Battlelogium.Installer.exe uninstall"), 
                Assembly.GetEntryAssembly().GetName().Version.ToString(),
                "Battlelogium",
                "http://ron975.github.com/Battlelogium");
        }
    }
}
