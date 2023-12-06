using DataBaseLink;
using LoginSpace;
using MainInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.EditorInterface;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.ProjectInterface
{
    public partial class createProjectFunc : Form
    {
        public createProjectFunc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //创建项目确认按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //去除时间字符串中空格
            string timeStr = dateTimePicker1.Value.ToString().Replace(" ", "-");

            //记载项目至数据库
            bool flag = false;                   //判断输入框是否存在空
            string str1 = "";                    //声明
            string str2 = "";
            string str3 = "";

            if (pName.Text.Length != 0)
                str1 = pName.Text;         //项目名称
            else
                flag = true;

            if (cName.Text.Length != 0)
                str2 = cName.Text;         //创建者
            else
                flag = true;

            if (lName.Text.Length != 0)
                str3 = lName.Text;         //客户
            else
                flag = true;

            string fileHead = "";         //设置文件头 - 项目名称、创建者、客户、到期时间
            fileHead += str1 + " " + str2 + " " + str3 + " " + timeStr;

            fileHead += " ";                                    //分割 + 创建时间 + 项目运行初始状态
            //项目开始时间
            string startTime = System.DateTime.Now.ToString("G").Replace(" ", "-");
            fileHead += startTime + " " + "0%";

            //flag - 基本输入信息；Flag - 文件导入； flag2 - 文件另存为信息
            //if (flag || !Flag || !flag2)
            if (flag)
            {                                   //信息没有填写完成
                MessageBoxExt.Show(this, @"请填写完整项目信息！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            else
            {
                if (pName.Text.Length > 20)
                {
                    MessageBoxExt.Show(this, @"项目名称不能超过20字！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                if (cName.Text.Length > 15)
                {
                    MessageBoxExt.Show(this, @"创建者名称不能超过15字！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                if (lName.Text.Length > 15)
                {
                    MessageBoxExt.Show(this, @"客户名称不能超过15字！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                if(OpenBox.Text.Length <= 0)
                {
                    MessageBoxExt.Show(this, @"请打开待翻译文件！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                if(SaveBox.Text.Length <= 0)
                {
                    MessageBoxExt.Show(this, @"请浏览项目存储位置！", "创建项目", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    return;
                }

                string savePath = SaveBox.Text;
                savePath = savePath.Replace("\\", "/");         //解决数据库无法存储问题，替换为/，该路径windows也能访问
                string openPath = OpenBox.Text;
                //eComponent.setFileHead(fileHead);       //文件属性设置

                //原项目文件编号
                Editor.GetPreStartDate = MyLogin.admin.StartDate;
                
                MyLogin.admin.StartDate = startTime;     //设置用户新项目开始时间

                string[] AllInfo = { openPath, fileHead, savePath };
                //开启子线程导入数据并存储
                Thread importMemoryThread = new Thread(new ParameterizedThreadStart(Interface.GetOnlyInterface.CreateProject));
                importMemoryThread.Start(AllInfo);                        //开启导入记忆库数据线程

                this.Close();
            }
        }

        //浏览打开文件
        private void button3_Click(object sender, EventArgs e)
        {
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default";
            openFileDialog1.Filter = "待翻译文件.txt|*.txt|待翻译文件.doc|*.doc|待翻译文件.docx|*.docx";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                string Name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if(!Name.Substring(Name.Length - 6).Contains(".txt"))
                {
                    Data.GetOpenModel = true;           //打开方式设置为word
                }
                string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                OpenBox.Text = path;
            }
        }

        //浏览保存文件
        private void button4_Click(object sender, EventArgs e)
        {
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
                string path = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                SaveBox.Text = path;
            }
        }
    }
}
