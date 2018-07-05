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
        internal WatForm(WarframeWorldStateDownloader worldState) {
            InitializeComponent();

            worldState.Update += OnWorldStateUpdate;
            worldState.Loop();
        }

        private void OnWorldStateUpdate(WorldState.WorldState worldState) {
            // TODO.
        }
    }
}
