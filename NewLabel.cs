using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    class NewLabel : Label
    {
        public NewLabel()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor |
            //     ControlStyles.OptimizedDoubleBuffer |
            //     ControlStyles.AllPaintingInWmPaint |
            //     ControlStyles.UserPaint, true);
            //BackColor = System.Drawing.Color.Transparent;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲s
        }
    }
}
