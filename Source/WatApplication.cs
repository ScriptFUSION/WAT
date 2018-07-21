using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private WatForm WatForm { get; set; } = new WatForm();

        public WatApplication() {
            WatForm.FormClosed += delegate { ExitThread(); };
            WatForm.Show();

            var downloader = new Downloader();
            var worldStateDownloader = new WorldStateDownloader(downloader);
            var solNodesDownloader = new SolNodesDownloader(downloader);
            var solNodes = solNodesDownloader.Download();

            worldStateDownloader.Update += async worldState => UpdateWorldState(worldState.Fissures, await solNodes);
            worldStateDownloader.DownloadIndefinitely();
        }

        private void UpdateWorldState(IEnumerable<Fissure> fissures, JObject solNodes) {
            WatForm.Update(fissures, solNodes);
        }
    }
}
