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
    public partial class updatauser1 : Form
    {
        public updatauser1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
            conn.Open();

            if (string.IsNullOrEmpty(this.textBoxuser.Text))
                {

                    this.textBoxuser.Clear();
                    this.textBoxPwd.Clear();
                    MessageBox.Show("请输入账号");

                }
            else if (string.IsNullOrEmpty(this.textBoxPwd.Text))
            {

                MessageBox.Show("请输入密码");

            }
            else
            {

                string sql = String.Format("select count(*) from upiscores where UserName= " + this.textBoxuser.Text);
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                long num = (long)comm.ExecuteScalar();

                if (num > 0)
                {

                    string sqlselect = "select * from upiscores where UserName=" + this.textBoxuser.Text;
                    SQLiteCommand command1 = new SQLiteCommand(sqlselect, conn);
                    SQLiteDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string PassWording=reader1["PassWording"].ToString();

                        if (PassWording==this.textBoxPwd.Text)
                            {
                                
                                this.textBoxPwd.Clear();
                                MessageBox.Show("新密码不能和旧密码一致");

                            }
                        else
                            {
                                SQLiteCommand command2 = new SQLiteCommand(sqlselect, conn);
                                SQLiteDataReader reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                    {  
                                        
                                        string UserIdentity = reader2["UserIdentity"].ToString();
                                         string sqlde = "delete from upiscores where UserName=" + this.textBoxuser.Text;
                                        SQLiteCommand command3 = new SQLiteCommand(sqlde, conn);
                                        command3.ExecuteNonQuery();
                                         string sqlin = "insert into upiscores(UserName,PassWording,UserIdentity)values('" + this.textBoxuser.Text + "','" + this.textBoxPwd.Text + "','" + UserIdentity + "')";
                                        SQLiteCommand command4 = new SQLiteCommand(sqlin, conn);
                                        command4.ExecuteNonQuery();
                                        this.textBoxuser.Clear();
                                        this.textBoxPwd.Clear();
                                        MessageBox.Show("修改成功");
                                        this.Hide();
                                        Administrator ad = new Administrator();
                                        ad.ShowDialog();
                                        
                                        
                                    }
                            }
                    }

                }
                else
                {
                    
                    this.textBoxuser.Clear();
                    this.textBoxPwd.Clear();
                    MessageBox.Show("不存在的用户名");

                }

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator ad = new Administrator();
            ad.ShowDialog(); 
            this.Close();
        }
    }
}
