using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    public partial class WatForm : Form {
        private WorldState.WorldState worldState;

        private WorldState.WorldState WorldState
        {
            get
            {
                return worldState;
            }
            set
            {
                worldState = value;

                UpdateComponents();
            }
        }

        private WarframeWorldStateDownloader WorldStateDownloader { get; set; }

        private SolNodesDownloader SolNodesDownloader { get; set; }

        private Task<JObject> SolNodes { get; set; }

        internal WatForm(WarframeWorldStateDownloader worldStateDownloader, SolNodesDownloader solNodesDownloader) {
            InitializeComponent();

            WorldStateDownloader = worldStateDownloader;
            SolNodesDownloader = solNodesDownloader;
        }

        private void WatForm_Load(object sender, EventArgs e) {
            WorldStateDownloader.Update += worldState => WorldState = worldState;
            WorldStateDownloader.DownloadIndefinitely();

            SolNodes = SolNodesDownloader.Download();
        }

        private async void UpdateComponents() {
            fissures.UpdateComponents(WorldState.Fissures.ToList(), await SolNodes);
        }
    }
}
