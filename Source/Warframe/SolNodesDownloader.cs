using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class SolNodesDownloader {
        private const string SOLNODES_URL = "https://raw.githubusercontent.com/WFCD/warframe-worldstate-data/master/data/solNodes.json";

        private Downloader Downloader { get; }

        public SolNodesDownloader(Downloader downloader) {
            Downloader = downloader;
        }

        public async Task<JObject> Download() {
            return JObject.Parse(await Downloader.Download(SOLNODES_URL));
        }
    }
}
