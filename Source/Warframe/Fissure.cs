﻿using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class Fissure {
        public string Id { get; private set; }
        public MissionType Mission { get; private set; }
        public FissureTier Tier { get; private set; }
        public Region Region { get; private set; }
        public string Node { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }

        public Fissure(JToken token) {
            ParseJson(token);
        }

        private void ParseJson(JToken token) {
            Id = token["_id"]["$oid"].ToString();

            MissionType missionType;
            if (Enum.TryParse(token["MissionType"].ToString(), out missionType)) {
                Mission = missionType;
            };

            var modifier = token["Modifier"].ToString();
            Debug.Assert(modifier.StartsWith("VoidT"));
            Tier = (FissureTier)int.Parse(modifier.Last().ToString());

            Region = (Region)token["Region"].Value<int>();

            Node = token["Node"].ToString();

            Start = UnixTime.Epoch.AddSeconds(token["Activation"]["$date"]["$numberLong"].Value<long>() / 1000).ToLocalTime();
            Finish = UnixTime.Epoch.AddSeconds(token["Expiry"]["$date"]["$numberLong"].Value<long>() / 1000).ToLocalTime();
        }

        public bool IsEndless
        {
            get
            {
                return
                    Mission == MissionType.MT_DEFENSE
                    || Mission == MissionType.MT_EXCAVATE
                    || Mission == MissionType.MT_SURVIVAL
                    || Mission == MissionType.MT_TERRITORY
                ;
            }
        }
    }
}