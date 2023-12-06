using System.Drawing;

namespace LoginSpace
{
	public class Admin
	{
		private string id;       //用户id 
		private string name;     //用户昵称
		private string password; //密码
		private string startDate;   //当前打开项目
        private string path;        //头像存储路径

		public Admin()
		{
		}

		public Admin(string id, string name, string password)
		{
			this.id = id;
			this.name = name;
			this.password = password;
            path = "";
		}

        public virtual string Id
        {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }

        public virtual string Path
        {
            set
            {
                this.path = value;
            }
            get
            {
                return this.path;
            }
        }
        
		public virtual string Name
		{
			set
			{
				this.name = value;
			}
			get
			{
				return this.name;
			}
		}
		public virtual string Password
		{
			set
			{
				this.password = value;
			}
			get
			{
				return this.password;
			}
		}
		public virtual string StartDate
		{
			set
			{
				this.startDate = value;
			}
			get
			{
				return this.startDate;
			}
		}

	}



}