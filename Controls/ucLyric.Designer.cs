namespace MusicPlayer.Controls
{
    partial class ucLyric
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
            this.listLyricBox = new MusicPlayer.TransparentListBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // listLyricBox
            // 
            this.listLyricBox.BackColor = System.Drawing.Color.Transparent;
            this.listLyricBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLyricBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLyricBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listLyricBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listLyricBox.FormattingEnabled = true;
            this.listLyricBox.ItemHeight = 16;
            this.listLyricBox.Location = new System.Drawing.Point(0, 0);
            this.listLyricBox.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.listLyricBox.Name = "listLyricBox";
            this.listLyricBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listLyricBox.Size = new System.Drawing.Size(368, 193);
            this.listLyricBox.TabIndex = 0;
            this.listLyricBox.TextAllign = MusicPlayer.TransparentListBox.AllignMode.CENTER;
            this.listLyricBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listLyricBox_MouseDoubleClick);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel.Location = new System.Drawing.Point(114, 76);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(135, 20);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "未找到歌词，搜索？";
            this.linkLabel.Visible = false;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // ucLyric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MusicPlayer.Properties.Resources.backpanel_tran;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.listLyricBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucLyric";
            this.Size = new System.Drawing.Size(368, 193);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TransparentListBox listLyricBox;
        private System.Windows.Forms.LinkLabel linkLabel;
    }
}
