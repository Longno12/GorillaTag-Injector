








// Random Code I was Going To Add Never Did



















/*using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class RoundedButton : Button
    {
        private int _cornerRadius = 10;
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
                path.AddArc(new Rectangle(Width - CornerRadius - 1, 0, CornerRadius, CornerRadius), -90, 90);
                path.AddArc(new Rectangle(Width - CornerRadius - 1, Height - CornerRadius - 1, CornerRadius, CornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - CornerRadius - 1, CornerRadius, CornerRadius), 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);

                using (var pen = new Pen(this.BackColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 10;
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
                path.AddArc(new Rectangle(Width - CornerRadius - 1, 0, CornerRadius, CornerRadius), -90, 90);
                path.AddArc(new Rectangle(Width - CornerRadius - 1, Height - CornerRadius - 1, CornerRadius, CornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - CornerRadius - 1, CornerRadius, CornerRadius), 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
                using (var brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (var pen = new Pen(Color.FromArgb(98, 114, 164), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}*/