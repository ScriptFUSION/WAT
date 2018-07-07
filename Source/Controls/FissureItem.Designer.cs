namespace ScriptFUSION.WarframeAlertTracker.Controls {
    partial class FissureItem {
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
            this.tier = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.Label();
            this.relic = new ScriptFUSION.WarframeAlertTracker.Controls.PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.relic)).BeginInit();
            this.SuspendLayout();
            // 
            // tier
            // 
            this.tier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tier.Location = new System.Drawing.Point(3, 66);
            this.tier.Name = "tier";
            this.tier.Size = new System.Drawing.Size(59, 14);
            this.tier.TabIndex = 0;
            this.tier.Text = "LITH";
            this.tier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type.Location = new System.Drawing.Point(68, 7);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(26, 15);
            this.type.TabIndex = 1;
            this.type.Text = "Dig";
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.Location = new System.Drawing.Point(68, 25);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(80, 30);
            this.location.TabIndex = 2;
            this.location.Text = "Earth, E Prime\r\nGrineer";
            // 
            // relic
            // 
            this.relic.Image = global::ScriptFUSION.WarframeAlertTracker.Properties.Resources.Relic_bronze;
            this.relic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.relic.Location = new System.Drawing.Point(3, 3);
            this.relic.Name = "relic";
            this.relic.Size = new System.Drawing.Size(59, 58);
            this.relic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.relic.TabIndex = 3;
            this.relic.TabStop = false;
            // 
            // FissureItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.relic);
            this.Controls.Add(this.location);
            this.Controls.Add(this.type);
            this.Controls.Add(this.tier);
            this.Name = "FissureItem";
            this.Size = new System.Drawing.Size(299, 84);
            ((System.ComponentModel.ISupportInitialize)(this.relic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tier;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label location;
        private PictureBoxEx relic;
    }
}
