using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.WorldState {
    internal static class MissionName {
        private static readonly Dictionary<MissionType, string> missionNames = new Dictionary<MissionType, string> {
            { MissionType.MT_CAPTURE, "Capture" },
            { MissionType.MT_DEFENSE, "Defense" },
            { MissionType.MT_EXCAVATE, "Excavation" },
            { MissionType.MT_EXTERMINATION, "Extermination" },
            { MissionType.MT_HIVE, "Hive" },
            { MissionType.MT_INTEL, "Spy" },
            { MissionType.MT_MOBILE_DEFENSE, "Mobile Defense" },
            { MissionType.MT_RESCUE, "Rescue" },
            { MissionType.MT_SABOTAGE, "Sabotage" },
            { MissionType.MT_SURVIVAL, "Survival" },
            { MissionType.MT_TERRITORY, "Interception" },
        };

        public static string FromType(MissionType type) {
            if (!missionNames.ContainsKey(type)) {
                return type.ToString();
            }

            return missionNames[type];
        }
    }
}
