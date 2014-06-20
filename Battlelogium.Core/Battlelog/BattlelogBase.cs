using Battlelogium.Core.Javascript;
using Battlelogium.Core.UI;
using Battlelogium.Utilities;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battlelogium.Core.Update;
using System.Diagnostics;

namespace Battlelogium.Core.Battlelog
{
    public partial class BattlelogBase : IDisposable, IRequestHandler
    {

        public WebView battlelogWebview;
        public JavascriptObject javascriptObject;

        public string battlelogURL;
        public string battlefieldName;
        public string battlefieldShortname;
        public string[] executableNames;
        public int gameId;
        public string javascriptURL;

        public bool IsWebviewInitialized { get; private set; }
        
        public BattlelogBase(string battlelogURL, string battlefieldName, string battlefieldShortname, string[] executableNames, int originCode, string javascriptPath)
        {
            this.javascriptObject = new JavascriptObject();
            this.javascriptURL = javascriptPath;

            this.battlelogURL = battlelogURL;
            this.battlefieldName = battlefieldName;
            this.battlefieldShortname = battlefieldShortname;
            this.executableNames = executableNames;
            this.gameId = originCode;

            this.InitListenGame();

        }

        public void InitializeWebview()
        {
            Settings settings = new Settings
            {
#if DEBUG
                PackLoadingDisabled = false,
#else
                PackLoadingDisabled = true,
#endif
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Battlelogium", "cache")
                
            };
            CEF.Initialize(settings);
            
            BrowserSettings browserSettings = new BrowserSettings
            {
                FileAccessFromFileUrlsAllowed = true,
                UniversalAccessFromFileUrlsAllowed = true,
#if CEF_DEVTOOLS
                DeveloperToolsDisabled = false,
#else
                DeveloperToolsDisabled = true,
#endif
                UserStyleSheetEnabled = true,
                //UserStyleSheetLocation = "data:text/css;charset=utf-8;base64,Ojotd2Via2l0LXNjcm9sbGJhcnt2aXNpYmlsaXR5OmhpZGRlbn0NCiNjb21tdW5pdHktYmFyIC5vdXRlcmFycm93e2Rpc3BsYXk6bm9uZX0="
                UserStyleSheetLocation = "data:text/css;charset=utf-8;base64,I2NvbW11bml0eS1iYXIgLm91dGVyYXJyb3d7ZGlzcGxheTpub25lfQ0KI2NvbW11bml0eS1iYXJ7cGFkZGluZzo1cHggMCFpbXBvcnRhbnR9DQo6Oi13ZWJraXQtc2Nyb2xsYmFye3dpZHRoOjZweDtoZWlnaHQ6NnB4O2JhY2tncm91bmQ6cmdiYSgxOSwyMiwyNiwwLjQpfQ0KOjotd2Via2l0LXNjcm9sbGJhci10cmFja3tiYWNrZ3JvdW5kOnJnYmEoMCwwLDAsMC4xKX0NCjo6LXdlYmtpdC1zY3JvbGxiYXItdGh1bWJ7YmFja2dyb3VuZDpyZ2JhKDAsMCwwLDAuMyl9DQo6Oi13ZWJraXQtc2Nyb2xsYmFyLXRodW1iOmhvdmVye2JhY2tncm91bmQ6cmdiYSgwLDAsMCwwLjQpfQ0KOjotd2Via2l0LXNjcm9sbGJhci10aHVtYjphY3RpdmV7YmFja2dyb3VuZDpyZ2JhKDAsMCwwLC42KX0=",
                /* UserStyleSheetLocation is the data in userstylesheet.css minified and encoded in utf8 base64 data URI*/


            };           
            this.battlelogWebview = new WebView(this.battlelogURL, browserSettings);
            this.battlelogWebview.RegisterJsObject("app", javascriptObject);
            this.battlelogWebview.LoadCompleted += this.LoadCompleted;
            this.battlelogWebview.PropertyChanged += battlelogWebview_PropertyChanged;
            this.battlelogWebview.RequestHandler = this;
            this.IsWebviewInitialized = true;
        }
        
        private void battlelogWebview_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Address")
            {
                this.battlelogWebview.ExecuteScript("runCustomJS()");
                if (!this.battlelogWebview.Address.Contains(battlelogURL)) this.battlelogWebview.Load(battlelogURL);
            }
        }

        private void LoadCompleted(object sender, EventArgs e)
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
#if CEF_DEVTOOLS
            this.battlelogWebview.ShowDevTools();
#endif

        }
    
        public static bool CheckBattlelogConnection()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://battlelog.com/");
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
                if (response == null || response.StatusCode != HttpStatusCode.OK) return false;
                else return true;
            }catch (WebException){
                return false;
            }

        }

        public async static Task<bool> CheckBattlelogConnectionAsync()
        {
           bool task = await Task.Run(() => { return CheckBattlelogConnection(); });
           return task;
        }

        public void Dispose()
        {
            throw new NotImplementedException(); //TODO implement Dispose properly
        }

        private void InitUpdateWebPlugin(string url)
        {
            if (!url.Contains("battlelog-web-plugins")) throw new ArgumentException();
            string filename = Path.GetFileName(new Uri(url).LocalPath);
            var dl = new UIDownloader(url, filename, "Downloading Battlelog Web Plugins...");
            dl.DownloadComplete += (s, e) =>
            {
                dl.SyncCloseWindow();
                Process.Start(e.completedFilePath).WaitForExit();
                this.battlelogWebview.Reload(true);
            };
            dl.Show();
            dl.Start();
                
        }
    }
}
