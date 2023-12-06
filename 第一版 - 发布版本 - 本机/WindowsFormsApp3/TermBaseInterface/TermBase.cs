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

namespace WindowsFormsApp3.TermBaseInterface
{
    class TermBase
    {
        //区域声明
        private Panel area;
        private Panel left;
        //声明组件
        static private Panel panel3;
        static private Panel panel2;            //术语滚动区域
        Button button10;
        Button button9;
        Button button8;
        Button button7;
        Button button6;
        Label label1;

        //按钮点击En
        static string lastEn = "";
        static string buttonName = "";          //点击按钮的属性名 - 离开界面即清除，删除后清除
        //术语库本地Dictionary列表
        static private Dictionary<string, List<string>> TermMap = new Dictionary<string, List<string>>();
        
        static public Dictionary<string, List<string>> GetTermMap
        {
            get
            {
                return TermBase.TermMap;
            }
            set
            {
                TermBase.TermMap = value;
            }
        }

        static internal Panel GetPanel2
        {
            get
            {
                return TermBase.panel2;
            }
        }

        internal virtual Panel Area
        {
            get
            {
                return this.area;
            }
        }

        internal virtual Panel Left
        {
            get
            {
                return this.left;
            }
        }

        static internal string LastEn
        {
            get
            {
                return TermBase.lastEn;
            }
        }

