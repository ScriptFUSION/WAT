using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class WorldState {
        public DateTime Time { get; }

        public IEnumerable<Fissure> Fissures { get; }

        public WorldState(JObject json) {
            Time = UnixTime.Epoch.AddSeconds(json["Time"].Value<long>()).ToLocalTime();
            Fissures = json["ActiveMissions"].Select(t => new Fissure(t));
        }
    }
}
