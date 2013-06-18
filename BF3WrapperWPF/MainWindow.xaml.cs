using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using Awesomium.Core;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace BF3WrapperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process originProcess;
        private bool loadedOnce = false;
        //Removes ads and footers
        private String css = @"
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

        public MainWindow()
        {
            Log("Initiating Window");
            InitializeComponent();
            Log("Initiating Wrapper");
            InitializeWrapper();
            Log("Initiating Origin");
            InitializeOrigin();

        }

        private void Log(string log){
            Console.WriteLine(DateTime.Now.ToString()+" "+log);
        }
        #region Origin
        private void InitializeOrigin()

        {
            
            string originDefaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Origin", "Origin.exe");
            string originPath;
            Log("Getting Origin Path");
            if (Environment.Is64BitOperatingSystem)
            {
                originPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Origin", "ClientPath", originDefaultPath).ToString();
                Log("Got " + originPath);
            }
            else
            {
                originPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Origin", "ClientPath", originDefaultPath).ToString();
                Log("Got " + originPath);
            }
            

            ProcessStartInfo originProcessInfo = new ProcessStartInfo(originPath);
            Log("Starting Origin");
            originProcess = Process.Start(originProcessInfo);
            Timer disableTopMostTimer = new Timer(8000);
            disableTopMostTimer.AutoReset = false;
            disableTopMostTimer.Elapsed += new ElapsedEventHandler(disableTopMostTimer_Elapsed);
            Log("Starting Timer to keep wrapper on top");
            disableTopMostTimer.Start();


        }

        
        private void bringWrapperToTop()
        {
            Log("Unset Wrapper Topmost");
            this.Topmost = false;
            Log("Activate Wrapper");
            this.Activate();
            Log("Close Origin Main Window");
            originProcess.CloseMainWindow();
        }

        void disableTopMostTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(bringWrapperToTop));
        }
        #endregion

        #region Wrapper
        private void InitializeWrapper()
        {
            Log("Initializing Battlelog WebView");
            InitializeBattlelogWebview();
            Log("Registering Quit Event Handlers");
            this.KeyDown += new KeyEventHandler(KeyDownQuitHandler);
            this.Closing += new System.ComponentModel.CancelEventHandler(WrapperClosing);
        }

        private void WrapperClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Log("Shut down WebCore");
            WebCore.Shutdown();
            try
            {
                Log("Kill Origin");
                originProcess.Kill();
            }
            catch (Exception)
            {
                //If we can't kill by that, just kill all
                Log("Kill Origin");
                Process[] originProcesses = Process.GetProcessesByName("Origin");
                foreach (Process p in originProcesses)
                {
                    p.Kill();
                }
            }

            //We need to kill SonarHost.exe as well
            Log("Kill SonarHost");
            Process[] ESNSonarProcesses = Process.GetProcessesByName("SonarHost");
            foreach (Process p in ESNSonarProcesses)
            {
                p.Kill();
            }
            
        }

        #endregion

        #region Battlelog 
        private void InitializeBattlelogWebview()
        {
            Log("Create WebSession");
            WebSession session = WebCore.CreateWebSession(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bf3wrapper"), 
                                    new WebPreferences(){CustomCSS = css});

            Log("Registered WebView Source");
            BattlelogBrowser.Source = new Uri("http://battlelog.battlefield.com/");
            Log("Registered WebSession");
            BattlelogBrowser.WebSession = session;
            Log("Registered WebSession");
            BattlelogBrowser.DocumentReady += new UrlEventHandler(BattlelogBrowser_DocumentReady);
            BattlelogBrowser.ShowContextMenu += new ShowContextMenuEventHandler(BattlelogBrowser_ShowContextMenu);
            Log("Registered WebView Listeners");
        }

        void BattlelogBrowser_ShowContextMenu(object sender, Awesomium.Core.ContextMenuEventArgs e)
        {
            e.Handled = true;
            Log("Rightclicked Disabled");
        }


        private void BattlelogBrowser_DocumentReady(object sender, UrlEventArgs e)
        {
            if (!loadedOnce)
            {
                //Fade out the loading image for the first time
                FadeOutLoadingImage();
                Log("Begin Start Fade Image");
            }

            //Start adding the quit button
            StartAddQuitButtonTimer();
            Log("Start Add Quit Button Timer Loop");
            
          
        }
        #endregion

        #region Quit Handlers

        //When ESC is pressed, quit
        private void KeyDownQuitHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape){
                this.Close();
            }
        }
        
        //When the Javascript button is pressed, quit
        private void JavascriptQuitHandler(object sender, JavascriptMethodEventArgs args)
        {
            this.Close();
        }


      

        #endregion

        #region Loading Image
        private void FadeOutLoadingImage()
        {
            Storyboard sb = this.FindResource("FadeOut") as Storyboard;
            Log("Find FadeOut from Resources");
            Storyboard.SetTarget(sb, LoadingImage);
            Log("Set Storyboard Target to LoadingImage");
            sb.Completed += new EventHandler(sb_Completed);
            Log("Registered Storyboard Completed EventHandler");
            LoadingImageText.Visibility = Visibility.Hidden;
            Log("Hid Loading Text Image");
            Log("Begin Storyboard");
            sb.Begin();
        

        }

        private void sb_Completed(object sender, EventArgs e)
        {
            LoadingImage.Visibility = Visibility.Hidden;
            Log("Hide Loading Image");
        }
        #endregion

        #region Javascript Quit Button

        private void QuitButtonTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(AddQuitButton));
        }

        private void StartAddQuitButtonTimer()
        {
            JSObject quitMethod = BattlelogBrowser.CreateGlobalJavascriptObject("wrapper");
            Log("Create Javascript Object");
            quitMethod.Bind("quitWrapper", false, JavascriptQuitHandler);
            Log("Binded QuitWrapper to QuitHandler");
            AddQuitButtonFunction();
            Log("Added QuitButton Javascript Function to Page");
            Timer addQuitButtonTimer = new Timer(100);
            addQuitButtonTimer.AutoReset = true;
            addQuitButtonTimer.Elapsed += new ElapsedEventHandler(QuitButtonTimer_Elapsed);
            Log("Registered QuitButton Timer");
            addQuitButtonTimer.Start();
            Log("Start JavascriptQuitButton Loop");
        }

        

        private void AddQuitButtonFunction()
        {

            BattlelogBrowser.ExecuteJavascript(@"
                    function addQuitButton(){
	                    var quitButtonElement = document.getElementById('wrapperQuitButton');
	                    if (quitButtonElement == null){
			                    var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
			                    var button = document.createElement('button');
			                    var quit = document.createElement('p');
			                    quit.appendChild(document.createTextNode('QUIT'));
			                    button.appendChild(quit);
			                    button.setAttribute('class','common-button-large main-loggedin-playbutton');
			                    button.setAttribute('onclick','wrapper.quitWrapper()');
			                    button.setAttribute('id','wrapperQuitButton');
			                    playbar.appendChild(button);
	                    }
                    }
                 ");
            Log("Added quitButton function to page");
        }


        private void AddQuitButton()
        {
            if (BattlelogBrowser.IsDocumentReady)
            {

                BattlelogBrowser.ExecuteJavascript("addQuitButton()");
            }
        }

        #endregion


    }

}
