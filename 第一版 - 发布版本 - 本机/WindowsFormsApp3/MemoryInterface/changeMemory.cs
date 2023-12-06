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
    public partial class changeMemory : Form
    {
        public changeMemory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //修改记忆库
            if (En.Text.Trim().Length == 0)
                MessageBoxExt.Show(this, @"输入句对不能为空！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else if (Memory.modify(En.Text, Zn.Text))
            {
                MessageBoxExt.Show(this, @"修改句段对成功！", "修改句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                string[] AllInfo = { En.Text, Zn.Text };
                Memory.packageMemoryModify(AllInfo);         //更新记忆库展示区
            }
            else
                MessageBoxExt.Show(this, @"该句段对不存在！", "修改句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }
    }
}
