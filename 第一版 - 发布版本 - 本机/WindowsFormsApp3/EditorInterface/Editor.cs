using DataBaseLink;
using LoginSpace;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.MemoryInterface;
using WindowsFormsApp3.TermBaseInterface;
using WinformControlLibraryExtension;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using MainInterface;

namespace WindowsFormsApp3.EditorInterface
{
    class Editor
    {
        //区域声明
        private Panel area;
        private Panel left;
        //组件声明
        Label label1;
        static Panel panel4;
        static Panel statePanel;
        static Panel ZnPanel;
        static Panel EnPanel;
        static Panel panel3;        //术语区域
        static Panel panelTerm;     //匹配到词汇显示区域
        static Label label3;            
        static Panel panel2;        //翻译区域
        static Label label2;

        static Label label8 = new Label();          //分割线-垂直
        static Label label9 = new Label();          //分割线-水平
        //项目匹配度
        static internal double matchNum = 75;
        static private List<List<string>> TransMap = new List<List<string>>();  //本项目所有信息 En、Zn、State
        static private List<List<string>> TransList = new List<List<string>>();        //项目所有信息，分别为En，Zh，State
        static List<string[]> matchingResult = new List<string[]>();            //匹配结果
        //目前选中的英文文本框、中文文本框和对应状态栏
        static private RichTextBox preEnText = null;
        static private RichTextBox preZnText = null;
        static private Label preState = null;
        //是否更改项目数据
        static private bool IsChangeData = false;
        //是否开启机器翻译
        static private bool IsMachineTranslation = false;      

        //原项目文件对象：用于新建项目、导入项目时恢复原项目
        static private string PreStartDate = "";

        static public bool GetIsMachineTranslation
        {
            get
            {
                return Editor.IsMachineTranslation;
            }
            set
            {
                Editor.IsMachineTranslation = value;
            }
        }

        static public string GetPreStartDate
        {
            get
            {
                return Editor.PreStartDate;
            }
            set
            {
                Editor.PreStartDate = value;
            }
        }

        static internal bool GetIsChangeData
        {
            get
            {
                return Editor.IsChangeData;
            }
            set
            {
                Editor.IsChangeData = value;        //删除当前运行项目后，该标记置为空
            }
        }
        
        static internal RichTextBox PreEnText
        {
            get
            {
                return Editor.preEnText;
            }
        }
        static internal RichTextBox PreZnText
        {
            get
            {
                return Editor.preZnText;
            }
        }
        static internal Label PreState
        {
            get
            {
                return Editor.preState;
            }
        }

