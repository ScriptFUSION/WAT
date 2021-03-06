﻿using System.Linq;
using System.Threading.Tasks;
using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Registry;
using ScriptFUSION.WarframeAlertTracker.Properties;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class WatApplication : ApplicationContext {
        private WatForm mainForm;

        /// <remarks>
        /// Hides the base implementation so the base Form is always null. This is needed to stop
        /// Application.RunMessageLoopInner forcing the form to be visible, which is undesirable for our purposes since
        /// we provide an option to start the application hidden.
        /// </remarks>
        public new WatForm MainForm
        {
            get => mainForm;
            set
            {
                mainForm = value;

                value.HandleDestroyed += delegate { if (!value.RecreatingHandle) ExitThread(); };
            }
        }

        public CurrentWorldState CurrentWorldState { get; }

        public Settings Settings { get; } = Settings.Default;

        public RegistrySettings RegistrySettings { get; } = new RegistrySettings();

        public ImageRepository ImageRepository { get; } = new ImageRepository(new ResourceDownloader(Downloader));

        public Task<JObject> SolNodes { get; }

        private static Downloader Downloader { get; } = new Downloader();

        private SolNodesDownloader SolNodesDownloader { get; } = new SolNodesDownloader(Downloader);

        public static string CanonicalProductVersion { get; } =
            string.Join(".", Application.ProductVersion.Split('.').TakeWhile((_, i) => i < 3));

        public WatApplication() {
            CurrentWorldState = new CurrentWorldState(new WorldStateDownloader(Downloader), Settings);
            MainForm = new WatForm(this);
            new Notifier(this);

            CurrentWorldState.DownloadIndefinitely();
            SolNodes = SolNodesDownloader.Download();

            if (!Settings.LoadHidden) MainForm.Show();
        }
    }
}
