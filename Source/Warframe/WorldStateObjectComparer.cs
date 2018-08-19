using System.Collections.Generic;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal class WorldStateObjectComparer : EqualityComparer<IWorldStateObject> {
        public override bool Equals(IWorldStateObject x, IWorldStateObject y) {
            return x.Id == y.Id;
        }

        public override int GetHashCode(IWorldStateObject obj) {
            return obj.Id.GetHashCode();
        }
    }
}
