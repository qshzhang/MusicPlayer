using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Players
{
    public abstract class Player
    {
        //定义播放状态枚举变量  
        public enum State
        {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3
        };

        private string filename;
        private int duration;

        public string Filename { get => filename; protected set => filename = value; }
        public int Duration { get => duration; protected set => duration = value; }

        public abstract void InitSong();
        public abstract void Play();
        public abstract void Stop();

        public abstract void Puase();
        public abstract void SetPos(int rate);

        public abstract bool IsEnd();
    }
}
