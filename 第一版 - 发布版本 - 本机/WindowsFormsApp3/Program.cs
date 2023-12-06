using DataBaseLink;
using MainInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //初始化弹窗Style
            Data.GetMessageBoxStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            Data.GetMessageBoxStyle.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            Data.GetMessageBoxStyle.CaptionTextColor = System.Drawing.Color.White;
            Data.GetMessageBoxStyle.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            Data.GetMessageBoxStyle.ButtonBackEnterColor = System.Drawing.Color.FromArgb(7, 117, 244);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(LoginWin.GetLoginWin);
            /*
            Interface inter = new Interface("WeTrans");
            inter.InitializeComponent();
            Application.Run(inter);
            */
        }
    }
}
