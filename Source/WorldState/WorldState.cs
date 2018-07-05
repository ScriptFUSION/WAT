using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.WorldState {
    internal sealed class WorldState {
        public IEnumerable<Fissure> Fissures { get; private set; }

        public WorldState(JObject json) {
            Fissures = json["ActiveMissions"].Select(t => new Fissure(t)).ToList();
        }
    }
}
