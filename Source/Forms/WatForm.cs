using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private CurrentWorldState CurrentWorldState { get; }

        internal WatForm(Dependencies dependencies) {
            InitializeComponent();

            var solNodes = dependencies.SolNodesDownloader.Download();
            CurrentWorldState = dependencies.CurrentWorldState;
            CurrentWorldState.Update += async worldState => Update(worldState.Fissures.ToList(), await solNodes);
            CurrentWorldState.DownloadIndefinitely();

            fissures.ImageRepository = dependencies.ImageRepository;
        }

        internal struct Dependencies {
            public CurrentWorldState CurrentWorldState;
            public SolNodesDownloader SolNodesDownloader;
            public ImageRepository ImageRepository;
        }

        internal void Update(List<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }

        private void alerts_Click(object sender, EventArgs e) {
            using (var form = new AlertsForm()) {
                form.ShowDialog(this);
            }
        }
    }
}
