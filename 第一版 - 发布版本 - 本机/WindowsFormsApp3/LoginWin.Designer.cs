namespace WindowsFormsApp3
{
    partial class LoginWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Regis = new WinformControlLibraryExtension.ButtonExt();
            this.Login = new WinformControlLibraryExtension.ButtonExt();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userID = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Regis
            // 
            this.Regis.Animation.Options.AllTransformTime = 250D;
            this.Regis.Animation.Options.Data = null;
            this.Regis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.Regis.Location = new System.Drawing.Point(264, 289);
            this.Regis.Name = "Regis";
            this.Regis.Size = new System.Drawing.Size(100, 62);
            this.Regis.TabIndex = 0;
            this.Regis.Text = "注册";
            this.Regis.UseVisualStyleBackColor = true;
            this.Regis.Click += new System.EventHandler(this.Regis_Click);
            // 
            // Login
            // 
            this.Login.Animation.Options.AllTransformTime = 250D;
            this.Login.Animation.Options.Data = null;
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.Login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(92, 289);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(100, 62);
            this.Login.TabIndex = 2;
            this.Login.Text = "登陆";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码：";
            // 
            // userID
            // 
            this.userID.Location = new System.Drawing.Point(175, 125);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(189, 25);
            this.userID.TabIndex = 5;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(175, 198);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(189, 25);
            this.password.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(462, 453);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Regis);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "登陆界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userID;
        private System.Windows.Forms.TextBox password;
        private WinformControlLibraryExtension.ButtonExt Regis;
        private WinformControlLibraryExtension.ButtonExt Login;
    }
}

