using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        public WatApplication() {
            var watForm = new WatForm();
            watForm.FormClosed += delegate { ExitThread(); };
            watForm.Show();

            var downloader = new Downloader(() => new System.Net.WebClient());
            var worldStateDownloader = new WarframeWorldStateDownloader(downloader);
            var solNodesDownloader = new SolNodesDownloader(downloader);
            var solNodes = solNodesDownloader.Download();

            worldStateDownloader.Update += async worldState => watForm.Update(worldState.Fissures.ToList(), await solNodes);
            worldStateDownloader.DownloadIndefinitely();
        }
    }
}
