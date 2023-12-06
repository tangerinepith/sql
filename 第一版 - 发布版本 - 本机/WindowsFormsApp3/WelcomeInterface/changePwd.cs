using DataBaseLink;
using MySql.Data.MySqlClient;
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

namespace WindowsFormsApp3.WelcomeInterface
{
    public partial class changePwd : Form
    {
        public changePwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox2.Text.Trim();
            //鉴别两次密码是否一致
            if(!Check(textBox1.Text.Trim()))
            {
                MessageBoxExt.Show(this, @"原密码输入错误！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            else if (newPassword == null || newPassword.Length == 0)
            {
                MessageBoxExt.Show(this, @"新密码不能为空！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            else if (newPassword.Length < 6)
            {
                MessageBoxExt.Show(this, @"密码必须在6位以上！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            else if (newPassword.Length > 15)
            {
                MessageBoxExt.Show(this, @"密码最长不超过15位！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            else if(!newPassword.Equals(textBox3.Text.Trim()))
            {
                MessageBoxExt.Show(this, @"两次密码不一致！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return;
            }
            //保存新密码
            //修改数据库
            try
            {
                String sql0 = "create table if not exists user ( id varchar(254) primary key, name varchar(254), pW varchar(254) not null, path varchar(254) default 'default.jpg')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                String sql = "UPDATE user SET pW='{0}' WHERE id='{1}'";//向login表里修改数据
                sql = string.Format(sql, newPassword, LoginSpace.MyLogin.admin.Id);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                int res = cmd.ExecuteNonQuery();                          //返回执行结果

                if (res > 0)
                {
                    MessageBoxExt.Show(this, @"修改密码成功！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    this.Close();
                }
                else
                    MessageBoxExt.Show(this, @"修改密码失败！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);

            }
            catch (Exception)
            {
                MessageBoxExt.Show(this, @"修改密码失败！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            finally
            {
                Data.Close();
            }
        }

        private bool Check(string oldPw)
        {
            try
            {
                String sql0 = "create table if not exists user (id varchar(254) primary key, name varchar(254), pW varchar(254) not null, path varchar(254) default 'default.jpg')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                String sql = "select * from user where id='{0}'";        //获取密码数据
                sql = string.Format(sql, LoginSpace.MyLogin.admin.Id);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();                         //返回执行结果

                if (rs.Read())
                {
                    Console.WriteLine(rs.GetString("pW"));
                    if (oldPw.Equals(rs.GetString("pW")))
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                MessageBoxExt.Show(this, @"获取密码错误！", "修改密码", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                return false;
            }
            finally
            {
                Data.Close();
            }
        }
    }
}
