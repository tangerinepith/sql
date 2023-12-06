using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using WindowsFormsApp3;     //使用主窗体Form1
using WinformControlLibraryExtension;
using Word = Microsoft.Office.Interop.Word;

namespace DataBaseLink
{
    /// <summary>
    /// <para>Description：数据库连接类，提供数据库连接</para>
    /// @author：86151
    /// @version：1.0
    /// </summary>
    public class Data
    {
        public static LoginWin win;
        static private String connetStr = "server=localhost;port=3306;user=root;password=428005;database=trans;SslMode=none;Charset=utf8;";
        static MySqlConnection conn;
        private string command;

        //待翻译文本打开方式
        static private Word.Application m_word;
        static private bool openModel = false;          //打开文本方式，false-txt；true-word
        //默认以. ? ! ;分割 - 增加分割符记载功能，将用户勾选所有分隔符号全部记载下来
        static private string sp = ".?!;";

        //术语库打开方式
        static Microsoft.Office.Interop.Excel.Application excel = null;//lauch excel application
        static private bool openTermModel = false;      //默认txt

        //记忆库打开方式
        static private bool openMemoryModel = false;      //默认txt
                                                          
        //提示框样式
        static private MessageBoxExtStyles messageBoxStyle = new MessageBoxExtStyles();
        
        static public MessageBoxExtStyles GetMessageBoxStyle
        {
            get
            {
                return Data.messageBoxStyle;
            }
        }

        static public string GetSp
        {
            get
            {
                return sp;
            }
            set
            {
                sp = value;
            }
        }

        static public bool GetOpenMemory
        {
            get
            {
                return openMemoryModel;
            }
            set
            {
                openMemoryModel = value;
            }
        }

        static public bool GetOpenTermModel
        {
            get
            {
                return openTermModel;
            }
            set
            {
                openTermModel = value;
            }
        }
        
        static public bool GetOpenModel
        {
            get
            {
                return openModel;
            }
            set
            {
                openModel = value;
            }
        }

        //一系列设置与获取函数
        public virtual LoginWin Win
        {
            set
            {
                Data.win = value;
            }
        }
        public virtual string Command
        {
            set
            {
                command = value;
            }
            get
            {
                return command;
            }
        }

        static public MySqlConnection connect()
        {
            conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                //MessageBox.Show("数据库连接成功!", "数据库");
            }
            catch(MySqlException exp)
            {
                MessageBoxExt.Show(null, @"数据库连接失败！", "数据库连接", MessageBoxExtButtons.OK, MessageBoxExtIcon.Error);
                Console.WriteLine(exp);
            }
            return conn;
        }

        static public void Close()
        {
            if(conn != null)
            {
                conn.Close();
                Data.NAR(conn);
            }
        }

        //导出项目文件 - 一次性写入
        static public void WriteToProjectFile(string savePath, List<string> temp)
        {
            
            using (FileStream fs = new FileStream(@savePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    //输出所有数据
                    foreach(var str in temp)
                    {
                        //将字符串转为二进制输出
                        string data = StringToBinary(str);
                        sw.WriteLine("{0}", data, DateTime.Now);
                    }
                    sw.Flush();
                    Data.NAR(sw);
                }
                Data.NAR(fs);
            }
        }

