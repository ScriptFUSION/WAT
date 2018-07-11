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
    public partial class EndlessMarker : Control {
        public EndlessMarker() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var edge = ClientRectangle;
            edge.Width = 24;
            e.Graphics.FillPie(Brushes.ForestGreen, edge, 90, 180);
            edge.Offset(ClientRectangle.Width - edge.Width, 0);
            e.Graphics.FillPie(Brushes.ForestGreen, edge, 270, 180);

            var middle = ClientRectangle;
            middle.Offset(edge.Width / 2 - 1, 0);
            middle.Width -= edge.Width - 2;
            e.Graphics.FillRectangle(Brushes.ForestGreen, middle);

            using (var format = new StringFormat())
            using (var brush = new SolidBrush(Color.White)) {
                format.Alignment = format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Endless ☑", Font, brush, ClientRectangle, format);
            }
        }
    }
}
