using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private Form mainForm;

        public WatApplication() {
            mainForm = new WatForm(new WarframeWorldStateDownloader());
            mainForm.FormClosed += delegate { ExitThread(); };

            mainForm.Show();
        }
    }
}
