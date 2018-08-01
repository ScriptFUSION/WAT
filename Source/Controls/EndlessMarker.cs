using System.Drawing;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class EndlessMarker : ControlEx {
        public EndlessMarker() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Left edge.
            var edge = PaintRectangle;
            edge.Width = 22;
            e.Graphics.FillPie(Brushes.Green, edge, 90, 180);
            // Right edge.
            edge.Offset(PaintRectangle.Width - edge.Width, 0);
            e.Graphics.FillPie(Brushes.Green, edge, 270, 180);

            var middle = ClientRectangle;
            middle.Offset(edge.Width / 2 - 1, 0);
            middle.Width -= edge.Width - 1;
            e.Graphics.FillRectangle(Brushes.Green, middle);

            TextRenderer.DrawText(e.Graphics, "Endless ☑", Font, PaintRectangle, Color.White);
        }
    }
}
