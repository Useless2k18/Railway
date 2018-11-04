using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolBoxControls
{
    public sealed class ButtonZ : Button
    {
        private Color _clr1;
        private Color _color = Color.Teal;
        private Color _mHovercolor = Color.FromArgb(0, 0, 140);
        private Color _clickcolor = Color.FromArgb(160, 180, 200);
        private int _textX = 6;
        private int _textY = -20;
        private string _text;

        public string DisplayText
        {
            get => _text;
            set { _text = value; Invalidate(); }
        }
        public Color BzBackColor
        {
            get => _color;
            set { _color = value; Invalidate(); }
        }

        public Color MouseHoverColor
        {
            get => _mHovercolor;
            set { _mHovercolor = value; Invalidate(); }
        }

        public Color MouseClickColor1
        {
            get => _clickcolor;
            set { _clickcolor = value; Invalidate(); }
        }


        public int TextLocationX
        {
            get => _textX;
            set { _textX = value; Invalidate(); }
        }
        public int TextLocationY
        {
            get => _textY;
            set { _textY = value; Invalidate(); }
        }
        public ButtonZ()
        {
            Size = new Size(31, 24);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Text = "_";
            _text = Text;
        }

        //method mouse enter  
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _clr1 = _color;
            _color = _mHovercolor;
        }

        //method mouse leave  
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _color = _clr1;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _color = _clickcolor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _color = _clr1;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            _text = Text;
            if (_textX == 100 && _textY == 25)
            {
                _textX = Width / 3 + 10;
                _textY = Height / 2 - 1;
            }

            var p = new Point(_textX, _textY);
            pe.Graphics.FillRectangle(new SolidBrush(_color), ClientRectangle);
            pe.Graphics.DrawString(_text, Font, new SolidBrush(ForeColor), p);
        }

    }
}