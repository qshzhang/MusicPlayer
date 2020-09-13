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
    public partial class ucSongListBox : UserControl
    {
        private int curPage = 0;
        private int countPage = 0;

        private int curPlaySongIdx = -1;

        private const int songNumPerPage = 7;

        private const string splitChr = "___";

        public delegate void PlaySelectedSongEvent(string path);
        public PlaySelectedSongEvent OnPlaySelectedSong;

        List<ListItem> listSongItems = new List<ListItem>();
        public TransparentListBox.AllignMode TextAlign { get => songListBox.TextAllign; set => songListBox.TextAllign = value; }
        public ucSongListBox()
        {
            InitializeComponent();
            songListBox.DisplayMember = "Text";
            songListBox.ValueMember = "Value";

        }

        public void PlayPrevSong()
        {
            curPlaySongIdx--;
            if (curPlaySongIdx < 0)
            {
                curPlaySongIdx = 0;
                return;
            }
            selectSong();
        }

        public void PlayNextSong()
        {
            curPlaySongIdx++;
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

                BindingSource bs = new BindingSource();
                bs.DataSource = listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage);
                songListBox.DataSource = bs;

                this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
            }

            songListBox.SetSelected(curPlaySongIdx % songNumPerPage, true);

            string songPath = listSongItems[curPlaySongIdx].Value.ToString();

            if (OnPlaySelectedSong != null) OnPlaySelectedSong(songPath.Substring(0, songPath.LastIndexOf(splitChr)));
        }

        public void SetListBoxSourceData(List<string> songFiles)
        {
            listSongItems.Clear();
            foreach (string fullPath in songFiles)
            {
                string filename = System.IO.Path.GetFileName(fullPath);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fullPath);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);// 没有扩展名的文件名 “Default”

                ListItem item = new ListItem(filename, fullPath + splitChr + listSongItems.Count().ToString());
                listSongItems.Add(item);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = listSongItems.GetRange(0, listSongItems.Count() < songNumPerPage ? listSongItems.Count(): songNumPerPage);
            songListBox.DataSource = bs;

            countPage = listSongItems.Count() % songNumPerPage == 0 ? listSongItems.Count() / songNumPerPage : listSongItems.Count() / songNumPerPage + 1;
            curPage = 1;

            curPlaySongIdx = 0;


            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
        }

        private void songListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songListBox.SelectedItem == null) return;
            string name = songListBox.SelectedItem.ToString();


            string songname = ((ListItem)songListBox.SelectedItem).Text;
            string songPath = ((ListItem)songListBox.SelectedItem).Value.ToString();

            if(OnPlaySelectedSong != null) OnPlaySelectedSong(songPath);
        }

        private void ucSongList_Load(object sender, EventArgs e)
        {
            songListBox.Size = new Size(this.Width - 6, 16 * songNumPerPage + 3);
            songListBox.Location = new Point(3, 3);

            this.lbNextPage.Parent = panelBottom;
            this.lbPrevPage.Parent = panelBottom;
            this.lbPageInfo.Parent = panelBottom;

            this.lbPrevPage.Location = new Point(50, this.lbPrevPage.Location.Y);
            this.lbNextPage.Location = new Point(this.Width - 50, this.lbNextPage.Location.Y);
            this.lbPageInfo.Location = new Point(this.Width / 2 - this.lbPageInfo.Width / 2, this.lbPageInfo.Location.Y);
        }

        private void lbPrevPage_Click(object sender, EventArgs e)
        {
            if (curPage <= 1) return;
            curPage--;

            BindingSource bs = new BindingSource();
            bs.DataSource = listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage);
            songListBox.DataSource = bs;

            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
        }

        private void lbNextPage_Click(object sender, EventArgs e)
        {
            if (curPage == countPage) return;
            curPage++;

            BindingSource bs = new BindingSource();
            bs.DataSource = listSongItems.GetRange(songNumPerPage * (curPage - 1), listSongItems.Count() < songNumPerPage * (curPage) ? listSongItems.Count() - songNumPerPage * (curPage - 1) : songNumPerPage);
            songListBox.DataSource = bs;

            this.lbPageInfo.Text = curPage.ToString() + "/" + countPage.ToString();
        }

        private void songListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (songListBox.SelectedItem == null) return;
            string name = songListBox.SelectedItem.ToString();


            string songname = ((ListItem)songListBox.SelectedItem).Text;
            string songPath = ((ListItem)songListBox.SelectedItem).Value.ToString();

            string filepath = songPath.Substring(0, songPath.LastIndexOf(splitChr));

            curPlaySongIdx = Convert.ToInt32(songPath.Substring(songPath.LastIndexOf(splitChr) + splitChr.Length));

            if (OnPlaySelectedSong != null) OnPlaySelectedSong(filepath);
        }
    }
}

