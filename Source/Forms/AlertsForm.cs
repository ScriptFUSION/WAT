﻿using System;
using System.Windows.Forms;
using System.Linq;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using ScriptFUSION.WarframeAlertTracker.Warframe;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class AlertsForm : Form {
        private CurrentWorldState CurrentWorldState { get; }

        private AlertCollection Alerts { get; }

        internal AlertsForm(CurrentWorldState currentWorldState, AlertCollection alertAlerts) {
            CurrentWorldState = currentWorldState;
            Alerts = alertAlerts;

            InitializeComponent();
            PopulateData();

            currentWorldState.Update += OnWorldStateUpdate;
        }

        private void PopulateData() {
            PopulateFissureData();
            PopulateAlerts();
        }

        private void PopulateFissureData() {
            foreach (var missionType in EnumExtension.GetMembers<MissionType>()) {
                if (missionType == MissionType.Unknown) continue;
                fissureMissionType.Items.Add(new ComboItem(missionType, MissionTypeFormatter.From));
            }

            foreach (var tier in EnumExtension.GetMembers<FissureTier>()) {
                if (tier == FissureTier.Unknown) continue;
                fissureTier.Items.Add(new ComboItem(tier, FissureTierFormatter.From));
            }

            fissureMissionType.SelectedIndex = fissureTier.SelectedIndex = 0;
        }

        private void PopulateAlerts() {
            alerts.Items.Clear();

            foreach (var alert in Alerts.OrderBy(alert => alert.MatchingRule)) {
                alerts.Items.Add(new ListViewItem(alert.Type.ToString(), (int)alert.MatchingRule) {
                    Tag = alert,
                    Checked = alert.Enabled,
                    SubItems = { alert.Description, string.Empty }
                });
            }

            if (CurrentWorldState.CurrentState != null) {
                OnWorldStateUpdate(CurrentWorldState.CurrentState);
            }

            alerts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private static Alert ToAlert(ListViewItem item) {
            return (Alert)item.Tag;
        }

        private void AlertsForm_FormClosing(object sender, FormClosingEventArgs e) {
            CurrentWorldState.Update -= OnWorldStateUpdate;
        }

        private void OnWorldStateUpdate(WorldState worldState) {
            foreach (ListViewItem item in alerts.Items) {
                item.SubItems[2].Text = worldState.WorldStateObjects.Any(o => o.Matches(ToAlert(item))) ? "Yes" : "No";
            }
        }

        private void CreateFissureAlert(MatchingRule matchingRule) {
            Alerts.Add(new FissureAlert(
                (MissionType)((ComboItem)fissureMissionType.SelectedItem).Member,
                (FissureTier)((ComboItem)fissureTier.SelectedItem).Member
            ) {
                MatchingRule = matchingRule
            });

            PopulateAlerts();
        }

        private void ok_Click(object sender, EventArgs e) {
            Close();
        }

        private void fissureInclude_Click(object sender, EventArgs e) {
            CreateFissureAlert(MatchingRule.Include);
        }

        private void fissureExclude_Click(object sender, EventArgs e) {
            CreateFissureAlert(MatchingRule.Exclude);
        }

        private void removeAlert_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in alerts.SelectedItems) {
                Alerts.Remove(ToAlert(item));
            }

            PopulateAlerts();
        }

        private void alerts_ItemChecked(object sender, ItemCheckedEventArgs e) {
            ToAlert(e.Item).Enabled = e.Item.Checked;
        }

        private class ComboItem {
            public delegate string EnumNameFormatter(Enum member);

            private readonly EnumNameFormatter formatter;

            public Enum Member { get; }

            public ComboItem(Enum member, EnumNameFormatter formatter) {
                this.formatter = formatter;
                Member = member;
            }

            public override string ToString() {
                return formatter.Invoke(Member);
            }
        }
    }
}
