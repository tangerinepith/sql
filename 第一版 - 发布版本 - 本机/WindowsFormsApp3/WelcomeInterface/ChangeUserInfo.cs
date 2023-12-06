using DataBaseLink;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WindowsFormsApp3.WelcomeInterface
{
    public partial class ChangeUserInfo : Form
    {
        //头像
        static string path = "";
        Point pos;            //鼠标点击时位置
        Point posBmp;         //头像初始位置
        Point pictureSize;    //图像大小
        static string fileName = "";            //图片名称
        static Image smallImg;                  //小图片img形式

        public ChangeUserInfo()
        {
            InitializeComponent();
            path = "";      //路径置为空，导入后才显示图片
            pos = new Point(0, 0);            //鼠标点击时位置
            posBmp = new Point(0, 0);         //头像初始位置
            pictureSize = new Point(0, 0);    //图像大小
            fileName = "";
        }

        //头像移动
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //导入图片后才显示
            if(path.Length > 0)
            {
                try
                {
                    if (MouseButtons == MouseButtons.Left)
                    {
                        int x = MousePosition.X - pos.X;
                        int y = MousePosition.Y - pos.Y;
                        Bitmap bmp = new Bitmap(path);
                        //位置+200，也不能大于图像大小
                        if (posBmp.X - x / 4 >= 0 && posBmp.Y - y / 4 >= 0 && posBmp.X - x / 4 <= pictureSize.X && posBmp.Y - y / 4 <= pictureSize.Y)
                        {
                            posBmp.X = posBmp.X - x / 4;
                            posBmp.Y = posBmp.Y - y / 4;
                            bmp = Data.KiCut(bmp, posBmp.X, posBmp.Y, 100, 100);     //大小150
                        }
                        Image img = Image.FromHbitmap(bmp.GetHbitmap());
                        smallImg = img;         //更新最小图标
                        pictureBox1.Image = img;
                        pictureBox1.Show();
                        pictureBox1.Refresh();
                        bmp.Dispose();
                    }
                }
                catch
                {

                }
                finally
                {
                    GC.Collect();           //垃圾回收
                }
            }
        }

        //头像区域按下
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pos = MousePosition;        //鼠标初始区域更改
        }

        //上传头像
        private void button1_Click(object sender, EventArgs e)
        {
            //选择文件
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Default.jpg";
            openFileDialog1.Filter = ".jpg|*.jpg|.bmp|*.bmp|.png|*.png";

            //成功打开
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                path = System.IO.Path.GetFullPath(openFileDialog1.FileName);

                Bitmap bmp = new Bitmap(path);

                //确定文件后缀
                fileName = LoginSpace.MyLogin.admin.Id + path.Substring(path.Length - 4);

                //展示区域
                Image img = Image.FromHbitmap(bmp.GetHbitmap());
                smallImg = img;                 //更新图标
                pictureBox1.Image = img;
                pictureBox1.Show();
                pictureBox1.Refresh();
                pictureSize.X = bmp.Width;      //宽
                pictureSize.Y = bmp.Height;     //高
                DataBaseLink.Data.NAR(bmp);
            }
        }

        //修改昵称
        private void button2_Click(object sender, EventArgs e)
        {
            changeName name = new changeName();
            name.Show();
        }

        //修改密码
        private void button3_Click(object sender, EventArgs e)
        {
            changePwd pwd = new changePwd();
            pwd.Show();
        }

        //确认 - 保存信息
        //将图片上传至服务器
        //将路径和选定区域上传至数据库
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //上传图片，存储数据库
                if (path.Length > 0)
                {
                    pictureBox1.Controls.Clear();
                    GC.Collect();
                    uploadPicture();        //图片上传 - 操作两次防止更新失败
                    updatePath();           //写入数据库
                }
                MessageBoxExt.Show(this, @"资料修改成功！", "资料修改", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                //MessageBoxExt.Show(this, @"头像上传失败！", "资料修改", MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Data.GetMessageBoxStyle);
            }
            finally
            {
                GC.Collect();
            }

            //替换主页面
            Bitmap bmp = new Bitmap(path);
            bmp = Data.KiCut(bmp, posBmp.X, posBmp.Y, 100, 100);
            Image img = Image.FromHbitmap(bmp.GetHbitmap());

            byte[] imgByte = PhotoImageInsert(img);

            Welcome.WelcomePictureBox.Image = img;
            this.Dispose();
        }

        public byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }

        //将数据写入数据库
        private void updatePath()
        {
            String sql = "UPDATE user SET path='{0}' WHERE id='{1}'";//向login表里修改数据
            sql = string.Format(sql, fileName, LoginSpace.MyLogin.admin.Id);
            //写入字段
            MySqlCommand cmd = new MySqlCommand(sql, Data.connect());
            int res = cmd.ExecuteNonQuery();                          //返回执行结果

            //写入失败，抛出错误
            if(res == 0)
            {
                throw new Exception();
            }
        }

        //连接互联网上传图片
        private void uploadPicture()
        {
            try
            {
                //121.37.24.218
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //服务端链接ip与端口号
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse("121.37.24.218"), 50800));

                //发送图片
                if (smallImg != null)
                {
                    byte[] fileBytes = PhotoImageInsert(smallImg);
                    int num = fileBytes.Length + 517;
                    byte[] numByte = Data.intToBytes(num);

                    byte[] buffer = new byte[num];      //所有数据

                    //存储数据大小
                    for (int i = 1; i <= 4; i++)
                    {
                        buffer[i] = numByte[i - 1];
                    }

                    //存储路径5-516
                    for (int i = 5; i <= 516; i++)
                    {
                        buffer[i] = 0x00;
                    }
                    buffer[0] = 0xff;     //标注发送数据

                    //输入图片后缀
                    byte[] temp = Encoding.ASCII.GetBytes(ChangeUserInfo.fileName);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        buffer[i + 5] = temp[i];
                    }

                    //合并标注、路径和图片,517开始
                    for (int i = 0; i < fileBytes.Length; i++)
                    {
                        buffer[i + 517] = fileBytes[i];
                    }

                    clientSocket.Send(buffer);
                    //释放资源
                    buffer = null;
                    fileBytes = null;
                    temp = null;
                }

                //关闭客户端连接
                clientSocket.Close();
            }
            catch
            {
                throw;
            }
        }

        //取消
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
