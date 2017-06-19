using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace VisStudengManager
{
    public partial class studentupdataPwd : Form
    {
        public studentupdataPwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            student st = new student();
            st.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldpwd,newpwd1,newpwd2;
            oldpwd=OldPwd.Text;
            newpwd1=NewPwd1.Text;
            newpwd2=NewPwd2.Text;
            if(OldPwd.Text.Trim()!=Admin.passwording)
            {
                this.OldPwd.Clear();
                this.NewPwd1.Clear();
                this.NewPwd2.Clear();
                MessageBox.Show("原始密码错误");
            }
            else
            {
                if(NewPwd1.Text.Trim()!=newpwd2.Trim())
                {
                this.OldPwd.Clear();
                this.NewPwd1.Clear();
                this.NewPwd2.Clear();
                MessageBox.Show("2次输入密码不一致");
                }    
                else
                {
                    if (string.IsNullOrEmpty(this.NewPwd1.Text) || string.IsNullOrEmpty(this.NewPwd2.Text))
                    {
                        this.OldPwd.Clear();
                        this.NewPwd1.Clear();
                        this.NewPwd2.Clear();
                        MessageBox.Show("2次输入密码均不能为空");
                    }
                    
                    else
                    {
                        if (this.NewPwd1.Text == this.OldPwd.Text)
                        {

                            this.OldPwd.Clear();
                            this.NewPwd1.Clear();
                            this.NewPwd2.Clear();
                            MessageBox.Show("新旧密码不能相同");
                        }
                        else
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
                            conn.Open();

                            //string sql = "updata upiscores set PassWording='" + NewPwd1.Text + "' where UserName=" + Admin.userName;
                            //SQLiteCommand command = new SQLiteCommand(sql, conn);
                            //command.ExecuteNonQuery();

                            string sqlde = "delete from upiscores where UserName=" + Admin.userName;
                            SQLiteCommand command1 = new SQLiteCommand(sqlde, conn);
                            command1.ExecuteNonQuery();
                            string sqlin = "insert into upiscores(UserName,PassWording,UserIdentity)values('" + Admin.userName + "','" + NewPwd1.Text + "','" + Admin.userIdentity + "')";
                            SQLiteCommand command2 = new SQLiteCommand(sqlin, conn);
                            command2.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("修改成功");
                            this.Hide();
                            student st = new student();
                            st.ShowDialog();
                            this.Close();
                        }
                    }
                }
            
            }
        }
    }
}
