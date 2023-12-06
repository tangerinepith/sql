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
    public partial class findTerm : Form
    {
        public findTerm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] res = TermBase.findTermLower(En.Text);
            //显示查询信息 - 访问Map是否包含该键
            if (res != null && (res[0] != null && res[0].Length > 0 || res[1] != null && res[1].Length > 0))
                MessageBoxExt.Show(this, res[0] + " " + res[1], "查找术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else
                MessageBoxExt.Show(this, @"该词汇不存在！", "查找术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
        }
    }
}
