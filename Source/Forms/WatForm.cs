using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        internal WatForm(ImageRepository images) {
            InitializeComponent();

            fissures.ImageRepository = images;
        }

        internal void Update(IEnumerable<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }

        private void alerts_Click(object sender, EventArgs e) {
            using (var form = new AlertsForm()) {
                form.ShowDialog(this);
            }
        }
    }
}
