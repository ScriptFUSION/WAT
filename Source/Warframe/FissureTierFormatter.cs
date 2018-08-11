using System;
using System.Collections.Generic;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal static class FissureTierFormatter {
        private static readonly Dictionary<FissureTier, string> tierNames = new Dictionary<FissureTier, string>
        {
            { FissureTier.Any, "–Any–" }
        };

        public static string From(FissureTier tier) {
            return tierNames.ContainsKey(tier) ? tierNames[tier] : tier.ToString();
        }

        public static string From(Enum member) => From((FissureTier)member);
    }
}
