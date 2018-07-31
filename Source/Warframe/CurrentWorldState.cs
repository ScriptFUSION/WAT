using System;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    internal sealed class CurrentWorldState {
        public delegate void UpdateDelegate(WorldState worldState);

        public event UpdateDelegate Update;

        public WorldState CurrentState { get; private set; }

        /// <summary>
        /// Gets or sets a value that specifies the rate at which the world state is refreshed, in seconds.
        /// </summary>
        /// <remarks>It is observed that the server refreshes state once per minute.</remarks>
        public int RefreshRate { get; set; } = 10;

        private WorldStateDownloader Downloader { get; }

        public CurrentWorldState(WorldStateDownloader downloader) {
            Downloader = downloader;

            DownloadIndefinitely();
        }

        private async void DownloadIndefinitely() {
            while (true) {
                Download();

                await Task.Delay(RefreshRate * 1000);
            }
        }

        private async void Download() {
            var worldState = await Downloader.Download();

            if (CurrentState == null || worldState?.Time > CurrentState.Time) {
                Update?.Invoke(CurrentState = worldState);
            }
        }
    }
}
