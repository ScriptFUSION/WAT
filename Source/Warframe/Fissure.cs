using Newtonsoft.Json.Linq;
using System;
using ScriptFUSION.WarframeAlertTracker.Alerts;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class Fissure : IWorldStateObject {
        public string Id { get; private set; }

        public MissionType Mission { get; private set; }

        public FissureTier Tier { get; private set; }

        public int Region { get; private set; }

        public string Node { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime Finish { get; private set; }

        public Fissure(JToken token) {
            ParseJson(token);
        }

        private void ParseJson(JToken token) {
            Id = token["_id"]["$oid"].ToString();

            Mission = MissionTypeParser.Parse(token["MissionType"].ToString());

            Tier = FissureTierParser.Parse(token["Modifier"].ToString());

            Region = token["Region"].Value<int>();

            Node = token["Node"].ToString();

            Start = UnixTime.Epoch.AddSeconds(token["Activation"]["$date"]["$numberLong"].Value<long>() / 1000D).ToLocalTime();
            Finish = UnixTime.Epoch.AddSeconds(token["Expiry"]["$date"]["$numberLong"].Value<long>() / 1000D).ToLocalTime();
        }

        public bool IsEndless =>
            Mission == MissionType.Defense
            || Mission == MissionType.Excavation
            || Mission == MissionType.Survival
            || Mission == MissionType.Interception;

        public bool Matches(Alert alert) {
            if (alert is FissureAlert fissureAlert) {
                return
                    (fissureAlert.Tier == Tier || fissureAlert.Tier == FissureTier.Any)
                    && (
                        fissureAlert.Mission == Mission
                        || fissureAlert.Mission == MissionType.Any
                        || fissureAlert.Mission == MissionType.AnyEndless && IsEndless
                    )
                ;
            }

            return false;
        }
    }
}
