using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Common;
using MusicPlayer.Controls;
using MusicPlayer.Players;

namespace MusicPlayer
{
    public partial class MainFrm : Form
    {
        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern int waveOutSetVolume(int uDeviceID, int dwVolume); //Call waveOutSetVolume( 0, 100 );

        private Player myPlayer;// = Mp3Player.CreateInstance();

        private AppCfg tAppCfg = new AppCfg();

        private Size FrmCurSize = new Size();

        //private string songFilePath = "";

        //private bool IsRandomPlay = false;
        private bool IsLyricShow = false;

        private PlayType playType = PlayType.ORDER;

        public MainFrm()
        {
            InitializeComponent();

            this.ucBackPanel.OnBtnClose_Click += FrmClose;
            this.ucBackPanel.OnBtnMin_Click += AdjustWinByStatus;
            this.ucBackPanel.OnBtnMenu_Click += MenuShow;

            this.GMenu.OnSetBackImage += SetBackImage;
            this.GMenu.OnSetBackColor += SetBackColor;
            

            this.ucPlayerToolBar.OnStopClickEvent += PlayerStop;
            this.ucPlayerToolBar.OnPauseClickEvent += PlayerPause;
            this.ucPlayerToolBar.OnNextSongClickEvent += PlayerNext;
            this.ucPlayerToolBar.OnPrevSongClickEvent += PlayerPrev;
            this.ucPlayerToolBar.OnPlaySongTypeClickEvent += SetPlayType;
            this.ucPlayerToolBar.OnImportSongClickEvent += ImportSong;
            this.ucPlayerToolBar.OnLyricSwitchClickEvent += LyricSwitch;

            this.ucPlayerHeadInfo.OnProgressBarClickEvent += SongProgressBarClickEvent;
            this.ucPlayerHeadInfo.OnAutoPlayNextSongEvent += AutoPlayNextSong;
            this.ucPlayerHeadInfo.OnShowProperLyricEvent += ShowProperLyric;

            //this.ucSongListBox.OnPlaySelectedSong += PlaySelectedSong;

            this.ucSongLyricSwitch.ucListView.OnPlaySelectedSong += PlaySelectedSong;
            this.ucSongLyricSwitch.ucListView.OnRemoveSongInList += RemoveSongInList;
            

            this.ucVolCtrl.OnProgressBarClickEvent += SetVolValue;
            this.ucVolCtrl.OnQuietBtnClickEvent += QuietBtnClick;

        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
        //        return cp;
        //    }
        //}

        private void MenuShow(Point pt)
        {
            this.GMenu.Location = new Point(pt.X - this.GMenu.Width, pt.Y);
            this.GMenu.Visible = !this.GMenu.Visible;
        }


        private void SetBackColor(Color color)
        {
            this.BackgroundImage = null;
            this.BackColor = color;
            this.GMenu.Visible = !this.GMenu.Visible;
        }

        private void SetBackImage(string img)
        {
            this.BackgroundImage = Image.FromFile(img);
            this.GMenu.Visible = !this.GMenu.Visible;
        }

        private void AdjustWinByStatus(bool IsMiniWin)
        {
            if(IsMiniWin == true)
            {
                this.FrmCurSize = this.Size;
                //this.BackgroundImageLayout = ImageLayout.Tile;
                this.Height = this.ucVolCtrl.Location.Y - 1;
            }
            else
            {
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Height = this.FrmCurSize.Height;
            }
            tAppCfg.SetMiniWin(IsMiniWin);
        }


        private void SetInitStatusFromCfg()
        {
            this.ucVolCtrl.SetVolumnValue(tAppCfg.GetQuiet(), tAppCfg.GetVol());
            
            this.ucBackPanel.SetMiniWinFlag(tAppCfg.GetMiniWin());

            this.AdjustWinByStatus(tAppCfg.GetMiniWin());

            this.ucSongLyricSwitch.ucListView.SetListBoxSourceData(tAppCfg.GetSongsPath());
        }

        private void PlaySelectedSong(string song, int duration)
        {
            PlaySong(song, duration);
        }

        private void PlaySong(string path, int duration)
        {
            myPlayer = PlayerFactory.SelectPlayer(path);
            myPlayer.InitSong();
            myPlayer.Play();

            string fname = path.Substring(path.LastIndexOf("\\") + 1);

            string title = fname.Substring(0, fname.LastIndexOf("."));
            this.ucPlayerHeadInfo.SetSongInfo(title, duration);

            this.ucPlayerToolBar.SetPlaySong();

            this.ucSongLyricSwitch.ucSongLyric.InitLyrics(path.Substring(0, path.LastIndexOf(".")) + ".lrc");
        }

        private void AutoPlayNextSong()
        {
            if (null == myPlayer) return;
            if (myPlayer.IsEnd())
            {
                //this.ucSongListBox.PlayNextSong();
                this.ucSongLyricSwitch.ucListView.PlayNextSong(playType);
            }
        }

        private void SongProgressBarClickEvent(int rate)
        {
            if (myPlayer == null || myPlayer.IsEnd()) return;
            myPlayer.SetPos(rate);
            this.ucPlayerToolBar.SetPlaySong();
        }

        private void PlayerStop()
        {
            if (myPlayer == null) return;
            myPlayer.Stop();
            this.ucPlayerHeadInfo.SetPlayerStop();
        }

        private void PlayerNext()
        {
            //this.ucSongListBox.PlayNextSong();
            this.ucSongLyricSwitch.ucListView.PlayNextSong(playType);
        }

        private void PlayerPrev()
        {
            //this.ucSongListBox.PlayPrevSong();
            this.ucSongLyricSwitch.ucListView.PlayPrevSong();
        }

        private void PlayerPause(bool isPaused)
        {
            if (isPaused)
            {
                myPlayer.Puase();
                this.ucPlayerHeadInfo.SetPlayerPause();
            }
            else
            {
                if(myPlayer == null)
                {
                    this.ucPlayerToolBar.SetPauseSong();
                    //this.ucSongListBox.PlayCurSong();
                    this.ucSongLyricSwitch.ucListView.PlayCurSong();
                }
                else
                {
                    myPlayer.Play();
                }
                
                this.ucPlayerHeadInfo.SetPlayerRestart();
            }
        }

        private void SetPlayType(PlayType type)
        {
            this.playType = type;
        }

        private void ImportSong()
        {
            bool IsHasNewSong = false;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "音乐文件(*.mp3,*.wav)|*.mp3";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = dialog.FileNames;

                foreach (string file in files)
                {
                    IsHasNewSong |= tAppCfg.AddSongPath(file);
                }

                if(IsHasNewSong) this.ucSongLyricSwitch.ucListView.SetListBoxSourceData(tAppCfg.GetSongsPath());
            }
        }

