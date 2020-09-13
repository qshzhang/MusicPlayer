namespace MusicPlayer
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.GMenu = new MusicPlayer.Controls.ucMenu();
            this.ucSongLyricSwitch = new MusicPlayer.Controls.ucSongAndLyricShow();
            this.ucVolCtrl = new MusicPlayer.Controls.ucVolPanel();
            this.ucPlayerHeadInfo = new MusicPlayer.Controls.ucPlayerHead();
            this.ucPlayerToolBar = new MusicPlayer.Controls.ucToolBar();
            this.ucBackPanel = new MusicPlayer.Controls.ucBackPanel();
            this.SuspendLayout();
            // 
            // GMenu
            // 
            this.GMenu.BackColor = System.Drawing.Color.Transparent;
            this.GMenu.BackgroundImage = global::MusicPlayer.Properties.Resources.backpanel_tran;
            this.GMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GMenu.Location = new System.Drawing.Point(-15, 0);
            this.GMenu.Name = "GMenu";
            this.GMenu.Size = new System.Drawing.Size(105, 54);
            this.GMenu.TabIndex = 9;
            this.GMenu.Visible = false;
            // 
            // ucSongLyricSwitch
            // 
            this.ucSongLyricSwitch.BackColor = System.Drawing.Color.Transparent;
            this.ucSongLyricSwitch.Location = new System.Drawing.Point(33, 113);
            this.ucSongLyricSwitch.Margin = new System.Windows.Forms.Padding(1);
            this.ucSongLyricSwitch.Name = "ucSongLyricSwitch";
            this.ucSongLyricSwitch.Size = new System.Drawing.Size(400, 180);
            this.ucSongLyricSwitch.TabIndex = 8;
            // 
            // ucVolCtrl
            // 
            this.ucVolCtrl.BackColor = System.Drawing.Color.Transparent;
            this.ucVolCtrl.Location = new System.Drawing.Point(235, 93);
            this.ucVolCtrl.Margin = new System.Windows.Forms.Padding(1);
            this.ucVolCtrl.Name = "ucVolCtrl";
            this.ucVolCtrl.Size = new System.Drawing.Size(193, 13);
            this.ucVolCtrl.TabIndex = 7;
            // 
            // ucPlayerHeadInfo
            // 
            this.ucPlayerHeadInfo.BackColor = System.Drawing.Color.Transparent;
            this.ucPlayerHeadInfo.Location = new System.Drawing.Point(62, 23);
            this.ucPlayerHeadInfo.Margin = new System.Windows.Forms.Padding(1);
            this.ucPlayerHeadInfo.Name = "ucPlayerHeadInfo";
            this.ucPlayerHeadInfo.Size = new System.Drawing.Size(333, 45);
            this.ucPlayerHeadInfo.TabIndex = 5;
            // 
            // ucPlayerToolBar
            // 
            this.ucPlayerToolBar.BackColor = System.Drawing.Color.Transparent;
            this.ucPlayerToolBar.Location = new System.Drawing.Point(62, 70);
            this.ucPlayerToolBar.Margin = new System.Windows.Forms.Padding(1);
            this.ucPlayerToolBar.Name = "ucPlayerToolBar";
            this.ucPlayerToolBar.Size = new System.Drawing.Size(333, 20);
            this.ucPlayerToolBar.TabIndex = 4;
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMenuBtn = true;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Margin = new System.Windows.Forms.Padding(1);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(463, 304);
            this.ucBackPanel.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(463, 304);
            this.Controls.Add(this.GMenu);
            this.Controls.Add(this.ucSongLyricSwitch);
            this.Controls.Add(this.ucVolCtrl);
            this.Controls.Add(this.ucPlayerHeadInfo);
            this.Controls.Add(this.ucPlayerToolBar);
            this.Controls.Add(this.ucBackPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ucBackPanel ucBackPanel;
        private Controls.ucToolBar ucPlayerToolBar;
        private Controls.ucPlayerHead ucPlayerHeadInfo;
        private Controls.ucVolPanel ucVolCtrl;
        private Controls.ucSongAndLyricShow ucSongLyricSwitch;
        private Controls.ucMenu GMenu;
    }
}

