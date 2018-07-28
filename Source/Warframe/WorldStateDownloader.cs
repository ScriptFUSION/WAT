using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class WorldStateDownloader {
        private const string ALERTS_URL = "http://content.warframe.com/dynamic/worldState.php";

        public delegate void UpdateDelegate(WorldState worldState);

        public event UpdateDelegate Update;

        // Ticket system keeps track of responses that may arrive out of sequence.
        private uint currentTicket;

        private uint lastTicket;

        /// <summary>
        /// Gets or sets a value that specifies the rate at which the world state is refreshed, in seconds.
        /// </summary>
        public int RefreshRate { get; set; } = 10;

        private Downloader Downloader { get; }

        public WorldStateDownloader(Downloader downloader) {
            Downloader = downloader;
        }

        public async void DownloadIndefinitely() {
            while (true) {
                Download(currentTicket++);

                await Task.Delay(RefreshRate * 1000);
            }
        }

        private async void Download(uint ticket) {
            string response;

            try {
                response = await Downloader.Download(ALERTS_URL);
            }
            catch (WebException) {
                // TODO: log. Seems to occur when request times out.

                // Abandon this request.
                return;
            }

            // Ticket is obsolete; discard data.
            if (ticket < lastTicket) {
                return;
            }

            lastTicket = ticket;

            Update?.Invoke(Parse(response));
        }

        private WorldState Parse(string data) {
            var json = JObject.Parse(data);

            return new WorldState(json);
        }
    }
}
