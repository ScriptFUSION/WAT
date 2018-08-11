using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {

    [JsonConverter(typeof(StringEnumConverter))]
    internal enum MissionType : byte {
        Unknown,
        Any,
        AnyEndless,

        Capture = byte.MaxValue / 8,
        Defense,
        Excavation,
        Extermination,
        Hive,
        Interception,
        MobileDefense,
        Rescue,
        Sabotage,
        Spy,
        Survival,
    }
}
