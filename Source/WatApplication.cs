﻿using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Properties;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        public CurrentWorldState CurrentWorldState { get; } = new CurrentWorldState(new WorldStateDownloader(Downloader));

        public AlertCollection AlertCollection
        {
            get => Settings.Default.Alerts;
            set
            {
                Settings.Default.Alerts = value;

                SaveSettings();
            }
        }

        public SolNodesDownloader SolNodesDownloader { get; } = new SolNodesDownloader(Downloader);

        public ImageRepository ImageRepository { get; } = new ImageRepository(new ResourceDownloader(Downloader));

        private static Downloader Downloader { get; } = new Downloader();

        public WatApplication() {
            var watForm = new WatForm(this);
            watForm.FormClosed += delegate { ExitThread(); };
            watForm.Show();

            CurrentWorldState.DownloadIndefinitely();
        }

        private static void SaveSettings() {
            Settings.Default.Save();
        }
    }
}
