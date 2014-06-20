using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using Battlelogium.Core.UI;
using Battlelogium.Core.Configuration;

namespace Battlelogium.Core.Javascript
{
    public class JavascriptObject
    {
        private UICore Core;
        public bool ismaximized {
            get
            {
                switch (this.GetWindowState())
                {
                    case WindowState.Maximized:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public JavascriptObject()
        {

        }
        public void InitJavascriptObject(UICore core){
            this.Core = core;
        }
        public void forceupdate()
        {
            this.syncInvoke(() => this.Core.UpdateBattlelogium());
        }
        public void quit()
        {
            this.syncInvoke(() => this.Core.mainWindow.Close());
        }

        public void minimize()
        {
            this.syncInvoke(() => this.Core.mainWindow.WindowState = WindowState.Minimized);
            
        }
        public void maximize()
        {
            this.syncInvoke(() => this.Core.mainWindow.WindowState = WindowState.Maximized);

        }
        public void restore()
        {
            this.syncInvoke(() => this.Core.mainWindow.WindowState = WindowState.Normal);

        }
        public void clearcache()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Battlelogium.ExecUtils.exe"))) {
                Core.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Battlelogium.ExecUtils.exe not found. Please reinstall Battlelogium.', receiptTypes.ERROR)");
                return;
            }
            Core.mainWindow.Closing += (s,e) => Process.Start("Battlelogium.ExecUtils.exe", "clearcache " + Process.GetCurrentProcess().Id);
            Core.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Cache and cookies will be cleared on exit')");
        }

        public void opensettings()
        {
            syncInvoke(() => {
                var configEditor = new UIConfig(Core.config){Owner = Core.mainWindow};
                var overlay = new System.Windows.Shapes.Rectangle(){
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                    Stretch = System.Windows.Media.Stretch.Fill,
                    Opacity = 0.5D
                };
                Core.mainWindow.MainControl.MainGrid.Children.Add(overlay);
                bool? result = configEditor.ShowDialog();
                Core.mainWindow.MainControl.MainGrid.Children.Remove(overlay);

                switch (result)
                {
                    case true:
                        Core.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Settings will be applied on next start')");
                        break;
                    case false:
                        Core.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Settings were not changed', receiptTypes.ERROR)");
                        break;
                }
                

            });
        }
        /// <summary>
        /// Invoke a method on the UI thread
        /// </summary>
        /// <param name="action">delegate to invoke on main UI thread</param>
        private void syncInvoke(Action action)
        {
            this.Core.mainWindow.Dispatcher.Invoke(action);
        }

        private WindowState GetWindowState()
        {
            return this.Core.mainWindow.Dispatcher.Invoke(() => {
                return this.Core.mainWindow.WindowState;
            });
        }
    }
}