        static public List<List<string>> GetTransMap
        {
            get
            {
                //PreSaveContent();           //更新Map集信息，导出项目时防止数据过时
                Interface.GetOnlyInterface.SaveEditorContent();
                return Editor.TransMap;
            }
            set
            {
                Editor.TransMap = value;
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


        //添加组件
        private void addModule()
        {
            //获取变量内存空间
            panel4 = new System.Windows.Forms.Panel();
            panelTerm = new System.Windows.Forms.Panel();
            statePanel = new System.Windows.Forms.Panel();
            ZnPanel = new System.Windows.Forms.Panel();
            EnPanel = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            // 
            // label8 分割线竖直
            // 
            label8.AutoSize = false;
            label8.Location = new System.Drawing.Point(350, 0);
            label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label8.Name = "label8";         
            label8.TabIndex = 3;
            label8.Size = new System.Drawing.Size(0, 0);
            //label8.Size = new System.Drawing.Size(1, 850);      //随文本框数目变化
            //label8.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
            // 
            // label9 分割线水平
            // 
            label9.AutoSize = false;
            label9.Location = new System.Drawing.Point(0, 279);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(755, 2);
            label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label9.TabIndex = 3;
            
            //组件变量赋值
            // 
            // 右上角编辑区域
            // 
            panel4.Controls.Add(statePanel);
            panel4.Controls.Add(ZnPanel);
            panel4.Controls.Add(EnPanel);
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(755, 279);
            panel4.TabIndex = 1;
            panel4.MouseWheel += new System.Windows.Forms.MouseEventHandler(Editor_MouseWheel);
            // 
            // 匹配术语展示区域
            // 
            panelTerm.AutoSize = false;
            panelTerm.Location = new System.Drawing.Point(0, 41);
            panelTerm.Name = "panelTerm";
            panelTerm.Size = new System.Drawing.Size(240, 199);
            panelTerm.TabIndex = 1;
            panelTerm.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            panelTerm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // statePanel 339 42
            // 
            //statePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            //statePanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            statePanel.Location = new System.Drawing.Point(703, 0);
            statePanel.Name = "statePanel";
            statePanel.Size = new System.Drawing.Size(31, 279);
            statePanel.TabIndex = 6;
            statePanel.ForeColor = System.Drawing.Color.White;
            // 
            // ZnPanel
            // 
            ZnPanel.Location = new System.Drawing.Point(353, 0);
            ZnPanel.Name = "ZnPanel";
            ZnPanel.Size = new System.Drawing.Size(350, 279);
            ZnPanel.TabIndex = 5;
            // 
            // EnPanel
            // 
            EnPanel.Location = new System.Drawing.Point(0, 0);
            EnPanel.Name = "EnPanel";
            EnPanel.Size = new System.Drawing.Size(350, 279);
            EnPanel.TabIndex = 4;
            // 
            // 术语区域
            // 
            panel3.Controls.Add(label3);
            panel3.Location = new System.Drawing.Point(505, 280);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(250, 249);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = false;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(250, 41);
            label3.TabIndex = 0;
            label3.Text = "术语";
            //label3.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 40);
            label1.TabIndex = 0;
            label1.Text = "编辑器";
            label1.ForeColor = System.Drawing.Color.White ;

            // 
            // 匹配对比区域
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new System.Drawing.Point(0, 280);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(505, 249);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(505, 41);
            label2.TabIndex = 0;
            label2.Text = "匹配对比";
            //label2.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //小型模块区域添加
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();

            //左右大型区域添加模块
            this.area.Controls.Add(panel2);
            this.area.Controls.Add(panel4);
            this.area.Controls.Add(label9);        //上下分割线
            this.area.Controls.Add(panel3);
            this.left.Controls.Add(label1);

            //滑动条显示
            panel4.Controls.Add(label8);        //左右分割线
            panel4.AutoScroll = true;           //右上角
            panel3.AutoScroll = true;           //右下角术语区域
        }

        //组件添加功能
        private void addModuleFunc()
        {

        }

        //将带翻译句子读入，并封装成文本框和状态栏 - EnPanel、ZnPanel、statePanel
        public void startToWork()
        {

        }

        //鼠标滚轮控制编辑器区域移动
        static private void Editor_MouseWheel(object sender, MouseEventArgs e)
        {
            int pos = Editor.panel4.VerticalScroll.Value - e.Delta / 6;
            if (pos >= Editor.panel4.VerticalScroll.Minimum && pos <= Editor.panel4.VerticalScroll.Maximum)
                Editor.panel4.VerticalScroll.Value = pos;
            else if(pos < Editor.panel4.VerticalScroll.Minimum)         //比最小值小
                Editor.panel4.VerticalScroll.Value = Editor.panel4.VerticalScroll.Minimum;
            else    //比最大值大
                Editor.panel4.VerticalScroll.Value = Editor.panel4.VerticalScroll.Minimum;
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
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(103, 320);
            this.left.TabIndex = 3;
            this.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.left.Font = new System.Drawing.Font("宋体", 9f);

            this.area.Controls.Clear();         //清除
            this.left.Controls.Clear();         //清除

            //添加组件及其功能
            this.addModule();
            this.addModuleFunc();
        }

        //读取待翻译文件至数据库 project - content
        static public void addContent(List<List<string>> temp) //状态0表示未通过
        {
            try
            {
                Data.NAR(TransMap);
                TransMap = new List<List<string>>();          //加载新项目，重新分配内存区域
                TransMap = temp;

                saveContent();                      //将载入项目的所有句对信息全部加入至数据库内
            }
            catch (Exception)
            {
                return;
            }
        }

        //同步Text内容至List对象中
        static public void PreSaveContent()
        {
            //同步所有Text数据至Map中，防止数据过时
            for (int i = 0; i < Editor.EnPanel.Controls.Count; i++)
            {
                string En = Editor.EnPanel.Controls[i].Text.Trim();        //En
                string Zn = Editor.ZnPanel.Controls[i].Text.Trim();        //Zn
                string State = "";                                  //状态

                string state = Editor.statePanel.Controls[i].Text;
                if (state.Length >= 0 && state.Equals("√"))
                    State += "1";           //√ or ""
                else
                    State += "0";

                Editor.TransMap[i][0] = En;        //更新List数据
                Editor.TransMap[i][1] = Zn;
                Editor.TransMap[i][2] = State;
            }
        }

        //保存项目信息至数据库，封装函数
        static public bool saveContentFunc()
        {
            Interface.GetOnlyInterface.SaveEditorContent();
            //Editor.PreSaveContent();    //同步Text内容，防止数据过时

            //项目保存成功 - 更改标志去除
            Editor.IsChangeData = false;
            //保存信息至数据库
            if (Editor.saveContent())
                return true;
            else
                return false;
        }

        //保存本项目翻译后信息至数据库 全部Map - 数据库
        static private bool saveContent()
        {
            try
            {
                string Table = MyLogin.admin.Id + MyLogin.admin.StartDate;
                string TableName = "Content";       //归属哪个项目 - 项目开始时间，可更改为fileHead去除状态栏？
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

                String sql0 = "create table if not exists " + TableName + " (En varchar(254), Zn varchar(254), state int)DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                String sql = "insert ignore into " + TableName + " (En, Zn, state) values"; // 生成一条sql语句

                bool flag = false;                              //判断是否为第一个数据
                foreach (var temp in TransMap)
                {
                    //数据替换：放置插入时 单引号出错，故将之转为双引号，这样sql语句就会顺利插入
                    if (flag) sql += ",('" + temp[0].Replace("'", "''") + "','" + 
                            temp[1].Replace("'", "''") + "','" + temp[2].Replace("'", "''")  + "')";   //剩余数据
                    else
                    {
                        sql += "('" + temp[0].Replace("'", "''") + "','" +
                            temp[1].Replace("'", "''") + "','" + temp[2].Replace("'", "''") + "')";                    //第一个数据
                        flag = true;
                    }
                }
                
                cmd = new MySqlCommand(sql, Data.connect());    //写入字段
                cmd.ExecuteNonQuery();                //返回执行结果
                return true;
            }
            catch (Exception)
            {
                MessageBoxExt.Show(null, "存储失败！", "存储项目翻译信息", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return false;
            }
            finally
            {
                Data.Close();
            }
        }

        //从数据库内获取全部信息至Dictionary数据集
        static public void getAllContent()
        {
            try
            {
                Data.NAR(Editor.TransMap);
                Editor.TransMap = new List<List<string>>();       //置空
                string Table = MyLogin.admin.Id + MyLogin.admin.StartDate;
                string TableName = "Content";       //归属哪个项目 - 项目开始时间，可更改为fileHead去除状态栏？
                char[] CH = Table.ToCharArray();
                for (int i = 0; i < CH.Length; i++)
                {
                    char ch = CH[i];
                    if (ch >= '0' && ch <= '9')
                    {
                        TableName += (char)((ch - '0') + 'a');
                    }
                }
                String sql = "select * from " + TableName; // 生成一条sql语句
                                                           //写入字段
                MySqlCommand cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();         //返回执行结果
                
                while (rs.Read())
                {
                    List<string> temp = new List<string>();
                    temp.Add(rs.GetString("En"));
                    temp.Add(rs.GetString("Zn"));
                    temp.Add(rs.GetString("state"));
                    
                    TransMap.Add(temp);
                }
            }
            catch (Exception)
            {
                ;               //无数据表无操作
            }
            finally
            {
                Data.Close();
            }
        }
        
        //声明委托刷新编辑器区域函数
        public delegate void delegateFlushEditor();

        //封装数据至文本框 - 整体刷新编辑器界面
        static public void packageText()
        {
            try
            {
                //清空全部面板 
                Editor.packageTextDelete();

                string[] Result = { "", "", "" };
                
                if (TransMap == null) return;
                int index = 0;
                foreach (var str in Editor.TransMap)
                {
                    Result[0] = str[0];
                    Result[1] = str[1];
                    Result[2] = str[2];

                    string EnName = "En" + index.ToString();
                    string ZnName = "Zn" + index.ToString();
                    string stateName = "state" + index.ToString();

                    // 
                    // En
                    // 
                    RichTextBox En = new System.Windows.Forms.RichTextBox();
                    En.Name = EnName;
                    En.Text = Result[0];
                    En.TabIndex = 6;
                    En.ReadOnly = true;
                    En.AutoSize = false;
                    En.WordWrap = false;
                    En.ScrollBars = RichTextBoxScrollBars.None;
                    En.SelectionStart = En.TextLength;
                    
                    //En.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    // 
                    // Zn
                    // 
                    RichTextBox Zn = new System.Windows.Forms.RichTextBox();
                    Zn.Name = ZnName;
                    Zn.TabIndex = 6;
                    Zn.Text = Result[1];          //中文句对输出
                    Zn.AutoSize = false;
                    Zn.WordWrap = false;
                    Zn.ScrollBars = RichTextBoxScrollBars.None;
                    Zn.SelectionStart = En.TextLength;
                    //Zn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


                    //state
                    Label state = new System.Windows.Forms.Label();
                    state.Name = stateName;
                    if (Result[2].Equals("1"))
                        state.Text = "√";
                    state.TabIndex = 6;
                    state.AutoSize = false;
                    state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    //Panel3区域(349)
                    //设置两者高度和宽度,及所处位置
                    En.Size = new System.Drawing.Size(350, 30);
                    Zn.Size = new System.Drawing.Size(350, 30);
                    state.Size = new System.Drawing.Size(31, 30);
                    En.Font = new System.Drawing.Font("宋体", 9f);
                    Zn.Font = new System.Drawing.Font("宋体", 9f);
                    En.SelectionAlignment = HorizontalAlignment.Center;
                    Zn.SelectionAlignment = HorizontalAlignment.Center;
                    En.BorderStyle = BorderStyle.None;
                    Zn.BorderStyle = BorderStyle.None;

                    //位置设置
                    if (index > 0)
                    {
                        int y = EnPanel.Controls[EnPanel.Controls.Count - 1].Location.Y;
                        En.Location = new System.Drawing.Point(0, y + 30);
                        Zn.Location = new System.Drawing.Point(0, y + 30);
                        state.Location = new System.Drawing.Point(0, y + 30);
                    }
                    else
                    {
                        En.Location = new System.Drawing.Point(0, 0);
                        Zn.Location = new System.Drawing.Point(0, 0);
                        state.Location = new System.Drawing.Point(0, 0);
                    }
                    Zn.BackColor = En.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251))))); ;

                    //文本框添加响应功能
                    //传自定义参数至按钮点击事件
                    System.Drawing.Color preColor = En.BackColor;
                    //鼠标点击事件传参问题无需更改，传参即为对象
                    En.Click += (sender, e) => Text_Click(En, En, Zn, state, En.Text);
                    En.Leave += (sender, e) => Text_Leave(En);
                    Zn.Click += (sender, e) => Text_Click(Zn, En, Zn, state, En.Text);
                    Zn.Leave += (sender, e) => Text_Leave(Zn);
                    En.MouseMove += (sender, e) => Text_MouseMove(En);              //鼠标进来
                    Zn.MouseMove += (sender, e) => Text_MouseMove(Zn);
                    En.MouseLeave += (sender, e) => Text_MouseLeave(En, preColor);       //鼠标移动出去
                    Zn.MouseLeave += (sender, e) => Text_MouseLeave(Zn, preColor);
                    Zn.TextChanged += new EventHandler(Text_Content_Change);
                    
                    //鼠标滚动事件
                    En.MouseWheel += new MouseEventHandler(Editor_MouseWheel);
                    Zn.MouseWheel += new MouseEventHandler(Editor_MouseWheel);

                    //添加组件
                    Editor.EnPanel.Controls.Add(En);
                    Editor.statePanel.Controls.Add(state);
                    Editor.ZnPanel.Controls.Add(Zn);
                    index++;
                }
                //容器尺寸设置
                Editor.EnPanel.Size = new System.Drawing.Size(350, 30 * index);
                Editor.statePanel.Size = new System.Drawing.Size(31, 30 * index);
                Editor.ZnPanel.Size = new System.Drawing.Size(350, 30 * index);
                Editor.label8.Size = new System.Drawing.Size(2, 30 * index);
                //容器位置设置
                Editor.EnPanel.Location = new System.Drawing.Point(0, 0);
                Editor.statePanel.Location = new System.Drawing.Point(703, 0);
                Editor.ZnPanel.Location = new System.Drawing.Point(353, 0);
                Editor.statePanel.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                //Error
                //MessageBoxExt.Show(null, @"封装项目句对出错！", "封装项目句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error);
            }
        }

        //匹配翻译：替换指定栏文本内容
        static public void packageTextReplace()
        {
            try
            {
                //遍历所有容器，根据EnPanel控件文本框内容替换ZnPanel内容
                for(int i = 0; i < Editor.EnPanel.Controls.Count; i++)
                {
                    //string En = Editor.EnPanel.Controls[i].Text;
                    RichTextBox temp = (RichTextBox)Editor.ZnPanel.Controls[i];
                    temp.Text = Editor.TransMap[i][1];       //直接将List中文填至对应中文控件
                    temp.SelectionAlignment = HorizontalAlignment.Center;
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        //删除项目：直接清空
        static public void packageTextDelete()
        {
            //清空面板 - 上半部分
            Editor.panel4.Controls.Clear();          //清空上部分panel4
            Editor.EnPanel.Controls.Clear();
            Editor.statePanel.Controls.Clear();
            Editor.ZnPanel.Controls.Clear();

            //清空 - 下半部分
            Editor.panel2.Controls.Clear();
            Editor.panel3.Controls.Clear();         //清空术语区域

            //容器尺寸重置
            Editor.EnPanel.Size = new System.Drawing.Size(0, 0);
            Editor.statePanel.Size = new System.Drawing.Size(0, 0);
            Editor.ZnPanel.Size = new System.Drawing.Size(0, 0);
            Editor.label8.Size = new System.Drawing.Size(0, 0);

            //增加部分
            Editor.label2.Text = "匹配对比";
            Editor.panel2.Controls.Add(Editor.label2);      //匹配句对区域
            Editor.panel3.Controls.Add(Editor.label3);      //术语区域
            Editor.panel4.Controls.Add(EnPanel);            //上半部分
            Editor.panel4.Controls.Add(statePanel);
            Editor.panel4.Controls.Add(ZnPanel);
            Editor.panel4.Controls.Add(label8);             //竖直分割线
        }

        //文本框失去焦点时
        static private void Text_Leave(RichTextBox box)
        {
            //box.BorderStyle = BorderStyle.None;
        }

        //鼠标移除文本框
        static private void Text_MouseLeave(RichTextBox box, System.Drawing.Color preColor)
        {
            //更改本文本框颜色
            box.BackColor = preColor;
            box.ForeColor = System.Drawing.Color.Black;
        }

        //鼠标移动至文本框
        private static void Text_MouseMove(RichTextBox box)
        {
            //更改本文本框颜色
            box.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            box.ForeColor = System.Drawing.Color.White;
        }

        //文本框数据改变响应函数
        static private void Text_Content_Change(object sender, EventArgs e)
        {
            Editor.IsChangeData = true;         //更改数据之后,设置标志位
        }

        //点击文本框信息响应 - 执行术语匹配功能，展示翻译结果
        //本框 - En框，Zn框，state栏，词汇param
        static private void Text_Click(RichTextBox box, RichTextBox Enbox, RichTextBox Znbox, Label state, string paramStr)
        {
            try
            {
                try
                {
                    //确定选中文本框及标签
                    Editor.preEnText = Enbox;
                    Editor.preZnText = Znbox;
                    Editor.preState = state;

                    //更改本文本框颜色 - 新增边框
                    //box.BorderStyle = BorderStyle.FixedSingle;

                    packageTerm(TermBase.findTerm(paramStr));        //封装术语
                    packageSentence(paramStr);  //封装匹配句对
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
            }
            catch (Exception)
            {
                return;             //出错
            }
        }

        //点击文本框信息响应 - 执行术语匹配功能，展示翻译结果
        static private void packageTerm(List<List<string>> term)
        {
            //清空
            Editor.panelTerm.Controls.Clear();
            //Editor.panel3.Controls.Add(Editor.label3);
            int index = 0;
            foreach (List<string> list in term)
            {
                // 
                // label2
                // 100, 9， 234, 175
                Label label2 = new System.Windows.Forms.Label();
                label2.AutoSize = false;
                label2.Name = "En" + index.ToString();
                label2.Size = new System.Drawing.Size(110, 30);
                label2.TabIndex = 0;
                label2.Text = list[0];
                label2.Font = new System.Drawing.Font("宋体", 9f);

                // 
                // label3
                // 
                Label label3 = new System.Windows.Forms.Label();
                label3.AutoSize = false;
                label3.Name = "Zn" + index.ToString();
                label3.Size = new System.Drawing.Size(110, 30);
                label3.TabIndex = 0;
                label3.Text = list[1];
                label3.Font = new System.Drawing.Font("宋体", 9f);

                //位置、大小
                if (index > 0)
                {
                    int y = Editor.panelTerm.Controls[Editor.panelTerm.Controls.Count - 1].Location.Y;
                    label2.Location = new System.Drawing.Point(10, y + 30);
                    label3.Location = new System.Drawing.Point(120, y + 30);
                }
                else
                {
                    label2.Location = new System.Drawing.Point(10, 10);
                    label3.Location = new System.Drawing.Point(120, 10);
                }
                //序号递增
                index++;

                //放入区域
                panelTerm.Controls.Add(label2);
                panelTerm.Controls.Add(label3);
            }
            panel3.Controls.Add(panelTerm);     //添加区域
        }

        //进行匹配句对功能 - 展现匹配句对结果
        static private void packageSentence(string paramStr)
        {
            Editor.panel2.Controls.Clear();         //清空
            Editor.label2.Text = "匹配句对";
            Editor.panel2.Controls.Add(Editor.label2);

            bool[] flagA = new bool[100];
            bool[] flagB = new bool[100];

            string[] result = ClickMatchSentence(flagA, flagB, paramStr);
            
            //封装句对操作 - 201, 10    503, 175
            // 
            // richTextBox1
            // 
            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.Location = new System.Drawing.Point(10, 41);
            richTextBox1.Name = "preEn";
            richTextBox1.Size = new System.Drawing.Size(485, 95);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = paramStr;
            richTextBox1.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;

            RichTextBox richTextBox2 = new RichTextBox();
            richTextBox2.Location = new System.Drawing.Point(10, 145);
            richTextBox2.Name = "resEn";
            richTextBox2.Size = new System.Drawing.Size(485, 95);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "";
            richTextBox2.BackColor = System.Drawing.Color.FromArgb(207, 213, 225);
            richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            //放入区域
            Editor.panel2.Controls.Add(richTextBox1);
            Editor.panel2.Controls.Add(richTextBox2);

            if (result == null) return;             //无数据

            richTextBox2.Text = result[0];
            // 匹配度 - 加到匹配句对后面
            if (result[2].Length >= 4)
                Editor.label2.Text = "匹配对比" + "[" + result[2].Substring(0, 4) + "]";
            else
                Editor.label2.Text = "匹配对比" + "[" + result[2] + "]";

            //存在匹配句对情况下，处理并标红指定单词
            string[] En = paramStr.Split(' ');
            int Num = 0;
            for (int j = 1; j < En.Length; j++)
            {
                if (!flagA[j])
                {
                    //标红 Num - En[j-1].Length区域字体
                    richTextBox1.Select(Num, En[j - 1].Length);
                    richTextBox1.SelectionColor = System.Drawing.Color.Red;
                }
                Num += En[j - 1].Length + 1;
            }

            string[] res = result[0].Split(' ');
            int Num2 = 0;
            for (int j = 1; j < res.Length; j++)
            {
                if (!flagB[j])
                {
                    //标红 Num - En[j-1].Length区域字体
                    richTextBox2.Select(Num2, res[j - 1].Length);
                    richTextBox2.SelectionColor = System.Drawing.Color.Red;
                }
                Num2 += res[j - 1].Length + 1;
            }
        }
        
        //匹配算法
        static public string MatchSentence(string paramStr)
        {
            //英文
            string[] EnA = new string[100];
            EnA[0] = "";
            int lenA = 1;
            string[] str = paramStr.Split(' ');
            //获取英文串 - En
            for (int i = 0; i < str.Length; i++)
            {
                EnA[lenA++] = str[i];
            }
            lenA--;
            //去除末尾标点符号
            EnA[lenA] = EnA[lenA].Replace('.', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace(',', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace('?', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace('!', char.MinValue);
            
            //dp递归数组
            int[,] dp = new int[2, 150];
            //待封装结果集
            String Zn = "";
            //获取本地列表所有匹配句对
            Dictionary<string, string> ZnList = Memory.GetSentenceMap;

            //if (ZnList == null || ZnList.Count == 0) return null;

            //遍历所有记忆库句对
            foreach (var temp in ZnList)
            {
                //获取串B句对分割部分 - EnB
                string[] strB = temp.Key.Split(' ');
                string[] EnB = new string[150];
                EnB[0] = "";
                int lenB = 1;
                for (int i = 0; i < strB.Length; i++)
                {
                    EnB[lenB++] = strB[i];
                }
                lenB--;
                //去除末尾标点符号
                EnB[lenB] = EnB[lenB].Replace('.', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace(',', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace('?', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace('!', char.MinValue);

                //算法部分
                for (int i = 0; i <= lenA + 1 || i <= lenB + 1; i++)
                {
                    dp[0, i] = 0;
                }

                for (int i = 1; i <= lenA; i++)
                {
                    for (int j = 1; j <= lenB; j++)
                    {
                        if (EnA[i].Equals(EnB[j]))
                        {
                            //奇数
                            if (i % 2 == 1)
                            {
                                dp[1, j] = dp[0, j - 1] + 1;
                            }
                            else
                            {
                                dp[0, j] = dp[1, j - 1] + 1;
                            }
                        }
                        else
                        {
                            //奇数
                            if (i % 2 == 1)
                            {
                                if (dp[0, j] >= dp[1, j - 1])
                                {
                                    dp[i & 1, j] = dp[0, j];
                                }
                                else
                                {
                                    dp[i & 1, j] = dp[1, j - 1];
                                }
                            }
                            else
                            {
                                //i-1层大 
                                if (dp[1, j] >= dp[0, j - 1])
                                {
                                    dp[i & 1, j] = dp[1, j];
                                }
                                else
                                {
                                    dp[i & 1, j] = dp[0, j - 1];
                                }
                            }
                        }
                    }
                }

                //本次所具备匹配度 - Sorensen Dice 相似度系数
                double P = ((double)dp[lenA & 1, lenB] * 2) / (lenA + lenB);

                //目标要求匹配度
                double m = (double)Editor.matchNum / 100;

                if (P >= Math.Abs(m - 1e-8))
                {                       //如果达到匹配度要求 - 将该匹配串信息返回
                    Zn = temp.Value;
                    return Zn;                          //跳出循环，进行封装操作
                }
            }

            //无匹配结果，通过有道翻译进行输出【开启机器翻译输出】
            if(Editor.GetIsMachineTranslation)
                Zn = Editor.youdaoTrans(paramStr);

            //无结果
            return Zn;
        }
        
        //鼠标单机匹配算法
        static public string[] ClickMatchSentence(bool[] flagA, bool[] flagB, string paramStr)
        {
            //英文
            string[] EnA = new string[100];
            EnA[0] = "";
            int lenA = 1;
            string[] str = paramStr.Split(' ');
            //获取英文串 - En
            for (int i = 0; i < str.Length; i++)
            {
                EnA[lenA++] = str[i];
            }
            lenA--;
            //去除末尾标点符号
            EnA[lenA] = EnA[lenA].Replace('.', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace(',', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace('?', char.MinValue);
            EnA[lenA] = EnA[lenA].Replace('!', char.MinValue);

            //dp递归数组
            int[,] dp = new int[2, 100];
            //待封装结果集
            String[] EnAndZh = new String[3];
            //获取本地列表所有匹配句对
            Dictionary<string, string> ZnList = Memory.GetSentenceMap;

            //遍历所有中文句对
            foreach (var temp in ZnList)
            {
                //char数组，图
                char[,] mp = new char[100, 100];
                //获取串B句对分割部分 - EnB
                string[] strB = temp.Key.Split(' ');
                string[] EnB = new string[100];
                EnB[0] = "";
                int lenB = 1;
                for (int i = 0; i < strB.Length; i++)
                {
                    EnB[lenB++] = strB[i];
                    //去除标点符号
                }
                lenB--;
                //去除末尾标点符号
                EnB[lenB] = EnB[lenB].Replace('.', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace(',', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace('?', char.MinValue);
                EnB[lenB] = EnB[lenB].Replace('!', char.MinValue);

                //算法部分
                for (int i = 0; i <= lenA + 1 || i <= lenB + 1; i++)
                {
                    flagA[i] = false;       //初始化flagA数组
                    dp[0, i] = 0;
                }

                for (int i = 1; i <= lenA; i++)
                {
                    for (int j = 1; j <= lenB; j++)
                    {
                        if (EnA[i].Equals(EnB[j]))
                        {           
                            //奇数
                            if(i % 2 == 1)
                            {
                                dp[1, j] = dp[0, j - 1] + 1;
                                mp[i, j] = 'E';
                            }
                            else
                            {
                                dp[0, j] = dp[1, j - 1] + 1;
                                mp[i, j] = 'E';
                            }
                        }
                        else
                        {
                            //奇数
                            if(i % 2 == 1)
                            {
                                if (dp[0, j] >= dp[1, j - 1])
                                {
                                    dp[i & 1, j] = dp[0, j];
                                    mp[i, j] = 'U';
                                }
                                else
                                {
                                    dp[i & 1, j] = dp[1, j - 1];
                                    mp[i, j] = 'L';
                                }
                            }
                            else
                            {
                                //i-1层大 
                                if (dp[1, j] >= dp[0, j - 1])
                                {
                                    dp[i & 1, j] = dp[1, j];
                                    mp[i, j] = 'U';
                                }
                                else
                                {
                                    dp[i & 1, j] = dp[0, j - 1];
                                    mp[i, j] = 'L';
                                }
                            }
                        }
                    }
                }

                
                //本次所具备匹配度 - Sorensen Dice 相似度系数
                double P = ((double)dp[lenA & 1, lenB] * 2) / (lenA + lenB);
                
                //目标要求匹配度
                double m = (double)Editor.matchNum / 100;
                
                if (P >= Math.Abs(m - 1e-8))
                {                       //如果达到匹配度要求 - 将该匹配串信息返回
                    EnAndZh[0] = temp.Key;           //英文、中文、匹配度
                    EnAndZh[1] = temp.Value;
                    EnAndZh[2] = P.ToString();		//匹配度
                    
                    //遍历dp数组，找出颜色不同部分 - 标记至flagA和flagB
                    Editor.dfs(mp, flagA, flagB, lenA, lenB);
                    
                    return EnAndZh;                          //跳出循环，进行封装操作
                }
            }

            //无结果
            return null;
        }
        
        //图算法，遍历dp数组，标出两句对中共同部分
        static private void dfs(char[,] mp, bool[] flagA, bool[] flagB, int len1, int len2)
        {
            if (len1 == 0 || len2 == 0) return;

            if (mp[len1, len2] == 'E')
            {
                dfs(mp, flagA, flagB, len1 - 1, len2 - 1);
                flagA[len1] = true;
                flagB[len2] = true;
            }
            else if (mp[len1, len2] == 'U')
            {
                dfs(mp, flagA, flagB, len1 - 1, len2);
            }
            else
            {
                dfs(mp, flagA, flagB, len1, len2 - 1);
            }
        }

        //全部匹配翻译
        static public void MatchTrans()
        {
            if (TransMap == null || TransMap.Count == 0) return;
            
            //En、Zn、State - 111111
            foreach (var myStr in TransMap)
            {
                //状态为未确认，且中文句对没有时，匹配翻译
                if (int.Parse(myStr[2]) == 0 && (myStr[1] == null || myStr[1].Length == 0))
                {
                    //返回匹配到的英文、中文、匹配度
                    string str = MatchSentence(myStr[0]);
                    //匹配结果，状态未确认
                    if (str != null)
                    {
                        myStr[1] = str;    //中文添加
                    }
                    myStr[2] = "0";           //状态设为0
                }
            }
        }


        //有道翻译API调用
        private static string youdaoTrans(string En)
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();
            string url = "https://openapi.youdao.com/api";
            string q = En;
            string appKey = "17911c734617b270";
            string appSecret = "zkyhp1W9NfXC0r5LiVV7hPBDMlxN7te2";
            string salt = DateTime.Now.Millisecond.ToString();
            dic.Add("from", "en");
            dic.Add("to", "zh-CHS");
            dic.Add("signType", "v3");
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long)ts.TotalMilliseconds;
            string curtime = Convert.ToString(millis / 1000);
            dic.Add("curtime", curtime);
            string signStr = appKey + Truncate(q) + salt + curtime + appSecret; ;
            string sign = ComputeHash(signStr, new SHA256CryptoServiceProvider());
            dic.Add("q", System.Web.HttpUtility.UrlEncode(q));
            dic.Add("appKey", appKey);
            dic.Add("salt", salt);
            dic.Add("sign", sign);
            //dic.Add("vocabId", "您的用户词表ID");
            return Post(url, dic);
        }

        protected static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        protected static string Post(string url, Dictionary<String, String> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            if (resp.ContentType.ToLower().Equals("audio/mp3"))
            {
                SaveBinaryFile(resp, "合成的音频存储路径");
            }
            else
            {
                Stream stream = resp.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }

                //Json转string
                string output = JsonConvert.SerializeObject(result);

                string[] str = output.Split('"');

                for (int j = 0; j < str.Length; j++)
                {
                    //依据Json格式输出
                    if (str[j].Equals("translation\\"))
                    {
                        return str[j + 2].Remove(str[j + 2].Length - 1, 1);         //返回翻译结果
                    }
                }
            }

            return null;
        }

        protected static string Truncate(string q)
        {
            if (q == null)
            {
                return null;
            }
            int len = q.Length;
            return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
        }

        private static bool SaveBinaryFile(WebResponse response, string FileName)
        {
            string FilePath = FileName + DateTime.Now.Millisecond.ToString() + ".mp3";
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(FilePath))
                    File.Delete(FilePath);
                Stream outStream = System.IO.File.Create(FilePath);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                Value = false;
            }
            return Value;
        }

    }
}
