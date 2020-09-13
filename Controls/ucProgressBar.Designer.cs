namespace MusicPlayer.Controls
{
    partial class ucProgressBar
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
            this.panelBack = new System.Windows.Forms.Panel();
            this.panelFloat = new System.Windows.Forms.Panel();
            this.panelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.White;
            this.panelBack.Controls.Add(this.panelFloat);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(396, 89);
            this.panelBack.TabIndex = 0;
            this.panelBack.MouseEnter += new System.EventHandler(this.panelBack_MouseEnter);
            this.panelBack.MouseLeave += new System.EventHandler(this.panelBack_MouseLeave);
            this.panelBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBack_MouseMove);
            this.panelBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBack_MouseUp);
            // 
            // panelFloat
            // 
            this.panelFloat.BackColor = System.Drawing.Color.Black;
            this.panelFloat.Location = new System.Drawing.Point(0, 0);
            this.panelFloat.Name = "panelFloat";
            this.panelFloat.Size = new System.Drawing.Size(200, 86);
            this.panelFloat.TabIndex = 0;
            this.panelFloat.MouseEnter += new System.EventHandler(this.panelBack_MouseEnter);
            this.panelFloat.MouseLeave += new System.EventHandler(this.panelBack_MouseLeave);
            this.panelFloat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBack_MouseMove);
            this.panelFloat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBack_MouseUp);
            // 
            // ucProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelBack);
            this.Name = "ucProgressBar";
            this.Size = new System.Drawing.Size(396, 89);
            this.Load += new System.EventHandler(this.ucProgressBar_Load);
            this.panelBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Panel panelFloat;
    }
}
