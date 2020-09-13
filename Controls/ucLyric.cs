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
using System.IO;
using System.Net;

namespace MusicPlayer.Controls
{
    public partial class ucLyric : UserControl
    {
        private const int ItemCount = 11;
        private SongLyric songLyric = new SongLyric();

        private string curPlaySongPath = "";

        public ucLyric()
        {
            InitializeComponent();

            listLyricBox.DisplayMember = "Text";
            listLyricBox.ValueMember = "Value";

            for (int i = 0;i < ItemCount;i++)
            {
                listLyricBox.Items.Add("");
            }
        }

        public void InitLyrics(string path)
        {
            listLyricBox.SelectionMode = SelectionMode.None;
            curPlaySongPath = path;
            songLyric.init();
            songLyric.ReadFile(path);

            for (int i = 0; i < ItemCount; i++)
            {
                listLyricBox.Items[i] = "";
            }

            if (songLyric.IsNotHaveLyric())
            {
                linkLabel.Visible = true;
                return;
            }
            else
            {
                listLyricBox.CurDisplay = TransparentListBox.DisplayMode.LYRIC;
                listLyricBox.SelectionMode = SelectionMode.None;
                linkLabel.Visible = false;
                SetCurLyric(1, true);
            }

            
        }

        public void SetCurLyric(int time, bool IsInit = false)
        {
            bool IsChanged;

            if (songLyric.IsNotHaveLyric()) return;
            
            List<String> lys = songLyric.GetShowLyric(time, ItemCount - 2, IsInit, out IsChanged);

            if (IsChanged == false) return;
            for(int i = 1;i < ItemCount - 1; i++)
            {
                listLyricBox.Items[i] = lys[i - 1];
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = curPlaySongPath.Substring(curPlaySongPath.LastIndexOf("\\") + 1);
            name = name.Substring(0, name.IndexOf("."));
            if (name.IndexOf("-") != -1) name = name.Substring(name.IndexOf("-") + 1);

            Task<List<SongSearchStruct>> task = Task.Factory.StartNew<List<SongSearchStruct>>(() => getResult(name.Trim()));
            List<SongSearchStruct> jSon = task.Result;

            if (jSon == null || jSon.Count == 0)
            {
                MessageBox.Show("获取数据失败");
                return;
            }

            string artistname = "";

            for(int i = 0;i < jSon.Count && i < ItemCount; i++)
            {
                artistname = GetArtistNameById(jSon[i].artist_id);
                listLyricBox.Items[i] = new ListItem("   " + jSon[i].song + " -- " + artistname, jSon[i].lrc);
            }
            linkLabel.Visible = false;
            listLyricBox.SelectionMode = SelectionMode.One;
            listLyricBox.CurDisplay = TransparentListBox.DisplayMode.SEARCH;
            
        }

        private string GetArtistNameById(string artist_id)
        {
            string content = "";
            try
            {
                string apiUrl = "http://gecimi.com/api/artist/" + artist_id;
                Stream stm = System.Net.WebRequest.Create(apiUrl).GetResponse().GetResponseStream();
                StreamReader stmReader = new StreamReader(stm, Encoding.UTF8);
                content = (stmReader.ReadToEnd());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("加载失败");
                return "";
            }
            return GetNameFieldValue(content);
        }

        private string GetNameFieldValue(string content)
        {
            int pos1 = 0, pos2;
            pos1 = content.IndexOf("\"name\":");
            pos1 = pos1 + 8;
            pos2 = content.IndexOf(",", pos1);
            return content.Substring(pos1, pos2 - pos1 - 1);
        }


        private List<SongSearchStruct> getResult(string title)
        {
            string content = "";
            try
            {
                string apiUrl = "http://gecimi.com/api/lyric/" + title;
                Stream stm = System.Net.WebRequest.Create(apiUrl).GetResponse().GetResponseStream();
                StreamReader stmReader = new StreamReader(stm, Encoding.UTF8);
                content = (stmReader.ReadToEnd());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("加载失败");
                return new List<SongSearchStruct>();
            }
            return JsonResolver(content);
        }

        private List<SongSearchStruct> JsonResolver(string content)
        {
            int pos1 = content.IndexOf("[") + 1;
            int pos2 = content.LastIndexOf("]");
            content = content.Substring(pos1, pos2 - pos1);

            List<SongSearchStruct> listJson = new List<SongSearchStruct>();

            pos1 = 0;
            while (pos1 < content.Length)
            {
                SongSearchStruct temp = new SongSearchStruct();
                pos1 = content.IndexOf("\"aid\":", pos1);
                pos1 = pos1 + 6;
                pos2 = content.IndexOf(",", pos1);
                temp.aid = content.Substring(pos1, pos2 - pos1);

                pos1 = pos2 + 1;
                pos1 = content.IndexOf("\"artist_id\":", pos1);
                pos1 = pos1 + 12;
                pos2 = content.IndexOf(",", pos1);
                temp.artist_id = content.Substring(pos1, pos2 - pos1);

                pos1 = pos2 + 1;
                pos1 = content.IndexOf("\"lrc\":", pos1);
                pos1 = pos1 + 7;
                pos2 = content.IndexOf(",", pos1);
                temp.lrc = content.Substring(pos1, pos2 - pos1 - 1);

                pos1 = pos2 + 1;
                pos1 = content.IndexOf("\"sid\":", pos1);
                pos1 = pos1 + 6;
                pos2 = content.IndexOf(",", pos1);
                temp.sid = content.Substring(pos1, pos2 - pos1);

                pos1 = pos2 + 1;
                pos1 = content.IndexOf("\"song\":", pos1);
                pos1 = pos1 + 8;
                pos2 = content.IndexOf("}", pos1);
                temp.song = content.Substring(pos1, pos2 - pos1 - 1);

                pos1 = pos2 + 1;

                listJson.Add(temp);
            }
            return listJson;
        }
        private struct SongSearchStruct{
            public string aid;
            public string artist_id;
            public string lrc;
            public string sid;
            public string song;
        }

        private void listLyricBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string name = curPlaySongPath.Substring(curPlaySongPath.LastIndexOf("\\") + 1);
            string path = curPlaySongPath.Substring(0, curPlaySongPath.LastIndexOf("\\") + 1);
            name = name.Substring(0, name.IndexOf("."));

            try
            {
                string url = ((ListItem)listLyricBox.SelectedItem).Value.ToString();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(path + "\\" + name + ".lrc", FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, bArr.Length);
                }
                stream.Close();
                responseStream.Close();
            }
            catch(Exception ex)
            {

            }
            InitLyrics(path + "\\" + name + ".lrc");
        }
    }
}
