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

namespace WindowsFormsApp3.MemoryInterface
{
    public partial class addMemory : Form
    {
        public addMemory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //增加记忆库数据
            if(En.Text.Trim().Length == 0)
                MessageBoxExt.Show(this, @"输入句对不能为空！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else if (Memory.add(En.Text, Zn.Text))
            {
                MessageBoxExt.Show(this, @"句对添加成功！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                string[] AllInfo = { En.Text, Zn.Text };
                Memory.packageMemoryAdd(AllInfo);         //重新加载记忆库视图 - 增加句对
            }
            else
                MessageBoxExt.Show(this, @"句对已存在！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }
    }
}
