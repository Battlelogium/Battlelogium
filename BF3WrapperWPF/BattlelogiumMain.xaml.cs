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

    using BattlelogDialog;

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

        /// <summary> Battlelogium's Configuration data</summary>
        private BattlelogiumConfiguration config;

        /// <summary> Represents an instance of Origin managed by Battlelogium</summary>
        private ManagedOrigin managedOrigin;

        /// <summary> An event handler required for right-click dragging of the window<summary>
        private MouseButtonEventHandler rightDragBtnDown;

        /// <summary> An event handler required for right-click dragging of the window<summary>
        private MouseEventHandler rightDragMove;

        /// <summary> Whether Battlelogium is currently in Fullscreen or Windowed Mode</summary>
        private bool fullScreen = true;

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
            if (Process.GetProcessesByName("Battlelogium").Length > 1)
            {
                Utilities.Log("Process.GetProcessesByName(Battlelogium).Length > 1");
                CustomMessageBox.Show("There can only be one instance of Battlelogium running at a time. Wait for the other instance to close and try again");
                this.Close();
                return;
            }
            Utilities.Log("BattlelogiumMain.config = new BattlelogiumConfiguration()");
            this.config = new BattlelogiumConfiguration();
            Utilities.Log(config.ConfigDump());
            Utilities.Log("BattlelogiumMain.StartupConnectionCheck()");
            this.StartupConnectionCheck();
            splash.Close(TimeSpan.Zero); //Close the splash screen or it will hang.
            

            if (config.DirectToCampaign) //If we're going directly to campaign, there is no need to initialize the main window
            {
                Utilities.Log("BattlelogiumMain.Closing += WrapperClosing");
                this.Closing += WrapperClosing; //Since we don't call InitializeComponent, we need to manually add the closing event handler
                Utilities.Log("BattlelogiumMain.StartBF3Campaign()");
                this.StartBF3Campaign();
            }
            else
            {
                if (config.HandleOrigin)
                {
                    Utilities.Log("BattlelogiumMain.StartOriginProcess(/StartClientMinimized)");
                    this.retainOrigin = ManagedOrigin.CheckIfOriginIsRunning();
                    Utilities.Log("retainOrigin = " + retainOrigin.ToString());

                    Utilities.Log("this.managedOrigin = new ManagedOrigin(/StartClientMinimized)");
                    this.managedOrigin = new ManagedOrigin("/StartClientMinimized");
                    try{
                        this.managedOrigin.StartOriginProcess();
                    }catch(Exception e){
                        HandleOriginException(e);
                    }
                }

                Utilities.Log("BattlelogiumMain.InitializeComponent()");
                this.InitializeComponent();
                this.VersionLabel.Content = "Battlelogium " + Assembly.GetEntryAssembly().GetName().Version.ToString();

                Utilities.Log("BattlelogiumMain.SetupStoryboards()");
                this.SetupStoryboards();

                if (config.WindowedMode)
                {
                    Utilities.Log("BattlelogiumMain.SetWindowed()");
                    this.SetWindowed();
                }

                Utilities.Log("this.blinkLoading.Begin()");
                this.blinkLoading.Begin();

                Utilities.Log("this.Battlelog.Websession = CreateBattlelogWebSession()");
                this.Battlelog.WebSession = CreateBattlelogWebSession();

                if (config.CheckUpdates)
                {
                    Utilities.Log("Check Updates: new UpdateNotifier(Assembly.GetEntryAssembly().GetName().Version).run()");
                    new UpdateNotifier(Assembly.GetEntryAssembly().GetName().Version, this.Dispatcher).run();
                }

                if (config.UseSoftwareRender)
                {
                    Utilities.Log("RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly");
                    RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
                }

                this.ForceWindowToTop();
            }
        }

        #region Handlers

        private void HotkeyHandler(object sender, KeyEventArgs e)
        {
            Utilities.Log("BattlelogiumMain.HotkeyHandler() called");
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt)
            {
                ///We put e.Handled = true to suppress the beep that sounds if we don't.
                switch (e.SystemKey)
                {
                    case Key.N:
                        Utilities.Log("KeyEventArgs.Handled, Key.N");
                        this.WindowState = WindowState.Minimized;
                        e.Handled = true;
                        break;
                    case Key.Enter: //Replicate Alt+Enter functionailty
                        switch (this.fullScreen)
                        {
                            case true:
                                Utilities.Log("KeyEventArgs.Handled, Key.Enter, this.SetWindowed()");
                                this.SetWindowed();
                                break;
                            case false:
                                Utilities.Log("KeyEventArgs.Handled, Key.Enter, this.SetFullScreen()");
                                this.SetFullScreen();
                                break;
                        }
                        e.Handled = true;
                        break;
                    case Key.C:
                        Utilities.Log("KeyEventArgs.Handled, Key.C");
                        this.Battlelog.ExecuteJavascript("document.getElementById('btnCampaign').click()"); //todo add more gamemode hotkeys
                        e.Handled = true;
                        break;
                }
            }
        }

        private void WrapperClosing(object sender, CancelEventArgs e)
        {
            Utilities.Log("this.WrapperClosing() called");
            if (GetBattlefield3Process() != null)
            {
               Utilities.Log("GetBattlefield3Process() != null");
               this.Battlelog.ExecuteJavascript(JSDialog.ShowJavascriptDialog(new OKDialog("Battlefield 3 is still running", "Quit Battlefield 3 before closing Battlelogium")));
               e.Cancel = true;
               return;
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
                    if (config.HandleOrigin)
                    {
                        Utilities.Log("managedOrigin.KillOriginProcess()");
                        managedOrigin.KillOriginProcess();
                    }
                    Utilities.Log("Utilities.KillProcess(sonarhost)");
                    Utilities.KillProcess("sonarhost",false,false);

                    if (this.retainOrigin)
                    {

                        Utilities.Log("retainOrigin = True");
                        //We do not want this instance of Origin to be a child process, otherwise Steam will think we're still in Battlefield 3
                       
                        Utilities.Log("ManagedOrigin.CreateUnmanagedInstance");
                        ManagedOrigin.CreateUnmanagedInstance();
                    }

                    Utilities.Log("!---End Log---!");
                    Utilities.Log("Press Enter to Exit. Remember to submit battlelogium.log");
                    Utilities.FreeConsole();

                }));
            };

            Utilities.Log("Waiting " + config.WaitTimeToKillOrigin * 1000 + " milliseconds to kill Origin");
            cleanupOriginTimer.Start();
            this.Hide();
            System.Threading.Thread.Sleep(config.WaitTimeToKillOrigin * 1000 + 5000);

        }

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
                this.LoadingIcon.Visibility = Visibility.Hidden;
                this.VersionLabel.Visibility = Visibility.Hidden;
            }
            else if (this.finishedLoading)
            {
                this.loadingTextFinalPlay = true;
                this.blinkLoading.AutoReverse = false;
                this.blinkLoading.Begin();
                Utilities.Log("LoadingIcon Final Blink Started");
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
            Utilities.Log("BattlelogiumMain.SetupStoryboards() Called");
            Utilities.Log("this.FindResource(this.BlinkLoading)");
            this.blinkLoading = this.FindResource("BlinkLoading") as Storyboard;

            Utilities.Log("this.FindResource(this.FadeBackground)");
            this.fadeBackground = this.FindResource("FadeBackground") as Storyboard;

            Utilities.Log("Storyboard.SetTarget(this.blinkLoading, this.LoadingIcon)");
            Storyboard.SetTarget(this.blinkLoading, this.LoadingIcon);

            Utilities.Log("Storyboard.SetTarget(this.fadeBackground, this.LoadingImage)");
            Storyboard.SetTarget(this.fadeBackground, this.LoadingImage);
            
        }

        private void StartupConnectionCheck()
        {
            Utilities.Log("BattlelogiumMain.StartupConnectionCheck() Called");
            if (!CheckForBattlelogConnection())
            {
     
                Utilities.Log("Utilities.ShowChoiceDialog(startInOfflineMode)");
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

        private void HandleOriginException(Exception e)
        {
            Utilities.Log("BattlelogiumMain.HandleOriginException() Called");
            Utilities.Log("Exception while doing Origin related task");
            Utilities.Log("Exception type: " + e.GetType());
            MessageBox.Show("Please install Origin to play Battlefield 3", "Error");
            Process.Start("http://www.managedOrigin.com/download");
            this.Close();
        }

        private bool CheckForBattlelogConnection()
        {
            Utilities.Log("CheckForBattlelogConnection() Called");
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

        private Process GetBattlefield3Process()
        {
            Utilities.Log("Utilities.GetBattlefield3Process() Called");
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
            Utilities.Log("BattlelogiumMain.StartBF3Campaign() Called");
            if (!this.config.HandleOrigin)
            {
                Utilities.Log("!this.config.HandleOrigin");
                Process.Start(Path.Combine(Utilities.GetBF3Path(), "bf3.exe"), @"-webMode SP -requestState State_ResumeCampaign -onlineEnvironment prod -requestStateParams""<data levelmode=\""sp\""></data>").WaitForExit();
                this.Close();
            }
            Utilities.Log("this.managedOrigin = new ManagedOrigin(/StartOffline origin://LaunchGame/70619)");
            this.managedOrigin = new ManagedOrigin(@"""/StartOffline"" ""origin://LaunchGame/70619"""); //Starts Origin in offline mode, autolaunching Battlefield 3
            managedOrigin.StartOriginProcess();
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
            Utilities.Log("BattlelogiumMain.CreateBattlelogWebSession() Called");
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
            Utilities.Log(String.Format("BattlelogiumMain.InjectScript({0}) Called",scripturl));
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
            Utilities.Log("BattlelogiumMain.BindJavascriptEvents Called");
            jsObject.Bind("quitConfirm", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript QuitButton pressed");
                this.Battlelog.ExecuteJavascript(JSDialog.ShowJavascriptDialog(new QuitConfirmDialog("Are you sure you want to quit?", "Do you want to quit?")));
            }));
            Utilities.Log("Bound wrapper.quitConfirm()");

            jsObject.Bind("minimize", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript Minimize pressed");
                this.WindowState = WindowState.Minimized;
            }));
            Utilities.Log("Bound wrapper.minimize()");

            jsObject.Bind("quitWrapper", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Quit requested from Javascript call");
                this.Close();
            }));
            Utilities.Log("Bound wrapper.quitWrapper()");

            jsObject.Bind("clearCache", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript ClearCache pressed");
                this.Battlelog.WebSession.ClearCache();
                this.Battlelog.WebSession.ClearCookies();
                this.Battlelog.Reload(true);
            }));
            Utilities.Log("Bound wrapper.clearCache()");


            jsObject.Bind("editSettings", false, new JavascriptMethodEventHandler(delegate
            {
                Utilities.Log("Javascript EditSettings pressed");
                using (var configEditor = new BattlelogiumConfigEditor(config))
                {
                    var result = configEditor.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Battlelog.ExecuteJavascript(JSDialog.ShowJavascriptDialog(new QuitConfirmDialog("Settings will be saved on restart", "Do you wish to quit Battlelogium now?")));
                    }

                }
            }));
            Utilities.Log("Bound wrapper.editSettings()");
        }

        #endregion

        #region Window

        private void SetWindowed()
        {
            SetWindowed(this.config.StartMaximized, this.config.NoBorder, this.config.WindowWidth, this.config.WindowHeight);
        }

        private void SetWindowed(bool maximizedWindow, bool noBorder, int windowWidth, int windowHeight)
        {
            Utilities.Log(String.Format("BattlelogiumMain.SetWindowed({0}, {1}, {2}, {3}) Called", maximizedWindow, noBorder, windowWidth, windowHeight));
            if (!maximizedWindow)
            {
                Utilities.Log("!config.StartMaximized");
                this.WindowState = WindowState.Normal;
            }
            if (!noBorder)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.ResizeMode = ResizeMode.CanResizeWithGrip;
            }
            if (noBorder)
            {
                this.BorderBrush = new LinearGradientBrush(Color.FromRgb(128, 128, 128), Color.FromRgb(208, 208, 208), 90);
                this.BorderThickness = new Thickness(1D);
            }
            EnableRightClickMove();
            this.Width = windowWidth;
            this.Height = windowHeight;
            this.fullScreen = false;
        }

        private void SetFullScreen()
        {
            Utilities.Log("BattlelogiumMain.SetFullScreen() called");
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.BorderBrush = null;
            this.BorderThickness = new Thickness(0);
            this.ResizeMode = ResizeMode.NoResize;
            this.DisableRightClickMove();
            //Hide the taskbar
            this.ForceWindowToTop();
            //Set fullscreen indicator
            this.fullScreen = true;
        }

        /// <summary>Enable right click dragging of the window</summary>
        private void EnableRightClickMove()
        {
            Utilities.Log("BattlelogiumMain.EnableRightClickMove() called");
            Point startPosition = new Point();
            this.rightDragBtnDown = (sender, e) =>
            {
                startPosition = e.GetPosition(this);
            };
            this.rightDragMove += (sender, e) =>
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Point endPosition = e.GetPosition(this);
                    Vector vector = endPosition - startPosition;
                    this.Left += vector.X;
                    this.Top += vector.Y;
                }
            };

            this.PreviewMouseRightButtonDown += this.rightDragBtnDown;
            this.PreviewMouseMove += this.rightDragMove;
        }

        private void DisableRightClickMove()
        {
            Utilities.Log("BattlelogiumMain.DisableRightClickMove() called");
            this.PreviewMouseRightButtonDown -= this.rightDragBtnDown;
            this.PreviewMouseMove -= this.rightDragMove;
        }

        private void ForceWindowToTop()
        {
            Utilities.Log("ForceWindowToTop() called");
            this.Hide();
            this.Show();
            this.Focus();
            this.BringIntoView();
            this.Topmost = true;
            System.Threading.Thread.Sleep(100);
            this.Topmost = false;
        }
        #endregion
    }
}
        