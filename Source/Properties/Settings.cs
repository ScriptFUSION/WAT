using System;
using System.ComponentModel;
using ScriptFUSION.WarframeAlertTracker.Alerts;

namespace ScriptFUSION.WarframeAlertTracker.Properties {
    internal sealed partial class Settings {
        public event Action<AlertCollection> AlertsUpdate;

        public event Action<int> RefreshRateUpdate;

        public Settings() {
            if (Alerts == null) Alerts = new AlertCollection();

            PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case "Alerts":
                    AlertsUpdate?.Invoke(Alerts);
                    break;

                case "RefreshRate":
                    RefreshRateUpdate?.Invoke(RefreshRate);
                    break;
            }
        }
    }
}
