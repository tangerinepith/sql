namespace WindowsFormsApp3.TermBaseInterface
{
    partial class addTerm
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
            this.En = new System.Windows.Forms.TextBox();
            this.Zn = new System.Windows.Forms.TextBox();
            this.Exp = new System.Windows.Forms.TextBox();
            this.button1 = new WinformControlLibraryExtension.ButtonExt();
            this.button2 = new WinformControlLibraryExtension.ButtonExt();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "原文：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "译文：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "说明：";
            // 
            // En
            // 
            this.En.ForeColor = System.Drawing.Color.Black;
            this.En.Location = new System.Drawing.Point(129, 26);
            this.En.Name = "En";
            this.En.Size = new System.Drawing.Size(232, 25);
            this.En.TabIndex = 3;
            // 
            // Zn
            // 
            this.Zn.ForeColor = System.Drawing.Color.Black;
            this.Zn.Location = new System.Drawing.Point(129, 71);
            this.Zn.Name = "Zn";
            this.Zn.Size = new System.Drawing.Size(232, 25);
            this.Zn.TabIndex = 4;
            // 
            // Exp
            // 
            this.Exp.ForeColor = System.Drawing.Color.Black;
            this.Exp.Location = new System.Drawing.Point(129, 119);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(232, 25);
            this.Exp.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Animation.Options.AllTransformTime = 250D;
            this.button1.Animation.Options.Data = null;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(85, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Animation.Options.AllTransformTime = 250D;
            this.button2.Animation.Options.Data = null;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button2.Location = new System.Drawing.Point(238, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(425, 228);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Exp);
            this.Controls.Add(this.Zn);
            this.Controls.Add(this.En);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addTerm";
            this.Text = "添加术语";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox En;
        private System.Windows.Forms.TextBox Zn;
        private System.Windows.Forms.TextBox Exp;
        private WinformControlLibraryExtension.ButtonExt button1;
        private WinformControlLibraryExtension.ButtonExt button2;
    }
}