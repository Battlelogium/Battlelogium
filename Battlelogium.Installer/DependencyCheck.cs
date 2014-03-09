using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Battlelogium.Installer
{
    public class DependencyCheck
    {
        public bool IsOriginInstalled { get; private set; }
        public bool IsWebPluginInstalled { get; private set; }

        public DependencyCheck()
        {
            this.IsOriginInstalled = this.CheckOrigin();
            this.IsWebPluginInstalled = this.CheckWebPlugin();
        }
        private bool CheckOrigin()
        {
            return DependencyCheck.CheckKey(@"Software\Origin");
        }
        private bool CheckWebPlugin()
        {
            return DependencyCheck.CheckKey(@"Software\Battlelog Web Plugins");
        }

        private static bool CheckKey(string key)
        {
            var regkey = Registry.LocalMachine.OpenSubKey(key);
            if (regkey == null) return false;
            return true;
        }
    }
}
