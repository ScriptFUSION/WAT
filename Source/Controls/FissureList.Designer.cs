namespace ScriptFUSION.WarframeAlertTracker.Controls {
    partial class FissureList {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.dummy = new ScriptFUSION.WarframeAlertTracker.Controls.FissureControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fissureCount = new System.Windows.Forms.Label();
            this.summary = new ScriptFUSION.WarframeAlertTracker.Controls.RelicSummary();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.endlessCount = new System.Windows.Forms.Label();
            this.endlessSummary = new ScriptFUSION.WarframeAlertTracker.Controls.RelicSummary();
            this.table.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AutoScrollMargin = new System.Drawing.Size(30, 0);
            this.table.AutoSize = true;
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.dummy, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(431, 106);
            this.table.TabIndex = 0;
            // 
            // dummy
            // 
            this.dummy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dummy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dummy.Location = new System.Drawing.Point(5, 5);
            this.dummy.Name = "dummy";
            this.dummy.Size = new System.Drawing.Size(421, 94);
            this.dummy.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.table);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 308);
            this.panel1.TabIndex = 1;
            // 
            // fissureCount
            // 
            this.fissureCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fissureCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fissureCount.Location = new System.Drawing.Point(53, 0);
            this.fissureCount.Margin = new System.Windows.Forms.Padding(0);
            this.fissureCount.Name = "fissureCount";
            this.fissureCount.Size = new System.Drawing.Size(21, 34);
            this.fissureCount.TabIndex = 2;
            this.fissureCount.Text = "0";
            this.fissureCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // summary
            // 
            this.summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summary.Location = new System.Drawing.Point(74, 0);
            this.summary.Margin = new System.Windows.Forms.Padding(0);
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(140, 34);
            this.summary.TabIndex = 2;
            this.summary.Text = "relicSummary1";
            this.summary.ZeroColor = System.Drawing.Color.Firebrick;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fissures";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fissureCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.summary, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.endlessCount, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.endlessSummary, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(214, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endless";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // endlessCount
            // 
            this.endlessCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endlessCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endlessCount.Location = new System.Drawing.Point(267, 0);
            this.endlessCount.Margin = new System.Windows.Forms.Padding(0);
            this.endlessCount.Name = "endlessCount";
            this.endlessCount.Size = new System.Drawing.Size(21, 34);
            this.endlessCount.TabIndex = 4;
            this.endlessCount.Text = "0";
            this.endlessCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endlessSummary
            // 
            this.endlessSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endlessSummary.Location = new System.Drawing.Point(288, 0);
            this.endlessSummary.Margin = new System.Windows.Forms.Padding(0);
            this.endlessSummary.Name = "endlessSummary";
            this.endlessSummary.Size = new System.Drawing.Size(143, 34);
            this.endlessSummary.TabIndex = 5;
            this.endlessSummary.Text = "relicSummary1";
            this.endlessSummary.ZeroColor = System.Drawing.Color.Firebrick;
            // 
            // FissureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FissureList";
            this.Size = new System.Drawing.Size(431, 345);
            this.table.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private ScriptFUSION.WarframeAlertTracker.Controls.FissureControl dummy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fissureCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RelicSummary summary;
        private RelicSummary endlessSummary;
        private System.Windows.Forms.Label endlessCount;
        private System.Windows.Forms.Label label2;
    }
}
