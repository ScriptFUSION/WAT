namespace ScriptFUSION.WarframeAlertTracker.Registry {
    internal sealed class RegistrySettings {
        public LoadAtStartupRegistryEntry LoadAtStartUp { get; set; } = new LoadAtStartupRegistryEntry();

        public void Save() {
            LoadAtStartUp.Synchronise();
        }
    }
}
