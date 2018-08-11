using System.Collections.Generic;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal static class FissureTierParser {
        private static readonly Dictionary<string, FissureTier> tierMap = new Dictionary<string, FissureTier>
        {
            { "VoidT1", FissureTier.Lith },
            { "VoidT2", FissureTier.Meso },
            { "VoidT3", FissureTier.Neo },
            { "VoidT4", FissureTier.Axi },
        };

        public static FissureTier Parse(string tier) {
            return tierMap[tier];
        }
    }
}
