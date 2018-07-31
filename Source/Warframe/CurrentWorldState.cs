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

        public bool Running { get; private set; }

        private WorldStateDownloader Downloader { get; }

        public CurrentWorldState(WorldStateDownloader downloader) {
            Downloader = downloader;
        }

        public async void DownloadIndefinitely() {
            if (Running) throw new Exception("Already running.");

            Running = true;

            while (Running) {
                Download();

                await Task.Delay(RefreshRate * 1000);
            }
        }

        private async void Download() {
            var worldState = await Downloader.Download();

            if (CurrentState == null || worldState?.Time > CurrentState.Time) {
                CurrentState = worldState;
                Update?.Invoke(worldState);
            }
        }
    }
}
