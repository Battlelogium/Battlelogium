using Battlelogium.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Battlelogium.Core.Configuration
{
    public class Config
    {

        #region Fields
        private readonly int waitTimeToKillOrigin;
        private readonly bool checkUpdates;
        private readonly bool fullscreenMode;
        private readonly bool manageOrigin;
        private readonly int windowHeight;
        private readonly int windowWidth;
        private readonly bool disableHardwareAccel;
        private readonly bool rightClickDrag;
        private readonly string configFileName;

        #endregion

        public Config(string configFileName){

            this.configFileName = configFileName;
            this.CreateConfigFile();
            Dictionary<string, string> config = GetConfigurationData();

            if (!bool.TryParse(config.GetValueOrDefault("checkUpdates"), out checkUpdates)) checkUpdates = true;
            if (!int.TryParse(config.GetValueOrDefault("waitTimeToKillOrigin"), out waitTimeToKillOrigin)) waitTimeToKillOrigin = 10;
            if (!bool.TryParse(config.GetValueOrDefault("fullscreenMode"), out fullscreenMode)) fullscreenMode = false;
            if (!bool.TryParse(config.GetValueOrDefault("manageOrigin"), out manageOrigin)) manageOrigin = true;
            
            if (!int.TryParse(config.GetValueOrDefault("windowHeight"), out windowHeight)) windowHeight = 0;
            if (!int.TryParse(config.GetValueOrDefault("windowWidth"), out windowWidth)) windowWidth = 0;
            if (!bool.TryParse(config.GetValueOrDefault("rightClickDrag"), out rightClickDrag)) rightClickDrag = false;
            if (!bool.TryParse(config.GetValueOrDefault("disableHardwareAccel"), out disableHardwareAccel)) disableHardwareAccel = false;
        }

        public Config() : this("config.ini") { }

        public string ConfigDump()
        {
            StringBuilder configBuilder = new StringBuilder();
            configBuilder.AppendLine(String.Empty);
            configBuilder.AppendLine("Configuration Dump");
            configBuilder.AppendLine("WaitTimeToKillOrigin = " + WaitTimeToKillOrigin.ToString());
            configBuilder.AppendLine("FullscreenMode = " + FullscreenMode.ToString());
            configBuilder.AppendLine("WindowHeight = " + WindowHeight.ToString());
            configBuilder.AppendLine("WindowWidth = " + WindowWidth.ToString());
            configBuilder.AppendLine("ManageOrigin = " + ManageOrigin.ToString());
            configBuilder.AppendLine("DisableHardwareAccel = " + DisableHardwareAccel.ToString());
            return configBuilder.ToString();
        }

        public void WriteConfig(string key, object value)
        {
            string outvalue = value.ToString().ToLowerInvariant();
            string configFile = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium", this.configFileName));
            Regex regex = new Regex(String.Format(@"(?<=(?<!//){0}=)(\w+)",key));
            try{ 
                configFile = regex.Replace(configFile, outvalue);
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Battlelogium", this.configFileName), configFile);
            }catch{
                throw;
            }
        }

        public void CreateConfigFile()
        {
            if(!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium"));
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium", this.configFileName)))
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "defaultconfig"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium", this.configFileName), true);
        }
        #region Accessors

        /// <summary>How long to wait before closing Origin, to give it time to sync BF3's save data</summary>
        public int WaitTimeToKillOrigin
        {
            get
            {
                return this.waitTimeToKillOrigin;
            }
        }

        /// <summary>Whether to start Battlelogium in SetWindowed Mode</summary>
        public bool FullscreenMode
        {
            get
            {
                return this.fullscreenMode;
            }
        }
        
        /// <summary>Whether to check for Updates?</summary>
        public bool CheckUpdates
        {
            get
            {
                return this.checkUpdates;
            }
        }

        /// <summary>If we're in windowed mode, the height of the Window</summary>
        public int WindowHeight
        {
            get
            {
                return this.windowHeight;
            }
        }

        /// <summary>If we're in windowed mode, the width of the Window</summary>
        public int WindowWidth
        {
            get
            {
                return this.windowWidth;
            }
        }

        /// <summary>Whether to use the software renderer</summary>
        public bool DisableHardwareAccel
        {
            get
            {
                return this.disableHardwareAccel;
            }
        }

        /// <summary>Whether to start or handle Origin</summary>
        public bool RightClickDrag
        {
            get
            {
                return this.rightClickDrag;
            }
        }

        /// <summary>Whether to start or handle Origin</summary>
        public bool ManageOrigin
        {
            get
            {
                return this.manageOrigin;
            }
        }

    #endregion

        #region Getters
        private Dictionary<string, string> GetConfigurationData()
        {
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium", this.configFileName)))
            {
                var config = new Dictionary<string, string>();

                // Properties loading code from http://stackoverflow.com/questions/485659/
                foreach (string row in
                    File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium", this.configFileName)))
                {
                    //Ignore comments and blank lines.
                    if (row.StartsWith(";")) continue;
                    if (row.StartsWith("[") && row.EndsWith("]")) continue;

                    if (row.Length == 0) continue;

                    config.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }
                return config;
            }
            throw new FileNotFoundException();
        }
        #endregion
    }
}
