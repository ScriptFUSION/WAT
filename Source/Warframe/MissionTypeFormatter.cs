using System;
using System.Collections.Generic;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal static class MissionTypeFormatter {
        private static readonly Dictionary<MissionType, string> names = new Dictionary<MissionType, string>
        {
            { MissionType.Any, "–Any–" },
            { MissionType.AnyEndless, "–Any Endless–" },
            { MissionType.MobileDefense, "Mobile Defense" },
        };

        public static string From(MissionType missionType) {
            return names.ContainsKey(missionType) ? names[missionType] : missionType.ToString();
        }

        public static string From(Enum member) => From((MissionType)member);
    }
}
