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
                //UserStyleSheetLocation = "data:text/css;charset=utf-8;base64,I2NvbW11bml0eS1iYXIgLm91dGVyYXJyb3d7ZGlzcGxheTpub25lfTo6LXdlYmtpdC1zY3JvbGxiYXJ7aGVpZ2h0OjA7b3ZlcmZsb3c6dmlzaWJsZTt3aWR0aDoxMHB4O2JvcmRlci1sZWZ0OjFweCBzb2xpZCAjZTVlNWU1fTo6LXdlYmtpdC1zY3JvbGxiYXItdGh1bWJ7YmFja2dyb3VuZC1jb2xvcjpyZ2JhKDAsMCwwLC4yKTtiYWNrZ3JvdW5kLWNsaXA6cGFkZGluZy1ib3g7bWluLWhlaWdodDoyOHB4O3BhZGRpbmc6MTAwcHggMCAwO2JveC1zaGFkb3c6aW5zZXQgMXB4IDFweCAwIHJnYmEoMCwwLDAsLjEpLGluc2V0IDAgLTFweCAwIHJnYmEoMCwwLDAsLjA3KTtib3JkZXItd2lkdGg6MXB4IDFweCAxcHggNnB4fTo6LXdlYmtpdC1zY3JvbGxiYXItYnV0dG9ue2hlaWdodDowO3dpZHRoOjB9Ojotd2Via2l0LXNjcm9sbGJhci10cmFja3tiYWNrZ3JvdW5kLWNsaXA6cGFkZGluZy1ib3g7Ym9yZGVyOnNvbGlkIHRyYW5zcGFyZW50O2JvcmRlci13aWR0aDowIDAgMCA0cHh9Ojotd2Via2l0LXNjcm9sbGJhci1jb3JuZXJ7YmFja2dyb3VuZDowIDB9",
                UserStyleSheetLocation = "data:text/css;charset=utf-8;base64,I2NvbW11bml0eS1iYXIgLm91dGVyYXJyb3d7ZGlzcGxheTpub25lfSAvKlJlbW92ZSBnYW1lIHN3aXRjaGluZyBhcnJvdyovDQoNCjo6LXdlYmtpdC1zY3JvbGxiYXIgew0KICBoZWlnaHQ6IDA7DQogIG92ZXJmbG93OiB2aXNpYmxlOw0KICB3aWR0aDogMTBweDsgIA0KICBib3JkZXItbGVmdDoxcHggc29saWQgcmdiKDIyOSwgMjI5LCAyMjkpOw0KICBiYWNrZ3JvdW5kLWNvbG9yOiByZ2JhKDAsIDAsIDAsIDAuMSk7DQp9DQo6Oi13ZWJraXQtc2Nyb2xsYmFyLXRodW1iIHsNCiAgYmFja2dyb3VuZC1jb2xvcjogcmdiYSgwLDAsMCwuMDcpOw0KICBiYWNrZ3JvdW5kLWNsaXA6IHBhZGRpbmctYm94OyAgICANCiAgbWluLWhlaWdodDogMjhweDsNCiAgcGFkZGluZzogMTAwcHggMCAwOw0KICBib3gtc2hhZG93OiBpbnNldCAxcHggMXB4IDAgcmdiYSgwLDAsMCwuMSksaW5zZXQgMCAtMXB4IDAgcmdiYSgwLDAsMCwuMDgpOw0KICBib3JkZXItd2lkdGg6IDFweCAxcHggMXB4IDZweDsNCn0NCjo6LXdlYmtpdC1zY3JvbGxiYXItYnV0dG9uIHsNCiAgaGVpZ2h0OiAwOw0KICB3aWR0aDogMDsNCn0NCjo6LXdlYmtpdC1zY3JvbGxiYXItdHJhY2sgew0KICBiYWNrZ3JvdW5kLWNsaXA6IHBhZGRpbmctYm94Ow0KICBib3JkZXI6IHNvbGlkIHRyYW5zcGFyZW50Ow0KICBib3JkZXItd2lkdGg6IDAgMCAwIDRweDsNCn0NCjo6LXdlYmtpdC1zY3JvbGxiYXItY29ybmVyIHsNCiAgYmFja2dyb3VuZDogdHJhbnNwYXJlbnQ7DQp9",
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
