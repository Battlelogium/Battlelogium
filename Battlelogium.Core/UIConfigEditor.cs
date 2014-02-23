using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Battlelogium.Core.Utilities;

namespace Battlelogium.Core.UI
{
    public partial class UIConfigEditor : Form
    {
        Config config;

        public UIConfigEditor(Config config)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            InitializeComponent();
            this.config = config;

            //Load General Settings
            this.waitTimeToKillOrigin_input.Value = config.WaitTimeToKillOrigin;
            this.directToCampaign_input.Checked = config.DirectToCampaign;
            this.checkUpdates_input.Checked = config.CheckUpdates;
            this.useSoftwareRender_input.Checked = config.UseSoftwareRender;
            this.startOrigin_input.Checked = config.ManageOrigin;

            //Apply window height maximum and minimums
            this.windowHeight_input.Maximum = (decimal) SystemParameters.PrimaryScreenHeight;
            this.windowWidth_input.Maximum = (decimal) SystemParameters.PrimaryScreenWidth;

            this.windowHeight_input.Minimum = 400;
            this.windowWidth_input.Minimum = 400;  

            //Load Window Settings
            this.fullscreenMode_input.Checked = config.FullscreenMode;
            this.startMaximized_input.Checked = config.StartMaximized;
            this.noBorder_input.Checked = config.NoBorder;
            this.windowHeight_input.Value = config.WindowHeight;
            this.windowWidth_input.Value = config.WindowWidth;
            
            this.Refresh();
   
        }

        private void fullscreenMode_input_CheckedChanged(object sender, EventArgs e)
        {
                this.startMaximized_input.Enabled = !this.fullscreenMode_input.Checked;
                this.noBorder_input.Enabled = !this.fullscreenMode_input.Checked;
                this.windowHeight_input.Enabled = !this.fullscreenMode_input.Checked;
                this.windowWidth_input.Enabled = !this.fullscreenMode_input.Checked;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.config.WriteConfig("waitTimeToKillOrigin", ((int) this.waitTimeToKillOrigin_input.Value).ToString());
            this.config.WriteConfig("directToCampaign", this.directToCampaign_input.Checked.ToString());
            this.config.WriteConfig("checkUpdates", this.checkUpdates_input.Checked.ToString());
            this.config.WriteConfig("useSoftwareRender", this.useSoftwareRender_input.Checked.ToString());
            this.config.WriteConfig("manageOrigin", this.startOrigin_input.Checked.ToString());

            this.config.WriteConfig("fullscrenMode", this.fullscreenMode_input.Checked.ToString());
            this.config.WriteConfig("startMaximized", this.startMaximized_input.Checked.ToString());
            this.config.WriteConfig("noBorder", this.noBorder_input.Checked.ToString());
            this.config.WriteConfig("windowWidth", ((int)this.windowWidth_input.Value).ToString());
            this.config.WriteConfig("windowHeight", ((int)this.windowHeight_input.Value).ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxUtils.ShowChoiceDialog("Are you sure you want to discard your changes?", "Discard Changes", "Discard Changes", "Cancel"))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                return;
            }

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 1 && e.Column == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.CellBounds);
            }
            if (e.Row == 1 && e.Column == 1)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.CellBounds);
            }
        }
    }
}
