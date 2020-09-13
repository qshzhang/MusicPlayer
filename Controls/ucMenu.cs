using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Controls
{
    public partial class ucMenu : UserControl
    {
        public delegate void MenuItemClickEvent(string path);
        public MenuItemClickEvent OnSetBackImage;

        public delegate void MenuItemColorClickEvent(Color color);
        public MenuItemColorClickEvent OnSetBackColor;



        public ucMenu()
        {
            InitializeComponent();
        }

        private void lbExchangeSkin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "请选择文件夹";
            dialog.Filter = "图片文件|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;

                if (null != OnSetBackImage) OnSetBackImage(file);
            }
        }

        private void lbDeskLyric_Click(object sender, EventArgs e)
        {

        }

        private void lbExchangeSkin_MouseEnter(object sender, EventArgs e)
        {
            lbExchangeSkin.BackColor = Color.LightBlue;
        }

        private void lbExchangeSkin_MouseLeave(object sender, EventArgs e)
        {
            lbExchangeSkin.BackColor = Color.Transparent;
        }

        private void lbDeskLyric_MouseEnter(object sender, EventArgs e)
        {
            lbDeskLyric.BackColor = Color.LightBlue;
        }

        private void lbDeskLyric_MouseLeave(object sender, EventArgs e)
        {
            lbDeskLyric.BackColor = Color.Transparent;
        }

        private void lbExchangeColor_MouseEnter(object sender, EventArgs e)
        {
            lbExchangeColor.BackColor = Color.LightBlue;
        }

        private void lbExchangeColor_MouseLeave(object sender, EventArgs e)
        {
            lbExchangeColor.BackColor = Color.Transparent;
        }

        private void ucMenu_Load(object sender, EventArgs e)
        {
            this.Height = lbExchangeSkin.Height + lbDeskLyric.Height + lbExchangeColor.Height + 6;

            lbDeskLyric.Width = this.Width - 4;
            lbExchangeSkin.Width = this.Width - 4;
            lbExchangeColor.Width = this.Width - 4;

            lbExchangeSkin.Location = new Point(2, 2);
            lbExchangeColor.Location = new Point(2, lbExchangeSkin.Height + 2);
            lbDeskLyric.Location = new Point(2, lbExchangeSkin.Height + 2 + lbExchangeColor.Height + 2);
        }

        private void lbExchangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();

            if (colorDia.ShowDialog() == DialogResult.OK)
            {
                //获取所选择的颜色
                Color colorChoosed = colorDia.Color;
                if (null != OnSetBackColor) OnSetBackColor(colorChoosed);
            }
        }
    }
}
