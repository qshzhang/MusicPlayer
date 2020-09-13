using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicPlayer
{ 
    public class AppCfg
    {
        //public struct Config
        //{
        //    public int backImgType;
        //    public int vol;
        //    public string songPath;
        //    public bool isquiet;
        //}

        private const string AppCfgPath = "App.config";


        private int backImgType;
        private int vol;
        private List<string> songsPath = new List<string>();
        private bool isquiet;
        private bool isMiniWin;
        //private Config this;

        //public Config CfgParam { get => this; set => this = value; }

        public bool RemoveSongByIdx(int idx)
        {
            songsPath.RemoveAt(idx);
            return true;
        }

        public void SetVol(int rate)
        {
            this.vol = rate;
        }

        public void SetQuite(bool isQuiet)
        {
            this.isquiet = isQuiet;
        }

        public bool GetQuiet()
        {
            return this.isquiet;
        }

        public void SetMiniWin(bool isMini)
        {
            this.isMiniWin = isMini;
        }

        public bool GetMiniWin()
        {
            return this.isMiniWin;
        }

        public bool AddSongPath(string path)
        {
            foreach(string file in songsPath)
            {
                if (file.CompareTo(path) == 0) return false;
            }
            songsPath.Add(path);
            return true;
        }

        public int GetVol()
        {
            return this.vol;
        }

        public List<string> GetSongsPath()
        {
            //return this.songPath;
            return songsPath;
        }

        public void saveConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();

            //if (System.IO.File.Exists(AppCfgPath))
            //{
            //    xmlDoc.Load(AppCfgPath);
            //}
            //else
            //{
            //    XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            //    xmlDoc.AppendChild(dec);

            //    XmlElement root = xmlDoc.CreateElement("configuration"); 
            //    xmlDoc.AppendChild(root);

            //    XmlElement backimg = xmlDoc.CreateElement("backimg");
            //    backimg.InnerText = "0";
            //    root.AppendChild(backimg);

            //    XmlElement vol = xmlDoc.CreateElement("vol");
            //    vol.InnerText = "0";
            //    root.AppendChild(vol);

            //    XmlElement quiet = xmlDoc.CreateElement("quiet");
            //    quiet.InnerText = "0";
            //    //quiet.SetAttribute("id", "120");//设置id属性
            //    root.AppendChild(quiet);

            //    XmlElement songspath = xmlDoc.CreateElement("songstore");
            //    //songspath.InnerText = "0";
            //    root.AppendChild(songspath);
            //}

            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.AppendChild(dec);

            XmlElement root = xmlDoc.CreateElement("configuration");
            xmlDoc.AppendChild(root);

            XmlElement backimg = xmlDoc.CreateElement("backimg");
            backimg.InnerText = "0";
            root.AppendChild(backimg);

            XmlElement vol = xmlDoc.CreateElement("vol");
            vol.InnerText = "0";
            root.AppendChild(vol);

            XmlElement quiet = xmlDoc.CreateElement("quiet");
            quiet.InnerText = "0";
            //quiet.SetAttribute("id", "120");//设置id属性
            root.AppendChild(quiet);

            XmlElement miniwin = xmlDoc.CreateElement("miniwin");
            miniwin.InnerText = "0";
            //quiet.SetAttribute("id", "120");//设置id属性
            root.AppendChild(miniwin);

            XmlElement songspath = xmlDoc.CreateElement("songstore");
            //songspath.InnerText = "0";
            root.AppendChild(songspath);


            XmlNode xn = xmlDoc.SelectSingleNode("configuration");

            xn.SelectSingleNode("backimg").InnerText = this.backImgType.ToString();
            xn.SelectSingleNode("vol").InnerText = this.vol.ToString();
            xn.SelectSingleNode("quiet").InnerText = this.isquiet.ToString();
            xn.SelectSingleNode("miniwin").InnerText = this.isMiniWin.ToString();
            //xn.SelectSingleNode("songpath").InnerText = this.songPath;

            XmlNode songstore = xn.SelectSingleNode("songstore");
            foreach(string path in songsPath)
            {
                XmlElement xtsong = xmlDoc.CreateElement("song");
                songstore.AppendChild(xtsong);
                xtsong.InnerText = path;
            }

            xmlDoc.Save(AppCfgPath);
        }

        public void ReadConfig()
        {
            if(!System.IO.File.Exists(AppCfgPath))
            {
                this.backImgType = 0;
                this.vol = 50;
                this.songsPath = new List<string>();
                this.isquiet = false;
                this.isMiniWin = false;
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppCfgPath);

            XmlNode xn = xmlDoc.SelectSingleNode("configuration");


            this.backImgType = Convert.ToInt32(xn.SelectSingleNode("backimg").InnerText); ;
            this.vol = Convert.ToInt32(xn.SelectSingleNode("vol").InnerText);
            //this.songPath = xn.SelectSingleNode("songpath").InnerText;
            this.isquiet = Convert.ToBoolean(xn.SelectSingleNode("quiet").InnerText);

            try
            {
                this.isMiniWin = Convert.ToBoolean(xn.SelectSingleNode("miniwin").InnerText);
            }
            catch(Exception ex)
            {
                this.isMiniWin = false;
            }
            

            XmlNodeList nodeList = xn.SelectSingleNode("songstore").ChildNodes;
            foreach(XmlNode node in nodeList)
            {
                if(File.Exists(node.InnerText)) songsPath.Add(node.InnerText);
            }
        }
    }
}
