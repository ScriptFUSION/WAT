using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bitmap = System.Drawing.Bitmap;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    internal static class ControlExtension {
        public static bool IsDesignTime(this Control control) {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        public static Bitmap Snapshot(this Control control) {
            var image = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(image, control.ClientRectangle);

            return image;
        }
    }
}
