using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseLink;
using LoginSpace;
using MainInterface;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3
{
    public partial class LoginWin : Form
    {
        static private LoginWin loginWin = new LoginWin();


        static public LoginWin GetLoginWin
        {
            get
            {
                return LoginWin.loginWin;
            }
        }

        //弹出窗口
        static public void showLogin()
        {
            loginWin.Show();
        }

        //隐藏窗口
        static public void hideLogin()
        {
            loginWin.Hide();
        }

        public LoginWin()
        {
            InitializeComponent();
        }

        private void Regis_Click(object sender, EventArgs e)
        {
            RegisterForm.GetRegisterForm.Show();
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String ID = userID.Text;
            String passwd = password.Text;

            //创建一个Admin用户，把输入框中的用户名密码和提出来

            Admin admin = new Admin();
            admin.Id = ID;
            admin.Password = passwd;

            //登录
            MyLogin login = new MyLogin();
            MyLogin.admin = admin;

            if (login.JudgeAdmin() == 0)
            {
                //弹出账号或密码错误的窗口
                MessageBoxExt.Show(this, @"账号或密码错误！", "登陆", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                //清除密码框中的信息
                password.Text = "";
                //清除账号框中的信息
                userID.Text = "";
            }
            else
            {
                //弹出登录成功的窗口
                //点击确定后会跳转到主窗口
                this.Hide();
                Interface win = new Interface("Wetrans");
                win.InitializeComponent();          //初始化窗口信息
                win.Show();
                Interface.GetOnlyInterface = win;   //设置总体窗口对象 - 便于其他子线程调用内部线程函数
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭程序
            System.Environment.Exit(0);
        }
    }
}
