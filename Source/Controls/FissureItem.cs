using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.WorldState;
using ScriptFUSION.WarframeAlertTracker.Properties;
using Newtonsoft.Json.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureItem : UserControl {
        private static Dictionary<FissureTier, Bitmap> tierImageMap = new Dictionary<FissureTier, Bitmap>() {
            { FissureTier.LITH, Resources.Relic_bronze },
            { FissureTier.MESO, Resources.Relic_iron },
            { FissureTier.NEO, Resources.Relic_silver },
            { FissureTier.AXI, Resources.Relic_gold },
        };

        public FissureItem() {
            InitializeComponent();
        }

        internal void Update(Fissure fissure, JObject solNodes) {
            relic.Image = tierImageMap[fissure.Tier];
            tier.Text = fissure.Tier.ToString();
            type.Text = MissionName.FromType(fissure.Mission);
            location.Text = solNodes[fissure.Node]["value"].ToString().Replace(" (", ", ").Replace(")", string.Empty)
                + $"\n{solNodes[fissure.Node]["enemy"].ToString()}";
            endlessMarker.Visible = fissure.IsEndless;
            countdownClock.CountdownTo = fissure.Finish;
        }
    }
}
