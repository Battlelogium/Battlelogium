namespace Battlelogium.Core.UI
{
    partial class UIConfigEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIConfigEditor));
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.windowSettings = new System.Windows.Forms.GroupBox();
            this.windowSettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.windowHeight_input = new System.Windows.Forms.NumericUpDown();
            this.windowWidth_input = new System.Windows.Forms.NumericUpDown();
            this.noBorder_input = new System.Windows.Forms.CheckBox();
            this.windowHeight_label = new System.Windows.Forms.Label();
            this.windowWidth_label = new System.Windows.Forms.Label();
            this.noBorder_label = new System.Windows.Forms.Label();
            this.startMaximized_input = new System.Windows.Forms.CheckBox();
            this.startMaximized_label = new System.Windows.Forms.Label();
            this.fullscreenMode_input = new System.Windows.Forms.CheckBox();
            this.windowedMode_label = new System.Windows.Forms.Label();
            this.generalSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.waitTimeToKillOrigin_input = new System.Windows.Forms.NumericUpDown();
            this.waitTimeToKillOrigin_label = new System.Windows.Forms.Label();
            this.directToCampaign_label = new System.Windows.Forms.Label();
            this.directToCampaign_input = new System.Windows.Forms.CheckBox();
            this.checkUpdates_label = new System.Windows.Forms.Label();
            this.checkUpdates_input = new System.Windows.Forms.CheckBox();
            this.startOrigin_label = new System.Windows.Forms.Label();
            this.startOrigin_input = new System.Windows.Forms.CheckBox();
            this.groupSettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.useSoftwareRender_label = new System.Windows.Forms.Label();
            this.useSoftwareRender_input = new System.Windows.Forms.CheckBox();
            this.windowSettings.SuspendLayout();
            this.windowSettingsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowHeight_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowWidth_input)).BeginInit();
            this.generalSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeToKillOrigin_input)).BeginInit();
            this.groupSettingsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(378, 292);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(369, 28);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(3, 292);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(369, 28);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply Settings";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // windowSettings
            // 
            this.windowSettings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowSettings.Controls.Add(this.windowSettingsLayout);
            this.windowSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowSettings.Location = new System.Drawing.Point(378, 3);
            this.windowSettings.Name = "windowSettings";
            this.windowSettings.Size = new System.Drawing.Size(369, 283);
            this.windowSettings.TabIndex = 1;
            this.windowSettings.TabStop = false;
            this.windowSettings.Text = "Window Settings";
            // 
            // windowSettingsLayout
            // 
            this.windowSettingsLayout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowSettingsLayout.ColumnCount = 2;
            this.windowSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.windowSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.windowSettingsLayout.Controls.Add(this.windowHeight_input, 1, 4);
            this.windowSettingsLayout.Controls.Add(this.windowWidth_input, 1, 3);
            this.windowSettingsLayout.Controls.Add(this.noBorder_input, 1, 2);
            this.windowSettingsLayout.Controls.Add(this.windowHeight_label, 0, 4);
            this.windowSettingsLayout.Controls.Add(this.windowWidth_label, 0, 3);
            this.windowSettingsLayout.Controls.Add(this.noBorder_label, 0, 2);
            this.windowSettingsLayout.Controls.Add(this.startMaximized_input, 1, 1);
            this.windowSettingsLayout.Controls.Add(this.startMaximized_label, 0, 1);
            this.windowSettingsLayout.Controls.Add(this.fullscreenMode_input, 2, 0);
            this.windowSettingsLayout.Controls.Add(this.windowedMode_label, 0, 0);
            this.windowSettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowSettingsLayout.Location = new System.Drawing.Point(3, 16);
            this.windowSettingsLayout.Name = "windowSettingsLayout";
            this.windowSettingsLayout.RowCount = 5;
            this.windowSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.windowSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.windowSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.windowSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.windowSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.windowSettingsLayout.Size = new System.Drawing.Size(363, 264);
            this.windowSettingsLayout.TabIndex = 1;
            // 
            // windowHeight_input
            // 
            this.windowHeight_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.windowHeight_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowHeight_input.Location = new System.Drawing.Point(184, 226);
            this.windowHeight_input.Name = "windowHeight_input";
            this.windowHeight_input.Size = new System.Drawing.Size(176, 20);
            this.windowHeight_input.TabIndex = 18;
            this.windowHeight_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // windowWidth_input
            // 
            this.windowWidth_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.windowWidth_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowWidth_input.Location = new System.Drawing.Point(184, 172);
            this.windowWidth_input.Name = "windowWidth_input";
            this.windowWidth_input.Size = new System.Drawing.Size(176, 20);
            this.windowWidth_input.TabIndex = 17;
            this.windowWidth_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // noBorder_input
            // 
            this.noBorder_input.AutoSize = true;
            this.noBorder_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.noBorder_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noBorder_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noBorder_input.Location = new System.Drawing.Point(184, 107);
            this.noBorder_input.Name = "noBorder_input";
            this.noBorder_input.Size = new System.Drawing.Size(176, 46);
            this.noBorder_input.TabIndex = 16;
            this.noBorder_input.UseVisualStyleBackColor = false;
            // 
            // windowHeight_label
            // 
            this.windowHeight_label.AutoSize = true;
            this.windowHeight_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowHeight_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowHeight_label.Location = new System.Drawing.Point(3, 208);
            this.windowHeight_label.Name = "windowHeight_label";
            this.windowHeight_label.Size = new System.Drawing.Size(175, 56);
            this.windowHeight_label.TabIndex = 15;
            this.windowHeight_label.Text = "Window Height";
            this.windowHeight_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.windowHeight_label, "The height of the window");
            // 
            // windowWidth_label
            // 
            this.windowWidth_label.AutoSize = true;
            this.windowWidth_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowWidth_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowWidth_label.Location = new System.Drawing.Point(3, 156);
            this.windowWidth_label.Name = "windowWidth_label";
            this.windowWidth_label.Size = new System.Drawing.Size(175, 52);
            this.windowWidth_label.TabIndex = 14;
            this.windowWidth_label.Text = "Window Width";
            this.windowWidth_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.windowWidth_label, "The width of the window");
            // 
            // noBorder_label
            // 
            this.noBorder_label.AutoSize = true;
            this.noBorder_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.noBorder_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noBorder_label.Location = new System.Drawing.Point(3, 104);
            this.noBorder_label.Name = "noBorder_label";
            this.noBorder_label.Size = new System.Drawing.Size(175, 52);
            this.noBorder_label.TabIndex = 13;
            this.noBorder_label.Text = "Start in a Borderless Window";
            this.noBorder_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.noBorder_label, "If running in a window, start in a borderless window.\r\n\r\nWhile in a borderless wi" +
        "ndow, the only way to move the Battlelog window is dragging with the right mouse" +
        " button.");
            // 
            // startMaximized_input
            // 
            this.startMaximized_input.AutoSize = true;
            this.startMaximized_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startMaximized_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startMaximized_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startMaximized_input.Location = new System.Drawing.Point(184, 55);
            this.startMaximized_input.Name = "startMaximized_input";
            this.startMaximized_input.Size = new System.Drawing.Size(176, 46);
            this.startMaximized_input.TabIndex = 12;
            this.startMaximized_input.UseVisualStyleBackColor = false;
            // 
            // startMaximized_label
            // 
            this.startMaximized_label.AutoSize = true;
            this.startMaximized_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startMaximized_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startMaximized_label.Location = new System.Drawing.Point(3, 52);
            this.startMaximized_label.Name = "startMaximized_label";
            this.startMaximized_label.Size = new System.Drawing.Size(175, 52);
            this.startMaximized_label.TabIndex = 11;
            this.startMaximized_label.Text = "Start Maximized";
            this.startMaximized_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.startMaximized_label, "If running in a window, start in a maximized window");
            // 
            // fullscreenMode_input
            // 
            this.fullscreenMode_input.AutoSize = true;
            this.fullscreenMode_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fullscreenMode_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fullscreenMode_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullscreenMode_input.Location = new System.Drawing.Point(184, 3);
            this.fullscreenMode_input.Name = "fullscreenMode_input";
            this.fullscreenMode_input.Size = new System.Drawing.Size(176, 46);
            this.fullscreenMode_input.TabIndex = 10;
            this.fullscreenMode_input.UseVisualStyleBackColor = false;
            this.fullscreenMode_input.CheckedChanged += new System.EventHandler(this.fullscreenMode_input_CheckedChanged);
            // 
            // windowedMode_label
            // 
            this.windowedMode_label.AutoSize = true;
            this.windowedMode_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowedMode_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowedMode_label.Location = new System.Drawing.Point(3, 0);
            this.windowedMode_label.Name = "windowedMode_label";
            this.windowedMode_label.Size = new System.Drawing.Size(175, 52);
            this.windowedMode_label.TabIndex = 9;
            this.windowedMode_label.Text = "SetWindowed Mode";
            this.windowedMode_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.windowedMode_label, "Run Battlelogium in a Window instead of fullscreen");
            // 
            // generalSettings
            // 
            this.generalSettings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.generalSettings.Controls.Add(this.groupSettingsLayout);
            this.generalSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalSettings.Location = new System.Drawing.Point(3, 3);
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.Size = new System.Drawing.Size(369, 283);
            this.generalSettings.TabIndex = 0;
            this.generalSettings.TabStop = false;
            this.generalSettings.Text = "General Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.generalSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.windowSettings, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.applyButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(750, 323);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Tag = "";
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            // 
            // waitTimeToKillOrigin_input
            // 
            this.waitTimeToKillOrigin_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waitTimeToKillOrigin_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.waitTimeToKillOrigin_input.Location = new System.Drawing.Point(184, 11);
            this.waitTimeToKillOrigin_input.Name = "waitTimeToKillOrigin_input";
            this.waitTimeToKillOrigin_input.Size = new System.Drawing.Size(176, 20);
            this.waitTimeToKillOrigin_input.TabIndex = 1;
            this.waitTimeToKillOrigin_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waitTimeToKillOrigin_label
            // 
            this.waitTimeToKillOrigin_label.AutoSize = true;
            this.waitTimeToKillOrigin_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.waitTimeToKillOrigin_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waitTimeToKillOrigin_label.Location = new System.Drawing.Point(3, 0);
            this.waitTimeToKillOrigin_label.Name = "waitTimeToKillOrigin_label";
            this.waitTimeToKillOrigin_label.Size = new System.Drawing.Size(175, 43);
            this.waitTimeToKillOrigin_label.TabIndex = 0;
            this.waitTimeToKillOrigin_label.Text = "Seconds before closing Origin";
            this.waitTimeToKillOrigin_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.waitTimeToKillOrigin_label, "How long to wait, in seconds, before closing Origin on quit");
            // 
            // directToCampaign_label
            // 
            this.directToCampaign_label.AutoSize = true;
            this.directToCampaign_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.directToCampaign_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directToCampaign_label.Location = new System.Drawing.Point(3, 86);
            this.directToCampaign_label.Name = "directToCampaign_label";
            this.directToCampaign_label.Size = new System.Drawing.Size(175, 43);
            this.directToCampaign_label.TabIndex = 4;
            this.directToCampaign_label.Text = "Auto-start campaign after launch";
            this.directToCampaign_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.directToCampaign_label, "Skip Battlelog, and start campaign right after running Battlelogium with Steam Ov" +
        "erlay support");
            // 
            // directToCampaign_input
            // 
            this.directToCampaign_input.AutoSize = true;
            this.directToCampaign_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.directToCampaign_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.directToCampaign_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directToCampaign_input.Location = new System.Drawing.Point(184, 89);
            this.directToCampaign_input.Name = "directToCampaign_input";
            this.directToCampaign_input.Size = new System.Drawing.Size(176, 37);
            this.directToCampaign_input.TabIndex = 5;
            this.directToCampaign_input.UseVisualStyleBackColor = false;
            // 
            // checkUpdates_label
            // 
            this.checkUpdates_label.AutoSize = true;
            this.checkUpdates_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkUpdates_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkUpdates_label.Location = new System.Drawing.Point(3, 129);
            this.checkUpdates_label.Name = "checkUpdates_label";
            this.checkUpdates_label.Size = new System.Drawing.Size(175, 43);
            this.checkUpdates_label.TabIndex = 6;
            this.checkUpdates_label.Text = "Check for updates on start";
            this.checkUpdates_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.checkUpdates_label, "Check for updates to Battlelogium on start");
            // 
            // checkUpdates_input
            // 
            this.checkUpdates_input.AutoSize = true;
            this.checkUpdates_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkUpdates_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkUpdates_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkUpdates_input.Location = new System.Drawing.Point(184, 132);
            this.checkUpdates_input.Name = "checkUpdates_input";
            this.checkUpdates_input.Size = new System.Drawing.Size(176, 37);
            this.checkUpdates_input.TabIndex = 7;
            this.checkUpdates_input.UseVisualStyleBackColor = false;
            // 
            // startOrigin_label
            // 
            this.startOrigin_label.AutoSize = true;
            this.startOrigin_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startOrigin_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startOrigin_label.Location = new System.Drawing.Point(3, 215);
            this.startOrigin_label.Name = "startOrigin_label";
            this.startOrigin_label.Size = new System.Drawing.Size(175, 49);
            this.startOrigin_label.TabIndex = 10;
            this.startOrigin_label.Text = "Allow Battlelogium to handle Origin";
            this.startOrigin_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.startOrigin_label, "Disable only if Origin PAR Fix is installed");
            // 
            // startOrigin_input
            // 
            this.startOrigin_input.AutoSize = true;
            this.startOrigin_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.startOrigin_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startOrigin_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startOrigin_input.Location = new System.Drawing.Point(184, 218);
            this.startOrigin_input.Name = "startOrigin_input";
            this.startOrigin_input.Size = new System.Drawing.Size(176, 43);
            this.startOrigin_input.TabIndex = 11;
            this.startOrigin_input.UseVisualStyleBackColor = false;
            // 
            // groupSettingsLayout
            // 
            this.groupSettingsLayout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupSettingsLayout.ColumnCount = 2;
            this.groupSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.groupSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.groupSettingsLayout.Controls.Add(this.startOrigin_input, 1, 5);
            this.groupSettingsLayout.Controls.Add(this.startOrigin_label, 0, 5);
            this.groupSettingsLayout.Controls.Add(this.useSoftwareRender_input, 1, 4);
            this.groupSettingsLayout.Controls.Add(this.useSoftwareRender_label, 0, 4);
            this.groupSettingsLayout.Controls.Add(this.checkUpdates_input, 1, 3);
            this.groupSettingsLayout.Controls.Add(this.checkUpdates_label, 0, 3);
            this.groupSettingsLayout.Controls.Add(this.directToCampaign_input, 1, 2);
            this.groupSettingsLayout.Controls.Add(this.directToCampaign_label, 0, 2);
            this.groupSettingsLayout.Controls.Add(this.waitTimeToKillOrigin_label, 0, 0);
            this.groupSettingsLayout.Controls.Add(this.waitTimeToKillOrigin_input, 1, 0);
            this.groupSettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSettingsLayout.Location = new System.Drawing.Point(3, 16);
            this.groupSettingsLayout.Name = "groupSettingsLayout";
            this.groupSettingsLayout.RowCount = 6;
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.groupSettingsLayout.Size = new System.Drawing.Size(363, 264);
            this.groupSettingsLayout.TabIndex = 0;
            // 
            // useSoftwareRender_label
            // 
            this.useSoftwareRender_label.AutoSize = true;
            this.useSoftwareRender_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.useSoftwareRender_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSoftwareRender_label.Location = new System.Drawing.Point(3, 172);
            this.useSoftwareRender_label.Name = "useSoftwareRender_label";
            this.useSoftwareRender_label.Size = new System.Drawing.Size(175, 43);
            this.useSoftwareRender_label.TabIndex = 8;
            this.useSoftwareRender_label.Text = "Use the software renderer to fix Steam Overlay bugs";
            this.useSoftwareRender_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.useSoftwareRender_label, "Render Battlelog with the software renderer. \r\n\r\nThis disables Steam Overlay insi" +
        "de Battlelog, but not Battlefield 3. \r\nEnable if you have problems with the Stea" +
        "m Overlay in Battlelog.");
            // 
            // useSoftwareRender_input
            // 
            this.useSoftwareRender_input.AutoSize = true;
            this.useSoftwareRender_input.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.useSoftwareRender_input.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useSoftwareRender_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSoftwareRender_input.Location = new System.Drawing.Point(184, 175);
            this.useSoftwareRender_input.Name = "useSoftwareRender_input";
            this.useSoftwareRender_input.Size = new System.Drawing.Size(176, 37);
            this.useSoftwareRender_input.TabIndex = 9;
            this.useSoftwareRender_input.UseVisualStyleBackColor = false;
            // 
            // UIConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(750, 323);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UIConfigEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battlelogium";
            this.windowSettings.ResumeLayout(false);
            this.windowSettingsLayout.ResumeLayout(false);
            this.windowSettingsLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowHeight_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowWidth_input)).EndInit();
            this.generalSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeToKillOrigin_input)).EndInit();
            this.groupSettingsLayout.ResumeLayout(false);
            this.groupSettingsLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox windowSettings;
        private System.Windows.Forms.TableLayoutPanel windowSettingsLayout;
        private System.Windows.Forms.NumericUpDown windowHeight_input;
        private System.Windows.Forms.NumericUpDown windowWidth_input;
        private System.Windows.Forms.CheckBox noBorder_input;
        private System.Windows.Forms.Label windowHeight_label;
        private System.Windows.Forms.Label windowWidth_label;
        private System.Windows.Forms.Label noBorder_label;
        private System.Windows.Forms.CheckBox startMaximized_input;
        private System.Windows.Forms.Label startMaximized_label;
        private System.Windows.Forms.CheckBox fullscreenMode_input;
        private System.Windows.Forms.Label windowedMode_label;
        private System.Windows.Forms.GroupBox generalSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel groupSettingsLayout;
        private System.Windows.Forms.CheckBox startOrigin_input;
        private System.Windows.Forms.Label startOrigin_label;
        private System.Windows.Forms.CheckBox useSoftwareRender_input;
        private System.Windows.Forms.Label useSoftwareRender_label;
        private System.Windows.Forms.CheckBox checkUpdates_input;
        private System.Windows.Forms.Label checkUpdates_label;
        private System.Windows.Forms.CheckBox directToCampaign_input;
        private System.Windows.Forms.Label directToCampaign_label;
        private System.Windows.Forms.Label waitTimeToKillOrigin_label;
        private System.Windows.Forms.NumericUpDown waitTimeToKillOrigin_input;

    }
}