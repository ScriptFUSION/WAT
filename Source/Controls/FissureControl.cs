using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureControl : UserControl {
        internal ImageRepository ImageRepository { get; set; }

        public FissureControl() {
            InitializeComponent();

            Anchor |= AnchorStyles.Right;

            relic.Paint += Relic_Paint;
        }

        private void Relic_Paint(object sender, PaintEventArgs e) {
            if (relic.Image == null) {
                e.Graphics.FillPie(Brushes.SaddleBrown, relic.ClientRectangle, 0, 360);
            }
        }

        internal void Update(Fissure fissure, JObject solNodes) {
            tier.Text = fissure.Tier.ToString();
            type.Text = MissionName.FromType(fissure.Mission);
            location.Text = solNodes[fissure.Node]["value"].ToString().Replace(" (", ", ").Replace(")", string.Empty)
                + $"\n{solNodes[fissure.Node]["enemy"].ToString()}";
            endlessMarker.Visible = fissure.IsEndless;
            countdownClock.CountdownTo = fissure.Finish;

            // Image should only need to be set once.
            if (relic.Image == null) {
                UpdateImage(fissure.Tier);
            }
        }

        private async void UpdateImage(FissureTier fissureTier) {
            relic.Image = await (Task<Bitmap>)
                typeof(ImageRepository).GetProperty(
                    System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(
                        fissureTier.ToString().ToLowerInvariant()
                    )
                ).GetValue(ImageRepository)
            ;
        }
    }
}
