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
    public partial class ucVolPanel : UserControl
    {
        public delegate void ProgressBarClickEvent(int rate);
        public ProgressBarClickEvent OnProgressBarClickEvent;

        public delegate void QuietBtnClickEvent(bool isQuiet, int rate);
        public QuietBtnClickEvent OnQuietBtnClickEvent;

        private int preVol = 0;
        private bool isSilence = false;
        public ucVolPanel()
        {
            InitializeComponent();

            //this.ucVolProgBar.SetProgress(0);
            this.ucVolProgBar.OnClickEvent += progressBarClick;
            this.ucVolProgBar.OnMouseMoveEvent += progressBarMouseMove;
        }

        public void SetVolumnValue(bool isQuiet, int rate)
        {
            isSilence = isQuiet;
            if (isQuiet)
            {
                preVol = (int)(rate * 1.0 / 100 * this.ucVolProgBar.Width);
                this.ucVolProgBar.SetProgress(0);
                this.volIconPanel.BackgroundImage = Properties.Resources.vol_close;
                this.ucVolProgBar.IsCanOperate = false;
                return;
            }
            this.ucVolProgBar.SetProgress(rate);
            this.ucVolProgBar.Refresh();
            if (OnProgressBarClickEvent != null) OnProgressBarClickEvent(rate);
        }

        private void ucVolPanel_Load(object sender, EventArgs e)
        {
            volIconPanel.Size = new Size(this.Height, this.Height);

            this.ucVolProgBar.Size = new Size(this.Width - this.volIconPanel.Width - 2, 4);
            this.ucVolProgBar.Location = new Point(this.volIconPanel.Width + 2, (this.Height - 4) / 2);
        }

        private void progressBarClick(int rate)
        {
            if (isSilence) return;
            if (OnProgressBarClickEvent != null) OnProgressBarClickEvent(rate);
        }

        private void progressBarMouseMove(int rate)
        {
            if (isSilence) return;
            //curTime = (int)(rate * 1.0 / 100 * songDurationTime);
            //lbTime.Text = timeToStr(curTime) + "/" + timeToStr(songDurationTime);
            volTip.SetToolTip(this.ucVolProgBar, rate.ToString());

            if (OnProgressBarClickEvent != null) OnProgressBarClickEvent(rate);
        }

        private void volIconPanel_Click(object sender, EventArgs e)
        {
            if(isSilence == false)
            {
                isSilence = true;
                this.volIconPanel.BackgroundImage = Properties.Resources.vol_close;
                this.ucVolProgBar.IsCanOperate = false;
                preVol = this.ucVolProgBar.GetProgressBarWidth();
                this.ucVolProgBar.SetProgress(0);

                int rate = (int)(preVol * 1.0 / this.ucVolProgBar.Width * 100);
                if (OnProgressBarClickEvent != null) OnQuietBtnClickEvent(true, rate);
            }
            else
            {
                isSilence = false;
                this.volIconPanel.BackgroundImage = Properties.Resources.vol_open;
                this.ucVolProgBar.IsCanOperate = true;
                this.ucVolProgBar.SetProgressByWidth(preVol);

                int rate = (int)(preVol * 1.0 / this.ucVolProgBar.Width * 100);

                if (OnProgressBarClickEvent != null) OnQuietBtnClickEvent(false, rate);
            }
        }
    }
}
