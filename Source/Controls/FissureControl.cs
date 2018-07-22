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
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureControl : UserControl {
        internal ImageRepository ImageRepository { get; set; }

        public FissureControl() {
            InitializeComponent();

            Anchor |= AnchorStyles.Right;
        }

        internal void Update(Fissure fissure, JObject solNodes) {
            tier.Text = fissure.Tier.ToString();
            type.Text = MissionName.FromType(fissure.Mission);
            location.Text = solNodes[fissure.Node]["value"].ToString().Replace(" (", ", ").Replace(")", string.Empty)
                + $"\n{solNodes[fissure.Node]["enemy"].ToString()}";
            endlessMarker.Visible = fissure.IsEndless;
            countdownClock.CountdownTo = fissure.Finish;

            UpdateImage(fissure.Tier);
        }

        private async void UpdateImage(FissureTier fissureTier) {
            relic.Image = await (Task<Bitmap>)
               typeof(ImageRepository).InvokeMember(
                   System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(fissureTier.ToString().ToLowerInvariant()),
                   System.Reflection.BindingFlags.GetProperty,
                   null,
                   ImageRepository,
                   null
                )
            ;
        }
    }
}
