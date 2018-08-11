﻿namespace ScriptFUSION.WarframeAlertTracker.Forms {
    partial class AlertsForm {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Fissure",
            "Lith excavation mission"}, -1);
            this.fissuresGroup = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.fissureInclude = new System.Windows.Forms.Button();
            this.fissureTier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fissureMissionType = new System.Windows.Forms.ComboBox();
            this.alerts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.alertsGroup = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.fissuresGroup.SuspendLayout();
            this.alertsGroup.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fissuresGroup
            // 
            this.fissuresGroup.Controls.Add(this.button3);
            this.fissuresGroup.Controls.Add(this.fissureInclude);
            this.fissuresGroup.Controls.Add(this.fissureTier);
            this.fissuresGroup.Controls.Add(this.label2);
            this.fissuresGroup.Controls.Add(this.label1);
            this.fissuresGroup.Controls.Add(this.fissureMissionType);
            this.fissuresGroup.Location = new System.Drawing.Point(12, 12);
            this.fissuresGroup.Name = "fissuresGroup";
            this.fissuresGroup.Size = new System.Drawing.Size(501, 55);
            this.fissuresGroup.TabIndex = 0;
            this.fissuresGroup.TabStop = false;
            this.fissuresGroup.Text = "Fissures";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(433, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "Exclude";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // fissureInclude
            // 
            this.fissureInclude.Location = new System.Drawing.Point(371, 18);
            this.fissureInclude.Name = "fissureInclude";
            this.fissureInclude.Size = new System.Drawing.Size(56, 24);
            this.fissureInclude.TabIndex = 4;
            this.fissureInclude.Text = "Include";
            this.fissureInclude.UseVisualStyleBackColor = true;
            this.fissureInclude.Click += new System.EventHandler(this.fissureInclude_Click);
            // 
            // fissureTier
            // 
            this.fissureTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fissureTier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fissureTier.Location = new System.Drawing.Point(234, 20);
            this.fissureTier.Name = "fissureTier";
            this.fissureTier.Size = new System.Drawing.Size(121, 21);
            this.fissureTier.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mission";
            // 
            // fissureMissionType
            // 
            this.fissureMissionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fissureMissionType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fissureMissionType.Location = new System.Drawing.Point(62, 21);
            this.fissureMissionType.Name = "fissureMissionType";
            this.fissureMissionType.Size = new System.Drawing.Size(121, 21);
            this.fissureMissionType.TabIndex = 1;
            // 
            // alerts
            // 
            this.alerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alerts.CheckBoxes = true;
            this.alerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.alerts.ContextMenuStrip = this.contextMenuStrip1;
            this.alerts.FullRowSelect = true;
            this.alerts.GridLines = true;
            this.alerts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.alerts.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.alerts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.alerts.Location = new System.Drawing.Point(14, 22);
            this.alerts.Name = "alerts";
            this.alerts.Size = new System.Drawing.Size(475, 161);
            this.alerts.TabIndex = 0;
            this.alerts.UseCompatibleStateImageBehavior = false;
            this.alerts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Match";
            this.columnHeader3.Width = 260;
            // 
            // ok
            // 
            this.ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(178, 291);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 26);
            this.ok.TabIndex = 2;
            this.ok.Text = "&OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(273, 291);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 26);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // alertsGroup
            // 
            this.alertsGroup.Controls.Add(this.alerts);
            this.alertsGroup.Location = new System.Drawing.Point(12, 78);
            this.alertsGroup.Name = "alertsGroup";
            this.alertsGroup.Size = new System.Drawing.Size(501, 198);
            this.alertsGroup.TabIndex = 1;
            this.alertsGroup.TabStop = false;
            this.alertsGroup.Text = "Alerts";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAlert});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // removeAlert
            // 
            this.removeAlert.Name = "removeAlert";
            this.removeAlert.Size = new System.Drawing.Size(117, 22);
            this.removeAlert.Text = "Remove";
            this.removeAlert.Click += new System.EventHandler(this.removeAlert_Click);
            // 
            // AlertsForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(526, 331);
            this.Controls.Add(this.alertsGroup);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.fissuresGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AlertsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alerts setup – Warframe Alert Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertsForm_FormClosing);
            this.fissuresGroup.ResumeLayout(false);
            this.fissuresGroup.PerformLayout();
            this.alertsGroup.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fissuresGroup;
        private System.Windows.Forms.Button fissureInclude;
        private System.Windows.Forms.ComboBox fissureTier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fissureMissionType;
        private System.Windows.Forms.ListView alerts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox alertsGroup;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeAlert;
    }
}