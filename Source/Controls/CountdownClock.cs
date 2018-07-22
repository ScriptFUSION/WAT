using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class CountdownClock : ControlEx {
        private DateTime countdownTime;

        public DateTime CountdownTo
        {
            get { return countdownTime; }
            set
            {
                countdownTime = value;

                Invalidate();
            }
        }

        [Browsable(false)]
        public TimeSpan TimeRemaining
        {
            get { return CountdownTo - DateTime.Now; }
        }

        [DefaultValue(typeof(Color), "ControlDark")]
        public Color ClockFaceColour { get; set; } = SystemColors.ControlDark;

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

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var rect = PaintRectangle;

            using (var brush = new SolidBrush(ClockFaceColour)) {
                e.Graphics.FillPie(brush, rect, 0, 360);
            }

            if (TimeRemaining.TotalSeconds > 0) {
                e.Graphics.FillPie(Brushes.Green, rect, 270, (float)TimeRemaining.TotalSeconds / 3600 * 360);
            }

            using (var format = new StringFormat())
            using (var brush = new SolidBrush(Color.White)) {
                format.Alignment = format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(FormatTimeSpan(TimeRemaining), Font, brush, ClientRectangle, format);
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan) {
            var format = timeSpan.Hours > 0 ? @"h\h\ m\m\ s\s" : @"m\m\ s\s";

            if (timeSpan.TotalSeconds < 0) format = @"\-" + format;

            return timeSpan.ToString(format);
        }
    }
}
