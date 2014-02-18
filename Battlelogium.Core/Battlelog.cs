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
    public class Battlelog : IDisposable
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
                DeveloperToolsDisabled = !debug,
                UserStyleSheetEnabled = true,
                //UserStyleSheetLocation = "data:text/css;charset=utf-8;base64,Ojotd2Via2l0LXNjcm9sbGJhcnt2aXNpYmlsaXR5OmhpZGRlbn0NCiNjb21tdW5pdHktYmFyIC5vdXRlcmFycm93e2Rpc3BsYXk6bm9uZX0="
                UserStyleSheetLocation = @"data:text/css;charset=utf-8;base64,I2NvbW11bml0eS1iYXIgLm91dGVyYXJyb3d7ZGlzcGxheTpub25lfTo6LXdlYmtpdC1zY3JvbGxiYXJ7d2lkdGg6NnB4O2hlaWdodDo2cHg7YmFja2dyb3VuZDpyZ2JhKDE5LDIyLDI2LDAuNCl9Ojotd2Via2l0LXNjcm9sbGJhci10cmFja3tiYWNrZ3JvdW5kOnJnYmEoMCwwLDAsMC4xKX06Oi13ZWJraXQtc2Nyb2xsYmFyLXRodW1ie2JhY2tncm91bmQ6cmdiYSgwLDAsMCwwLjMpfTo6LXdlYmtpdC1zY3JvbGxiYXItdGh1bWI6aG92ZXJ7YmFja2dyb3VuZDpyZ2JhKDAsMCwwLDAuNCl9Ojotd2Via2l0LXNjcm9sbGJhci10aHVtYjphY3RpdmV7YmFja2dyb3VuZDpyZ2JhKDAsMCwwLC42KX0=",
                /* UserStyleSheetLocation is the following data encoded in utf8 base64 data URI
                 * ::-webkit-scrollbar{visibility:hidden}
                 * #community-bar .outerarrow{display:none}
                 */
                
            };
            Settings settings = new Settings
            {
                PackLoadingDisabled = !debug,
                CachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache")
                
            };
            
           //battlelogWebview.this.battlelogWebview.ContentsWidth;
            CEF.Initialize(settings);
            //browserSettings.WebSecurityDisabled = true;
           
            this.battlelogWebview = new WebView(this.battlelogURL, browserSettings);
            
            this.battlelogWebview.RegisterJsObject("app", javascriptObject);
            this.battlelogWebview.LoadCompleted += this.LoadCompleted;
            this.battlelogWebview.PropertyChanged += battlelogWebview_PropertyChanged;
          //  if (debug) this.battlelogWebview.ShowDevTools();
         
        }

        void battlelogWebview_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Address")
            {
                this.battlelogWebview.ExecuteScript("runCustomJS()");
                if (!this.battlelogWebview.Address.Contains(battlelogURL)) this.battlelogWebview.Load(battlelogURL);
            }
        }

        public void LoadCompleted(object sender, EventArgs e)
        {
            this.battlelogWebview.ExecuteScript(
                @"
                    if (document.getElementById('_inject') == null) {
                        var script = document.createElement('script');
    	                script.setAttribute('src', '"+this.javascriptURL+@"');
    	                script.setAttribute('id', '_inject');
    	                document.getElementsByTagName('head')[0].appendChild(script);
                    }"
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

        public void Dispose()
        {
            throw new NotImplementedException(); //TODO implement Dispose properly
        }

    }
}
