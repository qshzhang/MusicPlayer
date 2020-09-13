using MusicPlayer.Common;
using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.SongInfos
{
    class Mp3Info : SongInfo
    {
        public Mp3Info(string path)
        {
            SetSongInfo(path);
        }
        public override void SetSongInfo(string path)
        {
            GetMp3ID3V1Info(path);
            if (false == IsGetInfoSucc())
            {
                GetMp3ID3V2Info(path);
            }


            InitInfo(path);

            Duration = GetMusicTime(path);
        }

        private bool IsGetInfoSucc()
        {
            return Title != "" && Artist != "" && Album != "";
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


        private byte[] GetLast128(string FileName)
        {
            if (!File.Exists(FileName)) return null;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Stream stream = fs;
            stream.Seek(-128, SeekOrigin.End);
            const int seekPos = 128;
            int rl = 0;
            byte[] Info = new byte[seekPos];
            rl = stream.Read(Info, 0, seekPos);
            fs.Close();
            stream.Close();
            return Info;
        }

        

        private bool isAscii(byte hb, byte lb)
        {
            if (hb >= 0 && hb < 128 && lb >= 0 && lb < 128) return true;
            return false;
        }

        private bool isGBK(byte hb, byte lb)
        {
            if (hb >= 0xB0 && hb <= 0xF7 && lb >= 0xA1 && lb <= 0xFE) return true;
            if (hb == 0 && lb == 0) return true; 
            return false;
        }

        private bool isValidGBK(byte[] bt)
        {
            bool isValid = true;
            for(int i = 0;i < bt.Length/2; i++)
            {
                isValid = isAscii(bt[2 * i], bt[2 * i + 1]) || isGBK(bt[2 * i], bt[2 * i + 1]);
                if (isValid == false) return false;
            }

            return true;
        }

        //高字节范围：B0～F7
        //低字节范围：A1～FE
   
        private string ByteToString(byte[] b, EncodeType flag)
        {
            if (b == null) return "";
            //if (isValidGBK(b) == false) return "";

            Encoding enc;
            string str = "";
            if (flag == EncodeType.ISO88591 || flag == EncodeType.UTF8)
            {
                enc = Encoding.GetEncoding("UTF-8");
                str = enc.GetString(b);
            }
            else
            {
                byte[] arr;

                if (b.Length > 2 && ((b[0] == 0xfe && b[1] == 0xff) || (b[1] == 0xfe && b[0] == 0xff)))
                {
                    arr = new byte[b.Length - 2];
                    Array.Copy(b, 2, arr, 0, b.Length - 2);
                    enc = Encoding.GetEncoding("UTF-16");
                }
                else
                {
                    arr = b;
                    enc = Encoding.GetEncoding("GBK");
                }
                str = enc.GetString(arr);
            }
            
            string[] group = str.Split('\0');
            string ret = "";
            foreach(string s in group)
            {
                ret += s;
            }
            return ret;
        }

        private bool GetMp3ID3V1Info(string path)
        {
            //byte[] Info = GetLast128(path);
            byte[] Info = CommFunc.GetByteData(path, -128, 128);

            if (Info == null) return false;

            Tag = "" + (char)Info[0] + (char)Info[1] + (char)Info[2];

            if (Tag != "TAG") return false;

            //获取歌名（数组3-32）     
            byte[] bytTitle = new byte[30];//将歌名部分读到一个单独的数组中 
            Array.Copy(Info, 3, bytTitle, 0, 30);
            if(Title == "") Title = this.ByteToString(bytTitle, EncodeType.UTF16).Trim();
            //获取歌手名（数组33-62）     
            byte[] bytArtist = new byte[30];//将歌手名部分读到一个单独的数组中 
            Array.Copy(Info, 33, bytArtist, 0, 30);
            //Buffer.BlockCopy(Info, 33, dstArray, 0, srcArray.Length);
            if(Artist == "") Artist = this.ByteToString(bytArtist, EncodeType.UTF16).Trim();
            //获取唱片名（数组63-92）     
            byte[] bytAlbum = new byte[30];//将唱片名部分读到一个单独的数组中     
            Array.Copy(Info, 63, bytAlbum, 0, 30);
            if(Album == "") Album = this.ByteToString(bytAlbum, EncodeType.UTF16).Trim();
            //获取年 （数组93-96）    
            byte[] bytYear = new byte[4];//将年部分读到一个单独的数组中     
            Array.Copy(Info, 93, bytYear, 0, 4);
            Year = this.ByteToString(bytYear, EncodeType.UTF16).Trim();

            return true ;
        }

        private bool GetMp3ID3V2Info(string path)
        {
            byte[] Info = CommFunc.GetByteData(path, 0, 10);
            string tag = "" + (char)Info[0] + (char)Info[1] + (char)Info[2];
            if (tag != "ID3") return false;

            int tagSize = Info[6] << 21 | Info[7] << 14 | Info[8] << 7 | Info[9];

            byte[] frame = CommFunc.GetByteData(path, 10, tagSize);

            int index = 0, nameSize = 0;
            string type = "";
            while (index < frame.Length)
            {
                type = "" + (char)frame[index] + (char)frame[index + 1] + (char)frame[index + 2] + (char)frame[index + 3];
                index += 4;
                nameSize = frame[index] << 24 | frame[index + 1] << 16 | frame[index + 2] << 8 | frame[index + 3];
                if (nameSize == 0) return true;
                index += 4;
                index += 2;

                byte[] bt;

                switch (type)
                {
                    case "TIT2":
                        bt = new byte[nameSize - 1];
                        Array.Copy(frame, index + 1, bt, 0, nameSize - 1);
                        if(Title == "") Title = ByteToString(bt, (EncodeType)frame[index]);
                        break;
                    case "TPE1":
                        bt = new byte[nameSize - 1];
                        Array.Copy(frame, index + 1, bt, 0, nameSize - 1);
                        if(Artist == "") Artist = ByteToString(bt, (EncodeType)frame[index]);
                        break;
                    case "TPE2":
                        bt = new byte[nameSize - 1];
                        Array.Copy(frame, index + 1, bt, 0, nameSize - 1);
                        if (Artist == "") Artist = ByteToString(bt, (EncodeType)frame[index]);
                        break;
                    case "TALB":
                        bt = new byte[nameSize - 1];
                        Array.Copy(frame, index + 1, bt, 0, nameSize - 1);
                        if(Album == "") Album = ByteToString(bt, (EncodeType)frame[index]);
                        break;
                    case "TYER":
                        bt = new byte[nameSize];
                        Array.Copy(frame, index, bt, 0, nameSize);
                        Year = ByteToString(bt, 0);
                        break;
                    default:
                        break;
                }

                index += nameSize;
            }
            return true;
        }

        public enum EncodeType
        {
            ISO88591 = 0,
            UTF16 = 1,
            UTF16BE = 2,
            UTF8 = 3,
            GBK = 4,
        }

    }
}
