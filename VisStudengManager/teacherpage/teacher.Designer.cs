namespace VisStudengManager
{
    partial class teacher
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonClassOperate = new System.Windows.Forms.Button();
            this.buttonStudentOperate = new System.Windows.Forms.Button();
            this.SuspendLayout();


            this.buttonClassOperate.Location = new System.Drawing.Point(99, 250);
            this.buttonClassOperate.Name = "classOperate";
            this.buttonClassOperate.Size = new System.Drawing.Size(75, 23);
            this.buttonClassOperate.TabIndex = 4;
            this.buttonClassOperate.Text = "课程操作";
            this.buttonClassOperate.UseVisualStyleBackColor = true;
            this.buttonClassOperate.Click += new System.EventHandler(this.classOperate_click);



            this.buttonStudentOperate.Location = new System.Drawing.Point(99, 300);
            this.buttonStudentOperate.Name = "classOperate";
            this.buttonStudentOperate.Size = new System.Drawing.Size(75, 23);
            this.buttonStudentOperate.TabIndex = 4;
            this.buttonStudentOperate.Text = "课程操作";
            this.buttonStudentOperate.UseVisualStyleBackColor = true;
            this.buttonStudentOperate.Click += new System.EventHandler(this.studentOperater_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "修改密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "注销账号";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(99, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "分数查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonClassOperate);
            this.Controls.Add(this.buttonStudentOperate);
            this.Name = "teacher";
            this.Text = "teacher";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStudentOperate;
        private System.Windows.Forms.Button buttonClassOperate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}