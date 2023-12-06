using WinformControlLibraryExtension;

namespace WindowsFormsApp3
{
    partial class RegisterForm
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
            this.ReturnLogin = new WinformControlLibraryExtension.ButtonExt();
            this.userName = new System.Windows.Forms.TextBox();
            this.userID = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.confrimPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "账号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "确认密码：";
            // 
            // button1
            // 
            this.button1.Animation.Options.AllTransformTime = 250D;
            this.button1.Animation.Options.Data = null;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(79, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Register_Click);
            // 
            // ReturnLogin
            // 
            this.ReturnLogin.Animation.Options.AllTransformTime = 250D;
            this.ReturnLogin.Animation.Options.Data = null;
            this.ReturnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.ReturnLogin.Location = new System.Drawing.Point(267, 322);
            this.ReturnLogin.Name = "ReturnLogin";
            this.ReturnLogin.Size = new System.Drawing.Size(100, 62);
            this.ReturnLogin.TabIndex = 5;
            this.ReturnLogin.Text = "返回登陆";
            this.ReturnLogin.UseVisualStyleBackColor = true;
            this.ReturnLogin.Click += new System.EventHandler(this.ReturnLogin_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(185, 85);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(200, 25);
            this.userName.TabIndex = 6;
            // 
            // userID
            // 
            this.userID.Location = new System.Drawing.Point(185, 141);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(200, 25);
            this.userID.TabIndex = 7;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(185, 194);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(200, 25);
            this.password.TabIndex = 8;
            // 
            // confrimPassword
            // 
            this.confrimPassword.Location = new System.Drawing.Point(185, 246);
            this.confrimPassword.Name = "confrimPassword";
            this.confrimPassword.PasswordChar = '*';
            this.confrimPassword.Size = new System.Drawing.Size(200, 25);
            this.confrimPassword.TabIndex = 9;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(462, 453);
            this.Controls.Add(this.confrimPassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.ReturnLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterForm";
            this.Text = "注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox userID;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox confrimPassword;
        private ButtonExt button1;
        private ButtonExt ReturnLogin;
    }
}