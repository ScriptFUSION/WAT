﻿using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using ScriptFUSION.WarframeAlertTracker.Controls;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private FormWindowState lastWindowState;

        private WatApplication Application { get; }

        /// <summary>
        /// Gets or sets the last non-minimized window state.
        /// </summary>
        private FormWindowState LastWindowState
        {
            get => lastWindowState;
            set
            {
                Debug.Assert(value != FormWindowState.Minimized);

                lastWindowState = value;
            }
        }

        internal WatForm(WatApplication application) {
            InitializeComponent();

            Application = application;
            LastWindowState = WindowState;

            application.CurrentWorldState.Update +=
                async worldState => OnWorldStateUpdate(worldState.Fissures, await application.SolNodes);

            application.Settings.AlertsUpdate += OnAlertsUpdate;

            fissures.ImageRepository = application.ImageRepository;

            trayIcon.Icon = Icon;
        }

        public void ToggleWindowVisibility() {
            if (Visible = !Visible) {
                // Restore previous state.
                WindowState = LastWindowState;
            }
        }

        private void OnWorldStateUpdate(IReadOnlyCollection<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
            OnAlertsUpdate(Application.Settings.Alerts);
        }

        private void OnAlertsUpdate(AlertCollection alertsCollection) {
            fissures.Update(alertsCollection);

            alertsCount.Text = Application.CurrentWorldState.CurrentState.WorldStateObjects.Count(alertsCollection.Matches).ToString();
        }

        private void WatForm_Resize(object sender, EventArgs e) {
            ShowInTaskbar = WindowState != FormWindowState.Minimized;

            if (WindowState == FormWindowState.Minimized) {
                // Sync form visibility with minimized state.
                Visible = false;
            }
            else {
                // Record previous non-minimized state.
                LastWindowState = WindowState;
            }
        }

        private void alerts_Click(object sender, EventArgs e) {
            var alertCollection = Application.Settings.Alerts.Clone();

            using (var form = new AlertsForm(Application.CurrentWorldState, alertCollection)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    Application.Settings.Alerts = alertCollection;
                    Application.Settings.Save();
                }
            }
        }

        private async void options_Click(object sender, EventArgs e) {
            using (var form = new OptionsForm(Application.Settings, await FissureControl.CreateTestControl(Application.ImageRepository))) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    Application.Settings.Save();
                }
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
