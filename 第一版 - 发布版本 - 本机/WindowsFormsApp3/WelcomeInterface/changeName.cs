using DataBaseLink;
using LoginSpace;
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
    public partial class changeName : Form
    {
        public changeName()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //修改数据库
            try
            {
                String sql0 = "create table if not exists user ( id varchar(254) primary key, name varchar(254), pW varchar(254) not null, path varchar(254) default 'default.jpg')DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                String sql = "UPDATE user SET name='{0}' WHERE id='{1}'";
                sql = string.Format(sql, textBox1.Text.Trim(), MyLogin.admin.Id);
                //写入字段
                cmd = new MySqlCommand(sql, Data.connect());
                int res = cmd.ExecuteNonQuery();                          //返回执行结果
                
                if (res > 0)
                {
                    MessageBoxExt.Show(null, @"修改昵称成功！", "修改昵称", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
                    //刷新更改昵称界面
                    Welcome.ChangeUserName(textBox1.Text.Trim());       
                    this.Close();
                }
                else
                    MessageBoxExt.Show(null, @"修改昵称失败！", "修改昵称", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            
            }
            catch (Exception)
            {
                MessageBoxExt.Show(null, @"存储修改昵称失败！", "修改昵称", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            finally
            {
                Data.Close();
            }
        }
    }
}
