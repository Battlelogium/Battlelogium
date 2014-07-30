using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Battlelogium.Installer;
using System.Diagnostics;
namespace Battlelogium.Installer
{
    /// <summary>
    /// Interaction logic for UIComplete.xaml
    /// </summary>
    public partial class UIComplete : Window
    {
        string installPath;
        public UIComplete(string installPath)
        {
            this.installPath = installPath;
            InitializeComponent();
        }

        public void CreateDesktopShortcuts()
        {
            if (bf3Shortcut_input.IsChecked == true) InstallerCommon.CreateDesktopShortcut("Battlelogium - Battlefield 3.lnk", "Play Battlefield 3", Path.Combine(this.installPath, "Battlelogium.UI.BF3.exe"));
            if (bf4Shortcut_input.IsChecked == true) InstallerCommon.CreateDesktopShortcut("Battlelogium - Battlefield 4.lnk", "Play Battlefield 4", Path.Combine(this.installPath, "Battlelogium.UI.BF4.exe"));
            if (bfhShortcut_input.IsChecked == true) InstallerCommon.CreateDesktopShortcut("Battlelogium - Battlefield Hardline.lnk", "Play Battlefield Hardline", Path.Combine(this.installPath, "Battlelogium.UI.BFH.exe"));
            if (mohwShortcut_input.IsChecked == true) InstallerCommon.CreateDesktopShortcut("Battlelogium - Medal of Honor Warfighter.lnk", "Medal of Honor Warfighter", Path.Combine(this.installPath, "Battlelogium.UI.MOHW.exe"));

        }
        public void CreateStartMenuShortcuts()
        {
            InstallerCommon.CreateStartMenuShortcut("Battlelogium - Battlefield 3.lnk", "Play Battlefield 3", Path.Combine(this.installPath, "Battlelogium.UI.BF3.exe"));
            InstallerCommon.CreateStartMenuShortcut("Battlelogium - Battlefield 4.lnk", "Play Battlefield 4", Path.Combine(this.installPath, "Battlelogium.UI.BF4.exe"));
            InstallerCommon.CreateStartMenuShortcut("Battlelogium - Battlefield Hardline.lnk", "Play Battlefield Hardline", Path.Combine(this.installPath, "Battlelogium.UI.BFH.exe"));
            InstallerCommon.CreateStartMenuShortcut("Battlelogium - Medal of Honor Warfighter.lnk", "Medal of Honor Warfighter", Path.Combine(this.installPath, "Battlelogium.UI.MOHW.exe"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.CreateDesktopShortcuts();
            this.CreateStartMenuShortcuts();
            ControlPanel.CreateBattlelogiumControlPanelEntry(this.installPath);
            if (this.steamShortcut_input.IsChecked == true) Process.Start(Path.Combine(installPath, "Battlelogium.ExecUtils.exe"));
            Process.Start("taskkill", "/im origin.exe /f").WaitForExit(); //Kill any elevated instances of origin.
            this.Close();
        }
    }
}
