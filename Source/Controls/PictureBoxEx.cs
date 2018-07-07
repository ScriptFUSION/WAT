using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public class PictureBoxEx : PictureBox {
        private InterpolationMode interpolationMode = InterpolationMode.Default;

        [DefaultValue(typeof(InterpolationMode), "Default")]
        public InterpolationMode InterpolationMode
        {
            get
            {
                return interpolationMode;
            }
            set
            {
                interpolationMode = value;

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.InterpolationMode = InterpolationMode;

            base.OnPaint(e);
        }
    }
}
