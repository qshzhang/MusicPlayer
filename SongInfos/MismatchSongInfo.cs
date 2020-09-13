using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.SongInfos
{
    class MismatchSongInfo : SongInfo
    {
        public MismatchSongInfo(string path)
        {
            SetSongInfo(path);

            Duration = GetMusicTime(path);
        }

        private int GetMusicTime(string songPath)
        {
            if (!File.Exists(songPath)) return 0;
            string dirName = System.IO.Path.GetDirectoryName(songPath);
            string SongName = System.IO.Path.GetFileName(songPath);
            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(dirName);
            FolderItem item = dir.ParseName(SongName);
            string s = System.Text.RegularExpressions.Regex.Match(dir.GetDetailsOf(item, -1), "\\d:\\d{2}:\\d{2}").Value;
            string[] num = s.Split(':');
            return Convert.ToInt32(num[0]) * 3600 + Convert.ToInt32(num[1]) * 60 + Convert.ToInt32(num[2]);
        }

        public override void SetSongInfo(string path)
        {
            InitInfo(path);

            Duration = 0;
        }
    }
}
