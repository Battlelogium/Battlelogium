using System;
using System.Windows;
using System.Windows.Threading;

namespace Battlelogium.Core.Javascript
{
    public class JavascriptObject
    {
        private Window battlelogiumWindow;
        public JavascriptObject(Window battlelogiumWindow)
        {
            this.battlelogiumWindow = battlelogiumWindow;
        }

        public void quit()
        {
            this.syncInvoke(new Action(delegate
            {
                this.battlelogiumWindow.Close();
            }));
        }

        public void minimize()
        {
            this.syncInvoke(new Action(delegate
            {
                this.battlelogiumWindow.WindowState = WindowState.Minimized;
            }));
            
        }

        /// <summary>
        /// Invoke a method on the UI thread
        /// </summary>
        /// <param name="action">delegate to invoke on main UI thread</param>
        private void syncInvoke(Action action)
        {
            this.battlelogiumWindow.Dispatcher.Invoke(action);
        }
    }
}