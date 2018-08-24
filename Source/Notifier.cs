using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptFUSION.WarframeAlertTracker.Controls;
using ScriptFUSION.WarframeAlertTracker.Forms;
using ScriptFUSION.WarframeAlertTracker.Warframe;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class Notifier {
        private readonly Queue<Control> queue = new Queue<Control>();

        private WatApplication Application { get; }

        private NotificationForm Notification { get; set; }

        public Notifier(WatApplication application) {
            Application = application;
            application.CurrentWorldState.NewObject += OnNewWorldStateObject;
        }

        private void Notify(Control control) {
            if (Notification != null) {
                Queue(control);
                return;
            }

            Notification = new NotificationForm(control, Application.Settings.NotificationHoldTime);
            Notification.Closed += delegate {
                Notification = null;
                Next();
            };

            Notification.Show(Application.MainForm);
        }

        private void Queue(Control control) {
            queue.Enqueue(control);
        }

        private void Next() {
            if (queue.Count > 0) {
                Notify(queue.Dequeue());
            }
        }

        private async void OnNewWorldStateObject(IWorldStateObject worldStateObject) {
            if (!Application.Settings.Alerts.Matches(worldStateObject)) {
                return;
            }

            Notify(await CreateControl(worldStateObject));
        }

        private async Task<Control> CreateControl(IWorldStateObject worldStateObject) {
            switch (worldStateObject) {
                case Fissure fissure:
                    var fissureControl = new FissureControl {
                        ImageRepository = Application.ImageRepository,
                        Active = true,
                    };
                    fissureControl.Update(fissure, await Application.SolNodes);

                    return fissureControl;
            }

            throw new ApplicationException("Unrecognized world state object type.");
        }
    }
}
