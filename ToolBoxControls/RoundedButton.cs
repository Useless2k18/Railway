using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ToolBoxControls
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
        }

        private static GraphicsPath GetRoundGraphicsPath(RectangleF rectangleF, int radius)
        {
            var radius2 = radius / 2f;
            var graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(rectangleF.X, rectangleF.Y, radius, radius, 180, 90);
            graphicsPath.AddLine(rectangleF.X + radius, rectangleF.Y, rectangleF.Width - radius2, rectangleF.Y);
            graphicsPath.AddArc(rectangleF.X + rectangleF.Width - radius, rectangleF.Y, radius, radius, 270, 90);
            graphicsPath.AddLine(rectangleF.Width, rectangleF.Y + radius2, rectangleF.Width, rectangleF.Height - radius2);
            graphicsPath.AddArc(rectangleF.X + rectangleF.Width - radius, rectangleF.Y + rectangleF.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddLine(rectangleF.Width - radius2, rectangleF.Height, rectangleF.X + radius2, rectangleF.Height);
            graphicsPath.AddArc(rectangleF.X, rectangleF.Y + rectangleF.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddLine(rectangleF.X, rectangleF.Height - radius2, rectangleF.X, rectangleF.Y + radius2);

            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {

            var rectangleF = new RectangleF(0, 0, Width, Height);
            var graphicsPath = GetRoundGraphicsPath(rectangleF, 15);

            Region = new Region(graphicsPath);
            using (var pen = new Pen(Color.CadetBlue, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawPath(pen, graphicsPath);
            }

            base.OnPaint(pevent);

        }
    }
}