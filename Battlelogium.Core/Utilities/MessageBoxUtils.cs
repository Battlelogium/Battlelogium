using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battlelogium.ThirdParty.WPFCustomMessageBox;
using System.Windows;

namespace Battlelogium.Core.Utilities
{
    public static class MessageBoxUtils
    {
        public static bool ShowChoiceDialog(string messageBoxText, string caption, string okButtonText, string cancelButtonText)
        {
            MessageBoxResult result = CustomMessageBox.ShowOKCancel(messageBoxText, caption, okButtonText, cancelButtonText);

            if (result == MessageBoxResult.Cancel) 
                return false;
            else 
                return true;
        }

    }
}
