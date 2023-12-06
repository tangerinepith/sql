using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace LoginSpace
{

	using Data = DataBaseLink.Data;
    
    //登陆
	public class MyLogin
	{
		public static Admin admin = new Admin("111111", "userName", "pwd");

        //登陆函数
		public virtual bool login(Admin admin)
		{
            try
            {
                string sql = "select * from user where id='{0}' and pW='{1}'";

                sql = string.Format(sql, admin.Id, admin.Password);

                string sql0 = "create table if not exists user ( id varchar(254) primary key, name varchar(254), pW varchar(254) not null, path varchar(254) default 'default.jpg');";

                //创建表
                MySqlCommand cmd = new MySqlCommand(sql0, Data.connect());
                cmd.ExecuteNonQuery();
                Data.Close();

                cmd = new MySqlCommand(sql, Data.connect());
                MySqlDataReader rs = cmd.ExecuteReader();         //返回执行结果

                int ans = 0;
                if (rs.Read())
                {
                    ans = 1;
                    admin.Name = rs.GetString("name");
                    admin.Id = rs.GetString("id");
                    admin.Password = rs.GetString("pW");
                    try
                    {
                        admin.Path = rs.GetString("path");
                    }
                    catch
                    {
                        ;           //无头像数据，不做处理
                    }
                }

                if (ans == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Data.Close();
            }
		}
        
        //判断是否能够登陆
		internal virtual int JudgeAdmin()
		{
            //return 1;
			try
			{
				if (login(MyLogin.admin))
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			catch (Exception)
			{
				;
			}
			return 0;
		}
	}
}