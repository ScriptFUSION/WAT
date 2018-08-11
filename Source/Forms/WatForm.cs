using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private WatApplication Application { get; }

        internal WatForm(WatApplication application) {
            InitializeComponent();

            Application = application;

            var solNodes = application.SolNodesDownloader.Download();
            application.CurrentWorldState.Update +=
                async worldState => Update(worldState.Fissures, await solNodes);

            fissures.ImageRepository = application.ImageRepository;
        }

        private void Update(IReadOnlyCollection<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }

        private void alerts_Click(object sender, EventArgs e) {
            var alertCollection = Application.AlertCollection.Clone();

            using (var form = new AlertsForm(Application.CurrentWorldState, alertCollection)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    Application.AlertCollection = alertCollection;
                }
            }
        }
    }
}
