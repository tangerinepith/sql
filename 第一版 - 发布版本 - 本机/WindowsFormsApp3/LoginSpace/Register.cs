using DataBaseLink;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace LoginSpace
{

	//using Data = DataBaseLink.Data;
	//using MyDialog = MyButton.MyDialog;
    
	public class Register
	{
		internal string name = "Admin";
		internal string ID_Conflict;
		internal string password;
		internal string confirmpassword;

		internal virtual string Name
		{
			set
			{
				this.name = value;
			}
		}
		internal virtual string ID
		{
			set
			{
				this.ID_Conflict = value;
			}
		}
		internal virtual string Password
		{
			set
			{
				this.password = value;
			}
		}
		internal virtual void setconfirmpasswd(string confirmpassword)
		{
			this.confirmpassword = confirmpassword;
		}

        //判断是否注册成功
        internal virtual int JudgeRegister()
		{
			if (this.name.Equals(""))
			{
                return 0;
			}

			if (this.name.Length > 15)
			{
                return 1;
			}

			if (this.ID_Conflict.Equals(""))
			{
                return 2;
			}

			bool flag = false;
			char[] CH = ID_Conflict.ToCharArray();
			foreach (char ch in CH)
			{
				if (ch >= '0' && ch <= '9')
				{
					;
				}
				else
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
                return 3;
			}

			if (this.ID_Conflict.Length < 6)
			{
                return 4;
			}

			if (this.ID_Conflict.Length > 15)
			{
                return 5;
			}

			if (this.password.Equals(""))
			{
				return 6;
			}

			if (this.password.Length < 6)
			{
				return 7;
			}

			if (this.password.Length > 15)
			{
				return 8;
			}

			if (!this.password.Equals(this.confirmpassword))
			{
				return 9;
			}
            
            //注册成功
            if (addAdmin())
            {
                return -1;
            }
            else
                return 10;
        }
        
        //添加用户
		internal virtual bool addAdmin()
		{
			string sql = "insert into user (id, name, pW) values ('{0}','{1}','{2}')";
            
			try
			{
                string sql0 = "create table if not exists user ( id varchar(254) primary key, name varchar(254), pW varchar(254) not null, path varchar(254) default 'default.jpg');";
               
                sql = string.Format(sql, this.ID_Conflict, this.name, this.password);

                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                cmd = new MySqlCommand(sql, Data.connect());
                int result = cmd.ExecuteNonQuery();         //返回执行结果
                return true;
            }
            catch (MySqlException)
			{
                //注册失败
                return false;
            }
            finally
            {
                Data.Close();
            }
        }
    }


}