        private void LyricSwitch()
        {
            IsLyricShow = !IsLyricShow;
            this.ucSongLyricSwitch.SetLyricAndSongSwitch(IsLyricShow);
        }

        private void ShowProperLyric(int time)
        {
            this.ucSongLyricSwitch.ucSongLyric.SetCurLyric(time);
        }

        private void FrmClose()
        {
            tAppCfg.saveConfig();
            this.Close();
        }

        private void SetVolValue(int rate)
        {
            tAppCfg.SetVol(rate);

            SetVol(rate);
        }

        private void SetVol(int rate)
        {
            int iVolume = rate;//音量大小(0-100)
            int left = Convert.ToInt32(Convert.ToInt32(iVolume));
            int right = left;
            int volume = (left << 8) | right;
            waveOutSetVolume(0, volume);
        }

        private void QuietBtnClick(bool isQuiet, int rate)
        {
            tAppCfg.SetQuite(isQuiet);
            if (isQuiet)
            {
                SetVol(0);
            }
            else
            {
                SetVol(rate);
            }
        }

        private bool RemoveSongInList(int idx)
        {
            return tAppCfg.RemoveSongByIdx(idx);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_BLEND | AW_CENTER | AW_ACTIVE);


            FrmCurSize = this.Size;
            tAppCfg.ReadConfig();
            SetInitStatusFromCfg();

            //List<string> files = new List<string>();
            //if (System.IO.Directory.Exists(songFilePath))
            //{
            //    files = System.IO.Directory.GetFiles(songFilePath, "*.mp3*").ToList<string>();
            //}
            ////this.ucSongListBox.SetListBoxSourceData(files);

            //this.ucListView.SetListBoxSourceData(files);
        }


        #region AnimatedWindow
        [DllImport("user32.dll")]
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVE = 0x00020000;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_SLIDE = 0x00040000;
        #endregion
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_CENTER | AW_BLEND | AW_HIDE);
        }
    }
}
