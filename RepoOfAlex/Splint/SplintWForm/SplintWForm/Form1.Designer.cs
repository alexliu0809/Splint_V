namespace SplintWForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用Slpint生成本文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用Splint生成本项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用Splint整体分析项目文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出WordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TV_ProjectInfo = new System.Windows.Forms.TreeView();
            this.L_SourceFileName = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TB_DebugInfo = new System.Windows.Forms.TextBox();
            this.L_CodeLine = new System.Windows.Forms.Label();
            this.L_AnalysisResult = new System.Windows.Forms.Label();
            this.L_DebugInfo = new System.Windows.Forms.Label();
            this.TB_AnalyzeResult = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.生成ToolStripMenuItem,
            this.生成ToolStripMenuItem1,
            this.查看ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.打开项目ToolStripMenuItem});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            resources.ApplyResources(this.打开文件ToolStripMenuItem, "打开文件ToolStripMenuItem");
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 打开项目ToolStripMenuItem
            // 
            this.打开项目ToolStripMenuItem.Name = "打开项目ToolStripMenuItem";
            resources.ApplyResources(this.打开项目ToolStripMenuItem, "打开项目ToolStripMenuItem");
            this.打开项目ToolStripMenuItem.Click += new System.EventHandler(this.打开项目ToolStripMenuItem_Click);
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用Slpint生成本文件ToolStripMenuItem,
            this.用Splint生成本项目ToolStripMenuItem,
            this.用Splint整体分析项目文件ToolStripMenuItem});
            this.生成ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            resources.ApplyResources(this.生成ToolStripMenuItem, "生成ToolStripMenuItem");
            this.生成ToolStripMenuItem.Click += new System.EventHandler(this.生成ToolStripMenuItem_Click);
            // 
            // 用Slpint生成本文件ToolStripMenuItem
            // 
            this.用Slpint生成本文件ToolStripMenuItem.Name = "用Slpint生成本文件ToolStripMenuItem";
            resources.ApplyResources(this.用Slpint生成本文件ToolStripMenuItem, "用Slpint生成本文件ToolStripMenuItem");
            this.用Slpint生成本文件ToolStripMenuItem.Click += new System.EventHandler(this.用Slpint生成本文件ToolStripMenuItem_Click);
            // 
            // 用Splint生成本项目ToolStripMenuItem
            // 
            this.用Splint生成本项目ToolStripMenuItem.Name = "用Splint生成本项目ToolStripMenuItem";
            resources.ApplyResources(this.用Splint生成本项目ToolStripMenuItem, "用Splint生成本项目ToolStripMenuItem");
            this.用Splint生成本项目ToolStripMenuItem.Click += new System.EventHandler(this.用Splint生成本项目ToolStripMenuItem_Click);
            // 
            // 用Splint整体分析项目文件ToolStripMenuItem
            // 
            this.用Splint整体分析项目文件ToolStripMenuItem.Name = "用Splint整体分析项目文件ToolStripMenuItem";
            resources.ApplyResources(this.用Splint整体分析项目文件ToolStripMenuItem, "用Splint整体分析项目文件ToolStripMenuItem");
            this.用Splint整体分析项目文件ToolStripMenuItem.Click += new System.EventHandler(this.用Splint整体分析项目文件ToolStripMenuItem_Click);
            // 
            // 生成ToolStripMenuItem1
            // 
            this.生成ToolStripMenuItem1.BackColor = System.Drawing.Color.RoyalBlue;
            this.生成ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出WordToolStripMenuItem,
            this.生成报表ToolStripMenuItem});
            this.生成ToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.生成ToolStripMenuItem1.Name = "生成ToolStripMenuItem1";
            resources.ApplyResources(this.生成ToolStripMenuItem1, "生成ToolStripMenuItem1");
            // 
            // 导出WordToolStripMenuItem
            // 
            this.导出WordToolStripMenuItem.Name = "导出WordToolStripMenuItem";
            resources.ApplyResources(this.导出WordToolStripMenuItem, "导出WordToolStripMenuItem");
            this.导出WordToolStripMenuItem.Click += new System.EventHandler(this.导出WordToolStripMenuItem_Click);
            // 
            // 生成报表ToolStripMenuItem
            // 
            this.生成报表ToolStripMenuItem.Name = "生成报表ToolStripMenuItem";
            resources.ApplyResources(this.生成报表ToolStripMenuItem, "生成报表ToolStripMenuItem");
            this.生成报表ToolStripMenuItem.Click += new System.EventHandler(this.生成报表ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.历史版本ToolStripMenuItem});
            this.查看ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            resources.ApplyResources(this.查看ToolStripMenuItem, "查看ToolStripMenuItem");
            this.查看ToolStripMenuItem.Click += new System.EventHandler(this.查看ToolStripMenuItem_Click);
            // 
            // 历史版本ToolStripMenuItem
            // 
            this.历史版本ToolStripMenuItem.Name = "历史版本ToolStripMenuItem";
            resources.ApplyResources(this.历史版本ToolStripMenuItem, "历史版本ToolStripMenuItem");
            this.历史版本ToolStripMenuItem.Click += new System.EventHandler(this.历史版本ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            resources.ApplyResources(this.保存ToolStripMenuItem, "保存ToolStripMenuItem");
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            resources.ApplyResources(this.设置ToolStripMenuItem, "设置ToolStripMenuItem");
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // TV_ProjectInfo
            // 
            this.TV_ProjectInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TV_ProjectInfo.LineColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.TV_ProjectInfo, "TV_ProjectInfo");
            this.TV_ProjectInfo.Name = "TV_ProjectInfo";
            this.TV_ProjectInfo.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_ProjectInfo_NodeMouseDoubleClick);
            // 
            // L_SourceFileName
            // 
            resources.ApplyResources(this.L_SourceFileName, "L_SourceFileName");
            this.L_SourceFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.L_SourceFileName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_SourceFileName.Name = "L_SourceFileName";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            // 
            // TB_DebugInfo
            // 
            this.TB_DebugInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.TB_DebugInfo, "TB_DebugInfo");
            this.TB_DebugInfo.Name = "TB_DebugInfo";
            this.TB_DebugInfo.ReadOnly = true;
            // 
            // L_CodeLine
            // 
            resources.ApplyResources(this.L_CodeLine, "L_CodeLine");
            this.L_CodeLine.BackColor = System.Drawing.Color.Transparent;
            this.L_CodeLine.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.L_CodeLine.Name = "L_CodeLine";
            this.L_CodeLine.Click += new System.EventHandler(this.L_CodeLine_Click);
            // 
            // L_AnalysisResult
            // 
            resources.ApplyResources(this.L_AnalysisResult, "L_AnalysisResult");
            this.L_AnalysisResult.BackColor = System.Drawing.Color.Transparent;
            this.L_AnalysisResult.Name = "L_AnalysisResult";
            // 
            // L_DebugInfo
            // 
            resources.ApplyResources(this.L_DebugInfo, "L_DebugInfo");
            this.L_DebugInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.L_DebugInfo.Name = "L_DebugInfo";
            // 
            // TB_AnalyzeResult
            // 
            this.TB_AnalyzeResult.AcceptsReturn = true;
            this.TB_AnalyzeResult.AcceptsTab = true;
            this.TB_AnalyzeResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.TB_AnalyzeResult, "TB_AnalyzeResult");
            this.TB_AnalyzeResult.Name = "TB_AnalyzeResult";
            this.TB_AnalyzeResult.ReadOnly = true;
            this.TB_AnalyzeResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TB_AnalyzeResult_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TB_AnalyzeResult);
            this.Controls.Add(this.L_DebugInfo);
            this.Controls.Add(this.L_AnalysisResult);
            this.Controls.Add(this.L_CodeLine);
            this.Controls.Add(this.TB_DebugInfo);
            this.Controls.Add(this.L_SourceFileName);
            this.Controls.Add(this.TV_ProjectInfo);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用Slpint生成本文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用Splint生成本项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem1;
        private System.Windows.Forms.TreeView TV_ProjectInfo;
        private System.Windows.Forms.Label L_SourceFileName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TextBox TB_DebugInfo;
        private System.Windows.Forms.Label L_CodeLine;
        private System.Windows.Forms.Label L_AnalysisResult;
        private System.Windows.Forms.Label L_DebugInfo;
        private System.Windows.Forms.TextBox TB_AnalyzeResult;
        private System.Windows.Forms.ToolStripMenuItem 用Splint整体分析项目文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出WordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        //private ScintillaNET.Scintilla TB_CodeArea=new ScintillaNET.Scintilla();
    }
}

