using ScriptFUSION.WarframeAlertTracker.Warframe;

namespace ScriptFUSION.WarframeAlertTracker.Alerts {
    internal class FissureAlert : Alert {
        public override AlertType Type { get; } = AlertType.Fissure;

        public override string Description
        {
            get
            {
                string description;
                var mission = Mission == MissionType.AnyEndless ? "endless" : Mission.ToString();

                if (Mission < MissionType.Capture) {
                    description = Tier == FissureTier.Any ? mission : $"{mission} {Tier}";
                }
                else {
                    description = $"{Tier} {mission}";
                }

                description = $"{description.ToLowerInvariant()} mission";

                return description[0].ToString().ToUpperInvariant() + description.Substring(1);
            }
        }

        public MissionType Mission { get; }

        public FissureTier Tier { get; }

        public FissureAlert(MissionType mission, FissureTier tier) {
            Mission = mission;
            Tier = tier;
        }
    }
}
