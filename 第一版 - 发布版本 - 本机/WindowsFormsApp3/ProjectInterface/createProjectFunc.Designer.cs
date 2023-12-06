using System.Drawing;

namespace WindowsFormsApp3.ProjectInterface
{
    partial class createProjectFunc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new WinformControlLibraryExtension.ButtonExt();
            this.button2 = new WinformControlLibraryExtension.ButtonExt();
            this.pName = new System.Windows.Forms.TextBox();
            this.cName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new WinformControlLibraryExtension.ButtonExt();
            this.button4 = new WinformControlLibraryExtension.ButtonExt();
            this.OpenBox = new System.Windows.Forms.TextBox();
            this.SaveBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "创建者：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "截止日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "客户：";
            // 
            // button1
            // 
            this.button1.Animation.Options.AllTransformTime = 250D;
            this.button1.Animation.Options.Data = null;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(93, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Animation.Options.AllTransformTime = 250D;
            this.button2.Animation.Options.Data = null;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button2.Location = new System.Drawing.Point(376, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pName
            // 
            this.pName.ForeColor = System.Drawing.Color.Black;
            this.pName.Location = new System.Drawing.Point(154, 24);
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(423, 25);
            this.pName.TabIndex = 8;
            // 
            // cName
            // 
            this.cName.Location = new System.Drawing.Point(154, 77);
            this.cName.Name = "cName";
            this.cName.Size = new System.Drawing.Size(423, 25);
            this.cName.TabIndex = 9;
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(154, 181);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(423, 25);
            this.lName.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.Location = new System.Drawing.Point(154, 130);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(423, 25);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "打开翻译文件：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "保存项目至：";
            // 
            // button3
            // 
            this.button3.Animation.Options.AllTransformTime = 250D;
            this.button3.Animation.Options.Data = null;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            this.button3.Location = new System.Drawing.Point(455, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 25);
            this.button3.TabIndex = 16;
            this.button3.Text = "浏览";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Animation.Options.AllTransformTime = 250D;
            this.button4.Animation.Options.Data = null;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(155)))), ((int)(((byte)(244)))));
            this.button4.Location = new System.Drawing.Point(455, 276);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 25);
            this.button4.TabIndex = 17;
            this.button4.Text = "浏览";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OpenBox
            // 
            this.OpenBox.Location = new System.Drawing.Point(154, 228);
            this.OpenBox.Name = "OpenBox";
            this.OpenBox.Size = new System.Drawing.Size(282, 25);
            this.OpenBox.TabIndex = 18;
            // 
            // SaveBox
            // 
            this.SaveBox.Location = new System.Drawing.Point(154, 277);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(282, 25);
            this.SaveBox.TabIndex = 19;
            // 
            // createProjectFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(653, 433);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.OpenBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.cName);
            this.Controls.Add(this.pName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "createProjectFunc";
            this.Text = "创建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pName;
        private System.Windows.Forms.TextBox cName;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OpenBox;
        private System.Windows.Forms.TextBox SaveBox;
        private WinformControlLibraryExtension.ButtonExt button1;
        private WinformControlLibraryExtension.ButtonExt button2;
        private WinformControlLibraryExtension.ButtonExt button3;
        private WinformControlLibraryExtension.ButtonExt button4;
    }
}