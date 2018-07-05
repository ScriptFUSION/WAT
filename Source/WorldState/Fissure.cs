using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.WorldState {
    internal sealed class Fissure {
        public MissionType Type { get; private set; }
        public FissureTier Tier { get; private set; }
        public Region Region { get; private set; }
        public string Node { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }

        public Fissure(JToken token) {
            MissionType missionType;
            if (Enum.TryParse(token["MissionType"].ToString(), out missionType)) {
                Type = missionType;
            };

            var modifier = token["Modifier"].ToString();
            Debug.Assert(modifier.StartsWith("VoidT"));
            Tier = (FissureTier)int.Parse(modifier.Last().ToString());

            Region = (Region)token["Region"].Value<int>();

            Node = token["Node"].ToString();

            Start = UnixTime.Epoch.AddSeconds(token["Activation"]["$date"]["$numberLong"].Value<long>() / 1000).ToLocalTime();
            Finish = UnixTime.Epoch.AddSeconds(token["Expiry"]["$date"]["$numberLong"].Value<long>() / 1000).ToLocalTime();
        }
    }
}
