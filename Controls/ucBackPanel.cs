using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Controls
{
    public partial class ucBackPanel : UserControl
    {
        private Point frmPos;
        private Point mousePos;
        private Boolean isBeginMove = false;

        private bool IsMiniWin = false;


        public bool IsShowMinBtn { get => lbMinWin.Visible; set => lbMinWin.Visible = value; }
        public bool IsShowMenuBtn { get => lbMenu.Visible; set => lbMenu.Visible = value; }

        public ucBackPanel()
        {
            InitializeComponent();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            lbClose.BackColor = System.Drawing.Color.Red;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            lbClose.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            lbMinWin.BackColor = System.Drawing.Color.Red;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            lbMinWin.BackColor = System.Drawing.Color.Transparent;
        }

        public delegate void ucButton_Click();
        public event ucButton_Click OnBtnClose_Click;

        public delegate void BtnMenuClickEvent(Point pt);
        public event BtnMenuClickEvent OnBtnMenu_Click;

        public delegate void ucMiniButton_Click(bool IsMiniWin);
        public event ucMiniButton_Click OnBtnMin_Click;

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != OnBtnClose_Click)
            {
                OnBtnClose_Click();
            }
        }

        private void ucBackPanel_SizeChanged(object sender, EventArgs e)
        {
            //this.lbClose.Location = new Point(this.Width - this.lbClose.Width - 6, 6);

            //if(this.lbMinWin.Visible == true)
            //{
            //    this.lbMinWin.Location = new Point(this.Width - this.lbClose.Width - 6 - this.lbMinWin.Width, 6);
            //}


            //if(IsShowMenuBtn == true && IsShowMinBtn == false)
            //{
            //    this.lbMenu.Location = new Point(this.Width - this.lbClose.Width - 6 - this.lbMenu.Width, 6);
            //}
            //else
            //{
            //    this.lbMenu.Location = new Point(this.Width - this.lbClose.Width - 6 - this.lbMinWin.Width - 6 - this.lbMenu.Width, 6);
            //}

        }

        private void ucBackPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form form = this.Parent as Form;
                if (form != null)
                {
                    isBeginMove = true;
                    frmPos = form.Location;
                    mousePos = Control.MousePosition;
                }
            }
        }

        private void ucBackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isBeginMove)
            {
                Form form = this.Parent as Form;
                if (form != null)
                {
                    form.Location = frmPos + (Size)Control.MousePosition - (Size)mousePos;
                }
            }


        }

        public void SetMiniWinFlag(bool isMini)
        {
            IsMiniWin = isMini;
            if (IsMiniWin) lbMinWin.Text = "↗";
            else lbMinWin.Text = "↖";
        }

        private void lbMinWin_Click(object sender, EventArgs e)
        {
            if (null != OnBtnMin_Click)
            {
                SetMiniWinFlag(!IsMiniWin);

                OnBtnMin_Click(IsMiniWin);
            }
        }

        private void ucBackPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isBeginMove = false;
            }
        }

        private void ucBackPanel_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.Blue, 3);
            //e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);
            //e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);
            //e.Graphics.DrawLine(pen, this.Width, 0, this.Width, this.Height);
            //e.Graphics.DrawLine(pen, 0, this.Height, this.Width, this.Height);
        }

        private void ucBackPanel_Load(object sender, EventArgs e)
        {
            this.lbClose.Location = new Point(this.Width - this.lbClose.Width - 2, 2);

            if (IsShowMinBtn == true)
            {
                this.lbMinWin.Location = new Point(this.Width - this.lbClose.Width - 2 - this.lbMinWin.Width, 2);
            }


            if (IsShowMenuBtn == true && IsShowMinBtn == false)
            {
                this.lbMenu.Location = new Point(this.Width - this.lbClose.Width - 2 - this.lbMenu.Width, 2);
            }
            else
            {
                this.lbMenu.Location = new Point(this.Width - this.lbClose.Width - 2 - this.lbMinWin.Width - 2 - this.lbMenu.Width, 2);
            }
        }

        private void lbMenu_MouseEnter(object sender, EventArgs e)
        {
            lbMenu.BackColor = System.Drawing.Color.Red;
        }

        private void lbMenu_MouseLeave(object sender, EventArgs e)
        {
            lbMenu.BackColor = System.Drawing.Color.Transparent;
        }

        private void lbMenu_Click(object sender, EventArgs e)
        {
            if (null != OnBtnMenu_Click)
            {
                Point pt = new Point(lbMenu.Location.X + lbMenu.Width / 2, lbMenu.Location.Y + lbMenu.Height);
                OnBtnMenu_Click(pt);
            }
        }

    }
}