        //将指定数据保存到Excel文件中【记忆库】
        static public void WriteMemoryToExcel(string path, List<string> temp)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //无excel，退出
            if (excel == null)
            {
                return;
            }
            //设置为不可见，操作在后台执行，为 true 的话会打开 Excel
            excel.Visible = false;
            //初始化工作簿
            Microsoft.Office.Interop.Excel.Workbooks workbooks = excel.Workbooks;
            //新增加一个工作簿，Add（）方法也可以直接传入参数 true
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //新增加一个 Excel 表(sheet)
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            //设置表的名称
            worksheet.Name = "Sheet1";
            try
            {
                //创建一个单元格
                Microsoft.Office.Interop.Excel.Range range;
                //标题
                worksheet.Cells[1, 1] = "En";
                worksheet.Cells[1, 2] = "Zh";
                for (int i = 1; i <= 2; i++)
                {
                    range = worksheet.Cells[1, i];
                    range.Font.Bold = true;
                }

                //保存数据Excel下标
                int cnt = 2;
                //保存所有数据
                for (int i = 0; i < temp.Count; i += 2)
                {
                    //存储数据
                    worksheet.Cells[cnt, 1] = temp[i];
                    worksheet.Cells[cnt++, 2] = temp[i + 1];
                }
                //设置所有单元格列宽为自动列宽
                worksheet.Cells.Columns.AutoFit();
                //是否提示，如果想删除某个sheet页，首先要将此项设为fasle。
                excel.DisplayAlerts = false;
                //保存写入的数据，这里还没有保存到磁盘
                workbook.Saved = true;
                //创建文件 - 如果不存在，新建
                if (!File.Exists((string)path))
                {
                    FileStream file = new FileStream(path, FileMode.CreateNew);
                    //关闭释放流，不然没办法写入数据
                    file.Close();
                    file.Dispose();
                }

                //保存到指定的路径
                workbook.SaveCopyAs(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                workbook.Close(false, Type.Missing, Type.Missing);
                workbooks.Close();
                //关闭退出
                excel.Quit();

                //释放 COM 对象
                NAR(worksheet);
                NAR(workbook);
                NAR(workbooks);
                NAR(excel);
            }
        }

        //将指定数据保存到Excel文件中【术语库】
        static public void WriteTermToExcel(string path, List<string> temp)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //无excel，退出
            if (excel == null)
            {
                return;
            }
            //设置为不可见，操作在后台执行，为 true 的话会打开 Excel
            excel.Visible = false;
            //初始化工作簿
            Microsoft.Office.Interop.Excel.Workbooks workbooks = excel.Workbooks;
            //新增加一个工作簿，Add（）方法也可以直接传入参数 true
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //新增加一个 Excel 表(sheet)
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            //设置表的名称
            worksheet.Name = "Sheet1";
            try
            {
                //创建一个单元格
                Microsoft.Office.Interop.Excel.Range range;
                //标题
                worksheet.Cells[1, 1] = "En";
                worksheet.Cells[1, 2] = "Zh";
                worksheet.Cells[1, 3] = "Exp";
                for (int i = 1; i <= 3; i++)
                {
                    range = worksheet.Cells[1, i];
                    range.Font.Bold = true;
                }

                //保存数据Excel下标
                int cnt = 2;            
                //保存所有数据
                foreach (var str in temp)
                {
                    string En = "", Zh = "", Exp = "";
                    string[] info = str.Split(' ');

                    bool flag = false;          //是否为解释部分
                    for (int i = 0; i < info.Length; i++)
                    {
                        //有效数据
                        if (info[i] != null && info[i].Length > 0)
                        {
                            //继续为英文
                            if (info[i][0] >= 'a' && info[i][0] <= 'z' || info[i][0] >= 'A' && info[i][0] <= 'Z')
                            {
                                En += info[i];          //加入到En
                                En += ' ';
                            }
                            else
                            {
                                if (!flag)
                                {
                                    Zh += info[i];
                                    flag = true;
                                }
                                else
                                    Exp += info[i];
                            }
                        }
                    }
                    //存储数据
                    worksheet.Cells[cnt, 1] = En.Trim();
                    worksheet.Cells[cnt, 2] = Zh.Trim();
                    worksheet.Cells[cnt++, 3] = Exp.Trim();
                }
                //设置所有单元格列宽为自动列宽
                worksheet.Cells.Columns.AutoFit();
                //是否提示，如果想删除某个sheet页，首先要将此项设为fasle。
                excel.DisplayAlerts = false;
                //保存写入的数据，这里还没有保存到磁盘
                workbook.Saved = true;
                //创建文件 - 如果不存在，新建
                if (!File.Exists((string)path))
                {
                    FileStream file = new FileStream(path, FileMode.CreateNew);
                    //关闭释放流，不然没办法写入数据
                    file.Close();
                    file.Dispose();
                }

                //保存到指定的路径
                workbook.SaveCopyAs(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                workbook.Close(false, Type.Missing, Type.Missing);
                workbooks.Close();
                //关闭退出
                excel.Quit();

                //释放 COM 对象
                NAR(worksheet);
                NAR(workbook);
                NAR(workbooks);
                NAR(excel);
            }
        }

