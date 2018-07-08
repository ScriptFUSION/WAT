using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker {
    public partial class WatForm : Form {
        internal WatForm() {
            InitializeComponent();
        }

        internal void Update(List<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }
    }
}
