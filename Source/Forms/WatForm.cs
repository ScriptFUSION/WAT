using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Alerts;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private WatApplication Application { get; }

        internal WatForm(WatApplication application) {
            InitializeComponent();

            Application = application;

            var solNodes = application.SolNodesDownloader.Download();
            application.CurrentWorldState.Update +=
                async worldState => OnWorldStateUpdate(worldState.Fissures, await solNodes);

            application.AlertsUpdate += OnAlertsUpdate;

            fissures.ImageRepository = application.ImageRepository;
        }

        private void OnWorldStateUpdate(IReadOnlyCollection<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
            OnAlertsUpdate(Application.AlertCollection);
        }

        private void OnAlertsUpdate(AlertCollection alertsCollection) {
            fissures.Update(alertsCollection);

            alertsCount.Text = Application.CurrentWorldState.CurrentState.WorldStateObjects.Count(alertsCollection.Matches).ToString();
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
