using System.Windows;
using System.Windows.Shell;
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
            this.Width = windowWidth;
            this.Height = windowHeight;
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
    }
}
