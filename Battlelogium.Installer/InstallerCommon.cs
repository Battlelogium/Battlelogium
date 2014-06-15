using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using IWshRuntimeLibrary;


namespace Battlelogium.Installer
{
    internal class InstallerCommon
    {
        public static async Task<string> GetDownload(string dependency)
        {
            string url = await new WebClient().DownloadStringTaskAsync("http://ron975.github.io/Battlelogium/releaseinfo/download/" + dependency);
            return url;
        }

        private void KillBattlelogium()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "taskkill",
                Arguments = "/im Battlelogium.UI.BF3.exe /f",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
            Process.Start(new ProcessStartInfo()
            {
                FileName = "taskkill",
                Arguments = "/im Battlelogium.UI.BF4.exe /f",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
            Process.Start(new ProcessStartInfo()
            {
                FileName = "taskkill",
                Arguments = "/im Battlelogium.UI.BFH.exe /f",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
        }

        public static async Task ExtractZipFile(string fileName, string extractPath)
        {
            await Task.Run(() =>
            {
                using (ZipArchive package = ZipFile.OpenRead(fileName))
                {
                    foreach (var entry in package.Entries)
                    {
                        string fullPath = Path.Combine(extractPath, entry.FullName);
                        if (String.IsNullOrEmpty(entry.Name)) Directory.CreateDirectory(fullPath);
                        else entry.ExtractToFile(fullPath, true);
                    }
                }
            });

        }


        public static void CreateShortcut(string shortcutName, string description, string exePath, string shortcutPath)
        {
            WshShell shell = new WshShell();
            string shortcutAddr =  shortcutPath + @"\" + shortcutName;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddr);
            shortcut.Description = description;
            shortcut.TargetPath = exePath;
            shortcut.Save();
        }
        public static void CreateDesktopShortcut(string shortcutName, string description, string exePath)
        {
            WshShell shell = new WshShell();
            object shDesktop = (object)"Desktop";
            string shortcutPath = (string)shell.SpecialFolders.Item(ref shDesktop);
            CreateShortcut(shortcutName, description, exePath, shortcutPath);
        }

        public static void CreateStartMenuShortcut(string shortcutName, string description, string exePath)
        {
            if(!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms),"Battlelogium")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms), "Battlelogium"));
            WshShell shell = new WshShell();
            object shStartMenu = (object)"AllUsersPrograms";
            string shortcutPath = (string)shell.SpecialFolders.Item(ref shStartMenu);
            CreateShortcut(shortcutName, description, exePath, shortcutPath + @"\Battlelogium");
        }
    }
}

