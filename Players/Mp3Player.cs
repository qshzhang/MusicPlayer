using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Players
{
    class Mp3Player : Player
    {
        //结构变量  
        private struct structMCI
        {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public State state;
        };
        private structMCI mc = new structMCI();  //取得播放文件属性

        private static Mp3Player instance = null;

        private Mp3Player() { }
        private Mp3Player(string path) 
        {
            Filename = path;
        }

        public static Mp3Player CreateInstance(string path)
        {
            if(instance == null)
            {
                instance = new Mp3Player(path);
            }
            else
            {
                instance.Filename = path;
            }

            return instance;
        }

        public override void InitSong()
        {
            try
            {
                string Name = "";
                string TemStr = "";
                int ilong;
                string durLength = "";

                TemStr = "";
                TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
                Name = Name.PadLeft(260, Convert.ToChar(" "));
                mc.iName = Filename;
                ilong = APIClass.GetShortPathName(mc.iName, Name, Name.Length);
                Name = GetCurrPath(Name);
                Name = "open " + Convert.ToChar(34) + Name + Convert.ToChar(34) + " alias media";
                ilong = APIClass.mciSendString("close all", TemStr, TemStr.Length, 0);
                ilong = APIClass.mciSendString(Name, TemStr, TemStr.Length, 0);
                ilong = APIClass.mciSendString("set media time format milliseconds", TemStr, TemStr.Length, 0);
                mc.state = State.mStop;

                durLength = "";
                durLength = durLength.PadLeft(128, Convert.ToChar(" "));
                APIClass.mciSendString("status media length", durLength, durLength.Length, 0);
                durLength = durLength.Trim();
                if (durLength == "\0") base.Duration =  0;
                base.Duration = (int)(Convert.ToDouble(durLength) / 1000f);
            }
            catch
            { }
        }

      
        //播放  
        public override void Play()
        {
            string TemStr = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
            APIClass.mciSendString("play media", TemStr, TemStr.Length, 0);
            mc.state = State.mPlaying;
        }
        //停止  
        public override void Stop()
        {
            int ilong;
            string TemStr = "";

            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("close media", TemStr, 128, 0);
            ilong = APIClass.mciSendString("close all", TemStr, 128, 0);
            mc.state = State.mStop;
        }
        //暂停
        public override void Puase()
        {
            int ilong;
            string TemStr = "";
            
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("pause media", TemStr, TemStr.Length, 0);
            mc.state = State.mPuase;
        }

        public override void SetPos(int rate)
        {
            int ilong;
            string TemStr = "";

            long pos = (long)(Duration * 1000f * (rate * 1.0 / 100));
            string cmdSentence = string.Format("seek media to {0}", pos);
            TemStr = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
            ilong = APIClass.mciSendString(cmdSentence, TemStr, TemStr.Length, 0);
            Play();
            mc.state = State.mPlaying;
        }

        private string GetCurrPath(string name)
        {
            if (name.Length < 1) return "";
            name = name.Trim();
            name = name.Substring(0, name.Length - 1);
            return name;
        }
        //总时间  
        
        //当前时间  
        private int CurrentPosition()
        {
            string durLength = "";
            durLength = "";
            durLength = durLength.PadLeft(128, Convert.ToChar(" "));
            APIClass.mciSendString("status media position", durLength, durLength.Length, 0);
            durLength = durLength.Trim();
            if (durLength == "\0") return 0;
            mc.iPos = (int)(Convert.ToDouble(durLength) / 1000f);
            return mc.iPos;
        }

        public override bool IsEnd()
        {
            string durLength = "";
            durLength = durLength.PadLeft(128, Convert.ToChar(" "));
            APIClass.mciSendString("status media length", durLength, durLength.Length, 0);
            durLength = durLength.Trim();
            string curLength;
            curLength = "";
            curLength = curLength.PadLeft(128, Convert.ToChar(" "));
            APIClass.mciSendString("status media position", curLength, curLength.Length, 0);
            curLength = curLength.Trim();
            if (curLength == durLength)
            {
                return true;
            }
            return false;
        }   
    }
    
    public class APIClass
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string lpszLongPath, string shortFile, int cchBuffer);
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
    }

}
