using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class TransparentListBox : ListBox
    {
        public enum AllignMode
        {
            LEFT = 0,
            CENTER,
            RIGHT,
        }

        public enum DisplayMode
        {
            NORMAL = 0,
            LYRIC = 1,
            SEARCH = 2,
        }

        private AllignMode contAllign;
        private DisplayMode curdisplay;

        public AllignMode TextAllign { get => contAllign; set => contAllign = value; }
        public DisplayMode CurDisplay { get => curdisplay; set => curdisplay = value; }

        public TransparentListBox()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.StringFormat strFmt = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);

            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (this.SelectedItem != null)
            {
                Rectangle itemRect = this.GetItemRectangle(this.SelectedIndex);
                itemRect.Offset(3, 3);
                itemRect.Width -= 10;
                e.Graphics.FillRectangle(Brushes.LightBlue, itemRect);
            }
            for (int i = 0; i < Items.Count; i++)
            {
                if (AllignMode.CENTER == contAllign)
                {
                    strFmt.Alignment = System.Drawing.StringAlignment.Center;

                }
                else if (AllignMode.LEFT == contAllign)
                {
                    strFmt.Alignment = System.Drawing.StringAlignment.Near;
                }
                else
                {
                    strFmt.Alignment = System.Drawing.StringAlignment.Far;
                }

                if(curdisplay == DisplayMode.SEARCH)
                {
                    strFmt.Alignment = System.Drawing.StringAlignment.Near;

                    e.Graphics.DrawString(this.GetItemText(this.Items[i]), this.Font,
                            new SolidBrush(this.ForeColor), this.GetItemRectangle(i), strFmt);
                }
                else if(curdisplay == DisplayMode.LYRIC)
                {
                    if (i == Items.Count / 2)
                    {
                        e.Graphics.DrawString(this.GetItemText(this.Items[i]), new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold | FontStyle.Italic),
                            new SolidBrush(Color.DarkRed), this.GetItemRectangle(i), strFmt);
                    }
                    else
                    {
                        e.Graphics.DrawString(this.GetItemText(this.Items[i]), new Font(this.Font.FontFamily, this.Font.Size * (float)(1.0 - 0.05 * (Math.Abs(i - Items.Count / 2))), FontStyle.Italic),
                            new SolidBrush(this.ForeColor), this.GetItemRectangle(i), strFmt);
                    }
                }
                else
                {
                    e.Graphics.DrawString(this.GetItemText(this.Items[i]), this.Font,
                            new SolidBrush(this.ForeColor), this.GetItemRectangle(i), strFmt);
                }
            }
            base.OnPaint(e);
        }

    }

    public class ListItem
    {
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private object _Value;
        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public ListItem(string text, object value)
        {
            _Text = text;
            _Value = value;
        }
    }
}
