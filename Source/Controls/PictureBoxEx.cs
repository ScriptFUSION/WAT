using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using ScriptFUSION.WarframeAlertTracker.Drawing;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public class PictureBoxEx : PictureBox {
        private InterpolationMode interpolationMode = InterpolationMode.Default;

        private string caption;

        [DefaultValue(typeof(InterpolationMode), "Default")]
        public InterpolationMode InterpolationMode
        {
            get => interpolationMode;
            set
            {
                interpolationMode = value;

                Invalidate();
            }
        }

        public string Caption
        {
            get => caption;
            set
            {
                caption = value;

                Invalidate();
            }
        }

        [DefaultValue(typeof(Point), "0, 0")]
        public Point CaptionOffset { get; set; }

        [Browsable(true)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.InterpolationMode = InterpolationMode;

            base.OnPaint(e);

            e.Graphics.StrokeText(Caption, Font, ForeColor, Color.FromArgb(192, Color.Black), ClientRectangle, 2F, CaptionOffset);
        }
    }
}
