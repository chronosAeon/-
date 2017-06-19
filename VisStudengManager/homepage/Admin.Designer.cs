namespace VisStudengManager
{
    partial class Admin
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
            this.accound = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.custom = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radT = new System.Windows.Forms.RadioButton();
            this.radS = new System.Windows.Forms.RadioButton();
            this.radA = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accound
            // 
            this.accound.AutoSize = true;
            this.accound.Location = new System.Drawing.Point(95, 189);
            this.accound.Name = "accound";
            this.accound.Size = new System.Drawing.Size(41, 12);
            this.accound.TabIndex = 0;
            this.accound.Text = "账号：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(164, 180);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(133, 21);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(95, 250);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(41, 12);
            this.password.TabIndex = 2;
            this.password.Text = "密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(164, 241);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(133, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(233, 118);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(101, 12);
            this.title.TabIndex = 4;
            this.title.Text = "教务管理系统登录";
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(328, 179);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(112, 21);
            this.login.TabIndex = 6;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // custom
            // 
            this.custom.Location = new System.Drawing.Point(365, 399);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(75, 23);
            this.custom.TabIndex = 7;
            this.custom.Text = "custom";
            this.custom.UseVisualStyleBackColor = true;
            this.custom.Click += new System.EventHandler(this.custom_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(328, 250);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(112, 23);
            this.register.TabIndex = 9;
            this.register.Text = "register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radT);
            this.groupBox1.Controls.Add(this.radS);
            this.groupBox1.Controls.Add(this.radA);
            this.groupBox1.Location = new System.Drawing.Point(130, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "身份";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radT
            // 
            this.radT.AutoSize = true;
            this.radT.Location = new System.Drawing.Point(7, 66);
            this.radT.Name = "radT";
            this.radT.Size = new System.Drawing.Size(47, 16);
            this.radT.TabIndex = 2;
            this.radT.Text = "教师";
            this.radT.UseVisualStyleBackColor = true;
            // 
            // radS
            // 
            this.radS.AutoSize = true;
            this.radS.Location = new System.Drawing.Point(7, 44);
            this.radS.Name = "radS";
            this.radS.Size = new System.Drawing.Size(47, 16);
            this.radS.TabIndex = 1;
            this.radS.Text = "学生";
            this.radS.UseVisualStyleBackColor = true;
            // 
            // radA
            // 
            this.radA.AutoSize = true;
            this.radA.Checked = true;
            this.radA.Location = new System.Drawing.Point(7, 21);
            this.radA.Name = "radA";
            this.radA.Size = new System.Drawing.Size(59, 16);
            this.radA.TabIndex = 0;
            this.radA.TabStop = true;
            this.radA.Text = "管理员";
            this.radA.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 463);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.register);
            this.Controls.Add(this.custom);
            this.Controls.Add(this.login);
            this.Controls.Add(this.title);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.password);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.accound);
            this.Name = "Admin";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accound;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radT;
        private System.Windows.Forms.RadioButton radS;
        private System.Windows.Forms.RadioButton radA;
    }
}