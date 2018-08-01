using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Drawing;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class CountdownClock : ControlEx {
        private static readonly ColorBlend colourBands = new ColorBlend {
            Colors = new[]
            {
                Color.FromArgb(204, 92, 92),
                Color.FromArgb(242, 233, 97),
                Color.FromArgb(117, 205, 121),
                Color.FromArgb(117, 205, 121)
            },
            Positions = new[] { 0, .15F, .5F, 1 }
        };

        private DateTime countdownTime;

        public DateTime CountdownTo
        {
            get => countdownTime;
            set
            {
                countdownTime = value;

                Invalidate();
            }
        }

        [Browsable(false)]
        public TimeSpan TimeRemaining => CountdownTo - DateTime.Now;

        [DefaultValue(typeof(Color), "ControlDark")]
        public Color ClockFaceColour { get; set; } = SystemColors.ControlDark;

        [DefaultValue(typeof(Color), "Black")]
        public Color StrokeColour { get; set; } = Color.Black;

        public CountdownClock() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (!this.IsDesignTime()) {
                StartClock();
            }
        }

        private async void StartClock() {
            while (true) {
                await Task.Delay(1000);

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw face.
            var faceArea = PaintRectangle;
            faceArea.Inflate(-2, -2);
            using (var brush = new SolidBrush(ClockFaceColour)) {
                e.Graphics.FillPie(brush, faceArea, 0, 360);
            }

            var remaining = (float)TimeRemaining.TotalSeconds / 3600;

            if (remaining > 0) {
                var primaryColor = Rgb.Interpolate(colourBands, remaining);

                // Draw gradated time band.
                using (var gradientPath = new GraphicsPath()) {
                    var gradientArea = PaintRectangle;
                    gradientArea.Inflate(1, 1);
                    gradientPath.AddEllipse(gradientArea);

                    using (var brush = new PathGradientBrush(gradientPath)) {
                        brush.CenterColor = ClockFaceColour;
                        brush.SurroundColors = new[] { primaryColor };
                        brush.FocusScales = new PointF(.715F, .715F);

                        e.Graphics.FillPie(brush, PaintRectangle, 270, remaining * 360);
                    }
                }

                // Draw ticks every 10 minutes.
                using (var pen = new Pen(Color.FromArgb(128, primaryColor), 1.6F)) {
                    var origin = new PointF(PaintRectangle.Width / 2F, PaintRectangle.Height / 2F);

                    for (var i = 0; i < 6; ++i) {
                        // Skip ticks representing a time greater than currently remaining since it would overlap the face.
                        if (i / 6F > remaining) continue;

                        var extent = origin;
                        var cos = Math.Cos(i / 6F * Math.PI * 2 - Math.PI / 2);
                        var sin = Math.Sin(i / 6F * Math.PI * 2 - Math.PI / 2);
                        extent.X += (float)(origin.X * cos);
                        extent.Y += (float)(origin.Y * sin);

                        var lesserExtent = origin;
                        const int tickLength = 7;
                        lesserExtent.X += (float)((origin.X - tickLength) * cos);
                        lesserExtent.Y += (float)((origin.Y - tickLength) * sin);

                        e.Graphics.DrawLine(pen, extent, lesserExtent);
                    }
                }

                // Draw second hour overlay.
                if (remaining > 1) {
                    var rect = faceArea;
                    rect.Inflate(-9, -9);

                    using (var brush = new SolidBrush(Color.FromArgb(32, Color.White))) {
                        e.Graphics.FillPie(brush, rect, 270, (float)(TimeRemaining.TotalSeconds - 3600) / 3600 * 360);
                    }
                }
            }

            // Draw text.
            e.Graphics.StrokeText(FormatTimeSpan(TimeRemaining), Font, ForeColor, StrokeColour, ClientRectangle);
        }

        private static string FormatTimeSpan(TimeSpan timeSpan) {
            var format = timeSpan.Hours > 0 ? @"h\h\ m\m\ s\s" : @"m\m\ s\s";

            if (timeSpan.TotalSeconds < 0) format = @"\-" + format;

            return timeSpan.ToString(format);
        }
    }
}
