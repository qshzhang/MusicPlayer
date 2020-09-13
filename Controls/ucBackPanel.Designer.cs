namespace MusicPlayer.Controls
{
    partial class ucBackPanel
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
            this.lbClose = new System.Windows.Forms.Label();
            this.lbMinWin = new System.Windows.Forms.Label();
            this.lbMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbClose
            // 
            this.lbClose.BackColor = System.Drawing.Color.Transparent;
            this.lbClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbClose.ForeColor = System.Drawing.Color.Black;
            this.lbClose.Location = new System.Drawing.Point(352, 5);
            this.lbClose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(20, 20);
            this.lbClose.TabIndex = 0;
            this.lbClose.Text = "X";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lbClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.lbClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lbMinWin
            // 
            this.lbMinWin.BackColor = System.Drawing.Color.Transparent;
            this.lbMinWin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMinWin.ForeColor = System.Drawing.Color.Black;
            this.lbMinWin.Location = new System.Drawing.Point(324, 5);
            this.lbMinWin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMinWin.Name = "lbMinWin";
            this.lbMinWin.Size = new System.Drawing.Size(20, 20);
            this.lbMinWin.TabIndex = 1;
            this.lbMinWin.Text = "↖";
            this.lbMinWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMinWin.Click += new System.EventHandler(this.lbMinWin_Click);
            this.lbMinWin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.lbMinWin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // lbMenu
            // 
            this.lbMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMenu.ForeColor = System.Drawing.Color.Black;
            this.lbMenu.Location = new System.Drawing.Point(296, 5);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(20, 20);
            this.lbMenu.TabIndex = 2;
            this.lbMenu.Text = "▼";
            this.lbMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMenu.Click += new System.EventHandler(this.lbMenu_Click);
            this.lbMenu.MouseEnter += new System.EventHandler(this.lbMenu_MouseEnter);
            this.lbMenu.MouseLeave += new System.EventHandler(this.lbMenu_MouseLeave);
            // 
            // ucBackPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.lbMinWin);
            this.Controls.Add(this.lbClose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucBackPanel";
            this.Size = new System.Drawing.Size(381, 229);
            this.Load += new System.EventHandler(this.ucBackPanel_Load);
            this.SizeChanged += new System.EventHandler(this.ucBackPanel_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucBackPanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label lbMinWin;
        private System.Windows.Forms.Label lbMenu;
    }
}
