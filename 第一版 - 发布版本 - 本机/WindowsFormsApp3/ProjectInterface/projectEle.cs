using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.ProjectInterface
{
    //项目对象
    class projectEle
    {
        private string fileHead;            //头文件
        private string savePath;            //默认保存路径
        private int degreeOfMatch;          //匹配度
        private string splitSymbol;         //分隔符


        public string FileHead
        {
            get
            {
                return this.fileHead;
            }
            set
            {
                this.fileHead = value;
            }
        }

        public string SavePath
        {
            get
            {
                return this.savePath;
            }
            set
            {
                this.savePath = value;
            }
        }

        public int DegreeOfMatch
        {
            get
            {
                return this.degreeOfMatch;
            }
            set
            {
                this.degreeOfMatch = value;
            }
        }

        public string SplitSymbol
        {
            get
            {
                return this.splitSymbol;
            }
            set
            {
                this.splitSymbol = value;
            }
        }

    }
}
