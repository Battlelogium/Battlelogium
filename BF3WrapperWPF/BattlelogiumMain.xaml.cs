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
    using System.Windows.Media;
    using System.Windows.Interop;
    using System.Management;
    using System.Windows.Threading;
    using System.Security.Permissions;
    using WPFCustomMessageBox;

    using Awesomium.Core;
    using Awesomium.Core.Data;

    using Microsoft.Win32;
    using System.Net;

    public partial class BattlelogiumMain : Window
    {
        #region Fields

        private readonly SplashScreen splash = new SplashScreen("images/BattlelogiumSplash.png");

        /// <summary> Storyboard that fades the background image in the beginning </summary>
        private Storyboard fadeBackground;

        /// <summary> Storyboard that blinks the "Loading" text image in the beginning </summary>
        private Storyboard blinkLoading;

        /// <summary> Whether the page has finished loading once </summary>
        private bool finishedLoading;

        /// <summary> Whether its the "Loading" text's last blink</summary>
        private bool loadingTextFinalPlay;

        /// <summary> Whether to keep Origin running after the user has quit Battlelogium.</summary>
        private bool retainOrigin;

        private bool clearCache; 

        private BattlelogiumConfiguration config;

        #endregion

        public BattlelogiumMain()
        {
            // Attach a console instance to process
            Utilities.AttachConsole(-1);
            //The Steam Overlay will not work if we show splash by the SplashScreen build action, so we manually show it.
            splash.Show(true);
            Console.WriteLine(String.Empty);
            Utilities.Log("Battlelogium is licensed under GNU GPL v3");
            Utilities.Log("Battlelogium does not come with any warranty");
            Utilities.Log("neither express nor implied");
            Console.WriteLine(String.Empty);
            Utilities.Log("!---Begin Log---!");
            Utilities.Log("Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString());
            Utilities.Log("==================");
            Console.WriteLine(String.Empty);
            Utilities.Log("new BattlelogiumConfiguration()");
            config = new BattlelogiumConfiguration();
            Utilities.Log(config.ConfigDump());
            Utilities.Log("StartupConnectionCheck()");
            this.StartupConnectionCheck();

            if (config.DirectToCampaign) //If we're going directly to campaign, there is no need to initialize the main window
            {
                splash.Close(TimeSpan.Zero); //Close the splash screen or it will hang.
                Utilities.Log("Closing += WrapperClosing");
                this.Closing += WrapperClosing; //Since we don't call InitializeComponent, we need to manually add the closing event handler
                Utilities.Log("StartBF3Campaign");
                this.StartBF3Campaign();
            }
            else
            {
                Utilities.Log("StartOriginProcess(/StartClientMinimized)");
                this.StartOriginProcess("/StartClientMinimized");

                Utilities.Log("InitializeComponent()");
                this.InitializeComponent();

                Utilities.Log("SetupStoryboards()");
                this.SetupStoryboards();

                Utilities.Log("ApplyWindowedModeSettings()");
                this.ApplyWindowedModeSettings();

                Utilities.Log("blinkLoading.Begin()");
                this.blinkLoading.Begin();

                Utilities.Log("Battlelog.Websession = CreateBattlelogWebSession()");
                this.Battlelog.WebSession = CreateBattlelogWebSession();

                if (config.CheckUpdates)
                {
                    Utilities.Log("new UpdateNotifier(Assembly.GetEntryAssembly().GetName().Version).run()");
                    new UpdateNotifier(Assembly.GetEntryAssembly().GetName().Version, this.Dispatcher).run();
                }

                if (config.UseSoftwareRender)
                {
                    Utilities.Log("RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly");
                    RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
                }

            }
        }

        #region Handlers
        
        #region Quit Handlers

        private void WrapperClosing(object sender, CancelEventArgs e)
        {
            if (GetBattlefield3Process() != null)
            {
               this.Battlelog.ExecuteJavascript("showDialog(okDialog('Battlefield 3 is still running', 'Quit Battlefield 3 before closing Battlelogium'))");
               e.Cancel = true;
            }
            // Shutdown WebCore
            try
            {
                Utilities.Log("WebCore.Shutdown()");
                WebCore.Shutdown();
            }
            catch (Exception ex)
            {
                Utilities.Log("Exception occured when WebCore shutdown");
                Utilities.Log(ex.ToString());
            }

            Timer cleanupOriginTimer = new Timer(config.WaitTimeToKillOrigin);
            cleanupOriginTimer.AutoReset = false;
            cleanupOriginTimer.Elapsed += delegate
            {
                Dispatcher.Invoke(new Action(delegate
                {

                    Utilities.Log("KillProcess(origin)");
                    Utilities.KillProcess("origin");

                    Utilities.Log("KillProcess(sonarhost)");
                    Utilities.KillProcess("sonarhost");

                    if (this.clearCache)
                    {
                        Utilities.Log("clearCache True");

                        try
                        {
                            Directory.Delete(Path.Combine(
                                     AppDomain.CurrentDomain.BaseDirectory, "Battlelogium", "WebSession"), true);
                        }
                        catch
                        {
                            Utilities.Log("Exception occured when clearing cache");
                        }

                    }

                    if (this.retainOrigin)
                    {

                        Utilities.Log("retainOrigin True");
                        //We do not want this instance of Origin to be a child process, otherwise Steam will think we're still in Battlefield 3
                       
                        Utilities.Log("CreateOrphanedProcess(GetOriginPath(), /StartClientMinimized");
                        Utilities.CreateOrphanedProcess(GetOriginPath(), "/StartClientMinimized");
                    }

                    Utilities.Log("!---End Log---!");
                    Utilities.Log("Press Enter to Exit. Remember to mark output.");
                    Utilities.FreeConsole();

                }));
            };

            Utilities.Log("Waiting " + config.WaitTimeToKillOrigin * 1000 + " milliseconds to kill Origin");
            cleanupOriginTimer.Start();
            this.Hide();
            System.Threading.Thread.Sleep(config.WaitTimeToKillOrigin * 1000 + 5000);

        }

        #endregion

        #region Storyboard Handlers
        private void BlinkLoadingCompleted(object sender, EventArgs e)
        {
            /* 
             * We don't use Storyboard.RepeatBehavior = RepeatBehavior.Forever because that does not fire the 
             * Completed event. So we do this workaround to fade out gracefully after loading.
             * 
             */
            if (this.loadingTextFinalPlay)
            {
                Utilities.Log("LoadingImageText.Visibility = Visibility.Hidden");
                this.LoadingImageText.Visibility = Visibility.Hidden;
            }
            else if (this.finishedLoading)
            {
                this.loadingTextFinalPlay = true;
                this.blinkLoading.AutoReverse = false;
                this.blinkLoading.Begin();
                Utilities.Log("LoadingImageText Final Blink Started");
            }
            else
            {
                this.blinkLoading.Begin();
            }
        }

        private void FadeBackgroundCompleted(object sender, EventArgs e)
        {
            Utilities.Log("FadeBackgroundCompleted()");
            Utilities.Log("LoadingImage.Visibility = Visibility.Hidden");
            this.LoadingImage.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Awesomium Handlers
        //Single run event handler for DocumentReady
        private void BattlelogDocumentReady(object sender, UrlEventArgs e)
        {
            // Fade out the loading image for the first time

            Utilities.Log("finishedLoading = true");
            this.finishedLoading = true;
            
            Utilities.Log("fadeBackground.Begin()");
            this.fadeBackground.Begin();

            //Register the handler for the javascript Quit Button

            Utilities.Log("CreateGlobalJavascriptObject(wrapper)");
            JSObject wrapperObject = this.Battlelog.CreateGlobalJavascriptObject("wrapper");

            BindJavascriptEvents(wrapperObject);

            Utilities.Log("Battlelog.DocumentReady -= this.BattlelogDocumentReady");
            // Disable this one time EventHandler
            this.Battlelog.DocumentReady -= this.BattlelogDocumentReady;
        }

        //Disable the context menu in Awesomium
        private void BattlelogShowContextMenu(object sender, ContextMenuEventArgs e)
        {
            e.Handled = true;
        }

        //Inject button javascript and custom javascript
        private void BattlelogLoadingFrameComplete(object sender, FrameEventArgs e)
        {
            Utilities.Log("BattlelogLoadingFrameComplete");
            this.InjectScript("asset://local/battlelogium.js");
            if (config.CustomJsEnabled)
            {
                this.Battlelog.ExecuteJavascript(config.CustomJavascript);
            }
        }

        #endregion
        #endregion

        #region UI Code

        private void SetupStoryboards()
        {
            Utilities.Log("FindResource(BlinkLoading)");
            this.blinkLoading = this.FindResource("BlinkLoading") as Storyboard;

            Utilities.Log("FindResource(FadeBackground)");
            this.fadeBackground = this.FindResource("FadeBackground") as Storyboard;

            Utilities.Log("Storyboard.SetTarget(this.blinkLoading, this.LoadingImageText)");
            Storyboard.SetTarget(this.blinkLoading, this.LoadingImageText);

            Utilities.Log("Storyboard.SetTarget(this.fadeBackground, this.LoadingImage)");
            Storyboard.SetTarget(this.fadeBackground, this.LoadingImage);
            
        }

        private void ApplyWindowedModeSettings()
        {
            if (config.WindowedMode)
            {
                if (!config.StartMaximized)
                {
                    Utilities.Log("!config.StartMaximized");
                    this.WindowState = WindowState.Normal;
                }
                if (!config.NoBorder)
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.ResizeMode = ResizeMode.CanResizeWithGrip;
                } 
                if (config.NoBorder)
                {
                    this.BorderBrush = new LinearGradientBrush(Color.FromRgb(128, 128, 128), Color.FromRgb(208, 208, 208), 90);
                    this.BorderThickness = new Thickness(1D);
                }
                EnableRightClickMove();
                this.Height = config.WindowHeight;
                this.Width = config.WindowWidth;
            }
        }

        /// <summary>Enable right click dragging of the window</summary>
        private void EnableRightClickMove()
        {
            Point startPosition = new Point();
            this.PreviewMouseRightButtonDown += (sender, e) =>
            {
                startPosition = e.GetPosition(this);
            };

            this.PreviewMouseMove += (sender, e) =>
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Point endPosition = e.GetPosition(this);
                    Vector vector = endPosition - startPosition;
                    this.Left += vector.X;
                    this.Top += vector.Y;
                }
            };
        }

        private void StartupConnectionCheck()
        {
            if (!CheckForBattlelogConnection())
            {
     
                Utilities.Log("MessageBox startInOfflineMode");
                if (!Utilities.ShowChoiceDialog("Battlelog is not available. Launch Campaign instead?", "Battlelog not available", "Launch Campaign", "Quit"))
                {
                    Utilities.Log("startInOfflineMode = false");
                    Environment.Exit(0); //this.Close fires too late for some reason and we manage to start Origin before quitting, so we force quit.
                }
                else
                {
                    Utilities.Log("startInOfflineMode = true");
                    config.DirectToCampaign = true;
                }
            }
        }
        #endregion

        #region Origin

        private void OriginNotFound(Exception e)
        {
            Utilities.Log("Origin not found");
            Utilities.Log("Exception type: " + e.GetType());
            MessageBox.Show("Please install Origin to play Battlefield 3", "Error");
            Process.Start("http://www.origin.com/download");
            this.Close();
        }

        private void StartOriginProcess(string commandLineOptions)
        {
            Utilities.Log("GetOriginPath()");
            string originPath = GetOriginPath();
            var originProcessInfo = new ProcessStartInfo(originPath, commandLineOptions);
            
            Utilities.Log("CheckIfOriginIsRunning()");
            retainOrigin = CheckIfOriginIsRunning();
            if (retainOrigin)
            {
                Utilities.Log("Origin is running. Battlelogium will restore Origin after closing");
            }

            Utilities.Log("KillProcess(Origin)");
            Utilities.KillProcess("Origin");
         
            //We must relaunch Origin as a child process for Steam to properly apply the overlay hook.
            try
            {
                Utilities.Log("Process.Start(originProcessInfo)");
                Process.Start(originProcessInfo); 
            }
            catch (Exception ex)
            {
                this.OriginNotFound(ex);
                return;
            }
        }

        private bool CheckForBattlelogConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://battlelog.battlefield.com/"))
                {
                    Utilities.Log("Battlelog Accessible");
                    return true;
                }
            }
            catch
            {
                Utilities.Log("Battlelog Unaccessible");
                return false;
            }
        }

        private bool CheckIfOriginIsRunning()
        {
            Process[] pname = Process.GetProcessesByName("Origin");
            if (pname.Length == 0)
            {
                Utilities.Log("Origin is not running");
                return false;
            }
            else
            {
                Utilities.Log("Origin is running");
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
                    Utilities.Log("Got " + originPath);
                }
                else
                {
                    originPath =
                        Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Origin", "ClientPath", originDefaultPath).ToString();
                    Utilities.Log("Got " + originPath);
                }
                return originPath;
            }
            catch (Exception ex)
            {
                this.OriginNotFound(ex);
                return originDefaultPath;
            }
        }

        private Process GetBattlefield3Process()
        {
            Process[] processes = Process.GetProcessesByName("bf3");
            if (processes.Length == 1)
            {
                return processes[0];
            }
            else
            {
                return null;
            }

        }
        /// <summary> Start Origin, then get the bf3.exe handle to be able to close Battlelogium once we're done.
        private void StartBF3Campaign()
        {
            Utilities.Log("StartOriginProcess(/StartOffline origin://LaunchGame/70619)");
            StartOriginProcess(@"""/StartOffline"" ""origin://LaunchGame/70619"""); //Starts Origin in offline mode, autolaunching Battlefield 3
            Process battlefield3 = null;
            Utilities.Log("while (Process battlefield3 == null)");
            while (battlefield3 == null)
            {
                //Continuously loop through all processes until we find BF3.
                if (GetBattlefield3Process() != null)
                {
                    battlefield3 = GetBattlefield3Process();
                }
            }

            Utilities.Log("Process battlefield3.WaitForExit");
            battlefield3.WaitForExit();
            Utilities.Log("Battlefield 3 has closed");
            this.Close();
        }

        #endregion

        #region Javascript

        private WebSession CreateBattlelogWebSession()
        {
            Utilities.Log("CreateWebSession()");
            WebSession session =
                WebCore.CreateWebSession(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Battlelogium", "WebSession"),
                    new WebPreferences { CustomCSS = config.CSS, EnableGPUAcceleration = true, });
            session.AddDataSource("local", new ResourceDataSource(ResourceType.Packed));

            return session;
        }

        private void InjectScript(string scripturl)
        {
            this.Battlelog.ExecuteJavascript(
                @"
                    var script = document.createElement('script');
                    script.setAttribute('src','" + scripturl + @"');
                    document.getElementsByTagName('head')[0].appendChild(script);
                 ");
            Utilities.Log("Injected script " + scripturl);
        }

        private void BindJavascriptEvents(JSObject jsObject)
        {
            jsObject.Bind("quitConfirm", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript QuitButton pressed");
                this.Battlelog.ExecuteJavascript("showDialog(askToQuitDialog('Are you sure you want to quit?', 'Do you want to quit?'))");
            }));

            jsObject.Bind("minimize", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript Minimize pressed");
                this.WindowState = WindowState.Minimized;
            }));

            jsObject.Bind("quitWrapper", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Quit requested from Javascript call");
                this.Close();
            }));

            jsObject.Bind("clearCache", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript ClearCache pressed");
                this.clearCache = true;
                this.Battlelog.ExecuteJavascript("showDialog(askToQuitDialog('The cache will be cleared on restart', 'Do you wish to quit Battlelogium now?'))");
            }));


            jsObject.Bind("editSettings", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript EditSettings pressed");
                using (var configEditor = new BattlelogiumConfigEditor(config))
                {
                    var result = configEditor.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Battlelog.ExecuteJavascript("showDialog(askToQuitDialog('Settings will be saved on restart', 'Do you wish to quit Battlelogium now?'))");
                    }

                }
            }));
        }

        #endregion

    }
}
        