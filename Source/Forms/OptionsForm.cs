using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Controls;
using ScriptFUSION.WarframeAlertTracker.Properties;
using ScriptFUSION.WarframeAlertTracker.Resource;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class OptionsForm : Form {
        private readonly ImageRepository imageRepository;

        private Settings Settings { get; }

        internal OptionsForm(Settings settings, FissureControl dummyFissureControl) {
            InitializeComponent();
            ReadSettings(Settings = settings);

            imageRepository = dummyFissureControl.ImageRepository;
            dummyFissureControl.Size = sample.Size;
            sample.Image = dummyFissureControl.Snapshot();
        }

        private void ReadSettings(Settings settings) {
            loadHidden.Checked = settings.LoadHidden;
        }

        private void WriteSettings() {
            Settings.LoadHidden = loadHidden.Checked;
        }

        private async void sample_Click(object sender, System.EventArgs e) {
            new NotificationForm(await FissureControl.CreateTestControl(imageRepository)).Show(this);
        }

        private void ok_Click(object sender, System.EventArgs e) {
            WriteSettings();
        }
    }
}
