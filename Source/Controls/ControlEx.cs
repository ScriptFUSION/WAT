using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.WarframeAlertTracker.Controls {
    public abstract class ControlEx : Control {
        /// <summary>
        /// Gets the paint rectangle, which is exactly one pixel smaller than the client rectangle in both axes,
        /// because GDI cannot paint in the last row or column. This prevents unwanted clipping.
        /// </summary>
        protected Rectangle PaintRectangle
        {
            get
            {
                var rect = ClientRectangle;

                rect.Width -= 1;
                rect.Height -= 1;

                return rect;
            }
        }
    }
}
