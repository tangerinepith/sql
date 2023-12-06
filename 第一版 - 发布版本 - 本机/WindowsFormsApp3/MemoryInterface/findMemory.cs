﻿using DataBaseLink;
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
    public partial class findMemory : Form
    {
        public findMemory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查询记忆库
            string Zn = Memory.findTrans(En.Text);           //去除首尾空格
            if (En.Text.Trim().Length == 0)
                MessageBoxExt.Show(this, @"输入句对不能为空！", "添加句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            else if (Zn != null)
            {
                MessageBoxExt.Show(this, Zn, "查找句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            else
            {
                MessageBoxExt.Show(this, @"该句段对不存在！", "查找句对", MessageBoxExtButtons.OK, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }
    }
}
