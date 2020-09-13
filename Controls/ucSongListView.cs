using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.SongInfos;
using MusicPlayer.Common;

namespace MusicPlayer.Controls
{
    public partial class ucSongListView : UserControl
    {
        private int curPage = 0;
        private int countPage = 0;

        private int curPlaySongSeq = 0;
        private int curPlaySongIdx = -1;

        private const int songNumPerPage = 6;

        public delegate void PlaySelectedSongEvent(string path, int duration);
        public PlaySelectedSongEvent OnPlaySelectedSong;

        public delegate bool RemoveSongEvent(int idx);
        public RemoveSongEvent OnRemoveSongInList;

        List<SongItem> listSongItems = new List<SongItem>();

        private Random random = new Random();

        private bool IsClicked = false;


        public ucSongListView()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲s


            songListView.Size = new Size(this.Width - 6, this.Height - 3 - 2 - this.panelBottom.Height);
            songListView.Location = new Point(3, 3);


            this.colTitle.Width = (int)(this.songListView.Width * 0.55);
            this.colArtist.Width = (int)(this.songListView.Width * 0.3);
            this.colDuration.Width = (int)(this.songListView.Width * 0.15);
            this.colFilepath.Width = 0;
            this.colSeq.Width = 0;
        }

        public void PlayPrevSong()
        {
            curPlaySongIdx--;
            curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);
            if (curPlaySongIdx < 0)
            {
                curPlaySongIdx = 0;
                curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);
                return;
            }
            selectSong();
        }

        public void PlayNextSong(PlayType type)
        {
            if(type == PlayType.ORDER)
            {
                curPlaySongIdx++;
                curPlaySongIdx %= listSongItems.Count;
                curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);
            }
            else if(type == PlayType.RANDOM)
            {
                curPlaySongIdx = random.Next() % listSongItems.Count;
                curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);
            }
            else if(type == PlayType.SINGLE)
            {

            }
            selectSong();
        }

        public void PlayCurSong()
        {
            selectSong();
        }

        private void selectSong()
        {
            if (listSongItems.Count() == 0 || curPlaySongIdx == -1) return;

            curPlaySongIdx %= listSongItems.Count();

            int actPage = (curPlaySongIdx + 1) % songNumPerPage == 0 ? (curPlaySongIdx + 1) / songNumPerPage : (curPlaySongIdx + 1) / songNumPerPage + 1;

            if (actPage != curPage)
            {
                curPage = actPage;

                DataBind(listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage));

                this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
            }

            songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;

            string songPath = listSongItems[curPlaySongIdx].Path;
            

            if (OnPlaySelectedSong != null) OnPlaySelectedSong(songPath, listSongItems[curPlaySongIdx].Info.Duration);
        }

        public void SetListBoxSourceData(List<string> songFiles)
        {
            listSongItems.Clear();
            foreach (string fullPath in songFiles)
            {
                //if(!File.Exists(fullPath))
                //{
                //    if (null != OnRemoveSongInList) OnRemoveSongInList(i - RmCount);
                //    RmCount++;
                //    i++;
                //    continue;
                //}

                //i++;

                string filename = System.IO.Path.GetFileName(fullPath);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fullPath);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);// 没有扩展名的文件名 “Default”

                SongItem item = new SongItem();
                item.Path = fullPath;
                item.Seq = listSongItems.Count;
                item.Info = SoftInfoFactory.SelectSongInfogenerator(fullPath);

                listSongItems.Add(item);
            }

            DataBind(listSongItems.GetRange(0, listSongItems.Count() < songNumPerPage ? listSongItems.Count() : songNumPerPage));

            countPage = listSongItems.Count() % songNumPerPage == 0 ? listSongItems.Count() / songNumPerPage : listSongItems.Count() / songNumPerPage + 1;
            curPage = 1;

            curPlaySongIdx = 0;
            curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);


            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
        }

        private void songListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ucSongList_Load(object sender, EventArgs e)
        {
            songListView.Size = new Size(this.Width - 6, this.Height - 3 - 2 - this.panelBottom.Height);
            songListView.Location = new Point(3, 3);

            this.lbNextPage.Parent = panelBottom;
            this.lbPrevPage.Parent = panelBottom;
            this.lbPageInfo.Parent = panelBottom;

            this.lbPrevPage.Location = new Point(50, this.lbPrevPage.Location.Y);
            this.lbNextPage.Location = new Point(this.Width - 50, this.lbNextPage.Location.Y);
            this.lbPageInfo.Location = new Point(this.Width / 2 - this.lbPageInfo.Width / 2, this.lbPageInfo.Location.Y);

            ListViewItem viewhead = new ListViewItem();
            for (int j = 0; j < this.songListView.Columns.Count; j++)
            {
                if (j == 0) viewhead.Text = this.songListView.Columns[j].Text;
                else viewhead.SubItems.Add(this.songListView.Columns[j].Text);
            }

            this.songListView.Items.Add(viewhead);

        }

        private void lbPrevPage_Click(object sender, EventArgs e)
        {
            if (curPage <= 1) return;
            curPage--;

            DataBind(listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage));

            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();

            if(curPage == curPlaySongIdx/songNumPerPage + 1)
            {
                songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;
            }
        }

        private void lbNextPage_Click(object sender, EventArgs e)
        {
            if (curPage == countPage) return;
            curPage++;

            DataBind(listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage));

            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();

            if (curPage == curPlaySongIdx / songNumPerPage + 1)
            {
                songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;
            }
        }

        private void songListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (songListView.SelectedItems == null || songListView.SelectedItems.Count == 0 || songListView.SelectedIndices[0] == 0 || 
                IsClicked == true) return;

            //if (songListView.SelectedIndices[0] == 0)
            //{
            //    songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;
            //    return;
            //}

            curPlaySongSeq = Convert.ToInt32(songListView.SelectedItems[0].SubItems[4].Text);
            curPlaySongIdx = GetIdxBySeq(curPlaySongSeq);

            string filepath = listSongItems[curPlaySongIdx].Path;

            if (OnPlaySelectedSong != null) OnPlaySelectedSong(filepath, listSongItems[curPlaySongIdx].Info.Duration);

            //MessageBox.Show(songListView.HideSelection.ToString());
        }

        private void DataBind(List<SongItem> list)
        {
            ListViewItem head = this.songListView.Items[0];
            this.songListView.Items.Clear();
            this.songListView.Items.Add(head);

            foreach(SongItem song in list)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Text = GetShowStr(song.Info.Title, 23) ;
                viewItem.SubItems.Add(GetShowStr(song.Info.Artist, 15));
                viewItem.SubItems.Add((song.Info.Duration/60).ToString().PadLeft(2, '0') + ":" + (song.Info.Duration % 60).ToString().PadLeft(2, '0'));
                viewItem.SubItems.Add("");
                viewItem.SubItems.Add(song.Seq.ToString());

                this.songListView.Items.Add(viewItem);
            }

            if(curPage == curPlaySongIdx / songNumPerPage + 1)
            {
                songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;
            }
        }


        private string GetShowStr(string str, int maxlen)
        {
            if (str.Length < maxlen) return str;
            else return str.Substring(0, maxlen - 3) + "...";
        }

        private void songListView_MouseClick(object sender, MouseEventArgs e)
        {
            IsClicked = false;
            if (songListView.SelectedItems == null || songListView.SelectedItems.Count == 0) return;

            if (e.Button == MouseButtons.Left && (songListView.SelectedIndices[0] == 0) && curPage == curPlaySongIdx/songNumPerPage + 1)
            {
                IsClicked = true;
                songListView.Items[curPlaySongIdx % songNumPerPage + 1].Selected = true;
                return;
            }
            if (e.Button != MouseButtons.Right || listSongItems.Count == 0 || songListView.SelectedIndices[0] == 0) return;

            
            int seq = Convert.ToInt32(songListView.SelectedItems[0].SubItems[4].Text);
            int idx = GetIdxBySeq(seq);

            if(OnRemoveSongInList != null && false == OnRemoveSongInList(idx))
            {
                MessageBox.Show("delete failed");
                return;
            }

            listSongItems.RemoveAt(idx);

            if (idx == curPlaySongIdx)
            {

                curPlaySongIdx %= listSongItems.Count;
                curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);

                selectSong();
                //return;
            }
            else if(idx < curPlaySongIdx)
            {
                curPlaySongIdx--;
                if (curPlaySongIdx < 0) curPlaySongIdx = 0;
                curPlaySongSeq = GetSeqByIdx(curPlaySongIdx);
            }
            else
            {

            }

            
            countPage = listSongItems.Count % songNumPerPage == 0 ? listSongItems.Count / songNumPerPage : listSongItems.Count / songNumPerPage + 1;
            
            
            //curPlaySongIdx = 0;
            
            
            if (curPage > countPage) curPage = countPage;

            if(curPage != 0)
            {
                DataBind(listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count - songNumPerPage * (curPage - 1) : songNumPerPage));
            }
            else
            {
                DataBind(listSongItems);
            }
            

            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
        }

        public void SetBottomPanelVisible(bool isvisible)
        {
            this.panelBottom.Visible = isvisible;
        }


        private int GetSeqByIdx(int idx)
        {
            if (listSongItems.Count == 0) return -1;
            return listSongItems[idx].Seq;
        }

        private int GetIdxBySeq(int seq)
        {
            for(int i = 0;i < listSongItems.Count;i++)
            {
                if(seq == listSongItems[i].Seq)
                {
                    return i;
                }
            }

            return -1;
        }

    }

    public struct SongItem
    {
        public int Seq;
        public string Path;

        public SongInfo Info;
    }

    
}

