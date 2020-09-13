using MusicPlayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.SongInfos
{
    class SoftInfoFactory
    {
        public static SongInfo SelectSongInfogenerator(string path)
        {
            MusicType musicType = CommFunc.GetMusicType(path);

            switch (musicType)
            {
                case MusicType.MP3:
                    return new Mp3Info(path);
                case MusicType.AAC:
                    break;
                case MusicType.WMA:
                    break;
                case MusicType.NONE:
                    break;
                default:
                    break;   
            }
            return new MismatchSongInfo(path);
        }
    }
}
