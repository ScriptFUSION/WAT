using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private WatForm WatForm { get; }

        private Downloader Downloader { get; } = new Downloader();

        private CurrentWorldState CurrentWorldState { get; }

        public WatApplication() {
            WatForm = new WatForm(new ImageRepository(new ResourceDownloader(Downloader)));
            WatForm.FormClosed += delegate { ExitThread(); };
            WatForm.Show();

            var solNodes = new SolNodesDownloader(Downloader).Download();
            CurrentWorldState = new CurrentWorldState(new WorldStateDownloader(Downloader));
            CurrentWorldState.Update += async worldState => UpdateWorldState(worldState, await solNodes);
        }

        private void UpdateWorldState(WorldState worldState, JObject solNodes) {
            WatForm.Update(worldState.Fissures, solNodes);
        }
    }
}
