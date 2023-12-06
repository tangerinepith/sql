namespace MainInterface
{
    using LoginSpace;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using WindowsFormsApp3.EditorInterface;
    using WindowsFormsApp3.MainInterface;
    using WindowsFormsApp3.MemoryInterface;
    using WindowsFormsApp3.ProjectInterface;
    using WindowsFormsApp3.TermBaseInterface;
    using WindowsFormsApp3.WelcomeInterface;
    using Data = DataBaseLink.Data;
    using WinformControlLibraryExtension;
    using static WinformControlLibraryExtension.MaskingExt;
    using System.Threading;
    using System.Drawing;

    public class Interface : Form

    {
        private Panel panel1;
        private ButtonExt button5;
        private ButtonExt button4;
        private ButtonExt button3;
        private ButtonExt button2;
        private ButtonExt button1;
        //蒙版
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer1;
        private int timeNum = 0;                    //计时对象
        private int Time = 0;                       //展现蒙版时间
        
        //子界面
        private Welcome WelcomeInter = new Welcome();
        private Project ProjectInter = new Project();
        private Editor EditorInter = new Editor();
        private TermBase TermBaseInter = new TermBase();
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem CreateProjectToolStripMenuItem;
        private ToolStripMenuItem ImportProjectToolStripMenuItem;
        private ToolStripMenuItem SaveAsProjectToolStripMenuItem;
        private ToolStripMenuItem SaveProjectSToolStripMenuItem;
        private ToolStripMenuItem ImportTermBaseToolStripMenuItem;
        private ToolStripMenuItem ImportMemoryToolStripMenuItem;
        private ToolStripMenuItem ExportTransFileToolStripMenuItem;
        private ToolStripMenuItem itemSettingToolStripMenuItem;
        private ToolStripMenuItem settingMatchToolStripMenuItem;
        private ToolStripMenuItem importTermBaseToolStripMenuItem1;
        private ToolStripMenuItem importMemoryToolStripMenuItem1;
        private ToolStripMenuItem clearTermBaseToolStripMenuItem;
        private ToolStripMenuItem clearMemoryToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpInfoToolStripMenuItem;
        private ToolStripMenuItem aboutInfoToolStripMenuItem;
        private ToolStripMenuItem batchJobToolStripMenuItem;
        private ToolStripMenuItem calculateNumToolStripMenuItem;
        private ToolStripMenuItem addElementToolStripMenuItem;
        private ToolStripMenuItem addMemoryToolStripMenuItem;
        private ToolStripMenuItem addTermToolStripMenuItem;
        private ToolStripMenuItem translateFuncToolStripMenuItem;
        private ToolStripMenuItem matchTransToolStripMenuItem;
        private ToolStripMenuItem reTransToolStripMenuItem;
        private ToolStripMenuItem replaceTransToolStripMenuItem;
        private ToolStripMenuItem confirmTransToolStripMenuItem;
        private ToolStripMenuItem weightTermToolStripMenuItem;
        private ToolStripMenuItem importWeightTermToolStripMenuItem;
        private ToolStripMenuItem clearWeightsToolStripMenuItem;
        private ToolStripMenuItem addWeightsToolStripMenuItem;
        private ToolStripMenuItem changeWeightsToolStripMenuItem;
        private ToolStripMenuItem findWeightsToolStripMenuItem;
        private ToolStripMenuItem deleteWeightsToolStripMenuItem;
        private MyMenu.MLMenuStrip menuStrip1;
        private Memory MemoryInter = new Memory();
        
        private ToolStripMenuItem isMachineTranslationToolStripMenuItem;
        private ToolStripMenuItem SetSplitSymbolToolStripMenuItem; 
        
        //存储本窗体对象
        static private Interface OnlyInterface;

        static public Interface GetOnlyInterface
        {
            get
            {
                return OnlyInterface;
            }
            set
            {
                OnlyInterface = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Interface(string title)
		{
            this.Text = title;
			this.Visible = true;        //窗口可见

            //子界面初始化
            WelcomeInter.InitializeComponent();
            ProjectInter.InitializeComponent();
            EditorInter.InitializeComponent();
            TermBaseInter.InitializeComponent();
            MemoryInter.InitializeComponent();

            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(WelcomeInter.GetLeft);
            this.Controls.Add(WelcomeInter.Area);

            //对pictureBox重绘制区域
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(Welcome.WelcomePictureBox.ClientRectangle);
            Region region = new Region(gp);
            Welcome.WelcomePictureBox.Region = region;        //重新绘画选定区域
            gp.Dispose();
            region.Dispose();
        }

        public Interface()
        {
            this.Visible = true;        //窗口可见

            //子界面初始化
            WelcomeInter.InitializeComponent();
            ProjectInter.InitializeComponent();
            EditorInter.InitializeComponent();
            TermBaseInter.InitializeComponent();
            MemoryInter.InitializeComponent();

            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(WelcomeInter.GetLeft);
            this.Controls.Add(WelcomeInter.Area);
        }

        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new WinformControlLibraryExtension.ButtonExt();
            this.button4 = new WinformControlLibraryExtension.ButtonExt();
            this.button3 = new WinformControlLibraryExtension.ButtonExt();
            this.button2 = new WinformControlLibraryExtension.ButtonExt();
            this.button1 = new WinformControlLibraryExtension.ButtonExt();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProjectSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportTermBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportTransFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetSplitSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTermBaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importMemoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTermBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateNumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateFuncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isMachineTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importWeightTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new MyMenu.MLMenuStrip();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 249);
            this.panel1.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Animation.Options.AllTransformTime = 250D;
            this.button5.Animation.Options.Data = null;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button5.Font = new System.Drawing.Font("宋体", 10F);
            this.button5.Location = new System.Drawing.Point(0, 200);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 37);
            this.button5.TabIndex = 4;
            this.button5.Text = "记忆库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Animation.Options.AllTransformTime = 250D;
            this.button4.Animation.Options.Data = null;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button4.Font = new System.Drawing.Font("宋体", 10F);
            this.button4.Location = new System.Drawing.Point(1, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "术语库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Animation.Options.AllTransformTime = 250D;
            this.button3.Animation.Options.Data = null;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button3.Font = new System.Drawing.Font("宋体", 10F);
            this.button3.Location = new System.Drawing.Point(0, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "编辑器";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Animation.Options.AllTransformTime = 250D;
            this.button2.Animation.Options.Data = null;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button2.Font = new System.Drawing.Font("宋体", 10F);
            this.button2.Location = new System.Drawing.Point(0, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "项目";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Animation.Options.AllTransformTime = 250D;
            this.button1.Animation.Options.Data = null;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button1.Font = new System.Drawing.Font("宋体", 10F);
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "欢迎";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.AutoSize = false;
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateProjectToolStripMenuItem,
            this.ImportProjectToolStripMenuItem,
            this.SaveAsProjectToolStripMenuItem,
            this.SaveProjectSToolStripMenuItem,
            this.ImportTermBaseToolStripMenuItem,
            this.ImportMemoryToolStripMenuItem,
            this.ExportTransFileToolStripMenuItem});
            this.FileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // CreateProjectToolStripMenuItem
            // 
            this.CreateProjectToolStripMenuItem.Name = "CreateProjectToolStripMenuItem";
            this.CreateProjectToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.CreateProjectToolStripMenuItem.Text = "新建项目(&N)";
            this.CreateProjectToolStripMenuItem.Click += new System.EventHandler(this.CreateProjectToolStripMenuItem_Click);
            // 
            // ImportProjectToolStripMenuItem
            // 
            this.ImportProjectToolStripMenuItem.Name = "ImportProjectToolStripMenuItem";
            this.ImportProjectToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.ImportProjectToolStripMenuItem.Text = "导入项目(&A)";
            this.ImportProjectToolStripMenuItem.Click += new System.EventHandler(this.ImportProjectToolStripMenuItem_Click);
            // 
            // SaveAsProjectToolStripMenuItem
            // 
            this.SaveAsProjectToolStripMenuItem.Name = "SaveAsProjectToolStripMenuItem";
            this.SaveAsProjectToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.SaveAsProjectToolStripMenuItem.Text = "另存项目(&B)";
            this.SaveAsProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveAsProjectToolStripMenuItem_Click);
            // 
            // SaveProjectSToolStripMenuItem
            // 
            this.SaveProjectSToolStripMenuItem.Name = "SaveProjectSToolStripMenuItem";
            this.SaveProjectSToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.SaveProjectSToolStripMenuItem.Text = "保存项目(&S)";
            this.SaveProjectSToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectSToolStripMenuItem_Click);
            // 
            // ImportTermBaseToolStripMenuItem
            // 
            this.ImportTermBaseToolStripMenuItem.Name = "ImportTermBaseToolStripMenuItem";
            this.ImportTermBaseToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.ImportTermBaseToolStripMenuItem.Text = "导入术语库";
            this.ImportTermBaseToolStripMenuItem.Click += new System.EventHandler(this.ImportTermBaseToolStripMenuItem_Click);
            // 
            // ImportMemoryToolStripMenuItem
            // 
            this.ImportMemoryToolStripMenuItem.Name = "ImportMemoryToolStripMenuItem";
            this.ImportMemoryToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.ImportMemoryToolStripMenuItem.Text = "导入记忆库";
            this.ImportMemoryToolStripMenuItem.Click += new System.EventHandler(this.ImportMemoryToolStripMenuItem_Click);
            // 
            // ExportTransFileToolStripMenuItem
            // 
            this.ExportTransFileToolStripMenuItem.Name = "ExportTransFileToolStripMenuItem";
            this.ExportTransFileToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.ExportTransFileToolStripMenuItem.Text = "导出翻译文件";
            this.ExportTransFileToolStripMenuItem.Click += new System.EventHandler(this.ExportTransFileToolStripMenuItem_Click);
            // 
            // itemSettingToolStripMenuItem
            // 
            this.itemSettingToolStripMenuItem.AutoSize = false;
            this.itemSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingMatchToolStripMenuItem,
            this.SetSplitSymbolToolStripMenuItem,
            this.importTermBaseToolStripMenuItem1,
            this.importMemoryToolStripMenuItem1,
            this.clearTermBaseToolStripMenuItem,
            this.clearMemoryToolStripMenuItem});
            this.itemSettingToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.itemSettingToolStripMenuItem.Name = "itemSettingToolStripMenuItem";
            this.itemSettingToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.itemSettingToolStripMenuItem.Text = "项目设置";
            // 
            // settingMatchToolStripMenuItem
            // 
            this.settingMatchToolStripMenuItem.Name = "settingMatchToolStripMenuItem";
            this.settingMatchToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.settingMatchToolStripMenuItem.Text = "设置匹配度";
            this.settingMatchToolStripMenuItem.Click += new System.EventHandler(this.settingMatchToolStripMenuItem_Click);
            // 
            // SetSplitSymbolToolStripMenuItem
            // 
            this.SetSplitSymbolToolStripMenuItem.Name = "SetSplitSymbolToolStripMenuItem";
            this.SetSplitSymbolToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.SetSplitSymbolToolStripMenuItem.Text = "设置分隔符";
            this.SetSplitSymbolToolStripMenuItem.Click += new System.EventHandler(this.SetSplitSymbolToolStripMenuItem_Click);
            // 
            // importTermBaseToolStripMenuItem1
            // 
            this.importTermBaseToolStripMenuItem1.Name = "importTermBaseToolStripMenuItem1";
            this.importTermBaseToolStripMenuItem1.Size = new System.Drawing.Size(155, 26);
            this.importTermBaseToolStripMenuItem1.Text = "导入术语库";
            this.importTermBaseToolStripMenuItem1.Click += new System.EventHandler(this.importTermBaseToolStripMenuItem1_Click);
            // 
            // importMemoryToolStripMenuItem1
            // 
            this.importMemoryToolStripMenuItem1.Name = "importMemoryToolStripMenuItem1";
            this.importMemoryToolStripMenuItem1.Size = new System.Drawing.Size(155, 26);
            this.importMemoryToolStripMenuItem1.Text = "导入记忆库";
            this.importMemoryToolStripMenuItem1.Click += new System.EventHandler(this.importMemoryToolStripMenuItem1_Click);
            // 
            // clearTermBaseToolStripMenuItem
            // 
            this.clearTermBaseToolStripMenuItem.Name = "clearTermBaseToolStripMenuItem";
            this.clearTermBaseToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.clearTermBaseToolStripMenuItem.Text = "清空术语库";
            this.clearTermBaseToolStripMenuItem.Click += new System.EventHandler(this.clearTermBaseToolStripMenuItem_Click);
            // 
            // clearMemoryToolStripMenuItem
            // 
            this.clearMemoryToolStripMenuItem.Name = "clearMemoryToolStripMenuItem";
            this.clearMemoryToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.clearMemoryToolStripMenuItem.Text = "清空记忆库";
            this.clearMemoryToolStripMenuItem.Click += new System.EventHandler(this.clearMemoryToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.AutoSize = false;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpInfoToolStripMenuItem,
            this.aboutInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.helpToolStripMenuItem.Text = "帮助关于";
            // 
            // helpInfoToolStripMenuItem
            // 
            this.helpInfoToolStripMenuItem.Name = "helpInfoToolStripMenuItem";
            this.helpInfoToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.helpInfoToolStripMenuItem.Text = "帮助";
            this.helpInfoToolStripMenuItem.Click += new System.EventHandler(this.helpInfoToolStripMenuItem_Click);
            // 
            // aboutInfoToolStripMenuItem
            // 
            this.aboutInfoToolStripMenuItem.Name = "aboutInfoToolStripMenuItem";
            this.aboutInfoToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.aboutInfoToolStripMenuItem.Text = "关于";
            this.aboutInfoToolStripMenuItem.Click += new System.EventHandler(this.aboutInfoToolStripMenuItem_Click);
            // 
            // batchJobToolStripMenuItem
            // 
            this.batchJobToolStripMenuItem.AutoSize = false;
            this.batchJobToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateNumToolStripMenuItem});
            this.batchJobToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.batchJobToolStripMenuItem.Name = "batchJobToolStripMenuItem";
            this.batchJobToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.batchJobToolStripMenuItem.Text = "批任务";
            // 
            // calculateNumToolStripMenuItem
            // 
            this.calculateNumToolStripMenuItem.Name = "calculateNumToolStripMenuItem";
            this.calculateNumToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.calculateNumToolStripMenuItem.Text = "字数计算";
            this.calculateNumToolStripMenuItem.Click += new System.EventHandler(this.calculateNumToolStripMenuItem_Click);
            // 
            // addElementToolStripMenuItem
            // 
            this.addElementToolStripMenuItem.AutoSize = false;
            this.addElementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMemoryToolStripMenuItem,
            this.addTermToolStripMenuItem});
            this.addElementToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
            this.addElementToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.addElementToolStripMenuItem.Text = "添加元素";
            // 
            // addMemoryToolStripMenuItem
            // 
            this.addMemoryToolStripMenuItem.Name = "addMemoryToolStripMenuItem";
            this.addMemoryToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.addMemoryToolStripMenuItem.Text = "添加新译文";
            this.addMemoryToolStripMenuItem.Click += new System.EventHandler(this.addMemoryToolStripMenuItem_Click);
            // 
            // addTermToolStripMenuItem
            // 
            this.addTermToolStripMenuItem.Name = "addTermToolStripMenuItem";
            this.addTermToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.addTermToolStripMenuItem.Text = "添加新术语";
            this.addTermToolStripMenuItem.Click += new System.EventHandler(this.addTermToolStripMenuItem_Click);
            // 
            // translateFuncToolStripMenuItem
            // 
            this.translateFuncToolStripMenuItem.AutoSize = false;
            this.translateFuncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchTransToolStripMenuItem,
            this.reTransToolStripMenuItem,
            this.confirmTransToolStripMenuItem,
            this.replaceTransToolStripMenuItem,
            this.isMachineTranslationToolStripMenuItem});
            this.translateFuncToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.translateFuncToolStripMenuItem.Name = "translateFuncToolStripMenuItem";
            this.translateFuncToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.translateFuncToolStripMenuItem.Text = "翻译功能";
            // 
            // matchTransToolStripMenuItem
            // 
            this.matchTransToolStripMenuItem.Name = "matchTransToolStripMenuItem";
            this.matchTransToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.matchTransToolStripMenuItem.Text = "匹配翻译";
            this.matchTransToolStripMenuItem.Click += new System.EventHandler(this.matchTransToolStripMenuItem_Click);
            // 
            // reTransToolStripMenuItem
            // 
            this.reTransToolStripMenuItem.Name = "reTransToolStripMenuItem";
            this.reTransToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.reTransToolStripMenuItem.Text = "重新翻译";
            this.reTransToolStripMenuItem.Click += new System.EventHandler(this.reTransToolStripMenuItem_Click);
            // 
            // confirmTransToolStripMenuItem
            // 
            this.confirmTransToolStripMenuItem.Name = "confirmTransToolStripMenuItem";
            this.confirmTransToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.confirmTransToolStripMenuItem.Text = "确认翻译";
            this.confirmTransToolStripMenuItem.Click += new System.EventHandler(this.confirmTransToolStripMenuItem_Click);
            // 
            // replaceTransToolStripMenuItem
            // 
            this.replaceTransToolStripMenuItem.Name = "replaceTransToolStripMenuItem";
            this.replaceTransToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.replaceTransToolStripMenuItem.Text = "保存翻译";
            this.replaceTransToolStripMenuItem.Click += new System.EventHandler(this.replaceTransToolStripMenuItem_Click);
            // 
            // isMachineTranslationToolStripMenuItem
            // 
            this.isMachineTranslationToolStripMenuItem.Name = "isMachineTranslationToolStripMenuItem";
            this.isMachineTranslationToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.isMachineTranslationToolStripMenuItem.Text = "机器翻译";
            this.isMachineTranslationToolStripMenuItem.Click += new System.EventHandler(this.isMachineTranslationToolStripMenuItem_Click);
            // 
            // weightTermToolStripMenuItem
            // 
            this.weightTermToolStripMenuItem.AutoSize = false;
            this.weightTermToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importWeightTermToolStripMenuItem,
            this.clearWeightsToolStripMenuItem,
            this.addWeightsToolStripMenuItem,
            this.changeWeightsToolStripMenuItem,
            this.findWeightsToolStripMenuItem,
            this.deleteWeightsToolStripMenuItem});
            this.weightTermToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.weightTermToolStripMenuItem.Name = "weightTermToolStripMenuItem";
            this.weightTermToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.weightTermToolStripMenuItem.Text = "词汇权值";
            // 
            // importWeightTermToolStripMenuItem
            // 
            this.importWeightTermToolStripMenuItem.Name = "importWeightTermToolStripMenuItem";
            this.importWeightTermToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.importWeightTermToolStripMenuItem.Text = "导入词汇权值表";
            // 
            // clearWeightsToolStripMenuItem
            // 
            this.clearWeightsToolStripMenuItem.Name = "clearWeightsToolStripMenuItem";
            this.clearWeightsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.clearWeightsToolStripMenuItem.Text = "清空词汇权值表";
            // 
            // addWeightsToolStripMenuItem
            // 
            this.addWeightsToolStripMenuItem.Name = "addWeightsToolStripMenuItem";
            this.addWeightsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.addWeightsToolStripMenuItem.Text = "添加词汇权值";
            // 
            // changeWeightsToolStripMenuItem
            // 
            this.changeWeightsToolStripMenuItem.Name = "changeWeightsToolStripMenuItem";
            this.changeWeightsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.changeWeightsToolStripMenuItem.Text = "修改词汇权值";
            // 
            // findWeightsToolStripMenuItem
            // 
            this.findWeightsToolStripMenuItem.Name = "findWeightsToolStripMenuItem";
            this.findWeightsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.findWeightsToolStripMenuItem.Text = "查询词汇权值";
            // 
            // deleteWeightsToolStripMenuItem
            // 
            this.deleteWeightsToolStripMenuItem.Name = "deleteWeightsToolStripMenuItem";
            this.deleteWeightsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.deleteWeightsToolStripMenuItem.Text = "删除权值词汇";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 9F);
            this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.itemSettingToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.batchJobToolStripMenuItem,
            this.addElementToolStripMenuItem,
            this.translateFuncToolStripMenuItem,
            this.weightTermToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(103, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Interface
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(858, 569);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Interface_FormClosing);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        //添加公共组件
        private void addModule()
        {
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
        }

        //展现蒙版
        public void maskShow(int time)
        {
            this.Time = time;
            MaskingExt.Show(this, new MaskingExt.MaskingSettings() { TextOrientation = MaskingExt.MaskingTextOrientations.Right });
            this.timer1.Enabled = true;          //开始计时
        }

        
        //timer触发器
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeNum += timer1.Interval;
            if (this.timeNum >= this.Time)
            {
                //隐藏蒙版
                MaskingExt.Hide(this);
                this.timer1.Enabled = false;
                this.timeNum = 0;       //还原
            }
        }

        //欢迎按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(WelcomeInter.GetLeft);
            this.Controls.Add(WelcomeInter.Area);
            //Left.AutoScroll = true;
        }

        //项目按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(ProjectInter.GetLeft);
            this.Controls.Add(ProjectInter.Area);

        }

        //编辑器区域
        private void button3_Click(object sender, EventArgs e)
        {
            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(EditorInter.Left);
            this.Controls.Add(EditorInter.Area);

            //更新状态栏
        }

        //术语库区域
        private void button4_Click(object sender, EventArgs e)
        {
            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(TermBaseInter.Left);
            this.Controls.Add(TermBaseInter.Area);

            //重置术语库标记值
            TermBase.initLastTerm();
        }

        //记忆库区域
        private void button5_Click(object sender, EventArgs e)
        {
            //清除全部组件
            this.Controls.Clear();
            //添加公共组件
            this.addModule();
            //添加界面私有组件
            this.Controls.Add(MemoryInter.Left);
            this.Controls.Add(MemoryInter.Area);
        }

        //*******************************************菜单栏区域********************************
        //创建项目文件
        private void CreateProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ProjectInter.createProject();
        }
        //另存项目文件
        private void SaveAsProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                
                MessageBoxExt.Show(this, @"请先载入项目！", "另存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            // 
            // openFileDialog1
            // 
            saveFileDialog1.FileName = "Default.pb";
            saveFileDialog1.Filter = ".pb|*.pb";

            //成功打开
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String savePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);

                //启用子线程另存项目文件
                Thread ExportProjectThread = new Thread(new ParameterizedThreadStart(this.ExportProjectFile));
                ExportProjectThread.Start(savePath);                        //开启导出项目文件数据线程
            }
        }

        //保存项目文件
        private void SaveProjectSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "保存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //存储项目文件信息
            string[] projectInfo = Project.findFileHead();
            //另存为文件窗口 -- 选择文件
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            //存储路径
            String savePath = "";

            if (projectInfo[1].Length > 0)          //项目默认存储路径确认
                savePath = projectInfo[1];
            else                                    //无默认存储位置，则打开另存为窗口 - 是否需要修改默认存储路径？
            {
                // 
                // openFileDialog1
                // 
                saveFileDialog1.FileName = "Default.pb";
                saveFileDialog1.Filter = "项目文件.pb|*.pb";
                //成功打开另存为文件窗口
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //获取文件路径
                    savePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                }
            }

            string[] pathAndInfo = { savePath, projectInfo[0], projectInfo[2], projectInfo[3] };

            //开启子线程保存项目文件
            Thread SaveProjectThread = new Thread(new ParameterizedThreadStart(this.SaveProjectFile));
            SaveProjectThread.Start(pathAndInfo);                        //开启保存项目文件数据线程

        }

        //导入记忆库文件
        private void ImportMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "导入记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.txt";
            openFileDialog1.Filter = "翻译记忆库.txt|*.txt|翻译记忆库.xlsx|*.xlsx";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                string name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                name = name.Substring(name.Length - 6).ToLower();
                //设置打开模式
                if (!name.Contains(".txt"))
                {
                    Data.GetOpenMemory = true;           //设置为打开xlsx
                }

                //启用子线程加载数据至本地静态Map中
                Thread importMemoryThread = new Thread(new ParameterizedThreadStart(this.ImportMemory));
                importMemoryThread.Start(path);                        //开启导入记忆库数据线程
            }
        }
        
        //导入项目文件
        private void ImportProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.pb";
            openFileDialog1.Filter = "项目文件.pb|*.pb";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                string[] filestr = File.ReadAllLines(path, Encoding.UTF8);
                
                //未找到数据，返回
                if (filestr == null)
                {
                    MessageBoxExt.Show(this, @"该文件为空！", "导入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                //若干组数据
                string fileHead = Data.BinaryToString(filestr[0]);                //第一行文件头
                string savePath = Data.BinaryToString(filestr[1]);                //第二行项目文件保存路径
                string matchNum = Data.BinaryToString(filestr[2]);                  //匹配度
                string splitSymbol = Data.BinaryToString(filestr[3]);               //分隔符
                //初步检验项目文件头
                string[] check = fileHead.Split(' ');

                Editor.GetPreStartDate = MyLogin.admin.StartDate;      //存储原项目对象
                
                if (check.Length == 6 && Project.add(fileHead, savePath, int.Parse(matchNum), splitSymbol))
                {
                    MyLogin.admin.StartDate = check[4];                //导入项目对象
                    MessageBoxExt.Show(this, @"导入项目成功！", "导入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    Project pro = new Project();
                    pro.packageButton();                 //重新封装按钮
                }
                else if(check.Length != 6)
                {
                    MessageBoxExt.Show(this, @"项目文件头出错！", "导入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }
                else
                {
                    MessageBoxExt.Show(this, @"项目文件已导入！", "导入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                //开启子线程导入项目文件
                Thread ImportProjectThread = new Thread(new ParameterizedThreadStart(this.ImportProject));
                ImportProjectThread.Start(filestr);                        //开启导入项目文件数据线程
            }
        }

        //导入术语库文件
        private void ImportTermBaseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "导入术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.txt";
            openFileDialog1.Filter = "术语库.txt|*.txt|术语库.xlsx|*.xlsx";
            openFileDialog1.RestoreDirectory = true;

            //成功打开
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                string name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //设置打开模式
                if(!name.Substring(name.Length - 6).ToLower().Contains(".txt"))
                {
                    Data.GetOpenTermModel = true;           //设置为打开xlsx
                }

                //启用子线程加载数据至本地静态Map中
                //ThreadStart childref = new ThreadStart(Interface.GetOnlyInterface.ImportTerm(filestr));
                Thread importTermThread = new Thread(new ParameterizedThreadStart(this.ImportTerm));
                importTermThread.Start(path);                        //开启导入术语库数据线程
            }
        }

        //保存翻译文件
        private void ExportTransFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "保存翻译文件", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            // 
            // openFileDialog1
            // 
            saveFileDialog1.FileName = "Default";
            saveFileDialog1.Filter = "翻译文件.docx|*.docx|.txt|*.txt";

            //成功打开
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取导出翻译文件路径
                String savePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                string[] AllInfo = { savePath, "False" };            //默认导出Txt
                string name = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                //判断导出是Word还是Txt文件
                if(name.Substring(name.Length-6).ToLower().Contains(".docx"))
                {
                    AllInfo[1] = "True";            //导出Word
                }
                
                //开启子线程保存翻译文件
                Thread SaveTransFileThread = new Thread(new ParameterizedThreadStart(this.ExportTransFile));
                SaveTransFileThread.Start(AllInfo);                        //开启保存翻译文件数据线程
            }
                
        }
        //**************************************项目设置栏***********************************
        //设置匹配度
        private void settingMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "设置匹配度", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            SettingMatch match = new SettingMatch();
            match.Show();
        }

        //设置分隔符
        private void SetSplitSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setSplitSymbol symbol = new setSplitSymbol();
            symbol.Show();
        }

        //导入术语库
        private void importTermBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "导入术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.txt";
            openFileDialog1.Filter = "术语库.txt|*.txt|术语库.xlsx|*.xlsx";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                string name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //设置打开模式
                if (!name.Substring(name.Length - 6).ToLower().Contains(".txt"))
                {
                    Data.GetOpenTermModel = true;           //设置为打开xlsx
                }

                //启用子线程加载数据至本地静态Map中
                Thread importTermThread = new Thread(new ParameterizedThreadStart(this.ImportTerm));
                importTermThread.Start(path);                        //开启导入术语库数据线程
            }
        }

        //导入翻译记忆库
        private void importMemoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "导入翻译记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.txt";
            openFileDialog1.Filter = "翻译记忆库.txt|*.txt|翻译记忆库.xlsx|*.xlsx";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                string name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //设置打开模式
                if (!name.Substring(name.Length - 6).ToLower().Contains(".txt"))
                {
                    Data.GetOpenMemory = true;           //设置为打开xlsx
                }

                //启用子线程加载数据至本地静态Map中
                Thread importMemoryThread = new Thread(new ParameterizedThreadStart(this.ImportMemory));
                importMemoryThread.Start(path);                        //开启导入记忆库数据线程
            }
        }

        //清空术语库
        private void clearTermBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "清空术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //清空数据库函数
            if(TermBase.truncate())
            {
                TermBase.packageTermClear();            //清空所有界面
                MessageBoxExt.Show(this, @"清空术语库成功！", "清空术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        //清空记忆库
        private void clearMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "清空记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //清空数据库函数
            if(Memory.truncate())
            {
                MessageBoxExt.Show(this, @"清空记忆库成功！", "清空记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                Memory.packageMemoryClear();         //清空记忆库
            }
        }

        //*****************************************帮助关于栏*********************************
        //帮助
        private void helpInfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                //目前无法换成自己的网页
                System.Diagnostics.Process.Start("https://tangerinepith.github.io/wetrans.github.io/");
            }
            catch (Exception)
            {
                MessageBoxExt.Show(this, @"打开页面出错！", "帮助", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }

        }

        //关于
        private void aboutInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //添加新术语
        private void addTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "添加新术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            addTerm term = new addTerm();
            term.Show();
        }

        private void calculateNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "计算词汇数", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //字数计算
            else
            {
                UInt64 EnNum = 0;
                UInt64 ZnNum = 0;
                //将原文切割为若干词汇
                foreach (var str in Editor.GetTransMap)
                {
                    //英文
                    string En = str[0];
                    string Zn = str[1];
                    string[] temp = En.Split(' ');
                    EnNum += (UInt64)temp.Length;
                    ZnNum += (UInt64)Zn.Length;
                }
                MessageBoxExt.Show(this, "原文词汇数：" + EnNum.ToString() + "\n  中文字数：" + ZnNum.ToString(),
                    "计算词汇数", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        private void addMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "添加新译文", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //添加译文
            else
            {
                //未选中句对
                if(Editor.PreEnText == null || Editor.PreEnText.Text.Length == 0)
                {
                    MessageBoxExt.Show(this, @"请先选中句对！", "添加新译文", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                }
                else
                {
                    //选中句对存在译文
                    if (Editor.PreZnText.Text != null && Editor.PreZnText.Text.Length > 0)
                    {
                        //该译文在数据库内不存在
                        if (Memory.add(Editor.PreEnText.Text, Editor.PreZnText.Text))
                        {
                            MessageBoxExt.Show(this, @"添加译文成功！", "添加新译文", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                            string[] AllInfo = { Editor.PreEnText.Text, Editor.PreZnText.Text };
                            Memory.packageMemoryAdd(AllInfo);         //重新加载记忆库视图 - 添加句对
                        }
                        //添加失败
                        else
                        {
                            MessageBoxExt.Show(this, @"译文已存在！", "添加新译文", MessageBoxExtButtons.OK, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        }
                    }
                    //选中句对不存在译文 - 添加失败
                    else
                    {
                        MessageBoxExt.Show(this, @"该译文为空！", "添加新译文", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    }
                }
            }
        }
        
        //点击匹配翻译时
        private void matchTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "匹配翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            ThreadStart childref = new ThreadStart(MatchTransFunc);
            Thread transThread = new Thread(childref);
            transThread.Start();                        //开启翻译线程
        }

        //同步编辑器区域数据代理函数
        private delegate void DelegateSaveEditorContent();

        //同步编辑器区域代理函数调用
        public void SaveEditorContent()
        {
            if (this.IsHandleCreated)
            {
                //将编辑器区域数据进行同步，需要主线程操作，子线程不能访问主线程创建的控件
                this.Invoke(new DelegateSaveEditorContent(Editor.PreSaveContent));      //同步Text数据至Map，防止数据过时而重新翻译已存在信息的内容区域
            }
        }

        //匹配翻译功能线程执行函数 - 匹配功能函数内自动包含更新同步Map信息
        private void MatchTransFunc()
        {
            SaveEditorContent();        //同步编辑器区域内容函数
            //封装时，匹配翻译结果
            Editor.MatchTrans();        //可执行，线程不可执行非本线程创造的控件具体信息

            if (this.IsHandleCreated)
            {
                this.Invoke(new Editor.delegateFlushEditor(Editor.packageTextReplace));
            }
        }

        //重新翻译函数
        private void reTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "重新翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            if (Editor.PreEnText != null)
            {
                //英文、中文、匹配度
                string str = Editor.MatchSentence(Editor.PreEnText.Text);
                if(str != null)
                {
                    Editor.PreZnText.Text = str;
                    Editor.PreZnText.SelectionAlignment = HorizontalAlignment.Center;   //格式
                    Editor.PreState.Text = "";              //清除标记
                }
                //未找到
            }
            else
            {
                MessageBoxExt.Show(this, @"请先选中文本框！", "重新翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        //确认翻译函数
        private void confirmTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "确认翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            if (Editor.PreEnText != null)
            {
                //已经确认的，则取消确认选项
                if (Editor.PreState.Text.Equals("√") || Editor.PreState.Text.Length > 0)
                {
                    Editor.PreState.Text = "";
                }
                else if (Editor.PreZnText != null && Editor.PreZnText.Text.Length > 0)
                    Editor.PreState.Text = "√";
                else
                {
                    MessageBoxExt.Show(this, @"所选句对译文为空！", "确认翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    Editor.PreState.Text = "√";
                }
            }
            else
            {
                MessageBoxExt.Show(this, @"请先选中文本框！", "确认翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        //保存翻译功能：数据库文件
        private void replaceTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(this, @"请先载入项目！", "保存翻译", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //存储项目内容封装函数
            if(Editor.saveContentFunc())     //存储成功提示框
                MessageBoxExt.Show(this, @"存储成功！", "存储项目翻译信息", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //窗口关闭时
        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            //项目文本框经过改动
            if (Editor.GetIsChangeData)
            {
                DialogResult dr = MessageBoxExt.Show(this, @"项目已改动，是否保存？", "关闭窗口", MessageBoxExtButtons.OKCancel, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);

                if (dr == DialogResult.OK)
                {
                    //存储项目内容封装函数
                    Editor.saveContentFunc();
                }
            }
            
            Memory.InsertAllMemory(MyLogin.admin.StartDate);       //更新记忆库数据
            TermBase.InsertAllTerm(MyLogin.admin.StartDate);       //更新术语库数据
            //结束程序的运行
            Environment.Exit(0);
        }


        //*************************************子线程调用函数************************************
        //声明弹窗代理函数
        private delegate void DelegateMessageBox();

        //********************新建项目代理函数 - 从文本获取项目信息，存储至数据库
        public void CreateProject(object obj)
        {
            //数据获取
            string[] AllInfo = (string[])obj;
            string openPath = AllInfo[0];
            string fileHead = AllInfo[1];
            string savePath = AllInfo[2];
            //导入具体数据 - 多线程？
            List<string> filestr = Data.ReadContent(openPath);

            //将所有数据存入Temp，传入至Editor.addContent - 语句标点符号分割？ - .?!
            List<List<string>> temp = new List<List<string>>();

            if (filestr != null)
            {
                for (int i = 0; i < filestr.Count; i++)
                {
                    filestr[i] = filestr[i].Trim();
                    //将待翻译数据添加至数据库
                    if (filestr[i].Length != 0)
                    {
                        //中文和状态
                        List<string> ZS = new List<string>();
                        ZS.Add(filestr[i]);
                        ZS.Add("");
                        ZS.Add("0");

                        //重复值添加 - 顺序不变
                        temp.Add(ZS);
                    }
                }
            }
            //将数据传入TransMap字典集，并传入数据库
            Editor.addContent(temp);

            //将数据存入数据库
            if (Project.add(fileHead, savePath, 75, Data.GetSp))
            {
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示成功，刷新项目按钮
                    this.Invoke(new DelegateMessageBox(CreateProjectSuccess));
                }
            }
            else
            {
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示失败
                    this.Invoke(new DelegateMessageBox(CreateProjectError));
                }
            }
                
            //存储新项目文件完成后，还原原来的项目文件编号 - 运行的仍为原来的项目
            MyLogin.admin.StartDate = Editor.GetPreStartDate;
            //依据原文本框信息更新Map即可 - 保存新项目数据只会变动Map数据
            //Editor.PreSaveContent();            //重新同步Map信息
            Interface.GetOnlyInterface.SaveEditorContent();
        }

        //项目创建成功，并刷新项目按钮
        private void CreateProjectSuccess()
        {
            MessageBoxExt.Show(this, @"创建项目成功！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            Project pro = new Project();
            pro.packageButton();                //重新封装项目按钮
        }

        private void CreateProjectError()
        {
            MessageBoxExt.Show(this, @"创建项目失败！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //*********************开始工作按钮保存术语库和记忆库数据
        static AutoResetEvent threadLoadData = new AutoResetEvent(false);

        //开始工作 - 存储原项目术语库和记忆库信息，并导入新项目数据信息
        public void StoreTermMemory(object obj)
        {
            string[] oldAndNew = (string[])obj;
            string saveStartDate = oldAndNew[0];        //原项目编号
            string newStartDate = oldAndNew[1];         //新项目编号

            Memory.InsertAllMemory(saveStartDate);       //更新记忆库数据
            TermBase.InsertAllTerm(saveStartDate);       //更新术语库数据

            MyLogin.admin.StartDate = newStartDate;

            //获取数据至本地
            this.LoadData();                    //存储数据
        }


        //*********************所有数据获取至本地
        //声明代理函数
        private delegate void DelegateFlushAll();

        //子线程工作函数，将所有数据获取至本地
        public void LoadData()
        {
            //重置各个Map信息，意为开始新的项目
            Data.NAR(Editor.GetTransMap);
            Data.NAR(TermBase.GetTermMap);
            Data.NAR(Memory.GetSentenceMap);
            Editor.GetTransMap = new List<List<string>>();
            TermBase.GetTermMap = new Dictionary<string, List<string>>();
            Memory.GetSentenceMap = new Dictionary<string, string>();

            //将数据库内项目、记忆库、术语库信息存储至本地静态列表
            Editor.getAllContent();
            Memory.getSentenceFromDatabase();
            TermBase.getTermFromDatabase();

            //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
            if (this.IsHandleCreated)
            {
                //委托主线程完成封装
                this.Invoke(new DelegateFlushAll(FlushAll));
            }
        }

        //刷新所有界面数据
        private void FlushAll()
        {
            //清空编辑器区域全部面板 
            Editor.packageTextDelete();         //清空Editor面板，防止GetTransMap调用之后获取旧数据
            //如果总量大于1W，增加1s蒙版（依据总量设置蒙版时间）
            UInt64 total = (UInt64)Editor.GetTransMap.Count * 3 + (UInt64)TermBase.GetTermMap.Count + (UInt64)Memory.GetSentenceMap.Count * 2;
            this.maskShow((int)((float)total / 1500 * 1000));     //总封装数目/1500 S  
            //刷新编辑器、术语库和记忆库界面

            Editor.packageText();
            TermBase.packagingTerm();
            Memory.packageMemory();
            MessageBoxExt.Show(null, @"载入项目成功！", "载入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }


        //*****************************导入术语库
        //声明代理函数
        private delegate void DelegateAddTermButton(object obj);
        //private delegate void DelegateAddTermButton2(object En);

        //子线程工作函数，导入术语库至本地Map
        public void ImportTerm(object obj)
        {
            string Path = (string)obj;
            Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
            //获取文件信息 - Excel、Txt
            try
            {
                temp = Data.openTermBase(Path);
            }
            catch(Exception)
            {
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗
                    this.Invoke(new DelegateMessageBox(LoadTermBaseError));
                }
            }
            

            if(temp != null)
            {
                foreach (var dic in temp)
                {
                    //写入本地Map中，并增加依次按键
                    if (TermBase.add(dic.Key, dic.Value[0], dic.Value[1]))          //导入该术语成，添加新按钮
                    {
                        if (this.IsHandleCreated)
                        {
                            string[] AllInfo = { dic.Key, dic.Value[0], dic.Value[1] };
                            //委托主线程添加术语按钮
                            this.Invoke(new DelegateAddTermButton(TermBase.packageTermAddButton),
                                new Object[] { AllInfo });
                        }
                    }
                }
            }

            if (this.IsHandleCreated)
            {
                //委托主线程弹窗
                this.Invoke(new DelegateMessageBox(LoadTermBaseSuccess));
            }
            Data.NAR(temp);        //释放内存
        }

        //导入项目时附带的术语库
        public void saveTerm(object obj)
        {
            string[] filestr = (string[]) obj;          //强转obj参数

            string saveStartDate = "";                  //存储项目编号
            Dictionary<string, List<string>> tempTermMap = TermBase.GetTermMap;     //保存术语库现场信息
            int i = 0;          //遍历数据下标
            bool flagRecover = false;                          //是否需要恢复现场（导入项目中存在术语库特殊情况）
            if(filestr[0].Equals("#####True#####"))            //需要保存
            {
                i = 2;          //数据项为第二项
                saveStartDate = filestr[1];
                flagRecover = true;

                //清空原术语库现场
                Data.NAR(TermBase.GetTermMap);
                TermBase.GetTermMap = new Dictionary<string, List<string>>();       
            }

            //导入术语库
            //若干组数据
            for ( ; i < filestr.Length; i++)
            {
                bool flag = false;              //辨别是否经过空格
                bool Flag = false;              //是否为Exp
                string str = "";                //英文
                string Zn = "";
                string Exp = "";
                if (filestr[i] == null || filestr[i].Length == 0) continue;        //没有数据，读取下一个

                for (int j = 0; j < filestr[i].Length; j++)
                {
                    if (filestr[i][j] >= 'a' && filestr[i][j] <= 'z' || filestr[i][j] >= 'A' && filestr[i][j] <= 'Z')
                    {
                        if (flag)                //刚刚经过空格
                        {
                            str += " ";
                            flag = false;
                            if (filestr[i][j] >= 'a' && filestr[i][j] <= 'z') str += (char)(filestr[i][j] - 'a' + 'A');   //空格后首字母大写
                            else str += filestr[i][j];
                        }
                        else str += filestr[i][j];
                    }
                    else if (filestr[i][j] == ' ' || filestr[i][j] == '\t')      //空格、Tab
                    {
                        flag = true;                //空格
                        if (Zn.Length > 0)
                            Flag = true;            //解释部分

                    }
                    else      //中文
                    {
                        if (Flag)
                            Exp += filestr[i][j];
                        else
                            Zn += filestr[i][j];
                    }
                }
                //写入本地Map中 -- 交给对应模块
                if(TermBase.add(str, Zn, Exp) && !flagRecover)          //导入该术语成，添加新按钮
                {
                    if (this.IsHandleCreated)
                    {
                        string[] AllInfo = { str, Zn, Exp };
                        //委托主线程添加术语按钮
                        this.Invoke(new DelegateAddTermButton(TermBase.packageTermAddButton),
                            new Object[] { AllInfo });
                    }
                }
            }

            //恢复现场 - 导入项目，无需弹窗导入术语库成功
            if(flagRecover)
            {
                //存储操作 - 存储至数据库
                TermBase.InsertAllTerm(saveStartDate);

                TermBase.GetTermMap = tempTermMap;                           //恢复术语库现场
            }
            //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
            else if (this.IsHandleCreated)
            {
                //委托主线程完成封装
                this.Invoke(new DelegateMessageBox(LoadTermBaseSuccess));
            }
        }

        //主线程弹出导入术语库成功窗口
        private void LoadTermBaseSuccess()
        {
            MessageBoxExt.Show(this, @"导入术语库成功！", "导入术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        private void LoadTermBaseError()
        {
            MessageBoxExt.Show(this, @"导入术语库失败！", "导入术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //*****************************导入记忆库
        //声明代理函数
        private delegate void DelegatePackageMemoryAdd(object obj);

        //子线程工作函数，导入记忆库至本地Map
        public void ImportMemory(object obj)
        {
            string path = (string)obj;
            Dictionary<string, string> temp = Data.openMemoryFile(path);

            if(temp != null)
            {
                foreach(var dic in temp)
                {
                    //添加数据至Map，并更新控件
                    if (Memory.add(dic.Key, dic.Value))
                    {
                        string[] AllInfo = { dic.Key, dic.Value };
                        //委托主线程更新记忆库画面 - 添加句对
                        if (this.IsHandleCreated)
                            this.Invoke(new DelegatePackageMemoryAdd(Memory.packageMemoryAdd), new Object[] { AllInfo });
                    }
                }
            }

            if (this.IsHandleCreated)
            {
                //委托主线程弹窗提示已完成导入
                this.Invoke(new DelegateMessageBox(LoadMemorySuccess));
            }
        }

        //导入项目时保存记忆库信息至数据库
        public void saveMemory(object obj)
        {
            string[] filestr = (string[])obj;       //强转object对象至filestr
            string saveStartDate = "";              //存储项目编号
            Dictionary<string, string> tempMap = Memory.GetSentenceMap;           //保存记忆库现场信息

            int i = 0;          //遍历数据下标
            bool flagRecover = false;                          //是否需要恢复现场（导入项目中存在术语库特殊情况）
            if (filestr[0].Equals("#####True#####"))            //需要保存
            {
                i = 2;          //数据项为第二项

                saveStartDate = filestr[1];     //存储路径为第一项
                flagRecover = true;

                //清空原记忆库内容
                Data.NAR(Memory.GetSentenceMap);
                Memory.GetSentenceMap = new Dictionary<string, string>();           
            }


            //若干组数据
            string str = "";                //英文
            string Zn = "";
            for (; i < filestr.Length; i++)
            {
                if (filestr[i] == null || filestr[i].Length == 0) continue;

                if (i % 2 == 0)                  //奇数行英文
                {
                    str += filestr[i];          //英文
                }
                else
                {
                    Zn += filestr[i];           //中文
                                                //偶数行时写入数据库
                    if(Memory.add(str, Zn) && !flagRecover)     //插入成功 - 添加控件至记忆库界面；非导入项目时更新记忆库界面
                    {
                        string[] AllInfo = { str, Zn };
                        //委托主线程更新记忆库画面 - 添加句对
                        if (this.IsHandleCreated)
                            this.Invoke(new DelegatePackageMemoryAdd(Memory.packageMemoryAdd), new Object[] { AllInfo });
                    }
                    str = "";                   //恢复
                    Zn = "";
                }
            }

            //恢复现场 - 导入项目，无需弹窗导入记忆库成功
            if (flagRecover)
            {
                //存储操作 - 存储至数据库
                Memory.InsertAllMemory(saveStartDate);

                Memory.GetSentenceMap = tempMap;                   //恢复Map现场
            }
            //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
            else if (this.IsHandleCreated)
            {
                //委托主线程弹窗提示已完成导入
                this.Invoke(new DelegateMessageBox(LoadMemorySuccess));
            }
        }

        //通知导入成功
        private void LoadMemorySuccess()
        {
            //主线程弹窗提示导入成功
            MessageBoxExt.Show(this, @"导入记忆库成功！", "导入记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }


        //***********************另存项目文件

        //子线程工作函数，另存项目文件
        public void ExportProjectFile(object obj)
        {
            try
            {
                string savePath = (string)obj;
                //截断文本文件
                FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                fs.Close();

                string[] projectInfo = Project.findFileHead();

                //所有待输出至项目文件中内容
                List<string> res = new List<string>();
                //写入文件头 - 查找文件头
                res.Add(projectInfo[0]);
                //写入该项目默认存储路径 - 是否需要更新数据库内默认存储信息？还是在导入时更新？
                res.Add(savePath);
                //匹配度
                res.Add(projectInfo[2]);
                //分隔符
                res.Add(projectInfo[3]);

                //数据在选定开始工作时即锁定 - 导出待翻译数据
                foreach (var str in Editor.GetTransMap)
                {
                    //勾选状态 - 0表示未勾选，1表示勾选
                    res.Add(str[2]);
                    // 1 表示 有该行结果， 0表示该行无结果，依据#符号进行文本分割
                    if (str[0].Length > 0)
                        res.Add("1#" + str[0]);
                    else
                        res.Add("0#" + str[0]);

                    if (str[1].Length > 0)
                        res.Add("1#" + str[1]);
                    else
                        res.Add("0#" + str[1]);
                }

                string[] AllInfo = { "True", savePath };            //不弹出显示术语库和记忆库导出信息

                //导出术语库
                res.Add("##############################");
                Data.WriteToProjectFile(savePath, res);             //输出至项目文件
                ExportTerm(AllInfo);

                res = null;
                res = new List<string>();
                //导出记忆库
                res.Add("##############################");
                Data.WriteToProjectFile(savePath, res);             //输出至项目文件
                ExportMemory(AllInfo);

                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportProjectSucceedMessageBox));
                }
            }
            catch (Exception)
            {
                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportProjectErrorMessageBox));
                }
            }
        }

        //根据传参弹出导出项目消息框
        private void ExportProjectSucceedMessageBox()
        {
            MessageBoxExt.Show(this, @"导出项目文件成功！", "另存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //根据传参弹出导出项目消息框
        private void ExportProjectErrorMessageBox()
        {
            MessageBoxExt.Show(this, @"导出项目文件失败！", "另存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }



        //***********************保存项目文件

        //子线程工作函数，保存项目文件
        public void SaveProjectFile(object obj)
        {
            //执行保存本项目所有项目文件操作
            try
            {
                string[] pathAndInfo = (string[])obj;
                string savePath = pathAndInfo[0];
                string projectInfo = pathAndInfo[1];
                string matchingNum = pathAndInfo[2];
                string splitSymbol = pathAndInfo[3];
                //截断文本文件
                FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                fs.Close();

                List<string> res = new List<string>();
                //写入文件头 - 查找文件头
                res.Add(projectInfo);
                //写入该项目默认存储路径 - 是否需要更新数据库内默认存储信息？还是在导入时更新？
                res.Add(savePath);
                //匹配度
                res.Add(matchingNum);
                //分隔符
                res.Add(splitSymbol);

                //数据在选定开始工作时即锁定
                foreach (var str in Editor.GetTransMap)
                {
                    //勾选状态 - 0表示未勾选，1表示勾选
                    res.Add(str[2]);
                    // 1 表示 有该行结果， 0表示该行无结果，依据#符号进行文本分割
                    if (str[0].Length > 0)
                        res.Add("1#" + str[0]);
                    else
                        res.Add("0#" + str[0]);
                    //Zn
                    if (str[1].Length > 0)
                        res.Add("1#" + str[1]);
                    else
                        res.Add("0#" + str[1]);
                }

                string[] AllInfo = { "True", savePath };            //不弹出显示术语库和记忆库导出信息

                //导出术语库
                res.Add("##############################");
                Data.WriteToProjectFile(savePath, res);             //输出至项目文件
                ExportTerm(AllInfo);

                res = null;
                res = new List<string>();
                //导出记忆库
                res.Add("##############################");
                Data.WriteToProjectFile(savePath, res);             //输出至项目文件   
                ExportMemory(AllInfo);

                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(SaveProjectSucceedMessageBox));
                }
            }
            catch (Exception)
            {
                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(SaveProjectErrorMessageBox));
                }
            }
        }

        //根据传参弹出保存项目消息框
        private void SaveProjectSucceedMessageBox()
        {
            MessageBoxExt.Show(this, @"保存项目文件成功！", "保存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //根据传参弹出保存项目消息框
        private void SaveProjectErrorMessageBox()
        {
            MessageBoxExt.Show(this, @"保存项目文件失败！", "保存项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }


        //*****************************导入项目文件
        //子线程工作函数，导入术语库至本地Map
        public void ImportProject(object obj)
        {
            string[] filestr = (string[])obj;       //强转参数
            //将所有数据存入Temp，传入至Editor.addContent
            List<List<string>> temp = new List<List<string>>();

            //仅存在文件头，则插入空数据，创建数据库表
            if (filestr.Length < 5)
            {
                string en = "";
                List<string> ZS = new List<string>();
                ZS.Add(en);
                ZS.Add("");
                ZS.Add("0");

                temp.Add(ZS);
            }

            string En = "";
            string Zn = "";
            string state = "";
            int i;          //遍历指针
            //项目数据处理
            for (i = 4; i < filestr.Length; i++)
            {
                filestr[i] = Data.BinaryToString(filestr[i]);       //将获取的二进制数据转为string
                if ((i - 4) % 3 == 0)                  //第一行 - 状态
                {
                    if (filestr[i].Equals("##############################"))   //检测到术语库区域，则第i行为术语库，i+1行开始输入术语库
                        break;
                    state += filestr[i];
                }
                else if ((i - 4) % 3 == 1)             //第二行 - 英文
                {
                    En += filestr[i];
                }
                else                                   //第三行 - 中文
                {
                    Zn += filestr[i];

                    //添加句对至temp集合
                    List<string> ZS = new List<string>();
                    ZS.Add(En.Split('#')[1]);
                    ZS.Add(Zn.Split('#')[1]);
                    ZS.Add(state);

                    temp.Add(ZS);

                    En = Zn = state = "";               //还原数据
                }
            }
            //将所有数据传至TransMap字典集 - 存入数据库
            Editor.addContent(temp);

            //开启子线程，导入术语库信息，下标从i+i开始
            string[] tempTerm = new string[filestr.Length - i + 1];         //下标过大，会不会出错
            tempTerm[0] = "#####True#####";           //信号量，表示是否需要保存现场
            tempTerm[1] = MyLogin.admin.StartDate;    //待存储项目编号
            int cnt = 2;
            for(i++; i < filestr.Length; i++)
            {
                filestr[i] = Data.BinaryToString(filestr[i]);       //转二进制为string
                if (filestr[i].Equals("##############################"))           //检测到记忆库区域，则第i+1行为记忆库信息
                    break;
                else
                    tempTerm[cnt++] = filestr[i];
            }

            this.saveTerm(tempTerm);              //保存术语库信息
            
            string[] tempMemory = new string[filestr.Length - i + 1];
            tempMemory[0] = "#####True#####";                     //信号量，标记是否需要保存现场
            tempMemory[1] = MyLogin.admin.StartDate;              //待存储项目编号
            cnt = 2;
            for (i++; i < filestr.Length; i++)
            {
                filestr[i] = Data.BinaryToString(filestr[i]);       //转二进制为string
                tempMemory[cnt++] = filestr[i];         //记忆库信息
            }

            this.saveMemory(tempMemory);              //保存记忆库信息
            
            //恢复原项目对象，以及原Map数据
            MyLogin.admin.StartDate = Editor.GetPreStartDate;
            //Editor.PreSaveContent();            //恢复Map数据
            Interface.GetOnlyInterface.SaveEditorContent();
        }


        //***********************另存翻译文件
        //子线程工作函数，导出翻译文件
        public void ExportTransFile(object obj)
        {
            string[] AllInfo = (string[])obj;
            string savePath = AllInfo[0];
            //执行保存本项目所有翻译句对操作
            try
            {
                //截断文本文件
                FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                fs.Close();

                List<string> res = new List<string>();          //保存至word时一次性保存
                string[] Result = { "", "", "" };
                foreach (var str in Editor.GetTransMap)
                {
                    Result[0] = str[0];            //En
                    Result[1] = str[1];            //Zn
                    Result[2] = str[2];            //State

                    res.Add("原文：" + Result[0]);

                    if (Result[1].Length > 0)
                    {
                        if (Result[2].Equals("1"))
                            res.Add("已确认：" + Result[1]);
                        else
                            res.Add("未确认：" + Result[1]);
                    }
                    else
                        res.Add("无翻译：" + Result[1]);
                }

                //默认导出Txt
                if (AllInfo[1].Equals("False"))
                {
                    //写入Txt
                    Data.WriteToFile(savePath, res);
                }
                else
                {
                    //写入Word
                    Data.WriteToWord(savePath, res);
                }

                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportTransFileSucceedMessageBox));
                }
            }
            catch (Exception)
            {
                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated)
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportTransFileErrorMessageBox));
                }
            }
        }

        //根据传参弹出保存翻译文件消息框
        private void ExportTransFileSucceedMessageBox()
        {
            MessageBoxExt.Show(this, @"导出翻译文件成功！", "导出翻译文件", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //根据传参弹出保存翻译文件消息框
        private void ExportTransFileErrorMessageBox()
        {
            MessageBoxExt.Show(this, @"导出翻译文件失败！", "导出翻译文件", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //**************************导出术语库
        //子线程工作函数，导出术语库
        public void ExportTerm(object obj)
        {
            string[] AllInfo = (string[])obj;      //强转存储路径
            try
            {
                string savePath = AllInfo[1];
                //导出术语库操作
                List<string> res = new List<string>();
                foreach (var temp in TermBase.GetTermMap)
                {
                    res.Add(temp.Key + " " + temp.Value[0] + " " + temp.Value[1]);
                }

                //写入数据至术语库
                if (AllInfo[0].Equals("False"))
                {
                    if (AllInfo[2].Equals("False"))
                        Data.WriteToFile(savePath, res);        //文本文件    
                    else
                        Data.WriteTermToExcel(savePath, res);   //Excel
                }
                else
                    Data.WriteToProjectFile(savePath, res); //写入至项目文件

                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated && AllInfo[0].Equals("False"))         //单独导出术语库才弹窗提示是否导出成功
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportTermSucceedMessageBox));
                }
            }
            catch (Exception)
            {
                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated && AllInfo[0].Equals("False"))
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportTermErrorMessageBox));
                }
                else
                {
                    throw;      //导出项目时失败，抛出捕获的异常至项目级别，项目级别报项目导出失败
                }
            }
        }

        //成功导出术语库
        private void ExportTermSucceedMessageBox()
        {
            MessageBoxExt.Show(null, @"导出术语库成功！", "导出术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //导出术语库失败
        private void ExportTermErrorMessageBox()
        {
            MessageBoxExt.Show(null, @"导出术语库失败！", "导出术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }


        //**************************导出记忆库
        //子线程工作函数，导出记忆库
        public void ExportMemory(object obj)
        {
            string[] AllInfo = (string[])obj;      //强转存储路径
            try
            {
                string savePath = AllInfo[1];
                //导出记忆库操作
                List<string> res = new List<string>();          //存储所有数据
                foreach (var temp in Memory.GetSentenceMap)
                {
                    //将所有数据加入列表
                    res.Add(temp.Key);
                    res.Add(temp.Value);
                }

                if (AllInfo[0].Equals("False"))
                {
                    //自行封装的写入至Txt中
                    if (AllInfo[2].Equals("False"))
                        Data.WriteToFile(savePath, res);
                    else
                        Data.WriteMemoryToExcel(savePath, res);     //写入Excel中
                }
                else
                {
                    //导出至项目文件使用二进制输出
                    Data.WriteToProjectFile(savePath, res);
                }

                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated && AllInfo[0].Equals("False"))             //单独导出记忆库才弹窗提示是否成功
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportMemorySucceedMessageBox));
                }
            }
            catch (Exception)
            {
                //判断本控件窗口是否创建句柄，未创建则临时创建句柄，供Invoke调用
                if (this.IsHandleCreated && AllInfo[0].Equals("False"))
                {
                    //委托主线程弹窗提示
                    this.Invoke(new DelegateMessageBox(ExportMemoryErrorMessageBox));
                }
                else
                {
                    throw;      //导出项目时失败，抛出捕获的异常至项目级别，项目级别报项目导出失败
                }
            }
        }

        //成功导出记忆库
        private void ExportMemorySucceedMessageBox()
        {
            MessageBoxExt.Show(null, @"导出记忆库成功！", "导出记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //导出记忆库失败
        private void ExportMemoryErrorMessageBox()
        {
            MessageBoxExt.Show(null, @"导出记忆库失败！", "导出记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }

        //是否进行机器翻译 - true进行，false不进行
        private void isMachineTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = this.isMachineTranslationToolStripMenuItem;
            if (!Editor.GetIsMachineTranslation)
            {
                Editor.GetIsMachineTranslation = true;
                item.Text = "√ 机器翻译";
            }
            else
            {
                Editor.GetIsMachineTranslation = false;
                item.Text = "机器翻译";
            }
        }

        //清空所有项目数据
        public void deleteAllProject()
        {
            //List<string> allPro = Project.findAllProject();     //获取所有项目信息
            Project.findAllProject();       //更新数据
            List<projectEle> ls = Project.GetProjectElements; 

            if (ls == null) return;     //无数据，返回

            //遍历所有项目
            foreach (var pro in ls)
            {
                string str = pro.FileHead;      //获取头文件
                //分割项目头文件 - 获取所有项目编号信息
                string[] temp = str.Split(' ');
                Project.delete(temp[4]);                                    //删除该项目
            }
        }
        
    }

}