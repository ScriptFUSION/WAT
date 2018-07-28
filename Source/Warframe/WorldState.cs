using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class WorldState {
        public IEnumerable<Fissure> Fissures { get; }

        public WorldState(JObject json) {
            Fissures = json["ActiveMissions"].Select(t => new Fissure(t));
        }
    }
}
