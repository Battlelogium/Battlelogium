namespace Battlelogium
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class BattlelogiumConfiguration
    {
        #region Fields
        private readonly string css;
        private bool directToCampaign;
        private readonly bool customJsEnabled;
        private readonly int waitTimeToKillOrigin;
        private readonly bool windowedMode;
        private readonly bool startMaximized;
        private readonly int windowHeight;
        private readonly int windowWidth;
        private readonly string customJavascript;
        #endregion

        public BattlelogiumConfiguration(string configFileName, string cssFileName, string jsFileName){

            Utilities.Log(String.Empty);
            Utilities.Log("=========================================");
            Utilities.Log("New BattlelogiumConfiguration Initialized");
            Utilities.Log("configFileName is " + configFileName);
            Utilities.Log("cssFileName is " + cssFileName);
            Utilities.Log("jsFileName is " + jsFileName);
            Utilities.Log("=========================================");
            Utilities.Log(String.Empty);
            Dictionary<string, string> config = GetConfigurationData(configFileName);
            if (!bool.TryParse(config.GetValueOrDefault("directToCampaign"), out directToCampaign)) directToCampaign = false;
            if (!bool.TryParse(config.GetValueOrDefault("customJsEnabled"), out customJsEnabled)) customJsEnabled = false;
            if (!int.TryParse(config.GetValueOrDefault("waitTimeToKillOrigin"), out waitTimeToKillOrigin)) waitTimeToKillOrigin = 10;
            if (!bool.TryParse(config.GetValueOrDefault("windowedMode"), out windowedMode)) windowedMode = false;
            if (!bool.TryParse(config.GetValueOrDefault("startMaximized"), out startMaximized)) startMaximized = false;
            if (!int.TryParse(config.GetValueOrDefault("windowHeight"), out windowHeight)) windowHeight = 504;
            if (!int.TryParse(config.GetValueOrDefault("windowWidth"), out windowWidth)) windowWidth = 896;

            this.css = GetCascadingStyleSheet(cssFileName);
            this.customJavascript = GetCustomJavascript(jsFileName);

        }

        public BattlelogiumConfiguration() : this("config.ini", "style.css", "customjs.js") { }

        public string ConfigDump()
        {
            StringBuilder configBuilder = new StringBuilder();
            configBuilder.AppendLine(String.Empty);
            configBuilder.AppendLine("Configuration Dump");
            configBuilder.AppendLine("DirectToCampaign = " + DirectToCampaign.ToString());
            configBuilder.AppendLine("CustomJsEnabled = " + CustomJsEnabled.ToString());
            configBuilder.AppendLine("WaitTimeToKillOrigin = " + WaitTimeToKillOrigin.ToString());
            configBuilder.AppendLine("WindowedMode = " + WindowedMode.ToString());
            configBuilder.AppendLine("StatMaximized = " + StartMaximized.ToString());
            configBuilder.AppendLine("WindowHeight = " + WindowHeight.ToString());
            configBuilder.AppendLine("WindowWidth = " + WindowWidth.ToString());

            return configBuilder.ToString();
        }

        #region Accessors

        /// <summary>Whether to go directly to BF3's Campaign mode</summary>
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

        /// <summary>Whether Custom Javascript is enabled</summary>
        public bool CustomJsEnabled
        {
            get
            {
                return this.customJsEnabled;
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

        /// <summary>Whether to start Battlelogium in Windowed Mode</summary>
        public bool WindowedMode
        {
            get
            {
                return this.windowedMode;
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

        /// <summary>CSS to apply to Battlelog.</summary>
        public string CSS
        {
            get
            {
                return this.css != null ? this.css : 
                    @"
                    .gate-footer {
                        display: none;
                    }

                    #footer{
                        display: none;
                    }

                    .advirticement{
                        display: none;
                    }

                    ::-webkit-scrollbar{
                        visibility: hidden;
                    }
                    #feedback-popup-opener-tab{
                        display: none;
                    }
                ";
            }
        }

        /// <summary>Custom javascript to run on Battlelog, if there is any.</summary>
        public string CustomJavascript
        {
            get
            {
                return this.customJavascript != null ? this.customJavascript : String.Empty;
            }
        }

    #endregion

        #region Getters
        private Dictionary<string, string> GetConfigurationData(string fileName)
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            {
                var config = new Dictionary<string, string>();

                // Properties loading code from http://stackoverflow.com/questions/485659/
                foreach (string row in
                    File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
                {
                    //Ignore comments and blank lines.
                    if (row.StartsWith("//")) continue;
                    if (row.Length == 0) continue;

                    config.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }
                return config;
            }

            return null;
        }

        private string GetCascadingStyleSheet(string fileName)
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            {
                return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
            }
            return null;
        }

        private string GetCustomJavascript(string fileName)
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            {
                return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
            }
            return null;
        }

        #endregion
        
    }
}
