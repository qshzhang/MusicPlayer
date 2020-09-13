namespace MusicPlayer.Controls
{
    partial class ucSongListBox
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbPageInfo = new System.Windows.Forms.Label();
            this.lbNextPage = new System.Windows.Forms.Label();
            this.lbPrevPage = new System.Windows.Forms.Label();
            this.songListBox = new MusicPlayer.TransparentListBox();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbPageInfo);
            this.panelBottom.Controls.Add(this.lbNextPage);
            this.panelBottom.Controls.Add(this.lbPrevPage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 218);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(591, 35);
            this.panelBottom.TabIndex = 1;
            // 
            // lbPageInfo
            // 
            this.lbPageInfo.AutoSize = true;
            this.lbPageInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPageInfo.Location = new System.Drawing.Point(267, 2);
            this.lbPageInfo.Name = "lbPageInfo";
            this.lbPageInfo.Size = new System.Drawing.Size(40, 24);
            this.lbPageInfo.TabIndex = 2;
            this.lbPageInfo.Text = "0/0";
            // 
            // lbNextPage
            // 
            this.lbNextPage.AutoSize = true;
            this.lbNextPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNextPage.Location = new System.Drawing.Point(466, 2);
            this.lbNextPage.Name = "lbNextPage";
            this.lbNextPage.Size = new System.Drawing.Size(22, 24);
            this.lbNextPage.TabIndex = 1;
            this.lbNextPage.Text = "▶";
            this.lbNextPage.Click += new System.EventHandler(this.lbNextPage_Click);
            // 
            // lbPrevPage
            // 
            this.lbPrevPage.AutoSize = true;
            this.lbPrevPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrevPage.Location = new System.Drawing.Point(95, 2);
            this.lbPrevPage.Name = "lbPrevPage";
            this.lbPrevPage.Size = new System.Drawing.Size(22, 24);
            this.lbPrevPage.TabIndex = 0;
            this.lbPrevPage.Text = "◀";
            this.lbPrevPage.Click += new System.EventHandler(this.lbPrevPage_Click);
            // 
            // songListBox
            // 
            this.songListBox.BackColor = System.Drawing.Color.Transparent;
            this.songListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.songListBox.FormattingEnabled = true;
            this.songListBox.ItemHeight = 16;
            this.songListBox.Location = new System.Drawing.Point(15, 16);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(563, 192);
            this.songListBox.TabIndex = 0;
            this.songListBox.TextAllign = MusicPlayer.TransparentListBox.AllignMode.LEFT;
            this.songListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songListBox_MouseDoubleClick);
            // 
            // ucSongList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MusicPlayer.Properties.Resources.backpanel_tran;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.songListBox);
            this.DoubleBuffered = true;
            this.Name = "ucSongList";
            this.Size = new System.Drawing.Size(591, 253);
            this.Load += new System.EventHandler(this.ucSongList_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TransparentListBox songListBox;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbPageInfo;
        private System.Windows.Forms.Label lbNextPage;
        private System.Windows.Forms.Label lbPrevPage;
    }
}
