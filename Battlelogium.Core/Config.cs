using Battlelogium.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Battlelogium.Core
{
    public class Config
    {

        #region Fields
        private bool directToCampaign;
        private readonly int waitTimeToKillOrigin;
        private readonly bool checkUpdates;
        private readonly bool fullscreenMode;
        private readonly bool startMaximized;
        private readonly bool manageOrigin; 
        private readonly int windowHeight;
        private readonly int windowWidth;
        private readonly bool noBorder;
        private readonly bool useSoftwareRender;
        private readonly bool rightClickDrag;
        private readonly string configFileName;

        #endregion

        public Config(string configFileName){

            this.configFileName = configFileName;
            Dictionary<string, string> config = GetConfigurationData();

            if (!bool.TryParse(config.GetValueOrDefault("directToCampaign"), out directToCampaign)) directToCampaign = false;
            if (!bool.TryParse(config.GetValueOrDefault("checkUpdates"), out checkUpdates)) checkUpdates = true;
            if (!int.TryParse(config.GetValueOrDefault("waitTimeToKillOrigin"), out waitTimeToKillOrigin)) waitTimeToKillOrigin = 10;
            if (!bool.TryParse(config.GetValueOrDefault("fullscreenMode"), out fullscreenMode)) fullscreenMode = false;
            if (!bool.TryParse(config.GetValueOrDefault("startMaximized"), out startMaximized)) startMaximized = false;
            if (!bool.TryParse(config.GetValueOrDefault("manageOrigin"), out manageOrigin)) manageOrigin = true;
            
            if (!int.TryParse(config.GetValueOrDefault("windowHeight"), out windowHeight)) windowHeight = 1280;
            if (!int.TryParse(config.GetValueOrDefault("windowWidth"), out windowWidth)) windowWidth = 720;
            if (!bool.TryParse(config.GetValueOrDefault("noBorder"), out noBorder)) noBorder = true;
            if (!bool.TryParse(config.GetValueOrDefault("rightClickDrag"), out rightClickDrag)) rightClickDrag = false;
            if (!bool.TryParse(config.GetValueOrDefault("useSoftwareRender"), out useSoftwareRender)) useSoftwareRender = false;
        }

        public Config() : this("config.ini") { }

        public string ConfigDump()
        {
            StringBuilder configBuilder = new StringBuilder();
            configBuilder.AppendLine(String.Empty);
            configBuilder.AppendLine("Configuration Dump");
            configBuilder.AppendLine("DirectToCampaign = " + DirectToCampaign.ToString());
            configBuilder.AppendLine("WaitTimeToKillOrigin = " + WaitTimeToKillOrigin.ToString());
            configBuilder.AppendLine("FullscreenMode = " + fullscreenMode.ToString());
            configBuilder.AppendLine("StatMaximized = " + StartMaximized.ToString());
            configBuilder.AppendLine("WindowHeight = " + WindowHeight.ToString());
            configBuilder.AppendLine("WindowWidth = " + WindowWidth.ToString());
            configBuilder.AppendLine("manageOrigin = " + manageOrigin.ToString());

            return configBuilder.ToString();
        }

        public void WriteConfig(string key, string value)
        {
            value = value.ToLowerInvariant();
            string configFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName));
            Regex regex = new Regex(String.Format(@"(?<=(?<!//){0}=)(\w+)",key));
            try{ 
                configFile = regex.Replace(configFile, value);
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName), configFile);
            }catch{
                throw;
            }
        }

        #region Accessors
        /// <summary>Whether to go directly to Campaign mode. Hidden option</summary>
        public bool DirectToCampaign
        {
            get
            {
                return this.directToCampaign;
            }
            set
            {
                this.directToCampaign = value;
            }
        }

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

        /// <summary>If we're in windowed mode, do we want to start Maximized?</summary>
        public bool StartMaximized
        {
            get
            {
                return this.startMaximized;
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

        /// <summary>If we're in windowed mode, whether the window has a border</summary>
        public bool NoBorder
        {
            get
            {
                return this.noBorder;
            }
        }

        /// <summary>Whether to use the software renderer</summary>
        public bool UseSoftwareRender
        {
            get
            {
                return this.useSoftwareRender;
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
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName)))
            {
                var config = new Dictionary<string, string>();

                // Properties loading code from http://stackoverflow.com/questions/485659/
                foreach (string row in
                    File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.configFileName)))
                {
                    //Ignore comments and blank lines.
                    if (row.StartsWith(";")) continue;
                    if (row.StartsWith("[") && row.EndsWith("]")) continue;

                    if (row.Length == 0) continue;

                    config.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }
                return config;
            }

            return null;
        }
        #endregion
    }
}
