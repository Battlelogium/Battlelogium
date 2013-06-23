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
using System.ComponentModel;
using Awesomium.Core.Data;
namespace BF3WrapperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region vars

        private Process originProcess;
        private bool finishedLoading = false;
        private bool loadingTextFinalPlay = false;
        private Storyboard blinkLoading;
        private Storyboard fadeBackground;


        #region Config Variables
        //Removes ads and footers
        private string customJS = "";
        private bool customJSEnabled = false;
        private int waitTimeToCloseOrigin = 10000;
        private bool startTopmost = true;
        private string css = @"
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

        #endregion
        /// <summary>
        /// Main Window Constructor
        /// </summary>
        public MainWindow()
        {
            //Attach a console to process
            AttachConsole(-1);
            Log("Initiating Window");
            InitializeComponent();
            Log("Initiating Config");
            InitializeConfig();
            Log("Initiating Wrapper");
            InitializeWrapper();
            Log("Initiating Battlelog BattlelogBrowser");
            InitializeBattlelogBattlelogBrowser();
            Log("Initiating Origin");
            InitializeOrigin();


        }

        #region Console Logging
        /// <summary>
        /// Attach a console to program if ran from commandline
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);

        /// <summary>
        /// Frees Console before quit
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        #endregion

        #region Utils
        /// <summary>
        /// Kills processes with given name
        /// </summary>
        /// <param name="processname">Name of process to kill</param>
        private void KillProcess(string processname)
        {
            Process[] Processes = Process.GetProcessesByName(processname);
            foreach (Process p in Processes)
            {
                p.Kill();
            }
        }
        /// <summary>
        /// Appends date and time before writing to Stdout
        /// </summary>
        /// <param name="log">Text to log</param>
        private void Log(string log)
        {
            Console.WriteLine(DateTime.Now.ToString() + " " + log);
        }

        /// <summary>
        /// Raises a KeyDownEvent
        /// </summary>
        /// <param name="key"></param>
        private void SendKey(Key key)
        {
            IInputElement target = Keyboard.FocusedElement;

            //Code from http://stackoverflow.com/questions/1645815/
            try
            {
                target.RaiseEvent(
                    new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    });
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

        }
        #endregion

        #region Origin
        /// <summary>
        /// Logic for Management of the Origin Process
        /// </summary>
        private void InitializeOrigin()
        {
            StartOriginProcess();
            StartBringWrapperToTopTimer();
        }

        private void OriginNotFound(Exception e)
        {
            Log("Origin not found");
            Log("Exception type: " + e.GetType().ToString());
            MessageBox.Show("Please install Origin to play Battlefield 3", "Error");
            Process.Start("http://www.origin.com/download");
            this.Close();
        }
        /// <summary>
        /// Finds and Starts Origin
        /// </summary>
        private void StartOriginProcess()
        {
            string originDefaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Origin", "Origin.exe");
            string originPath = originDefaultPath;
            Log("Getting Origin Path");
            try
            {
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
            }catch(Exception ex){
                OriginNotFound(ex);
                return;
            }

            ProcessStartInfo originProcessInfo = new ProcessStartInfo(originPath);
            
            KillProcess("Origin");
            Log("Kill any Origin processes already started");
            
            try
            {
                originProcess = Process.Start(originProcessInfo);
                Log("Starting Origin");
            }
            catch (Exception ex)
            {
                OriginNotFound(ex);
                return;
            }
        }

        /// <summary>
        /// Starts Timer to keep wrapper to top after Origin starts
        /// </summary>
        private void StartBringWrapperToTopTimer()
        {
            Timer closeOriginWindowTimer = new Timer(waitTimeToCloseOrigin);
            closeOriginWindowTimer.AutoReset = false;
            closeOriginWindowTimer.Elapsed += new ElapsedEventHandler(disableTopMostTimer_Elapsed);
            Log("Starting Timer to keep wrapper on top");
            closeOriginWindowTimer.Start();
        }

        /// <summary>
        /// Forces Origin to the background and keeps this wrapper to the top
        /// </summary>
        private void BringWrapperToTop()
        {
            Log("Unset Wrapper Topmost");
            this.Topmost = false;
            Log("Activate Wrapper");
            this.Activate();
            originProcess.CloseMainWindow();
            Log("Close Origin Main Window");
           
        }

        /// <summary>
        /// Event Handler to BringWrapperToTop() after Timer Elapses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disableTopMostTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(BringWrapperToTop));
        }
        #endregion

        #region Wrapper

        /// <summary>
        /// General wrapper logic
        /// </summary>
        private void InitializeWrapper()
        {
            SetupStoryboards();
            Log("Setup Storyboards");
            this.Topmost = startTopmost;
            blinkLoading.Begin();
        }

        /// <summary>
        /// Finds storyboards and points them to their intended target
        /// </summary>
        private void SetupStoryboards()
        {
            blinkLoading = this.FindResource("BlinkLoading") as Storyboard;
            Log("Found blinkLoading Storyboard");
            fadeBackground = this.FindResource("FadeBackground") as Storyboard;
            Log("Found fadeBackground Storyboard");

            Storyboard.SetTarget(blinkLoading, LoadingImageText);
            Log("Set Target of blinkLoading to LoadingImageText");
            Storyboard.SetTarget(fadeBackground, LoadingImage);
            Log("Set Target of fadeBackground to LoadingImage");
        }

        /// <summary>
        /// Load configuration options from config if one exists
        /// </summary>
        private void InitializeConfig()
        {
            if (File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.properties")))
            {
                Dictionary<String, String> config = new Dictionary<String, String>();
                //Properties loading code from http://stackoverflow.com/questions/485659/
                foreach (var row in File.ReadAllLines(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.properties")))
                {
                    config.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }

                //Convert from seconds to milliseconds
                waitTimeToCloseOrigin = int.Parse(config["waitTimeToCloseOrigin"]) * 1000;
                startTopmost = bool.Parse(config["startTopmost"]);
                customJSEnabled = bool.Parse(config["customJSEnabled"]);

            }

            if (File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "style.css")))
            {
                css = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "style.css"));
            }

            if ((File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "customjs.js"))) && customJSEnabled){
                customJS = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "customjs.js"));
            }
            Log("Wait time to close Origin: " + waitTimeToCloseOrigin.ToString());
            Log("Starting Topmost: " + startTopmost.ToString());



        }
        #endregion

        #region Battlelog

        /// <summary>
        /// Creates a WebSession and makes the BattlelogBrowser use it
        /// </summary>
        private void InitializeBattlelogBattlelogBrowser()
        {
            Log("Create WebSession");
            WebSession session = WebCore.CreateWebSession(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "battlelog-chrome"),
                                    new WebPreferences() {
                                        CustomCSS = css,
                                        EnableGPUAcceleration = true,
                                    });
            session.AddDataSource("local", new ResourceDataSource(ResourceType.Packed));
            Log("Registered WebSession");
            BattlelogBrowser.WebSession = session;
            Log("Registered WebSession");
        }

        /// <summary>
        /// EventHandler to disable Context Menu in BattlelogBrowser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattlelogBrowser_ShowContextMenu(object sender, Awesomium.Core.ContextMenuEventArgs e)
        {
            e.Handled = true;
            Log("Rightclicked Disabled");
        }

        /// <summary>
        /// Event Handler to fade out background and start quit button JS loop if loaded once
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattlelogBrowser_DocumentReady(object sender, UrlEventArgs e)
        {

                //Fade out the loading image for the first time
                FadeOutLoadingImage();
                Log("Begin Start Fade Image");
                //We don't need this event handler any more
                Log("Initiating QuitButton");
                InitializeQuitButton();
                BattlelogBrowser.DocumentReady -= BattlelogBrowser_DocumentReady;
            

        }

        private void BattlelogBrowser_LoadingFrameComplete(object sender, FrameEventArgs e)
        {
            InjectScript("asset://local/buttons.js");
            if (customJSEnabled)
            {
                BattlelogBrowser.ExecuteJavascript(customJS);
            }
        }

        #endregion

        #region Quit

        //EventHandler to handle application closing
        private void WrapperClosing(object sender, CancelEventArgs e)
        {

            //Shutdown WebCore
            try
            {
                WebCore.Shutdown();
                Log("Shut down WebCore");
            }
            catch (Exception ex)
            {
                Log("Webcore unable to be shut down");
                Log(ex.ToString());
            }

            //Kill Origin
            try
            {
                Log("Kill Origin");
                originProcess.Kill();
            }
            catch (Exception)
            {
                //If we can't kill by killing our managed process, just kill all instances of Origin.exe
                Log("Kill Origin");
                KillProcess("Origin");
            }

            //We need to kill SonarHost.exe as well
            Log("Kill SonarHost");
            KillProcess("SonarHost");

            Log("Press Enter to Exit. Remember to mark output.");
            SendKey(Key.Enter);
            FreeConsole();
            SendKey(Key.Enter);
            //We need to send the enter key else application will hang.
            
           
        }

        /// <summary>
        /// EventHandler to handle when ESC is pressed, quits on ESC press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownQuitHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// EventHandler to handle when the JS quit button is pressed, quits on button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void JavascriptQuitHandler(object sender, JavascriptMethodEventArgs args)
        {
            this.Close();
        }

        #endregion

        #region Loading

        /// <summary>
        /// Fades out the loading background image
        /// </summary>
        private void FadeOutLoadingImage()
        {

            finishedLoading = true;
            Log("Set finishedLoading to true to allow LoadingImageText to stop gracefully");
            Log("Begin fadeoutBackground");
            fadeBackground.Begin();


        }

        /// <summary>
        /// EventHandler to handle blinkLoading completed, workaround to fade text gracefully after loading as RepeatBehavior.Forever does not fire Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blinkLoading_Completed(object sender, EventArgs e)
        {
            /* 
             * We don't use Storyboard.RepeatBehavior = RepeatBehavior.Forever because that does not fire the 
             * Completed event. So we do this workaround to fade out gracefully after loading.
             * 
             */

            if (loadingTextFinalPlay)
            {
                LoadingImageText.Visibility = Visibility.Hidden;
                Log("Hid LoadingImageText");
            }
            else
                if (finishedLoading)
                {
                    loadingTextFinalPlay = true;
                    blinkLoading.AutoReverse = false;
                    blinkLoading.Begin();
                    Log("Final blink of LoadingImageText");
                }
                else
                {

                    blinkLoading.Begin();
                }
        }

        /// <summary>
        /// EventHandler to hide the background image once fadeBackground is completed so BattlelogBrowser can be interacted with
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fadeBackground_Completed(object sender, EventArgs e)
        {
            LoadingImage.Visibility = Visibility.Hidden;
            Log("Hide Loading Image");
        }
        #endregion

        #region Javascript

        /// <summary>
        /// Injects a Javascript file to the page. Must be a resource in the root project path
        /// </summary>
        /// <param name="scripturl">URL of script to inject</param>


        private void InjectScript(String scripturl)
        {
            BattlelogBrowser.ExecuteJavascript(@"
                    var script = document.createElement('script');
                    script.setAttribute('src','"+scripturl+@"');
                    document.getElementsByTagName('head')[0].appendChild(script);
                 ");
            Log("Injected script " + scripturl);
        }

        #region Quit Button
        /// <summary>
        /// Creates the JSObject where our wrapper will be bound to.
        /// </summary>
        private void InitializeQuitButton()
        {
            JSObject quitMethod = BattlelogBrowser.CreateGlobalJavascriptObject("wrapper");
            Log("Create Javascript Object");
            quitMethod.Bind("quitWrapper", false, JavascriptQuitHandler);
            Log("Binded QuitWrapper to QuitHandler");
        }

        #endregion
        #endregion



    }

}
