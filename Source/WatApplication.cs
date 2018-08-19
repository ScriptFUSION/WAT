using System;
using System.Threading.Tasks;
using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Properties;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        public event Action<AlertCollection> AlertsUpdate;

        public CurrentWorldState CurrentWorldState { get; } = new CurrentWorldState(new WorldStateDownloader(Downloader));

        public AlertCollection AlertCollection
        {
            get => Settings.Default.Alerts ?? new AlertCollection();
            set
            {
                Settings.Default.Alerts = value;

                SaveSettings();

                AlertsUpdate?.Invoke(value);
            }
        }

        public ImageRepository ImageRepository { get; } = new ImageRepository(new ResourceDownloader(Downloader));

        public Task<JObject> SolNodes { get; }

        private static Downloader Downloader { get; } = new Downloader();

        private SolNodesDownloader SolNodesDownloader { get; } = new SolNodesDownloader(Downloader);

        public WatApplication() {
            MainForm = new WatForm(this);

            new Notifier(this);
            CurrentWorldState.DownloadIndefinitely();
            SolNodes = SolNodesDownloader.Download();
        }

        private static void SaveSettings() {
            Settings.Default.Save();
        }
    }
}
