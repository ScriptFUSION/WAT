using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Forms {
    public partial class NotificationForm : Form {
        private const int ANIMATION_TICK_FREQUENCY = 2;

        private Control childControl;

        public Control ChildControl
        {
            get => childControl;
            private set
            {
                value.Anchor = AnchorStyles.Left;
                Controls.Add(childControl = value);
            }
        }

        // Do not steal focus when shown.
        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOPMOST = 8;

                var baseParams = base.CreateParams;
                // Force window to be top-most, without stealing focus as TopMost property does.
                baseParams.ExStyle |= WS_EX_TOPMOST;

                return baseParams;
            }
        }

        /// <summary>
        /// Gets or sets the animation time in seconds.
        /// </summary>
        private double AnimationTime { get; } = .45;

        private double HoldTime { get; } = 2.75;

        public NotificationForm(Control childControl) {
            InitializeComponent();

            ChildControl = childControl;
        }

        private enum SlideDirection {
            /// <summary>
            /// Slide into view.
            /// </summary>
            In,

            /// <summary>
            /// Slide out of view.
            /// </summary>
            Out
        }

        private async Task Animate() {
            var target = ChildControl;
            var screen = Screen.FromHandle(Owner.Handle).Bounds;

            void ShowWindow(double portion) {
                var width = (int)Math.Round(target.Width * portion);

                Size = new Size(
                    screen.Width - width,
                    target.Height
                );
                Location = new Point(
                    screen.Right - width,
                    screen.Height / 2 - target.Height / 2
                );
            }

            async Task Slide(SlideDirection direction) {
                var animationTime = TimeSpan.FromSeconds(AnimationTime);
                var finishTime = DateTime.Now.Add(animationTime);

                while (DateTime.Now < finishTime) {
                    var portion = (finishTime - DateTime.Now).TotalMilliseconds / animationTime.TotalMilliseconds;
                    if (direction == SlideDirection.In) portion = 1 - portion;
                    ShowWindow(portion);

                    await Task.Delay(ANIMATION_TICK_FREQUENCY);
                }
            }

            // Animate in.
            await Slide(SlideDirection.In);

            // Ensure window completely visible.
            ShowWindow(1);
            await Task.Delay((int)(HoldTime * 1000));

            // Animate out.
            await Slide(SlideDirection.Out);
        }

        private async void NotificationForm_Load(object sender, EventArgs e) {
            try {
                await Animate();
            }
            // Owning form has been disposed.
            catch (ObjectDisposedException) {
                // Abort animation.
            }

            Close();
        }

        private void NotificationForm_FormClosed(object sender, FormClosedEventArgs e) {
            Controls.Remove(ChildControl);
        }
    }
}