        //将指定字符串追加到指定文件中【一次性】 - 自动添加末尾行：记忆库、术语库（Txt）
        static public void WriteToFile(string savePath, List<string> temp)
        {
            using (FileStream fs = new FileStream(@savePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    foreach (var str in temp)
                    {
                        sw.WriteLine("{0}", str, DateTime.Now);
                    }
                    sw.Flush();
                    Data.NAR(sw);
                }
                Data.NAR(fs);
            }
        }

        //将指定字符串追加到指定Word文档中
        static public void WriteToWord(object savePath, List<string> temp)
        {
            Word.Application wordApp;                //Word应用程序变量
            Word.Document wordDoc;                   //Word文档变量

            wordApp = new Word.ApplicationClass();   //初始化
                                                     //如果已存在，则删除
            if (File.Exists((string)savePath))
            {
                File.Delete((string)savePath);
            }
            //由于使用的是COM库，因此有许多变量需要用Missing.Value代替
            Object Nothing = System.Reflection.Missing.Value;

            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            //将所有数据全部写入Word
            foreach(var str in temp)
            {
                wordDoc.Paragraphs.Last.Range.Text = str + '\n';
                //wordDoc.Paragraphs.Last.Range.InsertAutoText(str)
            }
            //WdSaveFormat为Word 2007文档的保存格式
            object format = Word.WdSaveFormat.wdFormatDocumentDefault;
            //将wordDoc文档对象的内容保存为DOCX文档
            wordDoc.SaveAs(ref savePath, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            //关闭wordDoc文档对象
            wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            //关闭wordApp组件对象
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        }

        //字符串转二进制
        static private string StringToBinary(string str)
        {
            byte[] data = Encoding.Unicode.GetBytes(str);
            StringBuilder sb = new StringBuilder(data.Length * 8);
            foreach (byte item in data)
            {
                sb.Append(Convert.ToString(item,2).PadLeft(8,'0'));
            }
            return sb.ToString();
        }

        //二进制转string
        static public string BinaryToString(string str)
        {
            System.Text.RegularExpressions.CaptureCollection cs = System.Text.RegularExpressions.Regex.Match(str, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i<cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value,2);
            }
            return Encoding.Unicode.GetString(data,0,data.Length);
        }


        //待翻译文件打开文本方式：Word、Txt
        static public List<string> ReadContent(object path)
        {
            m_word = new Word.Application();
            Object confirmConversions = Type.Missing;
            Object readOnly = true;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;
            
            //word文档
            if(openModel)
            {
                try
                {
                    //打开文档
                    m_word.Documents.Open(ref path,
                            ref confirmConversions, ref readOnly, ref addToRecentFiles,
                            ref passwordDocument, ref passwordTemplate, ref revert,
                            ref writePasswordDocument, ref writePasswordTemplate,
                            ref format, ref encoding, ref visible, ref openConflictDocument,
                            ref openAndRepair, ref documentDirection, ref noEncodingDialog
                            );
                    m_word.Visible = false;

                    string AllContent = "";
                    //对整个段落句子进行进一步的分割处理
                    for (int i = 1; i <= m_word.ActiveDocument.Paragraphs.Count; i++)
                    {
                        string str = m_word.ActiveDocument.Paragraphs[i].Range.Text.Trim();

                        if (str != null && str.Length > 0)
                        {
                            AllContent += str;
                        }
                    }

                    //手写Split
                    return split(AllContent);
                }
                catch (System.Exception)
                {
                    //MessageBox.Show("打开Word文档出错");
                    return null;
                }
                finally
                {
                    openModel = false;      //恢复原状
                    Data.NAR(m_word);
                }
            }
            else
            {
                try
                {
                    string[] fileStr = File.ReadAllLines((string)path, Encoding.UTF8);
                    string AllContent = "";

                    for (int i = 0; i < fileStr.Length; i++)
                    {
                        fileStr[i] = fileStr[i].Trim();     //数据清洗
                        if (fileStr[i] != null && fileStr[i].Length >= 0)
                        {
                            AllContent += fileStr[i];
                        }
                    }

                    //应添加上末尾标点
                    return split(AllContent);
                }
                catch (System.Exception)
                {
                    //MessageBox.Show("访问Txt文档出错");
                    return null;
                }
            }
        }

