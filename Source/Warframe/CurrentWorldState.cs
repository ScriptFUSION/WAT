using System;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    /// <summary>
    /// Maintains a reference to the current world state by continuously downloading updates.
    /// </summary>
    internal sealed class CurrentWorldState {
        public event Action<WorldState> Update;

        public WorldState CurrentState { get; private set; }

        /// <summary>
        /// Gets or sets a value that specifies the rate at which the world state is refreshed, in seconds.
        /// </summary>
        /// <remarks>It is observed that the server refreshes state once per minute.</remarks>
        public int RefreshRate { get; set; } = 15;

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
