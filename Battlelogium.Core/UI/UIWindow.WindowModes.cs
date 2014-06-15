using System;
using System.Windows;
using System.Windows.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using Battlelogium.Utilities;

namespace Battlelogium.Core.UI
{
    public partial class UIWindow
    {
        public bool IsFullscreen { get; private set; }

        public void SetWindowed()
        {
            this.IsFullscreen = false;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.CanResize;
            
                this.WindowState = WindowState.Normal;
                switch ((this.UICore.config.WindowWidth == 0 || this.UICore.config.WindowHeight == 0))
                {
                    case true:
                        this.LoadBounds();
                        break;
                    case false:
                        this.Height = this.UICore.config.WindowHeight;
                        this.Width = this.UICore.config.WindowWidth;
                        break;
               }

             if (this.UICore.config.RightClickDrag){
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
            this.SaveBounds(); //Save window bounds before setting fullscreen
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
                this.UICore.config.WriteConfig("fullscreenMode", "true");
                return;
            }
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
