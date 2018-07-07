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
        public FissureList() {
            InitializeComponent();

            if (!DesignMode) {
                table.Controls.Clear();
            }
        }

        internal void UpdateComponents(List<Fissure> Fissures, JObject solNodes) {
            Fissures.Sort((f1, f2) => f1.Tier.CompareTo(f2.Tier));

            table.Controls.Clear();
            var rows = table.RowCount = Fissures.Count;

            for (var i = 0; i < rows; ++i) {
                var fi = new FissureItem();

                fi.Anchor |= AnchorStyles.Right;
                fi.Update(Fissures[i], solNodes);

                table.Controls.Add(fi, 0, i);
            }
        }
    }
}
