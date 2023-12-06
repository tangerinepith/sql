using DataBaseLink;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.TermBaseInterface
{
    public partial class addTerm : Form
    {
        public addTerm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        //添加术语
        private void button1_Click(object sender, EventArgs e)
        {
            string[] Temp = En.Text.Split(' ');
            string AllEn = "";
            
            foreach (var temp in Temp)
            {
                if (temp.Length == 0 || temp == null) continue;     //多余空格会导致越界

                if (temp[0] >= 'a' && temp[0] <= 'z')
                {
                    AllEn += (char)(temp[0] - 'a' + 'A');
                    AllEn += temp.Substring(1);
                }
                else
                {
                    AllEn += temp;
                }
                AllEn += " ";
            }

            //记录术语
            if (AllEn.Trim().Length == 0)      //已存在则提醒
                MessageBoxExt.Show(this, @"输入术语不能为空！", "添加术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else if (!TermBase.add(AllEn, Zn.Text, Exp.Text))      //已存在则提醒
                MessageBoxExt.Show(this, @"该词汇已存在！", "添加术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else
            {
                string[] AllInfo = { AllEn, Zn.Text, Exp.Text };
                TermBase.packageTermAddButton(AllInfo);             //刷新术语库
                MessageBoxExt.Show(this, @"术语添加成功！", "添加术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }
    }
}
