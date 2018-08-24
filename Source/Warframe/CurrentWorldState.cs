using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScriptFUSION.WarframeAlertTracker.Properties;

namespace ScriptFUSION.WarframeAlertTracker.Warframe {
    /// <summary>
    /// Maintains a reference to the current world state by continuously downloading updates.
    /// </summary>
    internal sealed class CurrentWorldState {
        public event Action<WorldState> Update;

        public event Action<IWorldStateObject> NewObject;

        public WorldState CurrentState { get; private set; }

        /// <summary>
        /// Gets or sets a value that specifies the rate at which the world state is refreshed, in seconds.
        /// </summary>
        /// <remarks>It is observed that the server refreshes state once per minute.</remarks>
        public int RefreshRate { get; private set; }

        public bool Running { get; private set; }

        public DateTime LastUpdate { get; private set; }

        private WorldStateDownloader Downloader { get; }

        public CurrentWorldState(WorldStateDownloader downloader, Settings settings) {
            Downloader = downloader;
            RefreshRate = settings.RefreshRate;

            settings.RefreshRateUpdate += i => RefreshRate = i;
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

            LastUpdate = DateTime.Now;

            if (CurrentState == null || worldState?.Time > CurrentState.Time) {
                UpdateWorldState(CurrentState, worldState);
            }
        }

        private void UpdateWorldState(WorldState oldState, WorldState newState) {
            CurrentState = newState;
            Update?.Invoke(newState);

            foreach (var worldStateObject in DetectNewObjects(oldState, newState)) {
                NewObject?.Invoke(worldStateObject);
            }
        }

        private static IEnumerable<IWorldStateObject> DetectNewObjects(WorldState oldState, WorldState newState) {
            return oldState == null ? Enumerable.Empty<IWorldStateObject>() :
                newState.WorldStateObjects.Except(oldState.WorldStateObjects, new WorldStateObjectComparer());
        }
    }
}
