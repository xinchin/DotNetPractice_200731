namespace Test_0805
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chapter1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.如何從文字檔讀取資料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.t001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHostIPDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chapter1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chapter1ToolStripMenuItem
            // 
            this.chapter1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.如何從文字檔讀取資料ToolStripMenuItem,
            this.fSToolStripMenuItem,
            this.t001ToolStripMenuItem,
            this.getHostIPDemoToolStripMenuItem,
            this.pingDemoToolStripMenuItem});
            this.chapter1ToolStripMenuItem.Name = "chapter1ToolStripMenuItem";
            this.chapter1ToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.chapter1ToolStripMenuItem.Text = "Chapter 1";
            this.chapter1ToolStripMenuItem.Click += new System.EventHandler(this.chapter1ToolStripMenuItem_Click);
            // 
            // 如何從文字檔讀取資料ToolStripMenuItem
            // 
            this.如何從文字檔讀取資料ToolStripMenuItem.Name = "如何從文字檔讀取資料ToolStripMenuItem";
            this.如何從文字檔讀取資料ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.如何從文字檔讀取資料ToolStripMenuItem.Text = "1-21 如何從文字檔讀取資料";
            this.如何從文字檔讀取資料ToolStripMenuItem.Click += new System.EventHandler(this.如何從文字檔讀取資料ToolStripMenuItem_Click);
            // 
            // fSToolStripMenuItem
            // 
            this.fSToolStripMenuItem.Name = "fSToolStripMenuItem";
            this.fSToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.fSToolStripMenuItem.Text = "FS";
            this.fSToolStripMenuItem.Click += new System.EventHandler(this.fSToolStripMenuItem_Click);
            // 
            // t001ToolStripMenuItem
            // 
            this.t001ToolStripMenuItem.Name = "t001ToolStripMenuItem";
            this.t001ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.t001ToolStripMenuItem.Text = "T001";
            this.t001ToolStripMenuItem.Click += new System.EventHandler(this.t001ToolStripMenuItem_Click);
            // 
            // getHostIPDemoToolStripMenuItem
            // 
            this.getHostIPDemoToolStripMenuItem.Name = "getHostIPDemoToolStripMenuItem";
            this.getHostIPDemoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.getHostIPDemoToolStripMenuItem.Text = "GetHostIPDemo";
            this.getHostIPDemoToolStripMenuItem.Click += new System.EventHandler(this.getHostIPDemoToolStripMenuItem_Click);
            // 
            // pingDemoToolStripMenuItem
            // 
            this.pingDemoToolStripMenuItem.Name = "pingDemoToolStripMenuItem";
            this.pingDemoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.pingDemoToolStripMenuItem.Text = "PingDemo";
            this.pingDemoToolStripMenuItem.Click += new System.EventHandler(this.pingDemoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 446);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chapter1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 如何從文字檔讀取資料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem t001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHostIPDemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingDemoToolStripMenuItem;
    }
}

