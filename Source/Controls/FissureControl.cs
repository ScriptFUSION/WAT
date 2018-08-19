using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;
using ScriptFUSION.WarframeAlertTracker.Alerts;

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

        public Color ActiveColour { get; } = Color.FromArgb(byte.MaxValue / 5, Color.CornflowerBlue);

        public FissureControl() {
            InitializeComponent();

            Anchor |= AnchorStyles.Right;

            relic.Paint += Relic_Paint;
        }

        internal static async Task<FissureControl> CreateTestControl(ImageRepository imageRepository) {
            return new FissureControl {
                relic = { Image = await imageRepository.Lith },
                countdownClock = { CountdownTo = DateTime.Now.AddHours(1.25) },
                ImageRepository = imageRepository,
                Active = true,
            };
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var rect = ClientRectangle;
            var penWidth = Active ? 2 : 1;
            rect.Offset(penWidth / 2, penWidth / 2);

            using (var pen = new Pen(SystemColors.ControlDark, penWidth)) {
                e.Graphics.DrawLines(pen, new[]
                {
                    new Point(rect.X, rect.Height - 1),
                    new Point(rect.Width - 1, rect.Height - 1),
                    new Point(rect.Width - 1, rect.Y),
                });
            }

            using (var pen = new Pen(SystemColors.ControlLightLight, penWidth)) {
                e.Graphics.DrawLines(pen, new[]
                {
                    new Point(rect.Width - 1, rect.Y),
                    rect.Location,
                    new Point(rect.X, rect.Height - 1),
                });
            }

            if (Active) {
                using (var brush = new SolidBrush(ActiveColour)) {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
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
