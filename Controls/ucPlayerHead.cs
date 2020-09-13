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
    public partial class ucPlayerHead : UserControl
    {
        private int songDurationTime;
        private int curTime;

        public delegate void ProgressBarClickEvent(int rate);
        public ProgressBarClickEvent OnProgressBarClickEvent;
        public ProgressBarClickEvent OnShowProperLyricEvent;

        public delegate void AutoPlayNextSongEvent();
        public AutoPlayNextSongEvent OnAutoPlayNextSongEvent;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }


        public ucPlayerHead()
        {
            InitializeComponent();
            this.ucSongProgressBar.Height = 4;

            this.Height = 85;

            //this.lbTime.Location = new Point(this.Width - 114, 80);

            this.ucSongProgressBar.SetProgress(0);
            curTime = 0;
            songDurationTime = 0;
            this.ucSongProgressBar.OnClickEvent += progressBarClick;
            this.ucSongProgressBar.OnMouseMoveEvent += progressBarMouseMove;
            timer.Stop();
            timerTitle.Start();
        }

        public void SetSongInfo(string title, int songTime)
        {
            this.ucSongProgressBar.SetProgress(0);
            this.lbSongTitle.Text = title;
            songDurationTime = songTime;
            curTime = 0;
            lbTime.Text = timeToStr(curTime) + "/" + timeToStr(songTime);
            this.lbSongTitle.Location = new Point((this.Width - this.lbSongTitle.Width)/2, 
                this.lbSongTitle.Location.Y);

            timer.Start();
        }

        public void SetPlayerStop()
        {
            timer.Stop();
            lbSongTitle.Text = "暂无歌曲";
            lbTime.Text = "00:00/00:00";
            this.songDurationTime = 0;
            this.curTime = 0;
        }

        public void SetPlayerPause()
        {
            timer.Stop();
        }

        public void SetPlayerRestart()
        {
            timer.Start();
        }


        private string timeToStr(int time)
        {
            return (time / 60).ToString().PadLeft(2, '0') + ":" + (time % 60).ToString().PadLeft(2, '0');
        }

        private void progressBarClick(int rate)
        {
            curTime = (int)(rate * 1.0 / 100 * songDurationTime);
            if (OnProgressBarClickEvent != null) OnProgressBarClickEvent(rate);
        }

        private void progressBarMouseMove(int rate)
        {
            curTime = (int)(rate * 1.0 / 100 * songDurationTime);
            lbTime.Text = timeToStr(curTime) + "/" + timeToStr(songDurationTime);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            curTime++;
            if (curTime > songDurationTime) curTime = songDurationTime;
            lbTime.Text = timeToStr(curTime) + "/" + timeToStr(songDurationTime);

            if (OnAutoPlayNextSongEvent != null) OnAutoPlayNextSongEvent();
            
        }

        private void timerTitle_Tick(object sender, EventArgs e)
        {
            //Point lbSongTitleLocation = this.lbSongTitle.Location;
            //this.lbSongTitle.Location = new Point(lbSongTitleLocation.X + 3, lbSongTitleLocation.Y);
            this.ucSongProgressBar.SetProgressByWidth((int)(curTime * 1.0 / songDurationTime * ucSongProgressBar.Width));

            //if (lbSongTitleLocation.X > panelRight.Location.X)
            //{
            //    this.lbSongTitle.Location = new Point(panelLeft.Width - lbSongTitle.Width + 5, lbSongTitleLocation.Y);
            //}

            if (OnShowProperLyricEvent != null) OnShowProperLyricEvent(curTime * 1000);
        }

        private void ucPlayerHead_Load(object sender, EventArgs e)
        {
            this.panelLeft.Location = new Point(0, 0);
            this.panelLeft.Size = new Size(50, 25);
            this.panelRight.Size = new Size(50, 25);
            this.panelRight.Location = new Point(this.Width - 50, 0);
        }
    }
}
