using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Alerts;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureList : UserControl {
        private ImageRepository imageRepository;

        /// <summary>
        /// Maintains a mapping between an id and a FissureControl.
        /// </summary>
        private readonly Dictionary<string, FissureControl> idMap = new Dictionary<string, FissureControl>();

        private readonly Dictionary<FissureControl, Fissure> fissureMap = new Dictionary<FissureControl, Fissure>();

        internal ImageRepository ImageRepository
        {
            get => imageRepository;
            set
            {
                imageRepository = value;

                summary.ImageRepository = value;
                endlessSummary.ImageRepository = value;
            }
        }

        public FissureList() {
            InitializeComponent();

            // Remove dummy controls at run-time (used for illustrative purposes at design-time).
            if (!this.IsDesignTime()) {
                table.Controls.Clear();
            }
        }

        internal void Update(IReadOnlyCollection<Fissure> fissures, JObject solNodes) {
            var ids = new List<string>(fissures.Count);

            foreach (var fissure in fissures.OrderBy(f => f.Tier)) {
                var fissureControl = GetOrCreateFissureControl(fissure.Id);

                fissureControl.Update(fissure, solNodes);

                // Ensure control is added and in the correct position.
                if (table.GetRow(fissureControl) != ids.Count) {
                    // Adding a control already added just causes it to move.
                    table.Controls.Add(fissureControl, 0, ids.Count);

                    fissureMap[fissureControl] = fissure;
                }

                ids.Add(fissure.Id);
            }

            RemoveObsoleteFissureControls(ids);

            UpdateTotals(fissures);
        }

        internal void Update(AlertCollection alerts) {
            foreach (FissureControl fissureControl in table.Controls) {
                fissureControl.Update(fissureMap[fissureControl], alerts);
            }
        }

        private void UpdateTotals(IReadOnlyCollection<Fissure> fissures) {
            UpdateFissureTotals(fissures);
            UpdateEndlessFissureTotals(fissures);
        }

        private void UpdateFissureTotals(IReadOnlyCollection<Fissure> fissures) {
            fissureCount.Text = fissures.Count.ToString();
            summary.Lith = fissures.Count(f => f.Tier == FissureTier.Lith);
            summary.Meso = fissures.Count(f => f.Tier == FissureTier.Meso);
            summary.Neo = fissures.Count(f => f.Tier == FissureTier.Neo);
            summary.Axi = fissures.Count(f => f.Tier == FissureTier.Axi);
        }

        private void UpdateEndlessFissureTotals(IReadOnlyCollection<Fissure> fissures) {
            endlessCount.Text = fissures.Count(f => f.IsEndless).ToString();
            endlessSummary.Lith = fissures.Count(f => f.IsEndless && f.Tier == FissureTier.Lith);
            endlessSummary.Meso = fissures.Count(f => f.IsEndless && f.Tier == FissureTier.Meso);
            endlessSummary.Neo = fissures.Count(f => f.IsEndless && f.Tier == FissureTier.Neo);
            endlessSummary.Axi = fissures.Count(f => f.IsEndless && f.Tier == FissureTier.Axi);
        }

        private FissureControl GetOrCreateFissureControl(string id) {
            if (idMap.ContainsKey(id)) {
                return idMap[id];
            }

            var fissureControl = new FissureControl {
                ImageRepository = ImageRepository,
                Margin = Padding.Empty,
            };
            idMap.Add(id, fissureControl);

            return fissureControl;
        }

        /// <summary>
        /// Removes all fissure controls from the UI and the ID mapping whose ID is not present in the specified list
        /// of valid IDs.
        /// </summary>
        /// <param name="validIds">List of valid IDs.</param>
        private void RemoveObsoleteFissureControls(IReadOnlyCollection<string> validIds) {
            // ToArray creates a copy that is necessary to avoid modifying the list during enumeration.
            foreach (var id in idMap.Keys.ToArray()) {
                if (validIds.Contains(id)) continue;

                table.Controls.Remove(idMap[id]);
                fissureMap.Remove(idMap[id]);
                idMap.Remove(id);
            }
        }

        private void borderPanel_Paint(object sender, PaintEventArgs e) {
            var rect = borderPanel.ClientRectangle;

            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.ControlDark, ButtonBorderStyle.Solid);

            rect.Inflate(-1, -1);
            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.ControlLightLight, ButtonBorderStyle.Solid);
        }
    }
}
