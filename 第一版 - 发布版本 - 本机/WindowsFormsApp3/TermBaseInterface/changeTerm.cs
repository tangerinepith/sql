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
    public partial class changeTerm : Form
    {
        public changeTerm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //修改术语
        private void button1_Click(object sender, EventArgs e)
        {
            //记载修改术语情况
            if (!TermBase.modify(TermBase.LastEn, newZn.Text, newExp.Text))
                MessageBoxExt.Show(this, @"请选择术语！", "修改术语", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else
                TermBase.packageTermBaseFlushRight();           //刷新术语库右侧界面
        }
    }
}
