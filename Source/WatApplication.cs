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

            var downloader = new Downloader();
            var worldStateDownloader = new WorldStateDownloader(downloader);
            var solNodesDownloader = new SolNodesDownloader(downloader);
            var solNodes = solNodesDownloader.Download();

            worldStateDownloader.Update += async worldState => watForm.Update(worldState.Fissures, await solNodes);
            worldStateDownloader.DownloadIndefinitely();
        }
    }
}
