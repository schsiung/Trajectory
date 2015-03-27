namespace Trajectory
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MI_FileContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_SysExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_EditContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_ViewContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_HelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_About = new System.Windows.Forms.ToolStripMenuItem();
            this.TSBar = new System.Windows.Forms.ToolStrip();
            this.mStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSysTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.split1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.mStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_FileContents,
            this.MI_EditContents,
            this.MI_ViewContents,
            this.MI_HelpContents});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1059, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MI_FileContents
            // 
            this.MI_FileContents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_FileOpen,
            this.MI_SysExit});
            this.MI_FileContents.Name = "MI_FileContents";
            this.MI_FileContents.Size = new System.Drawing.Size(58, 21);
            this.MI_FileContents.Text = "文件(&F)";
            // 
            // MI_FileOpen
            // 
            this.MI_FileOpen.Name = "MI_FileOpen";
            this.MI_FileOpen.Size = new System.Drawing.Size(118, 22);
            this.MI_FileOpen.Text = "打开(&O)";
            // 
            // MI_SysExit
            // 
            this.MI_SysExit.Name = "MI_SysExit";
            this.MI_SysExit.Size = new System.Drawing.Size(118, 22);
            this.MI_SysExit.Text = "退出(&X)";
            // 
            // MI_EditContents
            // 
            this.MI_EditContents.Name = "MI_EditContents";
            this.MI_EditContents.Size = new System.Drawing.Size(44, 21);
            this.MI_EditContents.Text = "编辑";
            // 
            // MI_ViewContents
            // 
            this.MI_ViewContents.Name = "MI_ViewContents";
            this.MI_ViewContents.Size = new System.Drawing.Size(44, 21);
            this.MI_ViewContents.Text = "视图";
            // 
            // MI_HelpContents
            // 
            this.MI_HelpContents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_About});
            this.MI_HelpContents.Name = "MI_HelpContents";
            this.MI_HelpContents.Size = new System.Drawing.Size(61, 21);
            this.MI_HelpContents.Text = "帮助(&H)";
            // 
            // MI_About
            // 
            this.MI_About.Name = "MI_About";
            this.MI_About.Size = new System.Drawing.Size(116, 22);
            this.MI_About.Tag = "关于";
            this.MI_About.Text = "关于(&A)";
            // 
            // TSBar
            // 
            this.TSBar.Location = new System.Drawing.Point(0, 25);
            this.TSBar.Name = "TSBar";
            this.TSBar.Size = new System.Drawing.Size(1059, 25);
            this.TSBar.TabIndex = 1;
            this.TSBar.Text = "toolStrip1";
            // 
            // mStatusStrip
            // 
            this.mStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSysTimer,
            this.split1,
            this.lblInfo});
            this.mStatusStrip.Location = new System.Drawing.Point(0, 551);
            this.mStatusStrip.Name = "mStatusStrip";
            this.mStatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mStatusStrip.Size = new System.Drawing.Size(1059, 22);
            this.mStatusStrip.TabIndex = 2;
            this.mStatusStrip.Text = "statusStrip1";
            // 
            // lblSysTimer
            // 
            this.lblSysTimer.Name = "lblSysTimer";
            this.lblSysTimer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSysTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1MinSize = 150;
            this.splitContainer.Panel2MinSize = 600;
            this.splitContainer.Size = new System.Drawing.Size(1059, 501);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // split1
            // 
            this.split1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.split1.Name = "split1";
            this.split1.Size = new System.Drawing.Size(4, 17);
            this.split1.Spring = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1059, 573);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mStatusStrip);
            this.Controls.Add(this.TSBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "轨迹实验系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mStatusStrip.ResumeLayout(false);
            this.mStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip TSBar;
        private System.Windows.Forms.ToolStripMenuItem MI_FileContents;
        private System.Windows.Forms.ToolStripMenuItem MI_EditContents;
        private System.Windows.Forms.ToolStripMenuItem MI_ViewContents;
        private System.Windows.Forms.ToolStripMenuItem MI_HelpContents;
        private System.Windows.Forms.ToolStripMenuItem MI_FileOpen;
        private System.Windows.Forms.ToolStripMenuItem MI_SysExit;
        private System.Windows.Forms.StatusStrip mStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblSysTimer;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem MI_About;
        private System.Windows.Forms.ToolStripStatusLabel split1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
    }
}

