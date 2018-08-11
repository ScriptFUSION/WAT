using System.Collections.Generic;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal static class MissionTypeParser {
        private static readonly Dictionary<string, MissionType> missionNames = new Dictionary<string, MissionType> {
            { "MT_CAPTURE", MissionType.Capture },
            { "MT_DEFENSE", MissionType.Defense },
            { "MT_EXCAVATE", MissionType.Excavation },
            { "MT_EXTERMINATION", MissionType.Extermination },
            { "MT_HIVE", MissionType.Hive },
            { "MT_INTEL", MissionType.Spy },
            { "MT_MOBILE_DEFENSE", MissionType.MobileDefense },
            { "MT_RESCUE", MissionType.Rescue },
            { "MT_SABOTAGE", MissionType.Sabotage },
            { "MT_SURVIVAL", MissionType.Survival },
            { "MT_TERRITORY", MissionType.Interception },
        };

        public static MissionType Parse(string type) {
            return missionNames.ContainsKey(type) ? missionNames[type] : MissionType.Unknown;
        }
    }
}
