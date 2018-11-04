using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolBoxControls
{
    public sealed class MinMaxButton : Button
    {
        private Color _clr1;
        private Color _color = Color.Gray;
        private Color _mHovercolor = Color.FromArgb(180, 200, 240);
        private Color _clickcolor = Color.FromArgb(160, 180, 200);
        private int _textX = 6;
        private int _textY = -20;
        private string _text = "_";

        public enum CustomFormState
        {
            Normal,
            Maximize
        }

        private CustomFormState _customFormState;

        public CustomFormState CFormState
        {
            get => _customFormState;
            set { _customFormState = value; Invalidate(); }
        }


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

        public MinMaxButton()
        {
            Size = new Size(31, 24);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
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

            switch (_customFormState)
            {
                case CustomFormState.Normal:
                    pe.Graphics.FillRectangle(new SolidBrush(_color), ClientRectangle);

                    //draw and fill thw rectangles of maximized window       
                    for (var i = 0; i < 2; i++)
                    {
                        pe.Graphics.DrawRectangle(new Pen(ForeColor), _textX + i + 1, _textY, 10, 10);
                        pe.Graphics.FillRectangle(new SolidBrush(ForeColor), _textX + 1, _textY - 1, 12, 4);
                    }
                    break;

                case CustomFormState.Maximize:
                    pe.Graphics.FillRectangle(new SolidBrush(_color), ClientRectangle);

                    //draw and fill thw rectangles of maximized window       
                    for (var i = 0; i < 2; i++)
                    {
                        pe.Graphics.DrawRectangle(new Pen(ForeColor), _textX + 5, _textY, 8, 8);
                        pe.Graphics.FillRectangle(new SolidBrush(ForeColor), _textX + 5, _textY - 1, 9, 4);

                        pe.Graphics.DrawRectangle(new Pen(ForeColor), _textX + 2, _textY + 5, 8, 8);
                        pe.Graphics.FillRectangle(new SolidBrush(ForeColor), _textX + 2, _textY + 4, 9, 4);

                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}