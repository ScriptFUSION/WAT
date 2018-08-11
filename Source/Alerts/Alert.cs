using Newtonsoft.Json;

namespace ScriptFUSION.WarframeAlertTracker.Alerts {
    internal abstract class Alert {
        public abstract AlertType Type { get; }

        [JsonIgnore]
        public abstract string Description { get; }

        public bool Enabled { get; set; } = true;

        public MatchingRule MatchingRule { get; set; }

        public Alert Clone() {
            return (Alert)MemberwiseClone();
        }
    }
}
