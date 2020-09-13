using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Common
{
    public enum PlayType
    {
        ORDER = 0,
        RANDOM,
        SINGLE,
    }

    public enum MusicType
    {
        NONE = 0,
        MP3 = 1,
        AAC,
        WMA,
        OGG,
    }

    class CommFunc
    {
        public static byte[] GetByteData(string FileName, int start, int len)
        {
            if (!File.Exists(FileName)) return null;
            if (start < 0)
            {
                FileInfo fileInfo = new FileInfo(FileName);
                start = (int)fileInfo.Length + start;
            }

            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Stream stream = fs;
            stream.Seek(start, SeekOrigin.Begin);
            byte[] Info = new byte[len];
            stream.Read(Info, 0, len);
            fs.Close();
            stream.Close();
            return Info;
        }

        public static MusicType GetMusicType(string path)
        {
            byte[] Info = GetByteData(path, 0, 3);
            if (Info == null) return MusicType.NONE;
            string tag = "" + (char)Info[0] + (char)Info[1] + (char)Info[2];
            if (tag == "ID3") return MusicType.MP3;

            Info = GetByteData(path, -128, 3);
            tag = "" + (char)Info[0] + (char)Info[1] + (char)Info[2];
            if (tag == "TAG") return MusicType.MP3;

            return MusicType.NONE;
        }
    }
}
