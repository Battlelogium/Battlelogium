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
        public List<string> javascriptPaths;

        public string battlelogURL;
        public string battlefieldName;
        public string battlefieldShortname;
        public string executableName;
        public string originCode;
        
        public Battlelog(string battlelogURL, string battlefieldName, string battlefieldShortname, string executableName, string originCode, JavascriptObject battlelogiumApp, List<string> javascriptPaths)
        {
            this.javascriptObject = battlelogiumApp;
            this.javascriptPaths = javascriptPaths;

            this.battlelogURL = battlelogURL;
            this.battlefieldName = battlefieldName;
            this.battlefieldShortname = battlefieldShortname;
            this.executableName = executableName;
            this.originCode = originCode;

            this.SetupWebview(true); //we're debugging.

        }

        public Battlelog(string battlelogURL, string battlefieldName, string battlefieldShortname, string executableName, string originCode, Window battlelogiumWindow) : this(battlelogURL, battlefieldName, battlefieldShortname, executableName, originCode , new JavascriptObject(battlelogiumWindow), new List<string>()) { }

        public Battlelog(string battlelogURL, string battlefieldName, string battlefieldShortname, string executableName, string originCode, Window battlelogiumWindow, List<string> javascriptPaths) : this(battlelogURL, battlefieldName, battlefieldShortname, executableName, originCode, new JavascriptObject(battlelogiumWindow), javascriptPaths) { }

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
            //WindowChrome
            this.InjectCSS("http://localhost/battlelogium/windowchrome/battlelog.windowchrome.css");
            this.InjectJS("http://localhost/battlelogium/windowchrome/battlelog.windowchrome.js");
        }

        public void InjectCSS(string cssURL){
            this.battlelogWebview.ExecuteScript(String.Format(@"
            var script = document.createElement('link');
            script.setAttribute('rel', 'stylesheet');
            script.setAttribute('type', 'text/css');
            script.setAttribute('href', '{0}');
            document.getElementsByTagName('head')[0].appendChild(script);", cssURL));
        }

        public void InjectJS(string jsURL)
        {
            this.battlelogWebview.ExecuteScript(String.Format(@"
            var script = document.createElement('script');
            script.setAttribute('src', '{0}');
            document.getElementsByTagName('head')[0].appendChild(script);", jsURL));
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
        public Battlefield3(Window battlelogiumWindow, List<string> javascriptPaths) : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", "70619", battlelogiumWindow, javascriptPaths) {
            this.battlelogWebview.LoadCompleted += battlelogWebview_LoadCompleted;
        }

        private void battlelogWebview_LoadCompleted(object sender, LoadCompletedEventArgs url)
        {
            this.InjectJS("http://localhost/battlelogium/button/battlelog.bf3.button.js");
            this.InjectJS("http://localhost/battlelogium/dialog/battlelog.bf3.dialog.js");
        }
    }
}
