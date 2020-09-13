using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    class TransparentListView : ListView
    {
        public TransparentListView()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

            this.DoubleBuffered = true;//设置本窗体
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲s

            this.HeaderStyle = ColumnHeaderStyle.None;
            this.FullRowSelect = true;
            this.BorderStyle = BorderStyle.None;
            this.View = View.Details;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnSelectedIndexChanged(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.StringFormat strFmt = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);

            if (this.SelectedItems != null && this.SelectedItems.Count != 0 && this.SelectedIndices[0] != 0)
            {
                Rectangle itemRect = this.GetItemRect(this.SelectedIndices[0]); //this.SelectedIndices[0]
                e.Graphics.FillRectangle(Brushes.LightBlue, itemRect);

            }

            Rectangle rectangle = new Rectangle();
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = 0; j < this.Columns.Count - 2; j++)
                {
                    rectangle =   this.Items[i].SubItems[j].Bounds;
                    rectangle.Offset(3, 3);
                    e.Graphics.DrawString(this.Items[i].SubItems[j].Text, this.Font,
                        new SolidBrush(this.ForeColor), rectangle, strFmt);
                }

            }

            if (Items.Count == 0) return;
            Pen pen = new Pen(Color.Brown, 1);
            Point start = new Point();
            Point end = new Point();
            for (int j = 0; j < this.Columns.Count - 3; j++)
            {
                start.X += this.Columns[j].Width;
                start.Y = 2;
                end.X = start.X;
                end.Y = this.Items[0].Bounds.Height - 6;
                e.Graphics.DrawLine(pen, start, end);
            }


            base.OnPaint(e);
        }
    }
}
