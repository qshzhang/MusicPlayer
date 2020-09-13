namespace MusicPlayer.Controls
{
    partial class ucToolBar
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
            this.lbPrevSong = new System.Windows.Forms.Label();
            this.lbPause = new System.Windows.Forms.Label();
            this.lbNextSong = new System.Windows.Forms.Label();
            this.lbImportSong = new System.Windows.Forms.Label();
            this.lbStop = new System.Windows.Forms.Label();
            this.lbFavorite = new System.Windows.Forms.Label();
            this.lbLyric = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPrevSong
            // 
            this.lbPrevSong.BackColor = System.Drawing.Color.Transparent;
            this.lbPrevSong.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrevSong.Location = new System.Drawing.Point(29, 0);
            this.lbPrevSong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrevSong.Name = "lbPrevSong";
            this.lbPrevSong.Size = new System.Drawing.Size(27, 21);
            this.lbPrevSong.TabIndex = 1;
            this.lbPrevSong.Text = "◀|";
            this.lbPrevSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrevSong.Click += new System.EventHandler(this.lbPrevSong_Click);
            // 
            // lbPause
            // 
            this.lbPause.BackColor = System.Drawing.Color.Transparent;
            this.lbPause.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPause.Location = new System.Drawing.Point(56, 0);
            this.lbPause.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPause.Name = "lbPause";
            this.lbPause.Size = new System.Drawing.Size(27, 21);
            this.lbPause.TabIndex = 2;
            this.lbPause.Text = "▶";
            this.lbPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPause.Click += new System.EventHandler(this.lbPause_Click);
            // 
            // lbNextSong
            // 
            this.lbNextSong.BackColor = System.Drawing.Color.Transparent;
            this.lbNextSong.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNextSong.Location = new System.Drawing.Point(83, 0);
            this.lbNextSong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNextSong.Name = "lbNextSong";
            this.lbNextSong.Size = new System.Drawing.Size(27, 21);
            this.lbNextSong.TabIndex = 3;
            this.lbNextSong.Text = "|▶";
            this.lbNextSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNextSong.Click += new System.EventHandler(this.lbNextSong_Click);
            // 
            // lbImportSong
            // 
            this.lbImportSong.BackColor = System.Drawing.Color.Transparent;
            this.lbImportSong.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbImportSong.Location = new System.Drawing.Point(219, 0);
            this.lbImportSong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbImportSong.Name = "lbImportSong";
            this.lbImportSong.Size = new System.Drawing.Size(27, 25);
            this.lbImportSong.TabIndex = 4;
            this.lbImportSong.Text = "+";
            this.lbImportSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbImportSong.Click += new System.EventHandler(this.lbImportSong_Click);
            // 
            // lbStop
            // 
            this.lbStop.BackColor = System.Drawing.Color.Transparent;
            this.lbStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStop.Location = new System.Drawing.Point(2, 0);
            this.lbStop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStop.Name = "lbStop";
            this.lbStop.Size = new System.Drawing.Size(27, 21);
            this.lbStop.TabIndex = 5;
            this.lbStop.Text = "▣";
            this.lbStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStop.Click += new System.EventHandler(this.lbStop_Click);
            // 
            // lbFavorite
            // 
            this.lbFavorite.BackColor = System.Drawing.Color.Transparent;
            this.lbFavorite.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFavorite.Location = new System.Drawing.Point(192, 0);
            this.lbFavorite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFavorite.Name = "lbFavorite";
            this.lbFavorite.Size = new System.Drawing.Size(27, 21);
            this.lbFavorite.TabIndex = 6;
            this.lbFavorite.Text = "O";
            this.lbFavorite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFavorite.Click += new System.EventHandler(this.lbFavorite_Click);
            // 
            // lbLyric
            // 
            this.lbLyric.BackColor = System.Drawing.Color.Transparent;
            this.lbLyric.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLyric.Location = new System.Drawing.Point(165, -1);
            this.lbLyric.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLyric.Name = "lbLyric";
            this.lbLyric.Size = new System.Drawing.Size(27, 25);
            this.lbLyric.TabIndex = 7;
            this.lbLyric.Text = "词";
            this.lbLyric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLyric.Click += new System.EventHandler(this.lbLyric_Click);
            // 
            // ucToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbLyric);
            this.Controls.Add(this.lbFavorite);
            this.Controls.Add(this.lbStop);
            this.Controls.Add(this.lbImportSong);
            this.Controls.Add(this.lbNextSong);
            this.Controls.Add(this.lbPause);
            this.Controls.Add(this.lbPrevSong);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucToolBar";
            this.Size = new System.Drawing.Size(250, 25);
            this.Load += new System.EventHandler(this.ucToolBar_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbPrevSong;
        private System.Windows.Forms.Label lbPause;
        private System.Windows.Forms.Label lbNextSong;
        private System.Windows.Forms.Label lbImportSong;
        private System.Windows.Forms.Label lbStop;
        private System.Windows.Forms.Label lbFavorite;
        private System.Windows.Forms.Label lbLyric;
    }
}
