using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using ScriptFUSION.WarframeAlertTracker.Drawing;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureControl : UserControl {
        private bool active;

        internal ImageRepository ImageRepository { get; set; }

        [DefaultValue(false)]
        public bool Active
        {
            get => active;
            set
            {
                active = value;

                Invalidate();
            }
        }

        public Color ActiveColour { get; } = Rgb.Interpolate(SystemColors.Control, Color.CornflowerBlue, .25F);

        public FissureControl() {
            InitializeComponent();

            Anchor |= AnchorStyles.Right;

            relic.Paint += Relic_Paint;
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);

            if (Active) {
                using (var brush = new SolidBrush(ActiveColour)) {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var baseColour = Active ? ActiveColour : BackColor;
            var rect = ClientRectangle;

            if (Active) rect.Inflate(-1, -1);

            using (var pen = new Pen(ControlPaint.Dark(baseColour, .01F))) {
                e.Graphics.DrawLines(pen, new[]
                {
                    new Point(rect.X, rect.Height - 1),
                    new Point(rect.Width - 1, rect.Height - 1),
                    new Point(rect.Width - 1, rect.Y),
                });
            }

            using (var pen = new Pen(ControlPaint.LightLight(baseColour))) {
                e.Graphics.DrawLines(pen, new[]
                {
                    new Point(rect.Width - 1, rect.Y),
                    rect.Location,
                    new Point(rect.X, rect.Height - 1),
                });
            }
        }

        private void Relic_Paint(object sender, PaintEventArgs e) {
            if (relic.Image == null) {
                e.Graphics.FillPie(Brushes.SaddleBrown, relic.ClientRectangle, 0, 360);
            }
        }

        internal void Update(Fissure fissure, JObject solNodes) {
            relic.Caption = fissure.Tier.ToString().ToUpperInvariant();
            type.Text = MissionTypeFormatter.From(fissure.Mission);
            location.Text = solNodes[fissure.Node]["value"].ToString().Replace(" (", ", ").Replace(")", string.Empty)
                + $"\n{solNodes[fissure.Node]["enemy"]}";
            endlessMarker.Visible = fissure.IsEndless;
            countdownClock.CountdownTo = fissure.Finish;

            // Image should only need to be set once.
            if (relic.Image == null) {
                UpdateImage(fissure.Tier);
            }
        }

        internal void Update(Fissure fissure, AlertCollection alerts) {
            Active = alerts.Matches(fissure);
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
