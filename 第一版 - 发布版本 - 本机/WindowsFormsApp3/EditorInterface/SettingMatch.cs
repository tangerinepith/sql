using DataBaseLink;
using MainInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.ProjectInterface;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.EditorInterface
{
    public partial class SettingMatch : Form
    {
        public SettingMatch()
        {
            InitializeComponent();
        }

        //取消设置
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确认设置
        private void button1_Click(object sender, EventArgs e)
        {
            String str = text.Text;
            str = str.Trim();
            if (str == null || str.Length == 0)
            {
                //没有值
                MessageBoxExt.Show(this, @"值不能为空！", "匹配度设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            else
            {
                int value = -1;
                try
                {
                    value = Convert.ToInt32(str);
                    if (value >= 30 && value <= 100)
                    {
                        this.Close();
                        //设置匹配值
                        Editor.matchNum = value;
                        //数据库存储匹配值
                        if(Project.updateMatching(value))          //更新值
                            MessageBoxExt.Show(Interface.GetOnlyInterface, @"设置项目匹配值成功！", "匹配度设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        else
                            MessageBoxExt.Show(Interface.GetOnlyInterface, @"更新项目匹配值失败！请检查网络设置", "匹配度设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    }
                    else
                    {
                        MessageBoxExt.Show(this, @"请输入30~100内整数！", "匹配度设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    }
                }
                catch(Exception)
                {
                    MessageBoxExt.Show(Interface.GetOnlyInterface, @"匹配度设置失败！", "匹配度设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                }
            }
        }
    }
}
