using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptFUSION.WarframeAlertTracker {
    internal static class EnumExtension {
        public static IEnumerable<T> GetMembers<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
