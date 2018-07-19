using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using ScriptFUSION.WarframeAlertTracker.Controls;
using Newtonsoft.Json.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureList : UserControl {
        private Dictionary<string, FissureControl> idMap = new Dictionary<string, FissureControl>();

        public FissureList() {
            InitializeComponent();

            // Remove dummy controls at run-time (used for illustrative purposes at design-time).
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) {
                table.Controls.Clear();
            }
        }

        internal void Update(IEnumerable<Fissure> fissures, JObject solNodes) {
            var ids = new List<string>();

            foreach (var fissure in fissures.OrderBy(f => f.Tier)) {
                var fissureControl = GetOrCreateFissureControl(fissure.Id);

                fissureControl.Update(fissure, solNodes);

                if (!table.Controls.Contains(fissureControl)) {
                    table.Controls.Add(fissureControl, 0, ids.Count);
                }

                ids.Add(fissure.Id);
            }

            RemoveObsoleteFissureControls(ids);
        }

        private FissureControl GetOrCreateFissureControl(string id) {
            if (idMap.ContainsKey(id)) {
                return idMap[id];
            }

            var fissureControl = new FissureControl();
            idMap.Add(id, fissureControl);

            return fissureControl;
        }

        private void RemoveObsoleteFissureControls(List<string> validIds) {
            // ToArray creates a copy that is necessary to avoid modifying the list during enumeration.
            foreach (var id in idMap.Keys.ToArray()) {
                if (!validIds.Contains(id)) {
                    table.Controls.Remove(idMap[id]);
                    idMap.Remove(id);
                }
            }
        }
    }
}
