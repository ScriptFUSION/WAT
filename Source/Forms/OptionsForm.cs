﻿using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Controls;
using ScriptFUSION.WarframeAlertTracker.Registry;
using ScriptFUSION.WarframeAlertTracker.Properties;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class OptionsForm : Form {
        private readonly ImageRepository imageRepository;

        private Settings Settings { get; }

        private RegistrySettings RegistrySettings { get; }

        internal OptionsForm(Settings settings, RegistrySettings registrySettings, FissureControl dummyFissureControl) {
            InitializeComponent();
            ReadSettings(Settings = settings, RegistrySettings = registrySettings);

            imageRepository = dummyFissureControl.ImageRepository;
            dummyFissureControl.Size = sample.Size;
            sample.Image = dummyFissureControl.Snapshot();
        }

        private void ReadSettings(Settings settings, RegistrySettings registrySettings) {
            loadSystem.Checked = registrySettings.LoadAtStartUp.Enabled;
            loadHidden.Checked = settings.LoadHidden;
        }

        private void WriteSettings() {
            RegistrySettings.LoadAtStartUp.Enabled = loadSystem.Checked;
            Settings.LoadHidden = loadHidden.Checked;
        }

        private async void sample_Click(object sender, System.EventArgs e) {
            new NotificationForm(await FissureControl.CreateTestControl(imageRepository)).Show(this);
        }

        private void ok_Click(object sender, System.EventArgs e) {
            WriteSettings();
        }
    }
}
