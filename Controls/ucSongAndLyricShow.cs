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
    public partial class ucSongAndLyricShow : UserControl
    {
        public ucSongListView ucListView { get => this.ucSongListView; }
        public ucLyric ucSongLyric { get => this.ucLyrics; }

        private bool IsShowLyric = false;
        private const int moveSpeed = 20;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        public ucSongAndLyricShow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        public void SetLyricAndSongSwitch(bool ShowLyric)
        {
            this.ucSongListView.SetBottomPanelVisible(false);
            IsShowLyric = ShowLyric;
            if (IsShowLyric == true)
            {
                this.ucSongListView.Location = new Point(0, 0);
                this.ucSongLyric.Location = new Point(this.Width, 0);
                this.ucSongLyric.BringToFront();
            }
            else
            {
                this.ucSongLyric.Location = new Point(0, 0);
                this.ucSongListView.Location = new Point(this.Width, 0);
                this.ucSongListView.BringToFront();
            }

            timerLyricSwitch.Start();
        }

        private void timerLyricSwitch_Tick(object sender, EventArgs e)
        {
            if (IsShowLyric == true)
            {
                this.ucSongLyric.Location = new Point(this.ucSongLyric.Location.X - moveSpeed, 0);
                if(this.ucSongLyric.Location.X - moveSpeed < 0)
                {
                    this.ucSongLyric.Location = new Point(0, 0);
                    timerLyricSwitch.Stop();
                }
            }
            else
            {
                this.ucSongListView.Location = new Point(this.ucSongListView.Location.X - moveSpeed, 0);
                if (this.ucSongListView.Location.X - moveSpeed < 0)
                {
                    this.ucSongListView.Location = new Point(0, 0);
                    timerLyricSwitch.Stop();

                    this.ucSongListView.SetBottomPanelVisible(true);
                }
            }
        }

        private void ucSongAndLyricShow_Load(object sender, EventArgs e)
        {
            this.ucListView.Size = this.Size;
            this.ucLyrics.Size = this.Size;
            this.ucListView.Location = new Point(0, 0);
            this.ucLyrics.Location = new Point(0, 0);
        }
    }
}
