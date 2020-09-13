using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MusicPlayer.Common
{
    class SongLyric
    {
        private string title = "";
        private string artist = "";
        private string album = "";
        List<LyricRecord> lyricRecords = new List<LyricRecord>();

        private int LastStartPos = -1;

        private int LastOnePos = 0;

        public bool IsNotHaveLyric()
        {
            return lyricRecords.Count == 0;
        }

        protected class LyricRecord: IComparable
        {
            private int _msec;
            private string _lyric;
            public LyricRecord(string time, string lyric)
            {
                this._msec = 0;
                this._lyric = lyric;
                string[] timestr = time.Split(':');

                int timebase = 60;
                for(int i = timestr.Length - 2; i >= 0; i--)
                {
                    this._msec += timebase * Convert.ToInt32(timestr[i]);
                    timebase *= 60;
                }

                string[] secstr = timestr[timestr.Length - 1].Split('.');
                this._msec += Convert.ToInt32(secstr[0]);

                this._msec = this._msec * 1000 + Convert.ToInt32(secstr[1]);
            }

            public int CompareTo(object obj)
            {
                return _msec.CompareTo(((LyricRecord)obj)._msec);
            }

            public int GetMSec()
            {
                return this._msec;
            }

            public string GetLysrc()
            {
                return this._lyric;
            }
        }

        public void init()
        {
            lyricRecords.Clear();
            LastStartPos = -1;
        }

        private string GetLyricForCur(int time)
        {
            for(int i = 0;i < lyricRecords.Count;i++)
            {
                if(time < lyricRecords[i].GetMSec())
                {
                    return lyricRecords[i].GetLysrc();
                }
            }
            return "";
        }

        public string GetOneShowLyric(int time, out bool IsChanged)
        {
            if(LastOnePos == lyricRecords.Count)
            {
                IsChanged = false;
                return "";
            }

            if(time > lyricRecords[LastOnePos].GetMSec())
            {
                IsChanged = true;
                LastOnePos++;
                return lyricRecords[LastOnePos - 1].GetLysrc();
            }

            IsChanged = false;
            return "";
        }

        public List<string> GetShowLyric(int time, int nRows, bool IsInit, out bool IsChanged)
        {
            List<string> lyrics = new List<string>();

            //if(lyricRecords.Count == 0)
            //{
            //    IsChanged = IsInit;
            //    for(int i = 0;i < nRows;i++)
            //    {
            //        if(i == nRows/2)
            //        {
            //            lyrics.Add("没有歌词，是否搜索？");
            //        }
            //        else
            //        {
            //            lyrics.Add("");
            //        }
            //    }
            //    return lyrics;
            //}

            IsChanged = true;

            if (lyricRecords.Count < nRows/2)
            {
                for(int i = 0;i < nRows - lyricRecords.Count; i++)
                {
                    lyrics.Add("");
                }
                for (int i = 0; i < lyricRecords.Count; i++)
                {
                    lyrics.Add(lyricRecords[i].GetLysrc());
                }
                IsChanged = IsInit;
                return lyrics;
            }

            int midpos = lyricRecords.Count;
            for (int i = 0; i < lyricRecords.Count; i++)
            {
                if (time < lyricRecords[i].GetMSec())
                {
                    midpos = i;
                    break;
                }
            }
            
            if(midpos < nRows/2 + 1)
            {
                for (int i = 0; i < nRows / 2; i++)
                {
                    lyrics.Add("");
                }
                for (int i = 0; i < nRows / 2 + 1; i++)
                {
                    lyrics.Add(lyricRecords[i].GetLysrc());
                }
                if (LastStartPos == 0) IsChanged = false;
                else
                {
                    IsChanged = true;
                    LastStartPos = 0;
                }
            }
            else if(midpos > lyricRecords.Count - nRows/2 - 1)
            {
                for (int i = midpos - nRows / 2 - 1; i < lyricRecords.Count; i++)
                {
                    lyrics.Add(lyricRecords[i].GetLysrc());
                }
                for (int i = 0; i < nRows - (lyricRecords.Count - midpos + nRows / 2 + 1); i++)
                {
                    lyrics.Add("");
                }
                if (LastStartPos == lyricRecords.Count - nRows/2) IsChanged = false;
                else
                {
                    IsChanged = true;
                    LastStartPos = midpos - nRows / 2;
                }
            }
            else
            {
                for (int i = midpos - nRows/2 - 1; i < midpos + nRows/2; i++)
                {
                    lyrics.Add(lyricRecords[i].GetLysrc());
                }
                if (LastStartPos == midpos - nRows / 2) IsChanged = false;
                else
                {
                    IsChanged = true;
                    LastStartPos = midpos - nRows / 2;
                }
            }

            return lyrics;
        }

        public SongLyric()
        {
            this.title = "";
            this.artist = "";
            this.album = "";
        }

        private bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1; //计算当前正分析的字符应还有的字节数 
            byte curByte; //当前分析的字节. 
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前 
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X 
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1 
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }

        public System.Text.Encoding GetFileEncodeType(string filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);

            int filelen;
            int.TryParse(fs.Length.ToString(), out filelen);

            Byte[] buffer = br.ReadBytes(filelen);
            if (buffer[0] == 0xFF && buffer[1] == 0xFE)
            {
                return System.Text.Encoding.Unicode;
            }
            else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
            {
                return System.Text.Encoding.BigEndianUnicode;
            }
            else if (IsUTF8Bytes(buffer) || (buffer[0] == 0xEF && buffer[1] == 0xBB)) 
            {
                return System.Text.Encoding.UTF8;
            }
            else
            {
                return System.Text.Encoding.Default;
            }
        }

        public void ReadFile(string filePath)
        {
            string pattern = @"\[([\d]{2}:[\d]{2}\.[\d]{2})\]";
            string lineStr;

            lyricRecords.Clear();
            this.title = "";
            this.artist = "";
            this.album = "";

            if (!File.Exists(filePath)) return;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs, GetFileEncodeType(filePath));

                while (sr.Peek() != -1)
                {
                    lineStr = sr.ReadLine();
                    if(Regex.IsMatch(lineStr, pattern))
                    {
                        List<string> times = new List<string>();
                        string strs = lineStr;
                        //lyricRecords.Add(new LyricRecord(lineStr.Substring(1, 8), lineStr.Substring(10)));

                        times.Add(strs.Substring(1, 8));
                        strs = strs.Substring(10);
                        while(Regex.IsMatch(strs, pattern))
                        {
                            times.Add(strs.Substring(1, 8));
                            strs = strs.Substring(10);
                        }
                        foreach(string t in times)
                        {
                            lyricRecords.Add(new LyricRecord(t, strs));
                        }
                    }
                    else
                    {
                        string str = GetMatchValue(lineStr, "\\[ar:", "\\]");
                        if (str != "")
                        {
                            this.artist = str;
                        }
                        else if((str = GetMatchValue(lineStr, "\\[ti:", "\\]")) != "")
                        {
                            this.title = str;
                        }
                        else if((str = GetMatchValue(lineStr, "\\[al:", "\\]")) != "")
                        {
                            this.album = str;
                        }
                    }
                    
                }

                sr.Close();
                fs.Close();

                lyricRecords.Add(new LyricRecord("00:00.0", title==""?"Unknown" : title));
                lyricRecords.Add(new LyricRecord("00:00.1", artist == "" ? "Unknown Artist" : artist));
                lyricRecords.Add(new LyricRecord("00:00.2", album == "" ? "Unknown Album" : album));

                lyricRecords.Sort();
            }
        }

        public string GetMatchValue(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            if (rg.IsMatch(str))
            {
                return rg.Match(str).Value;
            }
            return "";
        }
    }
}
