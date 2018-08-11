using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScriptFUSION.WarframeAlertTracker.Alerts {
    [TypeConverter(typeof(AlertCollectionConverter))]
    internal class AlertCollection : IEnumerable<Alert> {
        private List<Alert> Alerts { get; } = new List<Alert>();

        public void Add(Alert alert) {
            Alerts.Add(alert);
        }

        public void Remove(Alert alert) {
            Alerts.Remove(alert);
        }

        public AlertCollection Clone() {
            var clone = new AlertCollection();

            foreach (var alert in Alerts) {
                clone.Add(alert.Clone());
            }

            return clone;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<Alert> GetEnumerator() {
            return Alerts.GetEnumerator();
        }
    }
}
