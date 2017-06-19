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
    public partial class teacherupdataPwd : Form
    {
        public teacherupdataPwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            teacher te = new teacher();
            te.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //蔡雨池：实现老师自我修改密码：
            string oldpwd,newpwd1,newpwd2;
            oldpwd=OldPwd.Text;
            newpwd1=NewPwd1.Text;
            newpwd2=NewPwd2.Text;


            if(OldPwd.Text.Trim()!=Admin.passwording)
            {
                //原始密码不正确的情况
                //清除数据
                this.OldPwd.Clear();
                this.NewPwd1.Clear();
                this.NewPwd2.Clear();
                MessageBox.Show("密码错误");
            }
            else
            {
                //防止2次输入密码不一致：
                if(NewPwd1.Text.Trim()!=newpwd2.Trim())
                {
                this.OldPwd.Clear();
                this.NewPwd1.Clear();
                this.NewPwd2.Clear();
                MessageBox.Show("2次输入密码不一致");
                }    
                    //防止2次输入密码为空：
                else
                {
                    if (string.IsNullOrEmpty(this.NewPwd1.Text) || string.IsNullOrEmpty(this.NewPwd2.Text))
                    {
                        this.OldPwd.Clear();
                        this.NewPwd1.Clear();
                        this.NewPwd2.Clear();
                        MessageBox.Show("2次输入密码均不能为空");
                    }
                    //更新密码
                    else
                    {
                        if(this.NewPwd1.Text==this.OldPwd.Text)
                        {

                            this.OldPwd.Clear();
                            this.NewPwd1.Clear();
                            this.NewPwd2.Clear();
                            MessageBox.Show("新旧密码不能相同");
                        }
                        else
                        {
                        //创建链接并打开链接：
                        SQLiteConnection conn = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
                        conn.Open();
                        
                        //string sql = "updata upiscores set PassWording='" + NewPwd1.Text + "' where UserName=" + Admin.userName;
                        //SQLiteCommand command = new SQLiteCommand(sql, conn);
                        //command.ExecuteNonQuery();

                        //删除原来的信息：
                        string sqlde = "delete from upiscores where UserName=" + Admin.userName;
                        SQLiteCommand command1 = new SQLiteCommand(sqlde, conn);
                        command1.ExecuteNonQuery();
                        //添加新的信息：
                        string sqlin = "insert into upiscores(UserName,PassWording,UserIdentity)values('" + Admin.userName + "','" + NewPwd1.Text + "','" + Admin.userIdentity + "')";
                        SQLiteCommand command2 = new SQLiteCommand(sqlin, conn);
                        command2.ExecuteNonQuery();
                        //删除再添加实现了信息的更新

                        //关闭链接
                        conn.Close();
                        MessageBox.Show("修改成功");
                        this.Hide();
                        student st=new student();
                        st.ShowDialog();
                        this.Close();
                        }
                    }
                }
            
            }
        
        }
    }
}
