// -----------------------------------------------------------------------
// <copyright file="JsDialog.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Battlelogium.BattlelogDialog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Managed C# wrapped around the Dialog API in battlelogium.js
    /// </summary>
    public class JSDialog
    {
        string dialogHeaderText;
        string dialogBodyHeaderText;
        string dialogBodyText;
        bool showCloseX;
        JSButton[] dialogButtons;

        public JSDialog(string dialogHeaderText, string dialogBodyHeaderText, string dialogBodyText, bool showCloseX, params JSButton[] dialogButtons){
            this.dialogHeaderText = dialogHeaderText;
            this.dialogBodyHeaderText = dialogBodyHeaderText;
            this.dialogBodyText = dialogBodyText;
            this.showCloseX = showCloseX;
            this.dialogButtons = dialogButtons;
        }

        /// <summary> Converts the JSButton[] to a JavaScript string to pass onto createDialog() </summary>
        private string DialogButtonsToJS()
        {
            return String.Format("[{0}]", String.Join<JSButton>(", ",dialogButtons));
        }

        /// <summary> Creates a method call to createDialog(). Call ExecuteJavascript() with this.</summary>
        public static string ShowJavascriptDialog(JSDialog dialog)
        {
            return String.Format("showDialog({0})", dialog.ToString());
        }

        public override string ToString()
        {
            return String.Format("createDialog('{0}', '{1}', '{2}', {3}, {4})", dialogHeaderText, dialogBodyHeaderText, dialogBodyText, showCloseX.ToString().ToLowerInvariant(), DialogButtonsToJS());
        }
    }

    /// <summary>An OK dialog template</summary>
    public class OKDialog : JSDialog
    {
        public OKDialog(string header, string reason) : base(header, header, reason, false, new JSButton("okButton", "closeDialog()", " OK ", "null", true)) { }
    }

    /// <summary>A quit confirmation dialog template</summary>
    public class QuitConfirmDialog : JSDialog
    {
        public QuitConfirmDialog(string header, string reason) : base("Confirm Closing", header, reason, false, new JSButton("quitBattlelogiumButton", "wrapper.quitWrapper()", " Close Battlelogium ", "Quit Battlelogium", false), new JSButton("closeDialogButton", "closeDialog()", " Cancel ", "null", true)) { }
    }


}
