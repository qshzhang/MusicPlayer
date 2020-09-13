using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.SongInfos
{
    public abstract class SongInfo
    {
        private string _title = "";
        private string _artist = "";
        private int _duration = 0;
        private string _year = "";
        private string _album = "";
        private string _branch = "";
        private string _tag = "";


        public string Title { get => _title; set => _title = value; }
        public string Artist { get => _artist; set => _artist = value; }
        public string Year { get => _year; set => _year = value; }
        public string Album { get => _album; set => _album = value; }
        public string Branch { get => _branch; set => _branch = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string Tag { get => _tag; set => _tag = value; }


        private protected void InitInfo(string path)
        {
            if (Title == "")
            {
                string fname = path.Substring(path.LastIndexOf("\\") + 1);
                string title = fname.Substring(0, fname.LastIndexOf("."));
                Title = title;
            }
            if (Artist == "") Artist = "外星人";
        }

        public abstract void SetSongInfo(string path);
    }
}
