﻿using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Controls;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class NotificationOptionsForm : Form {
        private readonly ImageRepository imageRepository;

        public NotificationOptionsForm(FissureControl dummyFissureControl) {
            InitializeComponent();

            imageRepository = dummyFissureControl.ImageRepository;

            dummyFissureControl.Size = sample.Size;
            sample.Image = dummyFissureControl.Snapshot();
        }

        private async void sample_Click(object sender, System.EventArgs e) {
            new NotificationForm(await FissureControl.CreateTestControl(imageRepository)).Show(this);
        }
    }
}