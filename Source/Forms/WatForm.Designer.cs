namespace ScriptFUSION.WarframeAlertTracker.Forms {
    partial class WatForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.fissures = new ScriptFUSION.WarframeAlertTracker.Controls.FissureList();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.alerts = new System.Windows.Forms.ToolStripButton();
            this.options = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.alertsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.homePageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fissures
            // 
            this.fissures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fissures.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fissures.Location = new System.Drawing.Point(12, 18);
            this.fissures.Name = "fissures";
            this.fissures.Size = new System.Drawing.Size(449, 425);
            this.fissures.TabIndex = 2;
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alerts,
            this.options});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(473, 25);
            this.toolBar.TabIndex = 9;
            this.toolBar.Text = "toolStrip1";
            // 
            // alerts
            // 
            this.alerts.Name = "alerts";
            this.alerts.Size = new System.Drawing.Size(41, 22);
            this.alerts.Text = "Alerts";
            this.alerts.Click += new System.EventHandler(this.alerts_Click);
            // 
            // options
            // 
            this.options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(53, 22);
            this.options.Text = "Options";
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.alertsCount});
            this.statusBar.Location = new System.Drawing.Point(0, 456);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(473, 22);
            this.statusBar.TabIndex = 10;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Matches";
            // 
            // alertsCount
            // 
            this.alertsCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.alertsCount.Name = "alertsCount";
            this.alertsCount.Size = new System.Drawing.Size(14, 17);
            this.alertsCount.Text = "0";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuItem,
            this.alertsMenuItem,
            this.optionsMenuItem,
            this.toolStripSeparator1,
            this.homePageMenuItem,
            this.exitMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(274, 120);
            // 
            // showMenuItem
            // 
            this.showMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.showMenuItem.Name = "showMenuItem";
            this.showMenuItem.Size = new System.Drawing.Size(273, 22);
            this.showMenuItem.Text = "&Show/Hide Warframe Alert Tracker";
            this.showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);
            // 
            // alertsMenuItem
            // 
            this.alertsMenuItem.Name = "alertsMenuItem";
            this.alertsMenuItem.Size = new System.Drawing.Size(273, 22);
            this.alertsMenuItem.Text = "&Alerts...";
            this.alertsMenuItem.Click += new System.EventHandler(this.alerts_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(273, 22);
            this.optionsMenuItem.Text = "&Options...";
            this.optionsMenuItem.Click += new System.EventHandler(this.options_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(270, 6);
            // 
            // homePageMenuItem
            // 
            this.homePageMenuItem.Name = "homePageMenuItem";
            this.homePageMenuItem.Size = new System.Drawing.Size(273, 22);
            this.homePageMenuItem.Text = "&Home page";
            this.homePageMenuItem.Click += new System.EventHandler(this.homePageMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(273, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // WatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 478);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.fissures);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WAT – Warframe Alert Tracker";
            this.Resize += new System.EventHandler(this.WatForm_Resize);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FissureList fissures;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton alerts;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel alertsCount;
        private System.Windows.Forms.ToolStripButton options;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alertsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem homePageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
    }
}
