using DataBaseLink;
using LoginSpace;
using MainInterface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.MemoryInterface
{
    class Memory
    {
        //声明区域
        static private Panel area;
        private Panel left;
        //声明组件
        static Panel panel3;
        Button button10;
        Button button9;
        Button button8;
        Button button7;
        Button button6;
        Label label1;
        static Label label2;           //分割线，左右
        
        //记忆库数据 - 本地Map列表
        private static Dictionary<string, string> SentenceMap = new Dictionary<string, string>();
        
        static public Dictionary<string, string> GetSentenceMap
        {
            get
            {
                return Memory.SentenceMap;
            }
            set
            {
                Memory.SentenceMap = value;
            }
        }

        internal virtual Panel Area
        {
            get
            {
                return Memory.area;
            }
        }

        internal virtual Panel Left
        {
            get
            {
                return this.left;
            }
        }

        //初始化容器
        public void InitializeComponent()
        {
            Memory.area = new System.Windows.Forms.Panel();
            this.left = new System.Windows.Forms.Panel();
            // 
            // area
            // 
            Memory.area.Location = new System.Drawing.Point(103, 40);
            Memory.area.Name = "area";
            Memory.area.Size = new System.Drawing.Size(755, 529);
            Memory.area.TabIndex = 2;
            // 
            // left
            // 
            this.left.AutoScroll = false;
            this.left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(103, 320);
            this.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.left.TabIndex = 3;

            Memory.area.Controls.Clear();         //清除
            this.left.Controls.Clear();         //清除

            //添加组件及其功能
            this.addModule();
            this.addModuleFunc();
        }

        //添加组件
        private void addModule()
        {
            //获取变量空间
            panel3 = new System.Windows.Forms.Panel();
            button10 = new WinformControlLibraryExtension.ButtonExt();
            button9 = new WinformControlLibraryExtension.ButtonExt();
            button8 = new WinformControlLibraryExtension.ButtonExt();
            button7 = new WinformControlLibraryExtension.ButtonExt();
            button6 = new WinformControlLibraryExtension.ButtonExt();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            // 
            // label8 分割线竖直
            // 
            label2.AutoSize = false;
            label2.Location = new System.Drawing.Point(365, 0);
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Name = "label8";
            label2.TabIndex = 3;
            //label2.Size = new System.Drawing.Size(1, 850);      //随文本框数目变化
            // 
            // 记忆库显示区域
            // 
            panel3.AutoScroll = true;               //滚动条
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(755, 529);
            panel3.TabIndex = 1;
            // 
            // button10
            // 
            button10.Location = new System.Drawing.Point(0, 221);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(103, 34);
            button10.TabIndex = 5;
            button10.Text = "保存";
            button10.UseVisualStyleBackColor = true;
            button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(0, 176);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(103, 34);
            button9.TabIndex = 4;
            button9.Text = "查询句对";
            button9.UseVisualStyleBackColor = true;
            button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(0, 131);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(103, 34);
            button8.TabIndex = 3;
            button8.Text = "删除句对";
            button8.UseVisualStyleBackColor = true;
            button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(0, 86);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(103, 34);
            button7.TabIndex = 2;
            button7.Text = "修改句对";
            button7.UseVisualStyleBackColor = true;
            button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(0, 41);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(103, 34);
            button6.TabIndex = 1;
            button6.Text = "添加句对";
            button6.UseVisualStyleBackColor = true;
            button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 40);
            label1.TabIndex = 0;
            label1.Text = "记忆库";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.ForeColor = System.Drawing.Color.White;


            //右侧面积添加 
            Memory.area.Controls.Add(panel3);
            Memory.area.Controls.Add(label2);         //分割线放置于area
            //左侧区域添加
            this.left.Controls.Add(button10);
            this.left.Controls.Add(button9);
            this.left.Controls.Add(button8);
            this.left.Controls.Add(button7);
            this.left.Controls.Add(button6);
            this.left.Controls.Add(label1);
        }

        //组件添加功能
        private void addModuleFunc()
        {
            button6.Click += new System.EventHandler(this.addMemory);
            button7.Click += new System.EventHandler(this.changeMemory);
            button8.Click += new System.EventHandler(this.deleteMemory);
            button9.Click += new System.EventHandler(this.findMemory);
            button10.Click += new System.EventHandler(this.saveMemory);
        }

        private void addMemory(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            addMemory win = new addMemory();
            win.Show();
        }
        private void changeMemory(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "修改句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            changeMemory win = new changeMemory();
            win.Show();
        }
        private void deleteMemory(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "删除句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            deleteMemory win = new deleteMemory();
            win.Show();
        }
        private void findMemory(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "查询句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            findMemory win = new findMemory();
            win.Show();
        }

        //将Dictionary内所有数据全部导出至文本文件
        private void saveMemory(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "保存记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //同步文本框信息至Map/封闭文本框修改？


            //选择文件
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            // 
            // openFileDialog1
            // 
            saveFileDialog1.FileName = "Default.txt";
            saveFileDialog1.Filter = "记忆库.txt|*.txt|记忆库.xlsx|*.xlsx";

            //成功打开
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                String savePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                string name = System.IO.Path.GetFileName(saveFileDialog1.FileName);

                string[] AllInfo = { "False", savePath, "False" };           //单独导出，弹窗 - 默认Txt
                if (!name.Substring(name.Length - 4).ToLower().Contains(".txt"))
                {
                    AllInfo[2] = "True";
                }

                //不存在记忆库句对
                if (SentenceMap == null)
                {
                    MessageBoxExt.Show(null, @"记忆库为空！", "导出记忆库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error);
                }
                else
                {
                    try
                    {
                        //截断文本文件
                        FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                        fs.Close();
                        
                        //开启多线程导出术语库
                        Thread importMemoryThread = new Thread(new ParameterizedThreadStart(Interface.GetOnlyInterface.ExportMemory));
                        importMemoryThread.Start(AllInfo);                        //开启导入记忆库数据线程
                    }
                    catch
                    {
                        ;
                    }
                }
            }
        }

        //添加记忆库句对至数据库
        static public bool add(string En, string Zn)
        {
            //数据清洗
            En = En.Trim();
            Zn = Zn.Trim();

            try
            {
                //Map动态根据键去重
                Memory.SentenceMap.Add(En, Zn);           //加入Map前进行数据清洗
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //清空用户数据库中记忆库文件
        static public bool truncate()
        {
            Data.NAR(SentenceMap);
            Memory.SentenceMap = new Dictionary<string, string>();      //将Dictionary重新赋予内存空间
            return true;
        }
        
        //查询句对翻译
        static public string findTrans(string En)
        {
            //数据清洗
            En = En.Trim();
            
            //不存在数据，直接返回null
            if (SentenceMap == null) return null;

            //去除传参首尾空格
            En = En.Trim();
            string ResultZh = null;

            //查询时存在值
            if(SentenceMap.ContainsKey(En))
            {
                ResultZh = SentenceMap[En];
            }
            
            //返回结果：字符串 or null
            return ResultZh;
        }

        //删除句对
        static public bool delete(string En)
        {
            //数据清洗
            En = En.Trim();

            if (SentenceMap.ContainsKey(En))             //如果存在该句对
            {
                SentenceMap.Remove(En);                 //删除
                return true;
            }
            else
            {
                return false;
            }
        }

        //修改句对对
        static public bool modify(string En, string newZn)
        {
            //数据清洗
            En = En.Trim();
            newZn = newZn.Trim();

            if(SentenceMap.ContainsKey(En))     //判断是否包含键En
            {
                SentenceMap[En] = newZn;        //更新值
                return true;
            }
            else                                //键不存在，返回false
            {
                return false;
            }
        }

        //将本地列表中所有句对信息全部添加至数据库
        static public void InsertAllMemory(string StartDate)
        {
            try
            {
                if (SentenceMap == null) return;         //无数据，直接返回

                string Table = MyLogin.admin.Id + StartDate;
                string TableName = "Memory";
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                //如果旧表存在则删除，防止数据更新失败，需全部删除后进行重建
                String dropSql = "drop table if exists " + TableName;
                MySqlCommand cmd = new MySqlCommand(dropSql, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                //创建表
                String sql0 = "create table if not exists " + TableName + " (En varchar(750) not null, Zn varchar(500) not null)DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                //ignore插入时忽视冲突主键，仅返回0
                String sql = "insert ignore into " + TableName + " (En, Zn) values"; // 生成一条sql语句

                bool flag = false;                              //判断是否为第一个数据
                foreach (var temp in SentenceMap)             
                {
                    //数据替换：放置插入时 单引号出错，故将之转为双引号，这样sql语句就会顺利插入
                    if(flag) sql += ",('" + temp.Key.Replace("'", "''") + "','" + temp.Value.Replace("'", "''") + "')";   //剩余数据
                    else
                    {
                        sql += "('" + temp.Key.Replace("'", "''") + "','" + temp.Value.Replace("'", "''") + "')";                    //第一个数据
                        flag = true;
                    }
                }
                
                cmd = new MySqlCommand(sql, Data.connect());    //写入字段
                cmd.ExecuteNonQuery();                          //返回执行结果
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

        //刷新记忆库界面数据
        static public void packageMemory()
        {
            //不存在数据，直接返回
            if(SentenceMap == null)
            {
                return;
            }

            //显示面积区域
            Memory.panel3.Controls.Clear();

            string[] Result = { "", "" };

            int index = 0;
            //从本地句对列表中访问数据进行显示操作
            foreach (var temp in SentenceMap)
            {
                Result[0] = temp.Key;
                Result[1] = temp.Value;

                string EnName = "En" + index.ToString();
                string ZnName = "Zn" + index.ToString();

                // 
                // En
                // 
                RichTextBox En = new System.Windows.Forms.RichTextBox();
                En.ReadOnly = true;             //暂时封闭通过文本框修改记忆库属性，日后解封 - 保存时同步信息
                En.Name = EnName;
                En.Text = Result[0];
                En.TabIndex = 6;
                En.AutoSize = false;
                En.WordWrap = false;            //去掉滚轮
                En.ScrollBars = RichTextBoxScrollBars.None;
                En.SelectionStart = En.TextLength;
                En.BorderStyle = BorderStyle.None;
                En.SelectionAlignment = HorizontalAlignment.Center;
                En.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
                System.Drawing.Color preColor = En.BackColor;
                En.MouseMove += (sender, e) => memory_TextBox_Click(En);
                En.MouseLeave += (sender, e) => Text_Leave(En, preColor);

                // 
                // Zn
                // 
                RichTextBox Zn = new System.Windows.Forms.RichTextBox();
                Zn.ReadOnly = true;
                Zn.Name = ZnName;
                Zn.Text = Result[1];
                Zn.TabIndex = 6;
                Zn.AutoSize = false;
                Zn.WordWrap = false;            //去掉滚轮
                Zn.ScrollBars = RichTextBoxScrollBars.None;
                Zn.SelectionStart = En.TextLength;
                Zn.BorderStyle = BorderStyle.None;
                Zn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
                Zn.SelectionAlignment = HorizontalAlignment.Center;
                Zn.MouseMove += (sender, e) => memory_TextBox_Click(Zn);
                Zn.MouseLeave += (sender, e) => Text_Leave(Zn, preColor);

                //Panel3区域 (3, 3)(749, 534)
                //设置两者高度和宽度,及所处位置
                En.Size = new System.Drawing.Size(350, 30);
                Zn.Size = new System.Drawing.Size(350, 30);

                //鼠标滚轮控制
                En.MouseWheel += new MouseEventHandler(Memory_MouseWheel);
                Zn.MouseWheel += new MouseEventHandler(Memory_MouseWheel);

                if (index > 0)
                {
                    int y = Memory.panel3.Controls[Memory.panel3.Controls.Count - 1].Location.Y;
                    En.Location = new System.Drawing.Point(10, y + 30);
                    Zn.Location = new System.Drawing.Point(370, y + 30);
                }
                else
                {
                    En.Location = new System.Drawing.Point(10, 0);
                    Zn.Location = new System.Drawing.Point(370, 0);
                }

                //添加组件
                Memory.panel3.Controls.Add(En);
                Memory.panel3.Controls.Add(Zn);
                index++;
            }
            label2.Size = new System.Drawing.Size(1, index * 30);
            label2.Location = new System.Drawing.Point(365, 0);
            label2.BringToFront();      //最上面
        }

        //删除记忆库句对 - 拿最后面的句对进行文本内容替换即可，随即删除最后面一个控件！
        static public void packageMemroyDelete(object obj)
        {
            //数据清洗
            string En = (string)obj;
            En = En.Trim();

            try
            {
                //找到指定的英文文本框，替换内容为末尾的控件，随即删除末尾两控件
                for(int i = 0; i < Memory.panel3.Controls.Count; i++)
                {
                    //找到指定控件
                    if(En.Equals(Memory.panel3.Controls[i].Text))
                    {
                        RichTextBox tempEn = (RichTextBox)Memory.panel3.Controls[i];
                        RichTextBox tempZn = (RichTextBox)Memory.panel3.Controls[i + 1];

                        //倒数第二个控件为英文控件，倒数第一个为中文控件
                        tempEn.Text = Memory.panel3.Controls[Memory.panel3.Controls.Count - 2].Text;
                        tempZn.Text = Memory.panel3.Controls[Memory.panel3.Controls.Count - 1].Text;

                        //格式控制
                        tempEn.SelectionAlignment = HorizontalAlignment.Center;
                        tempZn.SelectionAlignment = HorizontalAlignment.Center;

                        //删除最后两个控件
                        Memory.panel3.Controls.Remove(Memory.panel3.Controls[Memory.panel3.Controls.Count - 2]);
                        Memory.panel3.Controls.Remove(Memory.panel3.Controls[Memory.panel3.Controls.Count - 1]);

                        break;      //替换结束
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        //修改记忆库句对更新界面 - 替换指定控件的Text内容
        static public void packageMemoryModify(object obj)
        {
            //数据清洗
            string[] AllInfo = (string[])obj;
            string En = AllInfo[0].Trim();
            string Zn = AllInfo[1].Trim();

            try
            {
                //遍历容器内所有控件，查询英文内容为En的控件，其下一个即为对应中文控件，进行文本替换即可
                for (int i = 0; i < Memory.panel3.Controls.Count; i++)
                {
                    //找到指定英文控件
                    if (Memory.panel3.Controls[i].Text.Equals(En))
                    {
                        RichTextBox temp = (RichTextBox)Memory.panel3.Controls[i + 1];
                        //替换中文控件
                        temp.Text = Zn;
                        //格式
                        temp.SelectionAlignment = HorizontalAlignment.Center;
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        //添加单个句对/导入记忆库更新显示界面 - 最底部增加数据
        static public void packageMemoryAdd(object obj)
        {
            string[] AllInfo = (string[])obj;
            string sentenceEn = AllInfo[0].Trim();
            string sentenceZn = AllInfo[1].Trim();

            string[] Result = { sentenceEn, sentenceZn };

            int index = 0;

            //index下标值即容器中控件数目的一半
            index = Memory.panel3.Controls.Count / 2;

            string EnName = "En" + index.ToString();
            string ZnName = "Zn" + index.ToString();

            //第一个位置为3
            System.Drawing.Point point = new System.Drawing.Point(4, -22);
            if (Memory.panel3.Controls.Count > 0)
                point = Memory.panel3.Controls[Memory.panel3.Controls.Count - 1].Location;
            // 
            // En
            // 
            RichTextBox En = new System.Windows.Forms.RichTextBox();
            En.ReadOnly = true;
            En.Name = EnName;
            En.Text = Result[0];
            En.TabIndex = 6;
            En.AutoSize = false;
            En.WordWrap = false;            //去掉滚轮
            En.ScrollBars = RichTextBoxScrollBars.None;
            En.SelectionStart = En.TextLength;
            En.BorderStyle = BorderStyle.None;
            En.SelectionAlignment = HorizontalAlignment.Center;
            En.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            System.Drawing.Color preColor = En.BackColor;
            En.Click += (sender, e) => memory_TextBox_Click(En);
            En.Leave += (sender, e) => Text_Leave(En, preColor);
            
            // 
            // Zn
            // 
            RichTextBox Zn = new System.Windows.Forms.RichTextBox();
            Zn.ReadOnly = true;
            Zn.Name = ZnName;
            Zn.Text = Result[1];
            Zn.TabIndex = 6;
            Zn.AutoSize = false;
            Zn.WordWrap = false;            //去掉滚轮
            Zn.ScrollBars = RichTextBoxScrollBars.None;
            Zn.SelectionStart = En.TextLength;
            Zn.BorderStyle = BorderStyle.None;
            Zn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            Zn.SelectionAlignment = HorizontalAlignment.Center;
            Zn.Click += (sender, e) => memory_TextBox_Click(Zn);
            Zn.Leave += (sender, e) => Text_Leave(Zn, preColor);

            //鼠标滚轮控制
            En.MouseWheel += new MouseEventHandler(Memory_MouseWheel);
            Zn.MouseWheel += new MouseEventHandler(Memory_MouseWheel);

            //Panel3区域 (3, 3)(749, 534)
            //设置两者高度和宽度,及所处位置
            En.Size = new System.Drawing.Size(350, 30);
            Zn.Size = new System.Drawing.Size(350, 30);
            En.Location = new System.Drawing.Point(10, point.Y + 30);
            Zn.Location = new System.Drawing.Point(370, point.Y + 30);

            //添加组件
            Memory.panel3.Controls.Add(En);
            Memory.panel3.Controls.Add(Zn);
            label2.Size = new System.Drawing.Size(1, Memory.panel3.Controls.Count * 15);
            label2.Location = new System.Drawing.Point(360, 0);
            label2.BringToFront();      //最上面
        }

        //清空记忆库、删除项目直接清空区域
        static public void packageMemoryClear()
        {
            //显示面积区域 - 全部清空即可
            Memory.panel3.Controls.Clear();

            Memory.label2.Size = new System.Drawing.Size(0, 0);
            //Memory.panel3.Controls.Add(label2);
        }

        //从数据库内获取记忆库句对数据至本地列表 - 该函数需要在载入项目之后，方可运行，否则索取空值
        static public void getSentenceFromDatabase()
        {
            try
            {
                string Table = MyLogin.admin.Id + MyLogin.admin.StartDate;
                string TableName = "Memory";
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql = "select * from " + TableName;          //生成一条sql选择语句
                //写入字段
                MySqlCommand cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();         //返回执行结果

                Data.NAR(SentenceMap);
                SentenceMap = new Dictionary<string, string>();     //声明Map，为其赋予内存空间
                
                while (rs.Read())
                {
                    //加入数据至本地Map
                    SentenceMap.Add(rs.GetString("En"), rs.GetString("Zn"));
                }
            }
            catch (Exception)
            {
                //无数据表时，不进行创建新表
                return;
            }
            finally
            {
                Data.Close();
            }
        }

        //鼠标滚轮控制编辑器区域移动
        static private void Memory_MouseWheel(object sender, MouseEventArgs e)
        {
            int pos = Memory.panel3.VerticalScroll.Value - e.Delta / 6;
            if (pos >= Memory.panel3.VerticalScroll.Minimum && pos <= Memory.panel3.VerticalScroll.Maximum)
                Memory.panel3.VerticalScroll.Value = pos;
            else if (pos < Memory.panel3.VerticalScroll.Minimum)         //比最小值小
                Memory.panel3.VerticalScroll.Value = Memory.panel3.VerticalScroll.Minimum;
            else    //比最大值大
                Memory.panel3.VerticalScroll.Value = Memory.panel3.VerticalScroll.Minimum;
        }

        //单机文本框时变色
        static private void memory_TextBox_Click(RichTextBox box)
        {
            //更改本文本框颜色
            box.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            box.ForeColor = System.Drawing.Color.White;
        }

        static private void Text_Leave(RichTextBox box, System.Drawing.Color preColor)
        {
            //更改本文本框颜色
            box.BackColor = preColor;
            box.ForeColor = System.Drawing.Color.Black;
        }
    }
}
