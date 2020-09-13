namespace MusicPlayer.Controls
{
    partial class ucVolPanel
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
            this.ucVolProgBar = new MusicPlayer.Controls.ucProgressBar();
            this.volIconPanel = new System.Windows.Forms.Panel();
            this.volTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ucVolProgBar
            // 
            this.ucVolProgBar.BackColor = System.Drawing.Color.Transparent;
            this.ucVolProgBar.IsCanOperate = true;
            this.ucVolProgBar.Location = new System.Drawing.Point(22, 7);
            this.ucVolProgBar.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucVolProgBar.Name = "ucVolProgBar";
            this.ucVolProgBar.PanelBackBarColor = System.Drawing.Color.White;
            this.ucVolProgBar.PanelFloatBarColor = System.Drawing.Color.Black;
            this.ucVolProgBar.Size = new System.Drawing.Size(164, 4);
            this.ucVolProgBar.TabIndex = 1;
            // 
            // volIconPanel
            // 
            this.volIconPanel.BackgroundImage = global::MusicPlayer.Properties.Resources.vol_open;
            this.volIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volIconPanel.Location = new System.Drawing.Point(0, 0);
            this.volIconPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.volIconPanel.Name = "volIconPanel";
            this.volIconPanel.Size = new System.Drawing.Size(13, 13);
            this.volIconPanel.TabIndex = 0;
            this.volIconPanel.Click += new System.EventHandler(this.volIconPanel_Click);
            // 
            // ucVolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucVolProgBar);
            this.Controls.Add(this.volIconPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucVolPanel";
            this.Size = new System.Drawing.Size(201, 13);
            this.Load += new System.EventHandler(this.ucVolPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel volIconPanel;
        private ucProgressBar ucVolProgBar;
        private System.Windows.Forms.ToolTip volTip;
    }
}
