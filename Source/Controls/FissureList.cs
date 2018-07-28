﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;
using Newtonsoft.Json.Linq;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public partial class FissureList : UserControl {
        private ImageRepository imageRepository;

        /// <summary>
        /// Maintains a mapping between an id and a FissureControl.
        /// </summary>
        private Dictionary<string, FissureControl> idMap = new Dictionary<string, FissureControl>();

        internal ImageRepository ImageRepository
        {
            get { return imageRepository; }
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

        internal void Update(IEnumerable<Fissure> fissures, JObject solNodes) {
            var ids = new List<string>(fissures.Count());

            foreach (var fissure in fissures.OrderBy(f => f.Tier)) {
                var fissureControl = GetOrCreateFissureControl(fissure.Id);

                fissureControl.Update(fissure, solNodes);

                // Ensure control is added and in the correct position.
                if (table.GetRow(fissureControl) != ids.Count) {
                    // Adding a control already added just causes it to move.
                    table.Controls.Add(fissureControl, 0, ids.Count);
                }

                ids.Add(fissure.Id);
            }

            RemoveObsoleteFissureControls(ids);

            UpdateTotals(fissures);
        }

        private void UpdateTotals(IEnumerable<Fissure> fissures) {
            fissureCount.Text = fissures.Count().ToString();
            summary.Lith = fissures.Where(f => f.Tier == FissureTier.LITH).Count();
            summary.Meso = fissures.Where(f => f.Tier == FissureTier.MESO).Count();
            summary.Neo = fissures.Where(f => f.Tier == FissureTier.NEO).Count();
            summary.Axi = fissures.Where(f => f.Tier == FissureTier.AXI).Count();

            endlessCount.Text = fissures.Where(f => f.IsEndless).Count().ToString();
            endlessSummary.Lith = fissures.Where(f => f.IsEndless && f.Tier == FissureTier.LITH).Count();
            endlessSummary.Meso = fissures.Where(f => f.IsEndless && f.Tier == FissureTier.MESO).Count();
            endlessSummary.Neo = fissures.Where(f => f.IsEndless && f.Tier == FissureTier.NEO).Count();
            endlessSummary.Axi = fissures.Where(f => f.IsEndless && f.Tier == FissureTier.AXI).Count();
        }

        private FissureControl GetOrCreateFissureControl(string id) {
            if (idMap.ContainsKey(id)) {
                return idMap[id];
            }

            var fissureControl = new FissureControl();
            fissureControl.ImageRepository = ImageRepository;
            idMap.Add(id, fissureControl);

            return fissureControl;
        }

        /// <summary>
        /// Removes all fissure controls from the UI and the ID mapping whose ID is not present in the specified list
        /// of valid IDs.
        /// </summary>
        /// <param name="validIds">List of valid IDs.</param>
        private void RemoveObsoleteFissureControls(List<string> validIds) {
            // ToArray creates a copy that is necessary to avoid modifying the list during enumeration.
            foreach (var id in idMap.Keys.ToArray()) {
                if (!validIds.Contains(id)) {
                    table.Controls.Remove(idMap[id]);
                    idMap.Remove(id);
                }
            }
        }
    }
}
