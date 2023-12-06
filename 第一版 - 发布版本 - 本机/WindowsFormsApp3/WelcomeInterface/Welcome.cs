using LoginSpace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Sockets;
using System.Net;
using DataBaseLink;

namespace WindowsFormsApp3.WelcomeInterface
{
    class Welcome
    {
        //区域
        private Panel area;
        private Panel left;
        //组件
        static private Label label1 = new Label();              //显示用户昵称

        //头像
        static private PictureBox pictureBox1 = new PictureBox();    //头像位置
        //右侧Logo水印
        static private PictureBox LogoBox = new PictureBox();        //右侧logo水印 

        
        static public PictureBox WelcomePictureBox
        {
            get
            {
                return Welcome.pictureBox1;
            }
        }

        static public void ChangeUserName(string NewName)
        {
            label1.Text = NewName;
        }

        internal virtual Panel Area
        {
            get
            {
                return this.area;
            }
        }

        internal virtual Panel GetLeft
        {
            get
            {
                return this.left;
            }
        }

        public void InitializeComponent()
        {
            this.area = new System.Windows.Forms.Panel();
            this.left = new System.Windows.Forms.Panel();
            // 
            // area
            // 
            //this.area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            this.area.Location = new System.Drawing.Point(103, 40);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(755, 529);
            this.area.TabIndex = 2;
            // 
            // left
            // 
            this.left.AutoScroll = true;
            //this.left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      //显示边框
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(103, 320);
            this.left.TabIndex = 3;
            this.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));

            //左侧栏
            this.left.Controls.Add(label1);
            this.left.Controls.Add(pictureBox1);
            this.area.Controls.Add(LogoBox);

            //图像区域
            ((System.ComponentModel.ISupportInitialize)(Welcome.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Welcome.LogoBox)).BeginInit();

            //添加组件及其功能
            this.addModule();
            this.addModuleFunc();

            ((System.ComponentModel.ISupportInitialize)(Welcome.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Welcome.pictureBox1)).EndInit();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        //添加组件
        private void addModule()
        {
            // 
            // 用户名
            // 
            label1.AutoSize = false;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "userName";
            label1.Size = new System.Drawing.Size(103, 40);
            label1.TabIndex = 0;
            label1.Text = LoginSpace.MyLogin.admin.Name;          //MyLogin.admin.Name
            label1.ForeColor = System.Drawing.Color.White;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            Welcome.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            Welcome.pictureBox1.Location = new System.Drawing.Point(4, 40);
            Welcome.pictureBox1.Name = "pictureBox1";
            Welcome.pictureBox1.Size = new System.Drawing.Size(95, 95);
            Welcome.pictureBox1.TabIndex = 3;
            Welcome.pictureBox1.TabStop = false;
            //登陆时加载图像
            //getPicture();

            // 
            // LogoBox
            // 
            Welcome.LogoBox.Location = new System.Drawing.Point(119, 6);
            Welcome.LogoBox.Name = "pictureBox1";
            Welcome.LogoBox.Size = new System.Drawing.Size(516, 516);
            Welcome.LogoBox.TabIndex = 3;
            Welcome.LogoBox.TabStop = false;
            //登陆时加载Logo图像
            LoadLogo();

        }

        //加载本地Logo
        private void LoadLogo()
        {
            string path = @"..\..\Logo\Logo.png";
            //string path = Application.StartupPath + @"\Logo.png";
            Welcome.LogoBox.Image = Image.FromFile(path);
        }

        //从服务器获取头像信息 - 存储至本地
        private void getPicture()
        {
            try
            {
                //121.37.24.218
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //服务端链接ip与端口号
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse("121.37.24.218"), 50800));
                
                string UserName = LoginSpace.MyLogin.admin.Path;        //获取图片后缀

                if (UserName == null || UserName.Length == 0) throw new Exception();

                byte[] buffer = new byte[517];

                buffer[0] = 0x00;

                //存储大小
                int num = 517;
                byte[] NumByte = Data.intToBytes(num);
                for (int i = 1; i <= 4; i++)
                    buffer[i] = NumByte[i - 1];

                //存储后缀
                for (int i = 5; i <= 516; i++)
                    buffer[0] = 0x00;

                byte[] Name = System.Text.Encoding.UTF8.GetBytes(UserName);

                //赋值用户名称给传输对象
                for (int i = 0; i < Name.Length; i++)
                    buffer[i + 5] = Name[i];

                //发517数据
                clientSocket.Send(buffer);

                //接受
                byte[] data = new byte[1024 * 1024];
                int count = 0;
                int totalSum = 0;
                do
                {
                    count = clientSocket.Receive(data, totalSum, data.Length - totalSum, SocketFlags.None);
                    totalSum += count;
                }
                while (count > 0);      //存在数据，则一直接收

                if (System.Text.Encoding.UTF8.GetString(data, 0, totalSum).Equals("File is not exist"))
                {
                    Console.WriteLine("服务器出现异常，无法找到对应头像"); //使用系统默认
                }
                else
                {
                    //转为Image图像存储至本地
                    Bitmap bmp = BytesToBitmap(data);

                    //加载的为缩减后的图片，故从0开始读取100*100像素即可
                    bmp = Data.KiCut(bmp, 0, 0, 95, 95);
                    Image img = Image.FromHbitmap(bmp.GetHbitmap());
                    Welcome.pictureBox1.Image = img;              //加载头像至显示区
                }

                clientSocket.Close();       //关闭客户端
            }
            catch
            {
                //头像不存在路径，加载系统头像
            }
        }

        //byte数组转bmp图像
        private System.Drawing.Bitmap BytesToBitmap(byte[] Bytes)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(Bytes);
                return new System.Drawing.Bitmap((System.Drawing.Image)new System.Drawing.Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }

        //组件添加功能
        private void addModuleFunc()
        {
            Welcome.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPicMove_MouseDown);
        }

        //鼠标按下 - 更新初始鼠标位置
        private void buttonPicMove_MouseDown(object sender, EventArgs e)
        {
            //弹窗 - 修改资料
            ChangeUserInfo changeInfo = new ChangeUserInfo();
            changeInfo.Show();

            //对pictureBox重绘制区域
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(changeInfo.GetPictureBox.ClientRectangle);
            System.Drawing.Region region = new System.Drawing.Region(gp);
            changeInfo.GetPictureBox.Region = region;        //重新绘画选定区域
            gp.Dispose();
            region.Dispose();
        }
    }
}
