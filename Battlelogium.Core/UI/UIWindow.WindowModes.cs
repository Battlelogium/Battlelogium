using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Battlelogium.ThirdParty.Animator;
using System.Windows.Media;
using System.Windows.Shell;

namespace Battlelogium.Core.UI
{
    public partial class UIWindow
    {
        public void SetWindowed()
        {
            SetWindowed(this.config.StartMaximized, this.config.NoBorder, this.config.WindowWidth, this.config.WindowHeight);
        }

        public void SetWindowed(bool maximizedWindow, bool noBorder, int windowWidth, int windowHeight)
        {
            switch (maximizedWindow)
            {
                case true:
                    this.WindowState = WindowState.Maximized;
                    break;
                case false:
                    this.WindowState = WindowState.Normal;
                    break;
            }
            switch (noBorder)
            {
                case true:
                    this.Loaded += delegate
                    {
                        var chrome = new WindowChrome();
                        chrome.CaptionHeight = 15D;
                        chrome.UseAeroCaptionButtons = true;
                        WindowChrome.SetWindowChrome(this, chrome);
                    };
                    break;
                case false:
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.ResizeMode = ResizeMode.CanResizeWithGrip;
                    break;
            }

          //  this.RightClickDrag();
            this.Width = windowWidth;
            this.Height = windowHeight;
        }

        public void SetFullScreen()
        {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.BorderBrush = null;
            this.BorderThickness = new Thickness(0);
            this.ResizeMode = ResizeMode.NoResize;
        }
    }
}