        //手写Split分割，将符号也带上
        static private List<string> split(string Str)
        {
            List<string> result = new List<string>();
            string temp = "";
            for(int i = 0; i < Str.Length; i++)
            {
                if (sp.Contains(Str[i]))
                {
                    temp += Str[i];
                    //加入数组中
                    result.Add(temp);
                    temp = "";
                }
                else temp += Str[i];
            }
            return result;
        }


        //术语库打开方式：txt、Excel
        static public Dictionary<string, List<string>> openTermBase(object obj)
        {
            string path = (string)obj;             //强转路径
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();   //结果

            //Excel打开
            if (openTermModel)
            {
                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();       //获取excel对象
                    object missing = System.Reflection.Missing.Value;
                    if (excel == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        excel.Visible = false;
                        excel.UserControl = true;
                        // 以只读的形式打开EXCEL文件
                        Workbook wb = excel.Application.Workbooks.Open((string)path, missing, true, missing, missing, missing,
                         missing, missing, missing, true, missing, missing, missing, missing, missing);
                        //取得第一个工作薄
                        Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);

                        //取得总记录行数   (包括标题列)
                        int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数

                        //取得数据范围区域 (不包括标题列) 
                        Microsoft.Office.Interop.Excel.Range rng1 = ws.Cells.get_Range("A2", "A" + rowsint);   //En
                        Microsoft.Office.Interop.Excel.Range rng2 = ws.Cells.get_Range("B2", "B" + rowsint);   //Zh
                        Microsoft.Office.Interop.Excel.Range rng3 = ws.Cells.get_Range("C2", "C" + rowsint);   //Exp
                        object[,] arryEn = (object[,])rng1.Value2;   //get range's value
                        object[,] arryZh = (object[,])rng2.Value2;
                        object[,] arryExp = (object[,])rng3.Value2;
                        //将新值赋给一个数组
                        string[,] arry = new string[rowsint - 1, 3];
                        for (int i = 1; i <= rowsint - 1; i++)
                        {
                            //En列
                            arry[i - 1, 0] = arryEn[i, 1].ToString();
                            //Zh列
                            arry[i - 1, 1] = arryZh[i, 1].ToString();
                            //Exp列
                            arry[i - 1, 2] = arryExp[i, 1].ToString();
                            
                            List<string> ls = new List<string>();
                            ls.Add(arry[i - 1, 1]);
                            ls.Add(arry[i - 1, 2]);

                            //去重
                            if (!result.Keys.Contains(arry[i - 1, 0]))
                                result.Add(arry[i - 1, 0], ls);
                        }
                    }

                    return result;
                }
                catch (Exception)
                {
                    //打开Excel失败 - 抛出错误
                    throw;
                }
                finally
                {
                    //关闭Excel操作
                    excel.Quit();
                    excel = null;
                    Process[] procs = Process.GetProcessesByName("excel");

                    foreach (Process pro in procs)
                    {
                        pro.Kill();//没有更好的方法,只有杀掉进程
                    }
                    GC.Collect();

                    openTermModel = false;        //恢复原打开方式
                }
            }
            //Txt打开术语库
            else
            {
                String[] filestr = File.ReadAllLines(path, Encoding.UTF8);

                //仅考虑打开Txt
                int i = 0;
                for (; i < filestr.Length; i++)
                {
                    bool flag = false;              //辨别是否经过空格
                    bool Flag = false;              //是否为Exp
                    string str = "";                //英文
                    string Zn = "";
                    string Exp = "";
                    if (filestr[i] == null || filestr[i].Length == 0) continue;        //没有数据，读取下一个

                    for (int j = 0; j < filestr[i].Length; j++)
                    {
                        if (filestr[i][j] >= 'a' && filestr[i][j] <= 'z' || filestr[i][j] >= 'A' && filestr[i][j] <= 'Z')
                        {
                            if (flag)                //刚刚经过空格
                            {
                                str += " ";
                                flag = false;
                                if (filestr[i][j] >= 'a' && filestr[i][j] <= 'z') str += (char)(filestr[i][j] - 'a' + 'A');   //空格后首字母大写
                                else str += filestr[i][j];
                            }
                            else str += filestr[i][j];
                        }
                        else if (filestr[i][j] == ' ' || filestr[i][j] == '\t')      //空格、Tab
                        {
                            flag = true;                //空格
                            if (Zn.Length > 0)
                                Flag = true;            //解释部分

                        }
                        else      //中文
                        {
                            if (Flag)
                                Exp += filestr[i][j];
                            else
                                Zn += filestr[i][j];
                        }
                    }
                    List<string> temp = new List<string>();
                    temp.Add(Zn);
                    temp.Add(Exp);

                    if (!result.Keys.Contains(str))
                        result.Add(str, temp);
                }

                Data.NAR(filestr);
                return result;
            }
        }


        //记忆库打开方式：txt、Excel
        static public Dictionary<string, string> openMemoryFile(object obj)
        {
            string path = (string)obj;             //强转路径
            Dictionary<string, string> result = new Dictionary<string, string>();   //结果

            //Excel打开
            if (openMemoryModel)
            {
                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();       //获取excel对象
                    object missing = System.Reflection.Missing.Value;
                    if (excel == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        excel.Visible = false;
                        excel.UserControl = true;
                        // 以只读的形式打开EXCEL文件
                        Workbook wb = excel.Application.Workbooks.Open((string)path, missing, true, missing, missing, missing,
                         missing, missing, missing, true, missing, missing, missing, missing, missing);
                        //取得第一个工作薄
                        Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);

                        //取得总记录行数   (包括标题列)
                        int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数

                        //取得数据范围区域 (不包括标题列) 
                        Microsoft.Office.Interop.Excel.Range rng1 = ws.Cells.get_Range("A2", "A" + rowsint);   //En
                        Microsoft.Office.Interop.Excel.Range rng2 = ws.Cells.get_Range("B2", "B" + rowsint);   //Zh
                        object[,] arryEn = (object[,])rng1.Value2;   //get range's value
                        object[,] arryZh = (object[,])rng2.Value2;
                        //将新值赋给一个数组
                        string[,] arry = new string[rowsint - 1, 3];
                        for (int i = 1; i <= rowsint - 1; i++)
                        {
                            //En列
                            arry[i - 1, 0] = arryEn[i, 1].ToString();
                            //Zh列
                            arry[i - 1, 1] = arryZh[i, 1].ToString();

                            //不包含才加入，否则报错
                            if(!result.Keys.Contains(arry[i - 1, 0]))
                                result.Add(arry[i - 1, 0], arry[i - 1, 1]);
                        }
                    }
                    
                    return result;
                }
                catch (Exception)
                {
                    //打开Excel失败 - 抛出错误
                    return null;
                }
                finally
                {
                    //关闭Excel操作
                    excel.Quit();
                    excel = null;
                    Process[] procs = Process.GetProcessesByName("excel");

                    foreach (Process pro in procs)
                    {
                        pro.Kill();//没有更好的方法,只有杀掉进程
                    }
                    GC.Collect();

                    openMemoryModel = false;        //恢复原打开方式
                }
            }
            //Txt打开记忆库
            else
            {
                String[] filestr = File.ReadAllLines(path, Encoding.UTF8);

                //若干组数据
                string str = "";                //英文
                string Zn = "";
                for (int i = 0; i < filestr.Length; i++)
                {
                    if (filestr[i] == null || filestr[i].Length == 0) continue;

                    if (i % 2 == 0)                  //奇数行英文
                    {
                        str += filestr[i];          //英文
                    }
                    else
                    {
                        Zn += filestr[i];           //中文

                        if (!result.Keys.Contains(str))
                            result.Add(str, Zn);        //偶数行时记载结果
                        str = "";                   //恢复
                        Zn = "";
                    }
                }

                return result;
            }
        }


        //释放对象资源
        static public void NAR(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch
            {
                ;
            }
            finally
            {
                obj = null;
                GC.Collect();           //垃圾回收机制
                GC.WaitForPendingFinalizers();
            }
        }

        //bmp图像按区域裁剪
        static public Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new System.Drawing.Rectangle(0, 0, iWidth, iHeight), new System.Drawing.Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        //int转Byte数组
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }
        
    }
}