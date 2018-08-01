using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScriptFUSION.WarframeAlertTracker.Drawing {
    internal static class GraphicsExtension {
        public static void StrokeText(
            this Graphics graphics,
            string text,
            Font font,
            Color foreground,
            Color stroke,
            Rectangle rect,
            float strokeWidth = 2,
            Point offset = default(Point)
        ) {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = new GraphicsPath())
            using (var pen = new Pen(stroke, strokeWidth))
            using (var brush = new SolidBrush(foreground))
            using (var format = new StringFormat()) {
                pen.LineJoin = LineJoin.Round;
                format.Alignment = format.LineAlignment = StringAlignment.Center;

                rect.Offset(offset);

                path.AddString(
                    text,
                    font.FontFamily,
                    (int)font.Style,
                    graphics.DpiY * font.SizeInPoints / 72,
                    rect,
                    format
                );

                graphics.DrawPath(pen, path);
                graphics.FillPath(brush, path);
            }
        }
    }
}
