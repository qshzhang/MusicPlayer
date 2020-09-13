namespace MusicPlayer.Controls
{
    partial class ucSongListView
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
            this.panelBottom = new MusicPlayer.NewPanel();
            this.lbPageInfo = new System.Windows.Forms.Label();
            this.lbNextPage = new System.Windows.Forms.Label();
            this.lbPrevPage = new System.Windows.Forms.Label();
            this.songListView = new MusicPlayer.TransparentListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFilepath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.lbPageInfo);
            this.panelBottom.Controls.Add(this.lbNextPage);
            this.panelBottom.Controls.Add(this.lbPrevPage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 160);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(394, 23);
            this.panelBottom.TabIndex = 1;
            // 
            // lbPageInfo
            // 
            this.lbPageInfo.AutoSize = true;
            this.lbPageInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPageInfo.Location = new System.Drawing.Point(178, 1);
            this.lbPageInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPageInfo.Name = "lbPageInfo";
            this.lbPageInfo.Size = new System.Drawing.Size(27, 17);
            this.lbPageInfo.TabIndex = 2;
            this.lbPageInfo.Text = "0/0";
            // 
            // lbNextPage
            // 
            this.lbNextPage.AutoSize = true;
            this.lbNextPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNextPage.Location = new System.Drawing.Point(311, 1);
            this.lbNextPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNextPage.Name = "lbNextPage";
            this.lbNextPage.Size = new System.Drawing.Size(18, 17);
            this.lbNextPage.TabIndex = 1;
            this.lbNextPage.Text = "▶";
            this.lbNextPage.Click += new System.EventHandler(this.lbNextPage_Click);
            // 
            // lbPrevPage
            // 
            this.lbPrevPage.AutoSize = true;
            this.lbPrevPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrevPage.Location = new System.Drawing.Point(63, 1);
            this.lbPrevPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrevPage.Name = "lbPrevPage";
            this.lbPrevPage.Size = new System.Drawing.Size(18, 17);
            this.lbPrevPage.TabIndex = 0;
            this.lbPrevPage.Text = "◀";
            this.lbPrevPage.Click += new System.EventHandler(this.lbPrevPage_Click);
            // 
            // songListView
            // 
            this.songListView.BackColor = System.Drawing.Color.Transparent;
            this.songListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colArtist,
            this.colDuration,
            this.colSeq,
            this.colFilepath});
            this.songListView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.songListView.FullRowSelect = true;
            this.songListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.songListView.HideSelection = false;
            this.songListView.Location = new System.Drawing.Point(14, 13);
            this.songListView.MultiSelect = false;
            this.songListView.Name = "songListView";
            this.songListView.Scrollable = false;
            this.songListView.Size = new System.Drawing.Size(362, 128);
            this.songListView.TabIndex = 2;
            this.songListView.UseCompatibleStateImageBehavior = false;
            this.songListView.View = System.Windows.Forms.View.Details;
            this.songListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.songListView_MouseClick);
            this.songListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songListBox_MouseDoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 200;
            // 
            // colArtist
            // 
            this.colArtist.Text = "Artist";
            this.colArtist.Width = 100;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            this.colDuration.Width = 90;
            // 
            // colSeq
            // 
            this.colSeq.DisplayIndex = 4;
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 0;
            // 
            // colFilepath
            // 
            this.colFilepath.DisplayIndex = 3;
            this.colFilepath.Text = "FilePath";
            this.colFilepath.Width = 0;
            // 
            // ucSongListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MusicPlayer.Properties.Resources.backpanel_tran;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.songListView);
            this.Controls.Add(this.panelBottom);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucSongListView";
            this.Size = new System.Drawing.Size(394, 183);
            this.Load += new System.EventHandler(this.ucSongList_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private NewPanel panelBottom;
        private System.Windows.Forms.Label lbPageInfo;
        private System.Windows.Forms.Label lbNextPage;
        private System.Windows.Forms.Label lbPrevPage;
        private TransparentListView songListView;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader colFilepath;
        private System.Windows.Forms.ColumnHeader colSeq;
    }
}
