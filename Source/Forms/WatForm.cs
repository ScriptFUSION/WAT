using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class WatForm : Form {
        private CurrentWorldState CurrentWorldState { get; }

        internal WatForm(Dependencies dependencies) {
            InitializeComponent();

            CurrentWorldState = dependencies.CurrentWorldState;

            var solNodes = dependencies.SolNodesDownloader.Download();
            CurrentWorldState.Update += async worldState => Update(worldState.Fissures, await solNodes);

            fissures.ImageRepository = dependencies.ImageRepository;
        }

        internal struct Dependencies {
            public CurrentWorldState CurrentWorldState;
            public SolNodesDownloader SolNodesDownloader;
            public ImageRepository ImageRepository;
        }

        internal void Update(IEnumerable<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }

        private void alerts_Click(object sender, EventArgs e) {
            using (var form = new AlertsForm()) {
                form.ShowDialog(this);
            }
        }
    }
}
