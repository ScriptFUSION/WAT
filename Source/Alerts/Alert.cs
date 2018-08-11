using Newtonsoft.Json;
using ScriptFUSION.WarframeAlertTracker.Warframe;

namespace ScriptFUSION.WarframeAlertTracker.Alerts {
    internal abstract class Alert {
        public abstract AlertType Type { get; }

        [JsonIgnore]
        public abstract string Description { get; }

        public bool Enabled { get; set; } = true;

        public MatchingRule MatchingRule { get; set; }

        public bool Matches(IWorldStateObject worldStateObject) {
            return worldStateObject.Matches(this);
        }
    }
}
