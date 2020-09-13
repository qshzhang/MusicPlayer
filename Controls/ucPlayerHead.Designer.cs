namespace MusicPlayer.Controls
{
    partial class ucPlayerHead
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbSongTitle = new MusicPlayer.NewLabel();
            this.lbTime = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerTitle = new System.Windows.Forms.Timer(this.components);
            this.ucSongProgressBar = new MusicPlayer.Controls.ucProgressBar();
            this.SuspendLayout();
            // 
            // lbSongTitle
            // 
            this.lbSongTitle.AutoSize = true;
            this.lbSongTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSongTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbSongTitle.Location = new System.Drawing.Point(139, -1);
            this.lbSongTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSongTitle.Name = "lbSongTitle";
            this.lbSongTitle.Size = new System.Drawing.Size(65, 19);
            this.lbSongTitle.TabIndex = 1;
            this.lbSongTitle.Text = "暂无歌曲";
            this.lbSongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(257, 22);
            this.lbTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(75, 17);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "00:00/00:00";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Location = new System.Drawing.Point(2, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(33, 13);
            this.panelLeft.TabIndex = 3;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Location = new System.Drawing.Point(300, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(33, 13);
            this.panelRight.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerTitle
            // 
            this.timerTitle.Tick += new System.EventHandler(this.timerTitle_Tick);
            // 
            // ucSongProgressBar
            // 
            this.ucSongProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ucSongProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSongProgressBar.IsCanOperate = true;
            this.ucSongProgressBar.Location = new System.Drawing.Point(0, 43);
            this.ucSongProgressBar.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucSongProgressBar.Name = "ucSongProgressBar";
            this.ucSongProgressBar.PanelBackBarColor = System.Drawing.Color.White;
            this.ucSongProgressBar.PanelFloatBarColor = System.Drawing.Color.Black;
            this.ucSongProgressBar.Size = new System.Drawing.Size(333, 3);
            this.ucSongProgressBar.TabIndex = 5;
            // 
            // ucPlayerHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucSongProgressBar);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbSongTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucPlayerHead";
            this.Size = new System.Drawing.Size(333, 46);
            this.Load += new System.EventHandler(this.ucPlayerHead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NewLabel lbSongTitle;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerTitle;
        private ucProgressBar ucSongProgressBar;
    }
}
