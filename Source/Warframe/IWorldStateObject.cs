using ScriptFUSION.WarframeAlertTracker.Alerts;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {

    internal interface IWorldStateObject {
        string Id { get; }

        bool Matches(Alert alert);
    }
}
