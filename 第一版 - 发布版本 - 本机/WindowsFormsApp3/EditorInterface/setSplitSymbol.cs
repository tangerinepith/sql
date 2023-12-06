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
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.EditorInterface
{
    public partial class setSplitSymbol : Form
    {
        public setSplitSymbol()
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
            if (str == null || str.Length == 0)
            {
                //没有值
                MessageBoxExt.Show(this, @"值不能为空！", "分隔符设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            else
            {
                try
                {
                    this.Close();                       //设置成功，关闭窗口
                    //可设置多个分隔符 - 但只能以单个进行分割
                    DataBaseLink.Data.GetSp = str;      //设置分隔符

                    MessageBoxExt.Show(Interface.GetOnlyInterface, @"分隔符设置成功！", "分隔符设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                }
                catch (Exception)
                {
                    MessageBoxExt.Show(Interface.GetOnlyInterface, @"分隔符设置失败！", "分隔符设置", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                }
            }
        }
    }
}
