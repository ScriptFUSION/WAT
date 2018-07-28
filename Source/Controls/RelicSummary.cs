using ScriptFUSION.WarframeAlertTracker.Resource;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public class RelicSummary : Control {
        private static readonly string[] order = { "Lith", "Meso", "Neo", "Axi" };

        private int lith, meso, neo, axi;

        [DefaultValue(0)]
        public int Lith
        {
            get => lith;
            set
            {
                if (lith == value) return;

                lith = value;
                Invalidate();
            }
        }

        [DefaultValue(0)]
        public int Meso
        {
            get => meso;
            set
            {
                if (meso == value) return;

                meso = value;
                Invalidate();
            }
        }

        [DefaultValue(0)]
        public int Neo
        {
            get => neo;
            set
            {
                if (neo == value) return;

                neo = value;
                Invalidate();
            }
        }

        [DefaultValue(0)]
        public int Axi
        {
            get => axi;
            set
            {
                if (axi == value) return;

                axi = value;
                Invalidate();
            }
        }

        internal RelicSummary() {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        internal ImageRepository ImageRepository { get; set; }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            if (ImageRepository == null) {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Dashed);
            }

            var segments = order.Length;
            var segment = ClientRectangle;
            segment.Width /= segments * 2;
            segment.Height = segment.Width;
            segment.Y = (int)((ClientRectangle.Height / 2F) - (segment.Height / 2F));

            for (var i = 0; i < segments; ++i) {
                Task<Bitmap> image = null;
                if (ImageRepository != null) {
                    image = (Task<Bitmap>)typeof(ImageRepository).GetProperty(order[i]).GetValue(ImageRepository);
                }

                // Draw image if available.
                if (image != null && image.IsCompleted) {
                    e.Graphics.DrawImage(image.Result, segment);
                }
                else {
                    // Draw placeholder when unavailable.
                    ControlPaint.DrawBorder(e.Graphics, segment, SystemColors.ControlDark, ButtonBorderStyle.Dashed);

                    // Invalidate control when image ready.
                    image?.ContinueWith(_ => Invalidate());
                }

                segment.Offset(segment.Width, 0);

                using (var brush = new SolidBrush(ForeColor))
                using (var format = new StringFormat()) {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    var value = (int)GetType().GetProperty(order[i]).GetValue(this);

                    e.Graphics.DrawString(value.ToString(), Font, brush, segment, format);
                }

                segment.Offset(segment.Width, 0);
            }
        }
    }
}
