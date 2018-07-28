using System.ComponentModel;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    internal static class ControlExtensions {
        public static bool IsDesignTime(this Control control) {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
}
