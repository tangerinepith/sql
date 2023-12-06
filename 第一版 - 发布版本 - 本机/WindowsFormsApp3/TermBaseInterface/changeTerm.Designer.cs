namespace WindowsFormsApp3.TermBaseInterface
{
    partial class changeTerm
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
            this.button1 = new WinformControlLibraryExtension.ButtonExt();
            this.button2 = new WinformControlLibraryExtension.ButtonExt();
            this.newZn = new System.Windows.Forms.TextBox();
            this.newExp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "新译文：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "新说明：";
            // 
            // button1
            // 
            this.button1.Animation.Options.AllTransformTime = 250D;
            this.button1.Animation.Options.Data = null;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(98, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Animation.Options.AllTransformTime = 250D;
            this.button2.Animation.Options.Data = null;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.button2.Location = new System.Drawing.Point(225, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // newZn
            // 
            this.newZn.ForeColor = System.Drawing.Color.Black;
            this.newZn.Location = new System.Drawing.Point(139, 27);
            this.newZn.Name = "newZn";
            this.newZn.Size = new System.Drawing.Size(207, 25);
            this.newZn.TabIndex = 4;
            // 
            // newExp
            // 
            this.newExp.ForeColor = System.Drawing.Color.Black;
            this.newExp.Location = new System.Drawing.Point(139, 73);
            this.newExp.Name = "newExp";
            this.newExp.Size = new System.Drawing.Size(207, 25);
            this.newExp.TabIndex = 5;
            // 
            // changeTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(416, 215);
            this.Controls.Add(this.newExp);
            this.Controls.Add(this.newZn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "changeTerm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "修改术语";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newZn;
        private System.Windows.Forms.TextBox newExp;
        private WinformControlLibraryExtension.ButtonExt button1;
        private WinformControlLibraryExtension.ButtonExt button2;
    }
}