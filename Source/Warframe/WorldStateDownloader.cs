using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class WorldStateDownloader {
        private const string ALERTS_URL = "http://content.warframe.com/dynamic/worldState.php";

        public Downloader Downloader { get; }

        public WorldStateDownloader(Downloader downloader) {
            Downloader = downloader;
        }

        public async Task<WorldState> Download() {
            string response;

            try {
                response = await Downloader.Download(ALERTS_URL);
            }
            catch (WebException) {
                // TODO: log. Seems to occur when request times out.

                // Abandon this request.
                return null;
            }

            return Parse(response);
        }

        private WorldState Parse(string data) {
            var json = JObject.Parse(data);

            return new WorldState(json);
        }
    }
}
