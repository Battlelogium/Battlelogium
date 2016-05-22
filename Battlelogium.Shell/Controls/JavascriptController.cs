using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;

namespace Battlelogium.Shell.Controls
{
    public class JavascriptController
    {
        private Window view;
        public bool isMaximized => this.view.WindowState == WindowState.Maximized;
       

        public JavascriptController(Window view)
        {
            this.view = view;
        }
        public void quit()
        {
            this.syncInvoke(() => this.view.Close());
        }

        public void minimize()
        {
            this.syncInvoke(() => this.view.WindowState = WindowState.Minimized);

        }
        public void maximize()
        {
            this.syncInvoke(() => this.view.WindowState = WindowState.Maximized);

        }
        public void restore()
        {
            this.syncInvoke(() => this.view.WindowState = WindowState.Normal);

        }
      
        /// <summary>
        /// Invoke a method on the UI thread
        /// </summary>
        /// <param name="action">delegate to invoke on main UI thread</param>
        private void syncInvoke(Action action)
        {
            this.view.Dispatcher.Invoke(action);
        }

        private WindowState GetWindowState()
        {
            return this.view.Dispatcher.Invoke(() => this.view.WindowState);
        }
    }
}