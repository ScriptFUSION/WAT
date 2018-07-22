namespace ScriptFUSION.WarframeAlertTracker {
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
            this.fissures = new ScriptFUSION.WarframeAlertTracker.Controls.FissureList();
            this.SuspendLayout();
            // 
            // fissures
            // 
            this.fissures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fissures.Location = new System.Drawing.Point(0, 0);
            this.fissures.Name = "fissures";
            this.fissures.Size = new System.Drawing.Size(420, 428);
            this.fissures.TabIndex = 2;
            // 
            // WatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 428);
            this.Controls.Add(this.fissures);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WAT – Warframe Alert Tracker";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FissureList fissures;
    }
}
