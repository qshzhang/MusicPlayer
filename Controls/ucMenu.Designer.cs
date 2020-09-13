namespace MusicPlayer.Controls
{
    partial class ucMenu
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
            this.lbExchangeSkin = new System.Windows.Forms.Label();
            this.lbDeskLyric = new System.Windows.Forms.Label();
            this.lbExchangeColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbExchangeSkin
            // 
            this.lbExchangeSkin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbExchangeSkin.Location = new System.Drawing.Point(0, 2);
            this.lbExchangeSkin.Name = "lbExchangeSkin";
            this.lbExchangeSkin.Size = new System.Drawing.Size(105, 23);
            this.lbExchangeSkin.TabIndex = 0;
            this.lbExchangeSkin.Text = "换肤";
            this.lbExchangeSkin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExchangeSkin.Click += new System.EventHandler(this.lbExchangeSkin_Click);
            this.lbExchangeSkin.MouseEnter += new System.EventHandler(this.lbExchangeSkin_MouseEnter);
            this.lbExchangeSkin.MouseLeave += new System.EventHandler(this.lbExchangeSkin_MouseLeave);
            // 
            // lbDeskLyric
            // 
            this.lbDeskLyric.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDeskLyric.Location = new System.Drawing.Point(0, 47);
            this.lbDeskLyric.Name = "lbDeskLyric";
            this.lbDeskLyric.Size = new System.Drawing.Size(105, 23);
            this.lbDeskLyric.TabIndex = 1;
            this.lbDeskLyric.Text = "桌面歌词";
            this.lbDeskLyric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDeskLyric.Click += new System.EventHandler(this.lbDeskLyric_Click);
            this.lbDeskLyric.MouseEnter += new System.EventHandler(this.lbDeskLyric_MouseEnter);
            this.lbDeskLyric.MouseLeave += new System.EventHandler(this.lbDeskLyric_MouseLeave);
            // 
            // lbExchangeColor
            // 
            this.lbExchangeColor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbExchangeColor.Location = new System.Drawing.Point(0, 25);
            this.lbExchangeColor.Name = "lbExchangeColor";
            this.lbExchangeColor.Size = new System.Drawing.Size(105, 23);
            this.lbExchangeColor.TabIndex = 2;
            this.lbExchangeColor.Text = "换色";
            this.lbExchangeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExchangeColor.Click += new System.EventHandler(this.lbExchangeColor_Click);
            this.lbExchangeColor.MouseEnter += new System.EventHandler(this.lbExchangeColor_MouseEnter);
            this.lbExchangeColor.MouseLeave += new System.EventHandler(this.lbExchangeColor_MouseLeave);
            // 
            // ucMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MusicPlayer.Properties.Resources.backpanel_tran;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbExchangeColor);
            this.Controls.Add(this.lbDeskLyric);
            this.Controls.Add(this.lbExchangeSkin);
            this.DoubleBuffered = true;
            this.Name = "ucMenu";
            this.Size = new System.Drawing.Size(105, 82);
            this.Load += new System.EventHandler(this.ucMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbExchangeSkin;
        private System.Windows.Forms.Label lbDeskLyric;
        private System.Windows.Forms.Label lbExchangeColor;
    }
}
