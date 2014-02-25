using System;
using System.Windows;
using System.Windows.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using Battlelogium.Core.Utilities;

namespace Battlelogium.Core.UI
{
    public partial class UIWindow
    {
        public bool IsFullscreen { get; private set; }
        public void SetWindowed()
        {
            SetWindowed(this.config.StartMaximized, this.config.NoBorder, this.config.WindowWidth, this.config.WindowHeight, this.config.RightClickDrag);
        }

        public void SetWindowed(bool maximizedWindow, bool noBorder, int windowWidth, int windowHeight, bool rightClickDrag=false)
        {
            this.IsFullscreen = false;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.CanResize;
            
            switch (maximizedWindow)
            {
                case true:
                    this.WindowState = WindowState.Maximized;
                    break;
                case false:
                    this.WindowState = WindowState.Normal;
                    switch((windowWidth == 0 || windowHeight == 0)){
                        case true:
                        this.LoadBounds();
                        break;
                        case false:
                        this.Height = windowHeight;
                        this.Width = windowWidth;
                        break;
                    }
                    break;
            }
            if (noBorder)
            {
                var chrome = new WindowChrome();
                chrome.CaptionHeight = 14D;
                chrome.UseAeroCaptionButtons = true;
                switch (this.IsLoaded)
                {
                    case true:
                        WindowChrome.SetWindowChrome(this, chrome);
                        break;
                    case false:
                        this.Loaded += (s, e) => WindowChrome.SetWindowChrome(this, chrome);
                        break;
                }
               
            }
            if (rightClickDrag)
            {
                if (!this.RightClickDragInitialized)
                {
                    this.InitRightClickDrag();
                }
                if (!this.RightClickDragEnabled)
                {
                    this.EnableRightClickDrag();
                }
            }
        }

        public void SetFullScreen()
        {
            this.IsFullscreen = true;
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.BorderBrush = null;
            this.BorderThickness = new Thickness(0);
            this.ResizeMode = ResizeMode.NoResize;
            if (this.RightClickDragEnabled) this.DisableRightClickDrag();
            this.Hide();
            this.Show();
            this.Activate();
        }

        private void LoadBounds()
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            try
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("windowbounds", FileMode.OpenOrCreate, storage))
                using (StreamReader reader = new StreamReader(stream))
                {

                    // Read restore bounds value from file
                    Rect restoreBounds = Rect.Parse(reader.ReadLine());
                    this.Left = restoreBounds.Left;
                    this.Top = restoreBounds.Top;
                    this.Width = restoreBounds.Width;
                    this.Height = restoreBounds.Height;
                }
            }
            catch (Exception)
            {
                this.Height = 720;
                this.Width = 1280;
            }
        }

        private void SaveBounds()
        {
            if (this.IsFullscreen)
            {
                config.WriteConfig("fullscreenMode", "true");
                return;
            }
            if (this.WindowState == WindowState.Maximized)
            {
                config.WriteConfig("startMaximized", "true");
                return;
            }
            config.WriteConfig("startMaximized", "false"); //Reset Fullscreen and Maximized
            config.WriteConfig("fullscreenMode", "false");
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("windowbounds", FileMode.Create, storage))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Write restore bounds value to file
                writer.WriteLine(this.RestoreBounds.ToString());
            }
        }
    }
}
