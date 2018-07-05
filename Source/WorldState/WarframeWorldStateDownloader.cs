using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.WorldState {
    internal sealed class WarframeWorldStateDownloader {
        private const string ALERTS_URL = "http://content.warframe.com/dynamic/worldState.php";

        public delegate void UpdateDelegate(WorldState worldState);

        public event UpdateDelegate Update;

        // Ticket system keeps track of responses that may arrive out of sequence.
        private uint currentTicket = 0;

        private uint lastTicket = 0;

        /// <summary>
        /// Gets or sets a value that specifies the rate at which the world state is refreshed, in seconds.
        /// </summary>
        public int RefreshRate { get; set; } = 10;

        private Downloader Downloader { get; } = new Downloader();

        public async void Loop() {
            while (true) {
                Download(currentTicket++);

                await Task.Delay(RefreshRate * 1000);
            }
        }

        private async void Download(uint ticket) {
            var data = await Downloader.Download(ALERTS_URL);

            // Ticket is obsolete; discard data.
            if (ticket < lastTicket) {
                return;
            }

            lastTicket = ticket;

            Update?.Invoke(Parse(data));
        }

        private WorldState Parse(string data) {
            var json = JObject.Parse(data);

            return new WorldState(json);
        }
    }
}
