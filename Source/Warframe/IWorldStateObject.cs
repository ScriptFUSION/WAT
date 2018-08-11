using ScriptFUSION.WarframeAlertTracker.Alerts;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {

    internal interface IWorldStateObject {
        bool Matches(Alert alert);
    }
}
