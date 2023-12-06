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
using WinformControlLibraryExtension;

namespace WindowsFormsApp3
{
    public partial class RegisterForm : Form
    {
        static private RegisterForm registerWin = new RegisterForm();

        static public RegisterForm GetRegisterForm
        {
            get
            {
                return RegisterForm.registerWin;
            }
        }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            String name = userName.Text;
            String ID = userID.Text;
            String passwd = password.Text;
            String confrimpasswd = confrimPassword.Text;

            //创建Register类
            Register register = new Register();
            register.ID = ID;
            register.Name = name;
            register.Password = passwd;
            register.setconfirmpasswd(confrimpasswd);

            //如果注册成功，返回登录界面
            try
            {
                switch(register.JudgeRegister())
                {
                    case -1:                //成功注册
                        MessageBoxExt.Show(this, @"注册成功！", "注册成功", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        this.Hide();
                        LoginWin.GetLoginWin.Show();
                        break;
                    case 0:
                        MessageBoxExt.Show(null, @"用户名不能为空！", "用户名", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 1:
                        MessageBoxExt.Show(this, @"用户名不能超过15个汉字！", "用户名", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 2:
                        MessageBoxExt.Show(this, @"账号不能为空！", "账号为空", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 3:
                        MessageBoxExt.Show(this, @"账号只能由数字组成！", "账号格式", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 4:
                        MessageBoxExt.Show(this, @"账号长度必须在6位以上！", "账号长度", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 5:
                        MessageBoxExt.Show(this, @"账号长度不能超过15位！", "账号长度", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 6:
                        MessageBoxExt.Show(this, @"密码不能为空！", "密码为空", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 7:
                        MessageBoxExt.Show(this, @"密码长度必须在6位以上！", "密码长度", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 8:
                        MessageBoxExt.Show(this, @"密码长度不能超过15位！", "密码长度", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 9:
                        MessageBoxExt.Show(this, @"两次输入的密码不一致！", "密码不一致", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                    case 10:            //数据库存储失败
                        MessageBoxExt.Show(this, @"账号已存在！", "注册失败", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBoxExt.Show(null, @"存储数据出错！", "数据存储", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
        }

        private void ReturnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            //声明新窗口，重新显示主窗口
            LoginWin.GetLoginWin.Show();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭程序
            System.Environment.Exit(0);
        }
    }
}
