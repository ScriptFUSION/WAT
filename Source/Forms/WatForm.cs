using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using ScriptFUSION.WarframeAlertTracker.Controls;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private WatApplication Application { get; }

        internal WatForm(WatApplication application) {
            InitializeComponent();

            Application = application;

            application.CurrentWorldState.Update +=
                async worldState => OnWorldStateUpdate(worldState.Fissures, await application.SolNodes);

            application.AlertsUpdate += OnAlertsUpdate;

            fissures.ImageRepository = application.ImageRepository;

            trayIcon.Icon = Icon;
        }

        private void ToggleWindowVisibility() {
            if (Visible = !Visible) {
                Activate();
            }
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

        private async void options_Click(object sender, EventArgs e) {
            using (var form = new OptionsForm(await FissureControl.CreateTestControl(Application.ImageRepository))) {
                form.ShowDialog(this);
            }
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button.HasFlag(MouseButtons.Left)) {
                ToggleWindowVisibility();
            }
        }

        private void showMenuItem_Click(object sender, EventArgs e) {
            ToggleWindowVisibility();
        }

        private void homePageMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/ScriptFUSION/WAT");
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
