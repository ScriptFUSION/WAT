using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class WorldState {
        public DateTime Time { get; }

        public IReadOnlyCollection<Fissure> Fissures { get; }

        /// <summary>
        /// Gets a collection of all world state objects in no particular order.
        ///
        /// TODO: Concat more collections when they're added.
        /// </summary>
        public IReadOnlyCollection<IWorldStateObject> WorldStateObjects => Fissures;

        public WorldState(JObject json) {
            Time = UnixTime.Epoch.AddSeconds(json["Time"].Value<long>()).ToLocalTime();
            Fissures = json["ActiveMissions"].Select(t => new Fissure(t)).ToList();
        }
    }
}
