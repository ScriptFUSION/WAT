using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScriptFUSION.WarframeAlertTracker.Drawing {
    public static class Rgb {
        public static Color Interpolate(ColorBlend blend, float position) {
            Color c1 = Color.Red, c2 = Color.Red;
            float amount = 0;

            position = Math.Min(Math.Max(position, 0), 1);

            for (var i = 1; i < blend.Positions.Length; ++i) {
                if (position <= blend.Positions[i]) {
                    c1 = blend.Colors[i - 1];
                    c2 = blend.Colors[i];
                    amount = position / blend.Positions[i];

                    break;
                }
            }

            return Color.FromArgb(
                (int)Math.Round(c1.R + (c2.R - c1.R) * amount),
                (int)Math.Round(c1.G + (c2.G - c1.G) * amount),
                (int)Math.Round(c1.B + (c2.B - c1.B) * amount)
            );
        }
    }
}
