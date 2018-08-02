using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScriptFUSION.WarframeAlertTracker.Drawing {
    public static class Rgb {
        public static Color Interpolate(Color c1, Color c2, float amount) {
            amount = Math.Min(Math.Max(amount, 0), 1);

            return Color.FromArgb(
                (int)Math.Round(c1.A + (c2.A - c1.A) * amount),
                (int)Math.Round(c1.R + (c2.R - c1.R) * amount),
                (int)Math.Round(c1.G + (c2.G - c1.G) * amount),
                (int)Math.Round(c1.B + (c2.B - c1.B) * amount)
            );
        }

        public static Color InterpolateGradient(ColorBlend blend, float position) {
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

            return Interpolate(c1, c2, amount);
        }
    }
}
