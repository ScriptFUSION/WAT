using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    internal static class ControlExtensions {
        public static bool IsDesignTime(this Control control) {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
}
