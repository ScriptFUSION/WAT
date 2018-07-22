using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private WatForm WatForm { get; set; }

        private Downloader Downloader = new Downloader();

        public WatApplication() {
            WatForm = new WatForm(new ImageRepository(new ResourceDownloader(Downloader)));
            WatForm.FormClosed += delegate { ExitThread(); };
            WatForm.Show();

            var worldStateDownloader = new WorldStateDownloader(Downloader);
            var solNodesDownloader = new SolNodesDownloader(Downloader);
            var solNodes = solNodesDownloader.Download();

            worldStateDownloader.Update += async worldState => UpdateWorldState(worldState.Fissures, await solNodes);
            worldStateDownloader.DownloadIndefinitely();
        }

        private void UpdateWorldState(IEnumerable<Fissure> fissures, JObject solNodes) {
            WatForm.Update(fissures, solNodes);
        }
    }
}
