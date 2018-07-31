using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private WatForm WatForm { get; }

        private Downloader Downloader { get; } = new Downloader();

        public WatApplication() {
            WatForm = new WatForm(new WatForm.Dependencies() {
                CurrentWorldState = new CurrentWorldState(new WorldStateDownloader(Downloader)),
                SolNodesDownloader = new SolNodesDownloader(Downloader),
                ImageRepository = new ImageRepository(new ResourceDownloader(Downloader)),
            });
            WatForm.FormClosed += delegate { ExitThread(); };
            WatForm.Show();
        }
    }
}
