// <copyright file="MainWindow.xaml.cs">
//    This file is part of Battleogium.
//
//    Battleogium is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    Battleogium is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with Battleogium.  If not, see <http://www.gnu.org/licenses/>
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
namespace Battlelogium
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Timers;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Animation;
    using System.Management;

    using Awesomium.Core;
    using Awesomium.Core.Data;

    using Microsoft.Win32;
    using System.Net;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BattlelogiumMain : Window
    {
        #region Fields

        #region Miscellaneous

        private SplashScreen splash = new SplashScreen("images/BattlelogiumSplash.png");

        /// <summary>
        /// Custom CSS that will be applied to Battlelog
        /// </summary>
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

        // Removes ads and footers

        /// <summary>
        /// Custom Javascript
        /// </summary>
        private string customJs = String.Empty;

        /// <summary>
        /// Storyboard that fades loading background
        /// </summary>
        private Storyboard fadeBackground;

        /// <summary>
        /// Loading text blink
        /// </summary>
        private Storyboard blinkLoading;

        /// <summary>
        /// Whether the page has finished loading once
        /// </summary>
        private bool finishedLoading;

        /// <summary>
        /// Whether it is the loading text's final blink
        /// </summary>
        private bool loadingTextFinalPlay;


        /// <summary>
        /// Whether to keep Origin running when Battlelogium ends
        /// </summary>
        private bool retainOrigin = false;


        /// <summary>
        /// Represents the Origin process
        /// </summary>
        private Process originProcess;
        #endregion

        #region Configuration Options
        private bool directToCampaign;

        /// <summary>
        /// Whether Custom Javascript is enabled
        /// </summary>
        private bool customJsEnabled;

        /// <summary>
        /// How long to wait to kill origin in milliseconds
        /// </summary>
        private int waitTimeToKillOrigin = 10000;

        /// <summary>
        /// Whether to start Battlelogium in a window
        /// </summary>
        private bool windowedMode = false;

        /// <summary>
        /// If windowed, do we want a maximized window?
        /// </summary>
        private bool startMaximized = true;

        /// <summary>
        /// Height of the window
        /// </summary>
        private int windowHeight = 504;

        /// <summary>
        /// Width of the window
        /// </summary>
        private int windowWidth = 896;

        #endregion

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BattlelogiumMain"/> class.
        /// Main Window Constructor
        /// </summary>
        public BattlelogiumMain()
        {
            // Attach a console to process

            AttachConsole(-1);
            splash.Show(true);
            Console.WriteLine(String.Empty);
            this.Log("Battlelogium is licensed under GNU GPL v3");
            this.Log("Battlelogium does not come with any warranty");
            this.Log("neither express nor implied");
            Console.WriteLine(String.Empty);
            this.Log("!---Begin Log---!");
            this.Log("Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString());
            this.Log("==================");
            Console.WriteLine(String.Empty);

            this.Log("Initiating Config");
            this.InitializeConfig();
            this.Log("Checking for Internet Connection");
            this.InitializeConnectionCheck();

            if (!this.directToCampaign) //We do not need to initialize Window if we're going directly into the campaign mode
            {
                this.Log("Initiating Origin");
                this.InitializeOrigin();
                this.Log("Initiating Window");
                this.InitializeComponent();
                this.Log("Initiating Wrapper");
                this.InitializeWrapper();
                this.Log("Initiating Battlelog BattlelogBrowser");
                this.InitializeBattlelogBattlelogBrowser();
            }
            else
            {
                this.LaunchBattlefield3Campaign();
            }
           
        }

        #endregion

        #region Console P/Invoke Utils

        /// <summary>
        /// Attach a console to program if ran from commandline
        /// </summary>
        /// <param name="processId">
        /// Id of process to attach console to. Attach -1 for this process.
        /// </param>
        [DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);

        /// <summary>
        /// Frees Console before quit
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        #endregion

        #region Main Methods

        #region Browser Webview
        /// <summary>
        /// Creates a WebSession and makes the BattlelogBrowser use it
        /// </summary>
        private void InitializeBattlelogBattlelogBrowser()
        {
            this.Log("Create WebSession");
            WebSession session =
                WebCore.CreateWebSession(
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battlelogium"),
                    new WebPreferences { CustomCSS = this.css, EnableGPUAcceleration = true, });
            session.AddDataSource("local", new ResourceDataSource(ResourceType.Packed));
            this.Log("Registered WebSession");
            this.BattlelogBrowser.WebSession = session;
            this.Log("Registered WebSession");
        }

        /// <summary>
        /// Event Handler to fade out background and start quit button JS loop if loaded once
        /// </summary>
        private void BattlelogBrowserDocumentReady(object sender, UrlEventArgs e)
        {
            // Fade out the loading image for the first time
            this.FadeOutLoadingImage();
            this.Log("Begin Start Fade Image");

            // We don't need this event handler any more
            this.Log("Initiating QuitButton");
            this.InitializeQuitButton();
            this.BattlelogBrowser.DocumentReady -= this.BattlelogBrowserDocumentReady;
        }

        /// <summary>
        /// When browser finishes loading frame
        /// </summary>
        private void BattlelogBrowserLoadingFrameComplete(object sender, FrameEventArgs e)
        {
            this.InjectScript("asset://local/buttons.js");
            if (this.customJsEnabled)
            {
                this.BattlelogBrowser.ExecuteJavascript(this.customJs);
            }
        }

        /// <summary>
        /// EventHandler to disable Context Menu in BattlelogBrowser
        /// </summary>
        private void BattlelogBrowserShowContextMenu(object sender, ContextMenuEventArgs e)
        {
            e.Handled = true;
            this.Log("Rightclicked Disabled");
        }
        #endregion

        #region Loading 
        /// <summary>
        /// EventHandler to handle blinkLoading completed, workaround to fade text gracefully after loading as RepeatBehavior.Forever does not fire Completed event
        /// </summary>
        private void BlinkLoadingCompleted(object sender, EventArgs e)
        {
            /* 
             * We don't use Storyboard.RepeatBehavior = RepeatBehavior.Forever because that does not fire the 
             * Completed event. So we do this workaround to fade out gracefully after loading.
             * 
             */
            if (this.loadingTextFinalPlay)
            {
                this.LoadingImageText.Visibility = Visibility.Hidden;
                this.Log("Hid LoadingImageText");
            }
            else if (this.finishedLoading)
            {
                this.loadingTextFinalPlay = true;
                this.blinkLoading.AutoReverse = false;
                this.blinkLoading.Begin();
                this.Log("Final blink of LoadingImageText");
            }
            else
            {
                this.blinkLoading.Begin();
            }
        }

        /// <summary>
        /// EventHandler to hide the background image once fadeBackground is completed so BattlelogBrowser can be interacted with
        /// </summary>
        private void FadeBackgroundCompleted(object sender, EventArgs e)
        {
            this.LoadingImage.Visibility = Visibility.Hidden;
            this.Log("Hide Loading Image");
        }

        /// <summary>
        /// Fades out the loading background image
        /// </summary>
        private void FadeOutLoadingImage()
        {
            this.finishedLoading = true;
            this.Log("Set finishedLoading to true to allow LoadingImageText to stop gracefully");
            this.Log("Begin fadeoutBackground");
            this.fadeBackground.Begin();
        }

    #endregion

        #region Pre Load

        /// <summary>
        /// Load configuration options from config if one exists
        /// </summary>
        private void InitializeConfig()
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.properties")))
            {
                var config = new Dictionary<string, string>();

                // Properties loading code from http://stackoverflow.com/questions/485659/
                foreach (string row in
                    File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.properties")))
                {
                    //Ignore comments and blank lines.
                    if (row.StartsWith(";")) continue;
                    if (row.Length == 0) continue;

                    config.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }

                // Convert from seconds to milliseconds
                this.waitTimeToKillOrigin = int.Parse(config["waitTimeToKillOrigin"]) * 1000;
                this.customJsEnabled = bool.Parse(config["customJSEnabled"]);
                this.directToCampaign = bool.Parse(config["directToCampaign"]);

                this.windowedMode = bool.Parse(config["windowedMode"]);
                this.startMaximized = bool.Parse(config["startMaximized"]);
                this.windowHeight = int.Parse(config["windowHeight"]);
                this.windowWidth = int.Parse(config["windowWidth"]);
                
            }

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "style.css")))
            {
                this.css = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "style.css"));
            }

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customjs.js"))
                && this.customJsEnabled)
            {
                this.customJs = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customjs.js"));
            }
        }

        /// <summary>
        /// Finds storyboards and points them to their intended target
        /// </summary>
        private void SetupStoryboards()
        {
            this.blinkLoading = this.FindResource("BlinkLoading") as Storyboard;
            this.Log("Found blinkLoading Storyboard");
            this.fadeBackground = this.FindResource("FadeBackground") as Storyboard;
            this.Log("Found fadeBackground Storyboard");

            Storyboard.SetTarget(this.blinkLoading, this.LoadingImageText);
            this.Log("Set Target of blinkLoading to LoadingImageText");
            Storyboard.SetTarget(this.fadeBackground, this.LoadingImage);
            this.Log("Set Target of fadeBackground to LoadingImage");
        }

        /// <summary>
        /// General wrapper logic
        /// </summary>
        private void InitializeWrapper()
        {
            if (this.windowedMode)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.ResizeMode = ResizeMode.CanResizeWithGrip;
                if (!this.startMaximized)
                {
                   this.WindowState = WindowState.Normal;
                }
                this.Height = this.windowHeight;
                this.Width = this.windowWidth;
            }
            this.SetupStoryboards();
            this.Log("Setup Storyboards");
            this.blinkLoading.Begin();
        }

        private void InitializeConnectionCheck()
        {

            if (CheckForInternetConnection())
            {
                Window temp = new Window() { Width = 0, Height = 0, WindowStyle = WindowStyle.None };
                temp.Show();
                MessageBoxResult startInOfflineMode = MessageBox.Show("Battlelog is not available. Start in Offline Mode", "Battlelog not available", MessageBoxButton.YesNo);
                if (startInOfflineMode == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    this.isOffline = true;
                    Process battlefield3 = null;
                    while (battlefield3 == null)
                    {
                        Process[] processes = Process.GetProcessesByName("bf3");
                        if (processes.Length == 1)
                        {
                            battlefield3 = processes[0];
                        }
                    }

                    battlefield3.WaitForExit();
                }
                temp.Close();

            }
        }
        #endregion

        #region Origin

        /// <summary>
        /// The origin not found.
        /// </summary>
        private void OriginNotFound(Exception e)
        {
            this.Log("Origin not found");
            this.Log("Exception type: " + e.GetType());
            MessageBox.Show("Please install Origin to play Battlefield 3", "Error");
            Process.Start("http://www.origin.com/download");
            this.Close();
        }

        /// <summary>
        /// Logic for Management of the Origin Process
        /// </summary>
        private void InitializeOrigin()
        {
            this.StartOriginProcess("/StartClientMinimized");
        }

        /// <summary>
        /// Finds and Starts Origin
        /// </summary>
        private void StartOriginProcess(string commandLineOptions)
        {
            this.Log("Getting Origin Path");

            string originPath = GetOriginPath();

            var originProcessInfo = new ProcessStartInfo(originPath, commandLineOptions);

            retainOrigin = CheckIfOriginIsRunning();

            if (retainOrigin)
            {
                this.Log("Origin is running. Battlelogium will restore Origin after closing");
            }

            this.KillProcess("Origin");
            this.Log("Kill any Origin processes already started");
            //We must relaunch Origin as a child process for Steam to properly apply the overlay hook.

            try
            {
                this.originProcess = Process.Start(originProcessInfo);
                this.Log("Starting Origin");
            }
            catch (Exception ex)
            {
                this.OriginNotFound(ex);
                return;
            }
        }

        private bool CheckForInternetConnection()
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

        private bool CheckIfOriginIsRunning()
        {
            Process[] pname = Process.GetProcessesByName("Origin");
            if (pname.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GetOriginPath()
        {
            string originDefaultPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Origin", "Origin.exe");
            string originPath;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    originPath =
                        Registry.GetValue(
                            @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Origin", "ClientPath", originDefaultPath).ToString();
                    this.Log("Got " + originPath);
                }
                else
                {
                    originPath =
                        Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Origin", "ClientPath", originDefaultPath).ToString();
                    this.Log("Got " + originPath);
                }
                return originPath;
            }
            catch (Exception ex)
            {
                this.OriginNotFound(ex);
                return originDefaultPath;
            }
        }
        #endregion

        #region Javascript
        /// <summary>
        /// Creates the JSObject where our wrapper will be bound to.
        /// </summary>
        private void InitializeQuitButton()
        {
            JSObject quitMethod = this.BattlelogBrowser.CreateGlobalJavascriptObject("wrapper");
            this.Log("Create Javascript Object");
            quitMethod.Bind("quitWrapper", false, this.JavascriptQuitHandler);
            this.Log("Binded QuitWrapper to QuitHandler");
        }

        /// <summary>
        /// Injects a Javascript file to the page. Must be a resource in the root project path
        /// </summary>
        /// <param name="scripturl">
        /// URL of script to inject
        /// </param>
        private void InjectScript(string scripturl)
        {
            this.BattlelogBrowser.ExecuteJavascript(
                @"
                    var script = document.createElement('script');
                    script.setAttribute('src','" + scripturl + @"');
                    document.getElementsByTagName('head')[0].appendChild(script);
                 ");
            this.Log("Injected script " + scripturl);
        }
        #endregion

        #region Quit Handling
        /// <summary>
        /// EventHandler to handle when ESC is pressed, quits on ESC press
        /// </summary>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
        /// <summary>
        /// EventHandler to handle when Battlelogium closes
        /// </summary>
        private void WrapperClosing(object sender, CancelEventArgs e)
        {
            // Shutdown WebCore
            try
            {
                WebCore.Shutdown();
                this.Log("Shut down WebCore");
            }
            catch (Exception ex)
            {
                this.Log("Webcore unable to be shut down");
                this.Log(ex.ToString());
            }

            Timer cleanupOriginTimer = new Timer(waitTimeToKillOrigin);
            cleanupOriginTimer.AutoReset = false;
            cleanupOriginTimer.Elapsed += delegate
            {
                Dispatcher.Invoke(new Action(delegate
                {
 
                    this.KillProcess("origin");
                    this.Log("Killed Origin");
                    this.KillProcess("sonarhost");
                    this.Log("Killed ESNSonar");
                    if (retainOrigin)
                    {
                        this.Log("Restarting Origin");
                        //We do not want this instance of Origin to be a child process, otherwise Steam will think we're still in Battlefield 3
                        CreateOrphanedProcess(GetOriginPath(), "/StartClientMinimized");
                    }

                    this.Log("!---End Log---!");
                    this.Log("Press Enter to Exit. Remember to mark output.");
                    FreeConsole();
                    
                }));
            };

            this.Log("Waiting " +waitTimeToKillOrigin+" milliseconds to kill Origin");
            cleanupOriginTimer.Start();
            this.Hide();
            System.Threading.Thread.Sleep(waitTimeToKillOrigin+5000);
           
        }


        /// <summary>
        /// EventHandler to handle when the JS quit button is pressed, quits on button press
        /// </summary>
        private void JavascriptQuitHandler(object sender, JavascriptMethodEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Utilities
        /// <summary>
        /// Kills processes with given name
        /// </summary>
        /// <param name="processname">
        /// Name of process to kill
        /// </param>
        private void KillProcess(string processname)
        {
            Process[] processes = Process.GetProcessesByName(processname);
            foreach (Process p in processes)
            {
                p.Kill();
            }
        }

        /// <summary>
        /// Appends date and time before writing to console
        /// </summary>
        /// <param name="log">
        /// Text to log
        /// </param>
        private void Log(string log)
        {
            Console.WriteLine(DateTime.Now.ToString() + " " + log);
        }

        /// <summary>
        /// Creates an process orphaned from parent. 
        /// Code snippet adapted from
        /// http://stackoverflow.com/questions/12068647/
        /// </summary>
        /// <param name="path">Path to executable</param>
        /// <param name="args">Commandline arguments</param>
        static void CreateOrphanedProcess(string path, string args)
        {
            string commandLine = @"""" + path + @""" " + args;
            using (var managementClass = new ManagementClass("Win32_Process"))
            {
                var processInfo = new ManagementClass("Win32_ProcessStartup");
                processInfo.Properties["CreateFlags"].Value = 0x00000008;

                var inParameters = managementClass.GetMethodParameters("Create");
                inParameters["CommandLine"] = commandLine;
                inParameters["ProcessStartupInformation"] = processInfo;

                var result = managementClass.InvokeMethod("Create", inParameters, null);
            }
        }
        #endregion

        private void LaunchBattlefield3Campaign(){


            StartOriginProcess(@" ""/StartOffline"" ""origin://LaunchGame/70619""");

            Process battlefield3 = null;
            while (battlefield3 == null)
            {
                Process[] processes = Process.GetProcessesByName("bf3");
                if (processes.Length == 1)
                {
                    battlefield3 = processes[0];
                }
            }
            battlefield3.WaitForExit();

            this.Close();

        }
        #endregion
    }
}
        