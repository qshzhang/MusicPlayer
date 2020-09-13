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
    public partial class ucProgressBar : UserControl
    {
        private bool isCanOperate = true;
        public Color PanelBackBarColor { get => this.panelBack.BackColor; set => this.panelBack.BackColor = value; }
        public Color PanelFloatBarColor { get => this.panelFloat.BackColor; set => this.panelFloat.BackColor = value; }
        public bool IsCanOperate { get => isCanOperate; set => isCanOperate = value; }


        public delegate void ClickEvent(int rate);
        public ClickEvent OnClickEvent;
        public ClickEvent OnMouseMoveEvent;
        public ucProgressBar()
        {
            InitializeComponent();

            if (this.Height < 3)
            {
                this.Height = 3;
            }
            this.panelFloat.Height = this.Height;
        }

        public ucProgressBar(int width, int height)
        {
            InitializeComponent();
            
            if(height < 3)
            {
                height = 3;
            }
            this.Width = width;
            this.Height = height;
        }

        public int GetProgressValue()
        {
            return (int)((panelFloat.Width * 1.0 / panelBack.Width) * 100);
        }

        public int GetProgressBarWidth()
        {
            return this.panelFloat.Width;
        }

        public void SetProgress(int rate)
        {
            if (rate > 100) rate = 100;
            panelFloat.Width = (int)(this.Width * 1.0 * rate / 100);
        }

        public void SetProgressByWidth(int width)
        {
            if (width > this.Width) width = this.Width;
            this.panelFloat.Width = width;
        }

        public void SetCannotOperate()
        {
            isCanOperate = false;
            panelFloat.Width = 0;
        }

        private void ucProgressBar_Load(object sender, EventArgs e)
        {
            panelFloat.Height = this.Height;
            panelFloat.Location = new Point(0, 0);
        }

        private void panelBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panelBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panelBack_MouseMove(object sender, MouseEventArgs e)
        {
            //if (IsCanOperate == false) return;
            if (e.Button != MouseButtons.Left) return;
            panelFloat.Width = e.Location.X > this.Width ? this.Width : e.Location.X;
            if (OnMouseMoveEvent != null) OnMouseMoveEvent(GetProgressValue());
        }

        private void panelBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (IsCanOperate == false) this.panelFloat.Width = 0;

            panelFloat.Width = e.Location.X > this.Width ? this.Width : e.Location.X;

            if (OnClickEvent != null)
            {
                OnClickEvent(GetProgressValue());
            }
        }
    }
}
