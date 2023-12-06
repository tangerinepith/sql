using DataBaseLink;
using LoginSpace;
using MainInterface;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TermBaseInterface;
using WindowsFormsApp3.EditorInterface;
using WindowsFormsApp3.MemoryInterface;
using WindowsFormsApp3.TermBaseInterface;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.ProjectInterface
{
    class Project
    {
        //区域定义
        static private Panel area;
        static private Panel left;
        //组件定义
        static Label label1 = new Label();
        static Label label2 = new Label();
        static Label label3 = new Label();
        static Label label4 = new Label();
        static Label label5 = new Label();
        static Label label6 = new Label();
        static Label label7 = new Label();
        static Label label8 = new Label();          //分割线
        static Button button6 = new ButtonExt();
        static Button button7 = new ButtonExt();
        static Button button8 = new ButtonExt();
        //定义刚点击的按钮信息
        static private string startTime = "";

        //存储全部项目信息
        static private List<projectEle> ProjectElements = new List<projectEle>();

        static public List<projectEle> GetProjectElements
        {
            get
            {
                return Project.ProjectElements;
            }
        }

        internal virtual Panel Area
        {
            get
            {
                return Project.area;
            }
        }

        internal virtual Panel GetLeft
        {
            get
            {
                return Project.left;
            }
        }

        static internal string PreStartTime
        {
            get
            {
                return Project.startTime;
            }
        }

        public void InitializeComponent()
        {
            Project.area = new System.Windows.Forms.Panel();
            Project.left = new System.Windows.Forms.Panel();
            // 
            // area
            // 
            Project.area.Location = new System.Drawing.Point(103, 40);
            //Project.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            Project.area.Name = "area";
            Project.area.Size = new System.Drawing.Size(755, 529);
            Project.area.TabIndex = 2;
            // 
            // left
            // 
            //Project.left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            Project.left.Location = new System.Drawing.Point(0, 0);
            Project.left.Name = "left";
            Project.left.Size = new System.Drawing.Size(103, 320);
            Project.left.TabIndex = 3;
            Project.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));

            Project.area.Controls.Clear();         //清除
            Project.left.Controls.Clear();         //清除

            //左侧显示滑动条
            Project.left.AutoScroll = true;
            //Project.left.VerticalScroll.Visible = true;
            //Project.left.HorizontalScroll.Visible = false;

            //封装项目按钮
            this.packageButton();
        }

        static private void addLeftModule()
        {
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 40);
            label1.TabIndex = 0;
            label1.Text = "项目编号";
            label1.ForeColor = System.Drawing.Color.White;
            //label1.Font = new System.Drawing.Font("宋体", 9.5F);
            //左侧区域
            Project.left.Controls.Add(label1);
        }
        //添加组件
        static private void addAreaModule()
        {
            //各类标签都需要重新声明，不然重叠添加按钮功能时，会导致按一次响应多次。
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button6 = new ButtonExt();
            button7 = new ButtonExt();
            button8 = new ButtonExt();
            // 
            // label8 分割线
            // 
            label8.AutoSize = false;
            label8.Location = new System.Drawing.Point(0, -5);
            label8.Name = "label1";
            label8.Size = new System.Drawing.Size(805, 20);
            label8.TabIndex = 3;
            //label8.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("宋体", 9f);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            label2.AutoSize = false;
            label2.Location = new System.Drawing.Point(17, 15);
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 15);
            label2.TabIndex = 1;
            label2.Text = "项目名称";
            // 
            // label3
            // 
            label3.AutoSize = false;
            label3.Location = new System.Drawing.Point(142, 15);
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 15);
            label3.TabIndex = 2;
            label3.Text = "状态";
            label3.Font = new System.Drawing.Font("宋体", 9f);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            // 
            // label4
            // 
            label4.AutoSize = false;
            label4.Location = new System.Drawing.Point(266, 15);
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 15);
            label4.TabIndex = 3;
            label4.Text = "到期日";
            label4.Font = new System.Drawing.Font("宋体", 9f);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            // 
            // label5
            // 
            label5.AutoSize = false;
            label5.Location = new System.Drawing.Point(392, 15);
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 15);
            label5.TabIndex = 4;
            label5.Text = "开始日期";
            label5.Font = new System.Drawing.Font("宋体", 9f);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            // 
            // label6
            // 
            label6.AutoSize = false;
            label6.Location = new System.Drawing.Point(518, 15);
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(104, 15);
            label6.TabIndex = 5;
            label6.Text = "客户";
            label6.Font = new System.Drawing.Font("宋体", 9f);
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            // 
            // label7
            // 
            label7.AutoSize = false;
            label7.Location = new System.Drawing.Point(643, 15);
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(104, 15);
            label7.TabIndex = 6;
            label7.Text = "创建者";
            label7.Font = new System.Drawing.Font("宋体", 9f);
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(667, 389);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(65, 40);
            button6.TabIndex = 0;
            button6.Text = "开始工作";
            button6.UseVisualStyleBackColor = true;
            button6.Font = new System.Drawing.Font("宋体", 9f);
            button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(667, 429);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(65, 40);
            button7.TabIndex = 0;
            button7.Text = "删除项目";
            button7.UseVisualStyleBackColor = true;
            button7.Font = new System.Drawing.Font("宋体", 9f);
            button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(667, 469);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(65, 40);
            button8.TabIndex = 0;
            button8.Text = "清空项目";
            button8.UseVisualStyleBackColor = true;
            button8.Font = new System.Drawing.Font("宋体", 9f);
            button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));

            //右侧区域
            Project.area.Controls.Add(label7);
            Project.area.Controls.Add(label6);
            Project.area.Controls.Add(label5);
            Project.area.Controls.Add(label4);
            Project.area.Controls.Add(label3);
            Project.area.Controls.Add(label2);
            Project.area.Controls.Add(label8);
            Project.area.Controls.Add(button6);
            Project.area.Controls.Add(button7);
            Project.area.Controls.Add(button8);
        }

        //组件添加功能
        private void addAreaModuleFunc()
        {
            //开始工作功能
            button6.Click += new System.EventHandler(this.button6_Click);
            //删除项目功能
            button7.Click += new System.EventHandler(this.button7_Click);
            //清空项目功能
            button8.Click += new System.EventHandler(this.button8_Click);
        }

        //开始工作按钮功能 - 将术语库、记忆库、编辑器部分数据导入程序，并刷新各部分界面
        private void button6_Click(object sender, EventArgs e)
        {
            if (Project.startTime == null || Project.startTime.Length == 0)
                MessageBoxExt.Show(null, @"请先选中项目！", "载入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else if(Project.startTime == MyLogin.admin.StartDate)
                MessageBoxExt.Show(null, @"所选项目已运行！", "载入项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else
            {
                //设定全局匹配度和分隔符
                foreach(var temp in Project.ProjectElements)
                {
                    //找到指定头文件
                    if(temp.FileHead.Contains(Project.startTime))
                    {
                        Editor.matchNum = temp.DegreeOfMatch;
                    }
                }

                //当前项目非空才进行数据保存（当前存在运行项目）
                if (MyLogin.admin.StartDate != null && !MyLogin.admin.StartDate.Equals("") && MyLogin.admin.StartDate.Length >= 0)
                {
                    //保存数据操作
                    //项目文本框经过改动
                    if (Editor.GetIsChangeData)
                    {
                        DialogResult dr = MessageBoxExt.Show(Interface.GetOnlyInterface, @"项目已改动，是否保存？", "载入项目", MessageBoxExtButtons.OKCancel, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);

                        if (dr == DialogResult.OK)
                        {
                            //主线程存储项目内容
                            Editor.saveContentFunc();
                        }
                    }
                    string[] oldAndNewDate = { MyLogin.admin.StartDate, Project.startTime };

                    //多线程存储上一个项目术语库和记忆库至数据库
                    Thread StoreTermMemoryThread = new Thread(new ParameterizedThreadStart(Interface.GetOnlyInterface.StoreTermMemory));
                    StoreTermMemoryThread.Start(oldAndNewDate);                        //开启导入记忆库数据线程
                }
                //当前不存在运行项目，直接开启子线程导入新项目数据即可
                else
                {
                    //定义该用户选择的文件为当前选中的文件
                    MyLogin.admin.StartDate = Project.startTime;

                    //启用子线程加载数据至本地静态Map中
                    ThreadStart childref = new ThreadStart(Interface.GetOnlyInterface.LoadData);
                    Thread LoadDataThread = new Thread(childref);

                    //加载数据线程得等到存储线程完成后方可执行
                    LoadDataThread.Start();                        //开启加载数据线程 - 否则该线程运行会清空Map，导致存储信息失败
                }
            }
        }
        
        //删除项目按钮功能
        private void button7_Click(object sender, EventArgs e)
        {
            if(Project.PreStartTime == null || Project.PreStartTime.Length == 0)
            {
                MessageBoxExt.Show(null, @"请先选中项目！", "删除项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            DialogResult dr = MessageBoxExt.Show(null, @"将导致数据库表删除，是否继续？", "删除项目", MessageBoxExtButtons.OKCancel, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);

            if (dr == DialogResult.OK)
            {
                string PreStartDate = Project.PreStartTime;             //存储前一项项目编号，在删除后会被置为空
                //数据库删除是否成功
                if (!Project.delete(Project.PreStartTime))
                {
                    MessageBoxExt.Show(null, @"项目已删除！", "删除项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    //重新封装项目按钮
                    this.packageButton();
                }
                else
                {
                    MessageBoxExt.Show(null, @"删除项目成功！", "删除项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);

                    //重新封装项目按钮 - 删除成功
                    this.packageButton();

                    //删除的是当前项目，则清空Map信息，并刷新各界面
                    if (PreStartDate.Equals(MyLogin.admin.StartDate))
                    {
                        //重置各个Map信息
                        Data.NAR(Editor.GetTransMap);
                        Data.NAR(TermBase.GetTermMap);
                        Data.NAR(Memory.GetSentenceMap);
                        Editor.GetTransMap = new List<List<string>>();
                        TermBase.GetTermMap = new Dictionary<string, List<string>>();
                        Memory.GetSentenceMap = new Dictionary<string, string>();

                        //将当前运行项目编号置为空
                        MyLogin.admin.StartDate = "";
                        Editor.GetIsChangeData = false;     //删除当前项目，无需保存

                        //重新加载术语库和记忆库（全部清空）,以及项目内容
                        TermBase.packageTermClear();
                        Memory.packageMemoryClear();
                        Editor.packageTextDelete();
                    }
                }
            }
        }

        //清空所有项目 - 展示为空
        private void button8_Click(object sender, EventArgs e)
        {
            //清空重置 - 左侧
            Project.left.Controls.Clear();
            Project.area.Controls.Clear();
            //添加标签组件及其功能
            Project.addLeftModule();
            Project.addAreaModule();
            this.addAreaModuleFunc();
            //判断是否有正在运行的项目，有则清空全部界面
            if(MyLogin.admin.StartDate != null && MyLogin.admin.StartDate.Length > 0)
            {
                //重置各个Map信息
                Data.NAR(Editor.GetTransMap);
                Data.NAR(TermBase.GetTermMap);
                Data.NAR(Memory.GetSentenceMap);
                Editor.GetTransMap = new List<List<string>>();
                TermBase.GetTermMap = new Dictionary<string, List<string>>();
                Memory.GetSentenceMap = new Dictionary<string, string>();

                //将当前运行项目编号置为空
                MyLogin.admin.StartDate = "";

                //重新加载术语库和记忆库（全部清空）,以及项目内容
                TermBase.packageTermClear();
                Memory.packageMemoryClear();
                Editor.packageTextDelete();
            }
            //启用子线程清空所有数据库数据
            ThreadStart childref = new ThreadStart(Interface.GetOnlyInterface.deleteAllProject);
            Thread DeleteAllProjectThread = new Thread(childref);
            DeleteAllProjectThread.Start();
        }

        //本文件夹下菜单栏功能
        public void createProject()
        {
            createProjectFunc win = new createProjectFunc();
            win.Show();
        }

        //添加项目
        static public bool add(string fileHead, string savePath, int matchingValue, string splitSymbol)
        {
            try
            {
                //生成、获取用户创建项目信息
                string Table = MyLogin.admin.Id;
                string TableName = "Project";
                
                //转成英文表名
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql0 = "create table if not exists " + TableName + " (fileHead varchar(254) primary key, savePath varchar(254), degreeOfMatch int default 75, splitSymbol varchar(40) default '.?!;')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                savePath = savePath.Replace('\\', '/');
                String sql = "insert into " + TableName + " (fileHead, savePath, degreeOfMatch, splitSymbol) values('{0}','{1}', '{2}', '{3}')"; // 生成一条sql语句
                sql = string.Format(sql, fileHead, savePath, matchingValue, splitSymbol);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                int result = cmd.ExecuteNonQuery();         //返回执行结果
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;                                   //重复导入，主键冲突不反应
            }
            finally
            {
                Data.Close();
            }
        }

        //删除项目
        static public bool delete(string startTime)
        {
            try
            {
                //生成、获取用户创建项目信息
                string Table = MyLogin.admin.Id;
                string TableName = "Project";
                //转成英文表名
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql0 = "create table if not exists " + TableName + " (fileHead varchar(254) primary key, savePath varchar(254), degreeOfMatch int default 75, splitSymbol varchar(40) default '.?!;')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd0 = new MySqlCommand(sql0, Data.connect());
                cmd0.ExecuteNonQuery();
                Data.Close();               //连续调用，中间需关闭Data，下次连接会重新声明conn连接对象

                //模糊查询删除项目
                String sql = "delete from " + TableName + " where fileHead like '%{0}%'";           // 生成一条sql语句
                sql = string.Format(sql, startTime);
                //写入字段
                MySqlCommand cmd = new MySqlCommand(sql, Data.connect());
                int result = cmd.ExecuteNonQuery();         //返回执行结果
                Data.Close();

                //删除数据库内相关表
                Table = MyLogin.admin.Id + startTime;           //删除选中的项目表
                string ContentTableName = "Content";       //归属哪个项目 - 项目开始时间，可更改为fileHead去除状态栏？
                string TermBaseTableName = "Term";
                string MemoryTableName = "Memory";
                string SecondeName = "";
                CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        SecondeName += (char)((ch - '0') + 'a');
                    }
                }

                ContentTableName += SecondeName;
                TermBaseTableName += SecondeName;
                MemoryTableName += SecondeName;

                sql0 = "drop table if exists " + ContentTableName + "," + TermBaseTableName + "," + MemoryTableName;
                //删除表
                cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();

                //结果集显示
                if (result > 0)
                    return true;
                else
                    return false;
                    
            }
            catch (Exception)
            {
                return false;                                   //删除失败
            }
            finally
            {
                Data.Close();
            }
        }

        //查询当前运行项目文件头、默认存储位置信息
        static public string[] findFileHead()
        {
            try
            {
                Project.findAllProject();       //更新数据

                if (Project.ProjectElements == null) return null;

                //文件头和存储路径值 + 匹配度 + 分隔符
                string[] Result = { "", "", "", "" };
                foreach (projectEle temp in Project.ProjectElements)
                {
                    Result[0] = temp.FileHead;            //fileHead
                    Result[1] = temp.SavePath;            //savePath
                    Result[2] = temp.DegreeOfMatch.ToString();
                    Result[3] = temp.SplitSymbol;
                    
                    //比对信息
                    if (Result[0].Contains(Project.startTime))
                    {
                        break;                              //查询到结果，result即为结果集
                    }
                }

                //返回指定项目文件头信息
                if (Result[0].Length > 0 && Result[1].Length > 0)
                    return Result;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;                                   //删除失败
            }
        }

        //返回全部项目信息
        static public void findAllProject()
        {
            try
            {
                Project.ProjectElements = null;
                Project.ProjectElements = new List<projectEle>();
                
                //生成、获取用户创建项目信息
                string Table = MyLogin.admin.Id;
                string TableName = "Project";
                //转成英文表名
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql0 = "create table if not exists " + TableName + " (fileHead varchar(254) primary key, savePath varchar(254), degreeOfMatch int default 75, splitSymbol varchar(40) default '.?!;')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                String sql = "select * from " + TableName;       // 生成一条sql语句
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();         //返回执行结果
                
                while (rs.Read())
                {
                    projectEle temp = new projectEle();
                    temp.FileHead = rs.GetString("fileHead");
                    temp.SavePath = rs.GetString("savePath");
                    temp.DegreeOfMatch = int.Parse(rs.GetString("degreeOfMatch"));
                    temp.SplitSymbol = rs.GetString("splitSymbol");

                    Project.ProjectElements.Add(temp);
                    //list.Add(rs.GetString("fileHead") + " " + rs.GetString("savePath"));
                }
            }
            catch (Exception)
            {
                return;                                    
            }
            finally
            {
                Data.Close();
            }
        }

        //更改当前项目的匹配度
        static public bool updateMatching(int value)
        {
            try
            {
                //生成、获取用户创建项目信息
                string Table = MyLogin.admin.Id;
                string TableName = "Project";
                //转成英文表名
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql0 = "create table if not exists " + TableName + " (fileHead varchar(254) primary key, savePath varchar(254), degreeOfMatch int default 75, splitSymbol varchar(40) default '.?!;')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                //模糊匹配更新值
                String sql = "UPDATE " + TableName + " SET degreeOfMatch='{0}' WHERE fileHead like '%{1}%'";//向login表里修改数据
                sql = string.Format(sql, value, LoginSpace.MyLogin.admin.StartDate);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                int res = cmd.ExecuteNonQuery();                          //返回执行结果

                if (res > 0)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Data.Close();
            }
        }

        //更改当前项目的分隔符
        static public bool updateSplitSymbol(string value)
        {
            try
            {
                //生成、获取用户创建项目信息
                string Table = MyLogin.admin.Id;
                string TableName = "Project";
                //转成英文表名
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql0 = "create table if not exists " + TableName + " (fileHead varchar(254) primary key, savePath varchar(254), degreeOfMatch int default 75, splitSymbol varchar(40) default '.?!;')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                //模糊匹配更新值
                String sql = "UPDATE " + TableName + " SET splitSymbol='{0}' WHERE fileHead like '%{1}%'";//向login表里修改数据
                sql = string.Format(sql, value, LoginSpace.MyLogin.admin.StartDate);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                int res = cmd.ExecuteNonQuery();                          //返回执行结果

                if (res > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Data.Close();
            }
        }

        //封装项目按钮
        public void packageButton()
        {
            try
            {
                //清空重置 - 左侧
                Project.left.Controls.Clear();
                Project.area.Controls.Clear();
                //添加标签组件及其功能
                Project.addLeftModule();
                Project.addAreaModule();
                this.addAreaModuleFunc();
                //List<string> rs = findAllProject();
                findAllProject();            //更新数据

                if (Project.ProjectElements == null) return;      //无数据，返回

                string[] Result = { "", "" };
                int index = 0;
                foreach (projectEle temp in Project.ProjectElements)
                {
                    //string[] temp = str.Split(' ');
                    Result[0] = temp.FileHead;      //fileHead
                    Result[1] = temp.SavePath;            //savePath

                    //分割项目头文件
                    string[] fileHead = Result[0].Split(' ');

                    string buttonName = "button" + index.ToString();

                    //Button button = new WinformControlLibraryExtension.ButtonExt();
                    Button button = new Button();
                    //button.FlatAppearance.BorderColor = System.Drawing.Color.Red;       //正在运行项目按钮为红色边框

                    //存在新按钮时，则位置为最后项目+1，否则为50
                    if (index > 0)
                        button.Location = new System.Drawing.Point(0, 30 + Project.left.Controls[Project.left.Controls.Count - 1].Location.Y);
                    else
                        button.Location = new System.Drawing.Point(0, 50);  //位置随按钮数量

                    button.AutoSize = false;
                    button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Name = buttonName;
                    button.FlatAppearance.BorderSize = 0;
                    button.ForeColor = System.Drawing.Color.White;
                    button.Size = new System.Drawing.Size(85, 25);             //高度25
                    button.TabIndex = index;
                    button.Text = fileHead[0];
                    //button.UseVisualStyleBackColor = true;
                    //button.FlatStyle = FlatStyle
                    
                    //鼠标选中按钮为凹面

                    //封装结果集
                    string paramStr = Result[0];
                    //button.Click += new System.EventHandler(func);    --  传统
                    //传自定义参数至按钮点击事件
                    button.Click += (sender, e) => project_Button_Click(paramStr);
                    button.MouseEnter += (sender, e) => project_MouseEnter(button);
                    button.MouseLeave += (sender, e) => project_MouseLeave(button);

                    Project.left.Controls.Add(button);

                    index++;
                }
                
            }
            catch (Exception)
            {
                MessageBoxExt.Show(null, @"加载历史项目失败！", "加载历史项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        //鼠标离开，恢复原色
        private void project_MouseLeave(Button button)
        {
            button.BackColor = System.Drawing.Color.FromArgb(111, 155, 244);
        }

        //鼠标进入，背景变色
        private void project_MouseEnter(Button button)
        {
            button.BackColor = System.Drawing.Color.FromArgb(167, 194, 248);
        }

        //项目按钮执行功能
        private void project_Button_Click(string paramStr)
        {
            Project.area.Controls.Clear();
            //添加标签组件及其功能
            Project.addAreaModule();
            addAreaModuleFunc();
            //设置文件头 - 项目名称、创建者、客户、到期时间、创建时间、项目运行初始状态
            //分割项目头文件
            string[] fileHead = paramStr.Split(' ');
            //记载项目编号 - 该项目开始时间
            Project.startTime = fileHead[4];

            //详细项目标签
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            Label label6 = new Label();
            Label label7 = new Label();
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new System.Drawing.Point(17, 30);
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 50);
            label2.TabIndex = 1;
            label2.Text = fileHead[0];
            // 
            // label3
            // 
            label3.AutoSize = false;
            label3.Location = new System.Drawing.Point(142, 30);
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 50);
            label3.TabIndex = 2;
            label3.Text = fileHead[5];
            // 
            // label4
            // 
            label4.AutoSize = false;
            label4.Location = new System.Drawing.Point(266, 30);
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 50);
            label4.TabIndex = 3;
            label4.Text = fileHead[3];
            // 
            // label5
            // 
            label5.AutoSize = false;
            label5.Location = new System.Drawing.Point(392, 30);
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 50);
            label5.TabIndex = 4;
            label5.Text = fileHead[4];
            // 
            // label6
            // 
            label6.AutoSize = false;
            label6.Location = new System.Drawing.Point(518, 30);
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(104, 50);
            label6.TabIndex = 5;
            label6.Text = fileHead[2];
            // 
            // label7
            // 
            label7.AutoSize = false;
            label7.Location = new System.Drawing.Point(643, 30);
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(104, 50);
            label7.TabIndex = 6;
            label7.Text = fileHead[1];

            //右侧区域
            Project.area.Controls.Add(label7);
            Project.area.Controls.Add(label6);
            Project.area.Controls.Add(label5);
            Project.area.Controls.Add(label4);
            Project.area.Controls.Add(label3);
            Project.area.Controls.Add(label2);
        }
    }
}
