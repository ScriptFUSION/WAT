using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Registry {
    internal sealed class LoadAtStartupRegistryEntry : RegistryEntry {
        private readonly string value = $"\"{Application.ExecutablePath}\"";

        private bool dirty;
        private bool enabled;

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;

                dirty = true;
            }
        }

        public LoadAtStartupRegistryEntry()
            : base(Microsoft.Win32.Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName) {
            enabled = IsSynchronised();
        }

        public override bool IsSynchronised() {
            using (var key = Hive.OpenSubKey(Key)) {
                return key?.GetValue(Name)?.ToString().StartsWith(value) ?? false;
            }
        }

        public override void Synchronise() {
            if (!dirty) return;

            using (var key = Hive.OpenSubKey(Key, true)) {
                if (Enabled) {
                    key.SetValue(Name, value);
                }
                else {
                    key.DeleteValue(Name, false);
                }
            }

            dirty = false;
        }
    }
}
