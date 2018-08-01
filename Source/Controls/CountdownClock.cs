using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class CountdownClock : ControlEx {
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

            var rect = PaintRectangle;

            using (var brush = new SolidBrush(ClockFaceColour)) {
                e.Graphics.FillPie(brush, rect, 0, 360);
            }

            if (TimeRemaining.TotalSeconds > 0) {
                e.Graphics.FillPie(Brushes.Green, rect, 270, (float)TimeRemaining.TotalSeconds / 3600 * 360);
            }

            e.Graphics.StrokeText(FormatTimeSpan(TimeRemaining), Font, ForeColor, StrokeColour, ClientRectangle, 2F);
        }

        private static string FormatTimeSpan(TimeSpan timeSpan) {
            var format = timeSpan.Hours > 0 ? @"h\h\ m\m\ s\s" : @"m\m\ s\s";

            if (timeSpan.TotalSeconds < 0) format = @"\-" + format;

            return timeSpan.ToString(format);
        }
    }
}
