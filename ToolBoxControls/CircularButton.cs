using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ToolBoxControls
{
    public class CircularButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(graphicsPath);
            base.OnPaint(pevent);
        }
    }
}
