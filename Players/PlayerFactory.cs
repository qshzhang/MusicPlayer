using MusicPlayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Players
{
    class PlayerFactory
    {
        public static Player SelectPlayer(string path)
        {
            MusicType musicType = CommFunc.GetMusicType(path);

            switch(musicType)
            {
                case MusicType.MP3:
                    return Mp3Player.CreateInstance(path);
                case MusicType.AAC:
                    break;
                case MusicType.WMA:
                    break;
                case MusicType.NONE:
                    break;
                default:
                    break;
            }
            return Mp3Player.CreateInstance(path);

        }
    }
}
