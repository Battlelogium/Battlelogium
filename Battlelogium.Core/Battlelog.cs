using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.Wpf;
using System.Windows;
using Battlelogium.Core.Javascript;
using CefSharp;
using System.Net;
using System.IO;

namespace Battlelogium.Core
{
    public class Battlelog
    {

        public WebView battlelogWebview;
        public JavascriptObject javascriptObject;

        public string battlelogURL;
        public string battlefieldName;
        public string battlefieldShortname;
        public string executableName;
        public string originCode;
        public string javascriptURL;
        
        public Battlelog(string battlelogURL, string battlefieldName, string battlefieldShortname, string executableName, string originCode, string javascriptPath, JavascriptObject battlelogiumApp)
        {
            this.javascriptObject = battlelogiumApp;
            this.javascriptURL = javascriptPath;

            this.battlelogURL = battlelogURL;
            this.battlefieldName = battlefieldName;
            this.battlefieldShortname = battlefieldShortname;
            this.executableName = executableName;
            this.originCode = originCode;

            this.SetupWebview(true); //we're debugging.

        }

        public Battlelog(string battlelogURL, string battlefieldName, string battlefieldShortname, string executableName, string originCode, string javascriptPath, Window battlelogiumWindow) : this(battlelogURL, battlefieldName, battlefieldShortname, executableName, originCode , javascriptPath, new JavascriptObject(battlelogiumWindow)) { }

        protected void SetupWebview(bool debug=false)
        {
            BrowserSettings browserSettings = new BrowserSettings
            {
                FileAccessFromFileUrlsAllowed = true,
                UniversalAccessFromFileUrlsAllowed = true,
                DeveloperToolsDisabled = !debug
            };
            Settings settings = new Settings
            {
                PackLoadingDisabled = !debug,
                CachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache")
            };
            CEF.Initialize(settings);
            //browserSettings.WebSecurityDisabled = true;
           
            this.battlelogWebview = new WebView(this.battlelogURL, browserSettings);
            this.battlelogWebview.RegisterJsObject("app", javascriptObject);
            this.battlelogWebview.LoadCompleted += this.LoadCompleted;
            if (debug) this.battlelogWebview.ShowDevTools();
         
        }

        public void LoadCompleted(object sender, EventArgs e)
        {
            if (!this.battlelogWebview.Address.Contains(battlelogURL)) this.battlelogWebview.Load(battlelogURL);

            this.battlelogWebview.ExecuteScript(
                String.Format(@"
                    if (document.getElementById('_inject') == null) {
                        var script = document.createElement('script');
    	                script.setAttribute('src', '{0}');
    	                script.setAttribute('id', '_inject');
    	                document.getElementsByTagName('head')[0].appendChild(script);
                    }",
                  this.javascriptURL)
            );
            this.battlelogWebview.ExecuteScript("runCustomJS();");
        }
    
        public static bool CheckBattlelogConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://battlelog.battlefield.com/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public class Battlefield3 : Battlelog
    {
        public Battlefield3(Window battlelogiumWindow) : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", "70619", "http://localhost/battlelogium/battlelog.bf3.inject.js" , battlelogiumWindow) {
        }
    }
}
