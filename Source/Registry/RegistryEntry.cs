using Microsoft.Win32;

namespace ScriptFUSION.WarframeAlertTracker.Registry {
    public abstract class RegistryEntry {
        protected RegistryKey Hive { get; }

        protected string Key { get; }

        protected string Name { get; }

        protected RegistryEntry(RegistryKey hive, string key, string name) {
            Hive = hive;
            Key = key;
            Name = name;
        }

        public abstract bool IsSynchronised();

        public abstract void Synchronise();
    }
}
