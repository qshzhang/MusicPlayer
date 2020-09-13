namespace MusicPlayer.Controls
{
    partial class ucSongAndLyricShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSongAndLyricShow));
            this.ucSongListView = new MusicPlayer.Controls.ucSongListView();
            this.ucLyrics = new MusicPlayer.Controls.ucLyric();
            this.timerLyricSwitch = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ucSongListView
            // 
            this.ucSongListView.BackColor = System.Drawing.Color.Transparent;
            this.ucSongListView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucSongListView.BackgroundImage")));
            this.ucSongListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucSongListView.Location = new System.Drawing.Point(27, 0);
            this.ucSongListView.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucSongListView.Name = "ucSongListView";
            this.ucSongListView.Size = new System.Drawing.Size(394, 183);
            this.ucSongListView.TabIndex = 0;
            // 
            // ucLyrics
            // 
            this.ucLyrics.BackColor = System.Drawing.Color.Transparent;
            this.ucLyrics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucLyrics.BackgroundImage")));
            this.ucLyrics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucLyrics.Location = new System.Drawing.Point(11, 19);
            this.ucLyrics.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucLyrics.Name = "ucLyrics";
            this.ucLyrics.Size = new System.Drawing.Size(371, 193);
            this.ucLyrics.TabIndex = 1;
            // 
            // timerLyricSwitch
            // 
            this.timerLyricSwitch.Interval = 1;
            this.timerLyricSwitch.Tick += new System.EventHandler(this.timerLyricSwitch_Tick);
            // 
            // ucSongAndLyricShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucSongListView);
            this.Controls.Add(this.ucLyrics);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucSongAndLyricShow";
            this.Size = new System.Drawing.Size(400, 180);
            this.Load += new System.EventHandler(this.ucSongAndLyricShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucSongListView ucSongListView;
        private ucLyric ucLyrics;
        private System.Windows.Forms.Timer timerLyricSwitch;
    }
}
