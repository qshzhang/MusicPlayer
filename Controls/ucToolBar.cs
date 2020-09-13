using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Common;

namespace MusicPlayer.Controls
{
    public partial class ucToolBar : UserControl
    {
        private const int lbwidth = 25;
        private const int lbheight = 20;
        private const int interval = 0;

        private bool isPause = true;
        //private bool isRandomPlay = false;
        private PlayType playtype = PlayType.ORDER;

        public delegate void ClickEvent();
        public ClickEvent OnStopClickEvent;
        public ClickEvent OnPrevSongClickEvent;
        public ClickEvent OnNextSongClickEvent;
        public ClickEvent OnImportSongClickEvent;
        public ClickEvent OnLyricSwitchClickEvent;


        public delegate void ClickEventWithBoolPara(bool isPaused);
        public ClickEventWithBoolPara OnPauseClickEvent;

        public delegate void ClickEventWithPlayTypeEnumPara(PlayType type);
        public ClickEventWithPlayTypeEnumPara OnPlaySongTypeClickEvent;


        public ucToolBar()
        {
            InitializeComponent();
            //if (this.Width < 260) this.Width = 260;
        }

        private void ucToolBar_Load(object sender, EventArgs e)
        {
            this.Height = lbheight;

            lbStop.Size = new Size(lbwidth, lbheight);
            lbPrevSong.Size = new Size(lbwidth, lbheight);
            lbPause.Size = new Size(lbwidth, lbheight);
            lbNextSong.Size = new Size(lbwidth, lbheight);
            lbImportSong.Size = new Size(lbwidth, lbheight);
            lbFavorite.Size = new Size(lbwidth, lbheight);
            lbLyric.Size = new Size(lbwidth, lbheight);

            lbStop.Location = new Point(0, 0);
            lbPrevSong.Location = new Point(lbStop.Location.X + lbwidth + interval, 0);
            lbPause.Location = new Point(lbPrevSong.Location.X + lbwidth + interval, 0);
            lbNextSong.Location = new Point(lbPause.Location.X + lbwidth + interval, 0);

            lbImportSong.Location = new Point(this.Width - lbwidth, 0);
            lbFavorite.Location = new Point(lbImportSong.Location.X - lbwidth - interval, 0);
            lbLyric.Location = new Point(lbImportSong.Location.X - lbwidth - interval - lbFavorite.Width - interval, 0);

            //foreach (Control ctl in this.Controls)
            //{
            //    ((Label)ctl).MouseLeave += LabelMouseLeave;
            //    ((Label)ctl).MouseEnter += LabelMouseEnter;
            //}
        }

        private void LabelMouseEnter(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ((Label)ctl).BorderStyle = BorderStyle.None;
            }
            ((Label)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        private void LabelMouseLeave(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ((Label)ctl).BorderStyle = BorderStyle.None;
            }
            ((Label)sender).BorderStyle = BorderStyle.None;
        }

        public void SetPlaySong()
        {
            isPause = false;
            lbPause.Text = "||";
        }

        public void SetPauseSong()
        {
            isPause = true;
            lbPause.Text = "▶";
        }

        private void lbStop_Click(object sender, EventArgs e)
        {
            lbPause.Text = "▶";
            isPause = true;
            if (OnStopClickEvent != null) OnStopClickEvent();
        }

        private void lbPrevSong_Click(object sender, EventArgs e)
        {
            if (OnPrevSongClickEvent != null) OnPrevSongClickEvent();
        }

        private void lbPause_Click(object sender, EventArgs e)
        {
            if(isPause == true)
            {
                isPause = false;
                lbPause.Text = "||"; 
            }
            else
            {
                isPause = true;
                lbPause.Text = "▶";
            }

            if(OnPauseClickEvent != null) OnPauseClickEvent(isPause);
        }

        private void lbImportSong_Click(object sender, EventArgs e)
        {
            if (OnImportSongClickEvent != null) OnImportSongClickEvent();
        }

        private void lbFavorite_Click(object sender, EventArgs e)
        {
            string[] intr = { "O", "R", "S" };
            if (OnPlaySongTypeClickEvent != null)
            {
                playtype = (PlayType)(((int)playtype + 1) % System.Enum.GetNames(playtype.GetType()).Length);
                lbFavorite.Text = intr[(int)playtype];

                OnPlaySongTypeClickEvent(playtype);
            }
        }

        private void lbNextSong_Click(object sender, EventArgs e)
        {
            if (OnNextSongClickEvent != null) OnNextSongClickEvent();
        }

        private void lbLyric_Click(object sender, EventArgs e)
        {
            if (OnLyricSwitchClickEvent != null) OnLyricSwitchClickEvent();
        }
    }
}
