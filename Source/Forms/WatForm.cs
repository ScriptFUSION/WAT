using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
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
        internal WatForm(ImageRepository images) {
            InitializeComponent();

            fissures.ImageRepository = images;
        }

        internal void Update(IEnumerable<Fissure> fissureList, JObject solNodes) {
            fissures.Update(fissureList, solNodes);
        }
    }
}
