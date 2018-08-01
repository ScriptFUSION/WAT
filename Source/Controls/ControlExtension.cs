using System.ComponentModel;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    internal static class ControlExtension {
        public static bool IsDesignTime(this Control control) {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
}
