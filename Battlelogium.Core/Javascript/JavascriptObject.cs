using System;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Diagnostics;
using Battlelogium.Core.UI;
using Battlelogium.Core.Configuration;

namespace Battlelogium.Core.Javascript
{
    public class JavascriptObject
    {
        private UICore uiCore;
        public JavascriptObject()
        {

        }
        public void InitJavascriptObject(UICore uiCore){
            this.uiCore = uiCore;
        }
        public void quit()
        {
            this.syncInvoke(new Action(delegate
            {
                this.uiCore.mainWindow.Close();
                
            }));
        }

        public void minimize()
        {
            this.syncInvoke(new Action(delegate
            {
                this.uiCore.mainWindow.WindowState = WindowState.Minimized;
            }));
            
        }

        public void clearcache()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Battlelogium.ExecUtils.exe"))) {
                uiCore.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Battlelogium.ExecUtils.exe not found. Please reinstall Battlelogium.', receiptTypes.ERROR)");
                return;
            }
            uiCore.mainWindow.Closing += (s,e) => Process.Start("Battlelogium.ExecUtils.exe", "clearcache " + Process.GetCurrentProcess().Id);
            uiCore.battlelog.battlelogWebview.ExecuteScript("base.showReceipt('Cache and cookies will be cleared on exit')");
        }

        public void opensettings()
        {
            new UIConfig().ShowDialog();
        }
        /// <summary>
        /// Invoke a method on the UI thread
        /// </summary>
        /// <param name="action">delegate to invoke on main UI thread</param>
        private void syncInvoke(Action action)
        {
            this.uiCore.mainWindow.Dispatcher.Invoke(action);
        }
    }
}