        public void InitializeComponent()
        {
            this.area = new System.Windows.Forms.Panel();
            this.left = new System.Windows.Forms.Panel();
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(103, 40);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(755, 529);
            this.area.TabIndex = 2;
            // 
            // left
            // 
            this.left.AutoScroll = false;
            this.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(103, 320);
            this.left.TabIndex = 3;

            this.area.Controls.Clear();         //清除
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
            panel2 = new System.Windows.Forms.Panel();
            button10 = new WinformControlLibraryExtension.ButtonExt();
            button9 = new WinformControlLibraryExtension.ButtonExt();
            button8 = new WinformControlLibraryExtension.ButtonExt();
            button7 = new WinformControlLibraryExtension.ButtonExt();
            button6 = new WinformControlLibraryExtension.ButtonExt();
            label1 = new System.Windows.Forms.Label();
            // 
            // 术语显示区域
            // 
            panel3.Location = new System.Drawing.Point(143, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(612, 529);
            panel3.TabIndex = 1;
            panel3.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            // 
            // 术语条
            // 
            panel2.AutoScroll = true;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(133, 529);
            panel2.TabIndex = 0;
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
            button9.Text = "查询术语";
            button9.UseVisualStyleBackColor = true;
            button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(0, 131);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(103, 34);
            button8.TabIndex = 3;
            button8.Text = "删除术语";
            button8.UseVisualStyleBackColor = true;
            button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(0, 86);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(103, 34);
            button7.TabIndex = 2;
            button7.Text = "修改术语";
            button7.UseVisualStyleBackColor = true;
            button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(0, 41);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(103, 34);
            button6.TabIndex = 1;
            button6.Text = "添加术语";
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
            label1.Text = "术语库";
            label1.ForeColor = System.Drawing.Color.White;
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Font = new System.Drawing.Font("宋体", 9f);


            //右侧面积添加 
            this.area.Controls.Add(panel3);
            this.area.Controls.Add(panel2);
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
            button6.Click += new System.EventHandler(this.addTerm);
            button7.Click += new System.EventHandler(this.changeTerm);
            button8.Click += new System.EventHandler(this.deleteTerm);
            button9.Click += new System.EventHandler(this.findTerm);
            button10.Click += new System.EventHandler(this.saveTerm);
        }

        private void addTerm(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "添加术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            addTerm win = new addTerm();
            win.Show();
        }
        private void changeTerm(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "修改术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            changeTerm win = new changeTerm();
            win.Show();
        }
        private void deleteTerm(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "删除术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //直接删除术语  --  改进：将术语库内内容读入程序列表，而非直接对数据库操作
            if (!TermBase.delete(lastEn))
                MessageBoxExt.Show(null, @"请选择待删除术语！", "删除术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else
                TermBase.packageTermDeleteButton(lastEn);                   //删除术语成功，移除指定按钮
        }
        private void findTerm(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "查询术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            findTerm win = new findTerm();
            win.Show();
        }

        //存储数据至术语库
        private void saveTerm(object sender, EventArgs e)
        {
            if (MyLogin.admin.StartDate == null || MyLogin.admin.StartDate.Length <= 0)
            {
                MessageBoxExt.Show(Interface.GetOnlyInterface, @"请先载入项目！", "保存术语库", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //选择文件
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            // 
            // openFileDialog1
            // 
            saveFileDialog1.FileName = "Default.txt";
            saveFileDialog1.Filter = "术语库.txt|*.txt|术语库.xlsx|*.xlsx";

            //成功打开
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //获取文件路径
                    String savePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                    string name = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    name = name.Substring(name.Length - 4).ToLower();

                    string[] AllInfo = { "False", savePath, "False" };          //第一个False：写入术语库，第二个False：写入Txt
                    //写入Excel
                    if (!name.Contains(".txt"))
                    {
                        AllInfo[2] = "True";
                    }

                    //执行保存本项目所有术语操作
                    //截断文本文件
                    FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                    fs.Close();
                    Data.NAR(fs);

                    //开启多线程导出术语库
                    Thread importMemoryThread = new Thread(new ParameterizedThreadStart(Interface.GetOnlyInterface.ExportTerm));
                    importMemoryThread.Start(AllInfo);                        //开启导入记忆库数据线程
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        //存储术语库至本地字典集 - 直接存储所有文件
        static public bool add(string pre, string last, string cep)
        {
            //数据清洗
            pre = pre.Trim();
            last = last.Trim();
            cep = cep.Trim();

            if (pre == null || pre.Length == 0) return false;       //无数据

            //已经存在该术语
            if(TermMap.ContainsKey(pre))
            {
                return false;
            }
            else
            {
                List<string> temp = new List<string>();
                temp.Add(last);
                temp.Add(cep);

                TermMap.Add(pre, temp);
                return true;
            }
        }

        //清空数据库内术语库
        static public bool truncate()
        {
            Data.NAR(TermMap);
            TermBase.TermMap = new Dictionary<string, List<string>>();          //清空本地字典信息
            return true;
        }
        
        //依据英文匹配相关术语
        static public List<List<string>> findTerm(string Paramstr)
        {
            try
            {
                //清洗数据
                string En = "";
                for(int i = 0; i < Paramstr.Length; i++)
                {
                    //获取所有英文信息、数字信息
                    if(Paramstr[i] >= 'a' && Paramstr[i] <= 'z' || Paramstr[i] >= 'A' && Paramstr[i] <= 'Z' || Paramstr[i] >= '0' && Paramstr[i] <= '9')
                    {
                        En += Paramstr[i];
                    }
                }
                En = En.ToLower();

                List<List<string>> result = new List<List<string>>();           //多个术语返回多个句对
                foreach(var term in TermBase.TermMap)
                {
                    //去除termEn的空格
                    string termEn = "";
                    for(int i = 0; i < term.Key.Length; i++)
                    {
                        if (term.Key[i] >= 'a' && term.Key[i] <= 'z' || term.Key[i] >= 'A' && term.Key[i] <= 'Z' || term.Key[i] >= '0' && term.Key[i] <= '9')
                        {
                            termEn += term.Key[i];
                        }
                    }
                    termEn = termEn.ToLower();          //转为小写
                    //包含该术语
                    if(En.Contains(termEn))
                    {
                        List<string> temp = new List<string>();
                        temp.Add(term.Key);
                        temp.Add(term.Value[0]);
                        result.Add(temp);
                    }
                }

                return result;
            }
            catch (Exception)       //中间有多余的空格，使用split会发生数组越界（直接返回无）
            {
                return null;
            }
        }

        //查询术语功能按键 - 忽略输入大小写【转为小写】
        static public string[] findTermLower(string En)
        {
            //数据清洗
            En = En.ToLower().Trim();
            
            string[] res = new string[2];
            foreach(var term in TermBase.TermMap)
            {
                //将键全部转为小写比较
                string str = term.Key.ToLower();
                if (str.Equals(En))
                {
                    res[0] = term.Value[0];
                    res[1] = term.Value[1];
                    break;
                }
            }
            return res;
        }

        //删除术语
        static public bool delete(string En)
        {
            //数据清洗
            En = En.Trim();

            if (TermBase.TermMap.ContainsKey(En))
            {
                TermMap.Remove(En);         //删除
                return true;
            }
            else return false;
        }

        //修改术语
        static public bool modify(string En, string Zn, string Exp)
        {
            //数据清洗
            En = En.Trim();
            Zn = Zn.Trim();
            Exp = Exp.Trim();

            if (TermMap.ContainsKey(En))
            {
                List<string> temp = new List<string>();
                temp.Add(Zn);
                temp.Add(Exp);

                TermMap[En] = temp;
                return true;
            }
            else return false;
        }
        

        //将数据库内所有信息全部加入至本地Dictionary字典中
        static public void getTermFromDatabase()
        {
            try
            {
                string Table = MyLogin.admin.Id + MyLogin.admin.StartDate;
                string TableName = "Term";
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql = "select * from " + TableName;//生成一条sql语句
                sql = string.Format(sql);
                //写入字段
                MySqlCommand cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();         //返回执行结果

                Data.NAR(TermMap);
                TermMap = new Dictionary<string, List<string>>();       //为Map分配内存空间
                
                while (rs.Read())
                {
                    List<string> temp = new List<string>();
                    temp.Add(rs.GetString("Zn"));
                    temp.Add(rs.GetString("ep"));

                    TermMap.Add(rs.GetString("En"), temp);      //字典对象添加数据
                }

                Data.NAR(cmd);
            }
            catch (Exception)
            {
                ;       //没有表则不创建
            }
            finally
            {
                Data.Close();
            }
        }

        //将本地字典所有术语数据全部插入至数据库
        static public void InsertAllTerm(string StartDate)
        {
            try
            {
                if (TermMap == null) return;         //无数据，直接返回

                string Table = MyLogin.admin.Id + StartDate;
                string TableName = "Term";
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
                String sql0 = "create table if not exists " + TableName + " (En varchar(254) primary key, Zn varchar(254) not null, ep varchar(254))DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                //ignore插入时忽视冲突主键，仅返回0
                String sql = "insert ignore into " + TableName + " (En, Zn, ep) values"; // 生成一条sql语句

                bool flag = false;                              //判断是否为第一个数据
                foreach (var temp in TermMap)
                {
                    if (flag) sql += ",('" + temp.Key.Replace("'", "''") + "','" +             //剩余数据
                            temp.Value[0].Replace("'", "''") + "','" + temp.Value[1].Replace("'", "''") + "')";
                    else
                    {
                        sql += "('" + temp.Key.Replace("'", "''") + "','" +                   //第一个数据
                            temp.Value[0].Replace("'", "''") + "','" + temp.Value[1].Replace("'", "''") + "')";  
                        flag = true;
                    }
                }

                cmd = new MySqlCommand(sql, Data.connect());    //写入字段
                cmd.ExecuteNonQuery();                          //返回执行结果

                Data.NAR(cmd);
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

        //载入项目一次性封装 - 封装术语词汇为按钮
        static public void packagingTerm()
        {
            try
            {
                //清空左、右原界面
                TermBase.panel2.Controls.Clear();
                TermBase.panel3.Controls.Clear();
                
                string[] Result = { "", "", "" };

                int index = 0;

                foreach (var temp in TermBase.TermMap)
                {
                    Result[0] = temp.Key;
                    Result[1] = temp.Value[0];
                    Result[2] = temp.Value[1];

                    string buttonName = "button" + index.ToString();

                    //Button button = new WinformControlLibraryExtension.ButtonExt();
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(8, 30 * index + 3);  //位置随按钮数量
                    button.Name = buttonName;
                    button.Size = new System.Drawing.Size(100, 25);             //高度25
                    button.TabIndex = index;
                    button.Text = Result[0];
                    button.UseVisualStyleBackColor = true;

                    //新增两个绑定的Label【定义List列表存储绑定的label、删除时一起删除，一起修改】
                    
                    //传自定义参数至按钮点击事件
                    button.Click += (sender, e) => term_Button_Click(button);

                    TermBase.panel2.Controls.Add(button);
                    //索引值增加
                    index++;
                }
            }
            catch (Exception)
            {
                ;       //没有表则不创建
            }
        }

        //删除单个术语封装按钮：以最后一个按钮进行位置替补
        static public void packageTermDeleteButton(object obj)
        {
            //数据清洗
            string En = (string)obj;
            En = En.Trim();

            TermBase.panel3.Controls.Clear();           //清除右侧详细信息

            try
            {
                Control[] button = new Control[1];
                //搜索获取数据找到点击的按钮
                if (TermBase.buttonName != null && TermBase.buttonName.Length > 0)
                    button = TermBase.panel2.Controls.Find(TermBase.buttonName, false);

                //button.Count - 1始终为同一个
                if(button != null && button.Count() != 0)
                {
                    //替换删除按钮文本的内容为容器最后一个按钮内容，并删除最后一个按钮
                    button[0].Text = TermBase.panel2.Controls[TermBase.panel2.Controls.Count - 1].Text;
                    TermBase.panel2.Controls.Remove(TermBase.panel2.Controls[TermBase.panel2.Controls.Count - 1]);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);       //没有表则不创建
            }
        }

        //导入术语库、添加术语按钮刷新 - 直接添加至尾部
        static public void packageTermAddButton(object obj)
        {
            string[] AllInfo = (string[])obj;
            //数据清洗
            string En = AllInfo[0].Trim();
            string Zn = AllInfo[1].Trim();
            string cep = AllInfo[2].Trim();

            try
            {
                int index = 0;                  //下标从0开始
                //新控件的下标即容器中的控件数Count
                index = TermBase.panel2.Controls.Count;

                string[] Result = { En, Zn, cep };

                string buttonName = "button" + index.ToString();

                //初始按钮位置为3【-27 + 30】
                System.Drawing.Point point = new System.Drawing.Point(11, -27);
                if (TermBase.panel2.Controls.Count > 0)
                   point  = TermBase.panel2.Controls[TermBase.panel2.Controls.Count - 1].Location;

                //Button button = new WinformControlLibraryExtension.ButtonExt();
                Button button = new Button();
                button.Location = new System.Drawing.Point(8, point.Y + 30);  //位置随按钮数量
                button.Name = buttonName;
                button.Size = new System.Drawing.Size(100, 25);             //高度25
                button.TabIndex = index;
                button.Text = Result[0];
                button.UseVisualStyleBackColor = true;
                
                //传自定义参数至按钮点击事件
                button.Click += (sender, e) => term_Button_Click(button);

                TermBase.panel2.Controls.Add(button);       //容器添加按钮

                Data.NAR(point);
            }
            catch (Exception)
            {
                ;       //没有表则不创建
            }
        }

        //删除项目、清空术语库按钮刷新 - 直接清空
        static public void packageTermClear()
        {
            try
            {
                //清空左、右原界面
                TermBase.panel2.Controls.Clear();
                TermBase.panel3.Controls.Clear();
            }
            catch (Exception)
            {
                ;
            }
        }

        //修改术语：刷新右侧显示界面
        static public void packageTermBaseFlushRight()
        {
            try
            {
                Control[] button = new Control[1];
                //搜索获取数据找到原点击的按钮
                if (TermBase.buttonName != null && TermBase.buttonName.Length > 0)
                    button = TermBase.panel2.Controls.Find(TermBase.buttonName, false);

                if (button != null && button.Count() != 0)
                {
                    term_Button_Click((Button)button[0]);          //依据先前点击按钮，刷新右侧界面
                }
            }
            catch (Exception)
            {

            }
        }

        //术语按钮响应事件
        static private void term_Button_Click(Button button)
        {
            //针对panel3进行更改
            TermBase.panel3.Controls.Clear();
            //结果集 - 依据TermMap查询该按钮的信息，封装至右侧容器
            string[] Res = { button.Text, TermBase.TermMap[button.Text][0], TermBase.TermMap[button.Text][1] };
            //记载点击En值
            TermBase.lastEn = Res[0];
            TermBase.buttonName = button.Name;           //传入按钮的Name属性

            //panel3位置及尺寸：(142, 3)(607, 534)，上下间隔20，宽400，高50
            // 
            // label1
            // 
            Label label1 = new System.Windows.Forms.Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 20);
            label1.Name = "En";
            label1.Size = new System.Drawing.Size(550, 50);
            label1.TabIndex = 0;
            label1.Text = "En：" + Res[0];
            label1.Font = new System.Drawing.Font("宋体", 9f);

            // 
            // label2
            // 
            Label label2 = new System.Windows.Forms.Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 90);
            label2.Name = "Zn";
            label2.Size = new System.Drawing.Size(550, 50);
            label2.TabIndex = 0;
            label2.Text = "Zn：" + Res[1];
            label2.Font = new System.Drawing.Font("宋体", 9f);

            // 
            // label3
            // 
            Label label3 = new System.Windows.Forms.Label();
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 160);
            label3.Name = "Exp";
            label3.Size = new System.Drawing.Size(550, 50);
            label3.TabIndex = 0;
            label3.Text = "Ep：" + Res[2];
            label3.Font = new System.Drawing.Font("宋体", 9f);

            TermBase.panel3.Controls.Add(label1);
            TermBase.panel3.Controls.Add(label2);
            TermBase.panel3.Controls.Add(label3);
        }
        
        //清空上一次标记
        static public void initLastTerm()
        {
            TermBase.lastEn = "";
            TermBase.buttonName = "";
        }
    }
}
