// -----------------------------------------------------------------------
// <copyright file="JsButton.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Battlelogium.BattlelogDialog{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class JSButton
    {
        public string id;
        public string onclick;
        public string text;
        public string tooltip;
        public bool grey;
        public JSButton(string id, string onclick, string text, string tooltip, bool grey)
        {
            this.id = id;
            this.onclick = onclick;
            this.text = text;
            this.tooltip = tooltip;
            this.grey = grey;
        }

        public override string ToString()
        {
            return String.Format("createDialogButton('{0}', '{1}', '{2}', '{3}', {4})", id, onclick, text, tooltip, grey.ToString().ToLowerInvariant());
        }

    }
}

