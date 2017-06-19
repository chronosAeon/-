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
    public partial class sign : Form
    {
        static SQLiteConnection u_dbConnection;
        public sign()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //蔡雨池：实现教师、学生用户的注册功能
            string User =this.textBoxUser.Text;
            string Pwd = this.textBoxPwd.Text;
           string userIdentity = "";
            foreach (Control ctl in groupBox1.Controls)
            {
                RadioButton rad = (RadioButton)ctl;
                if (rad.Checked) userIdentity = rad.Text;
            }
            //加一个账号密码不为空的识别机制：
            if (string.IsNullOrEmpty(this.textBoxUser.Text))
            {
                if (string.IsNullOrEmpty(this.textBoxPwd.Text))
                {
                    this.textBoxUser.Clear();
                    this.textBoxPwd.Clear();
                    MessageBox.Show("账号,密码不能为空");
                }
                else
                {
                    this.textBoxUser.Clear();
                    this.textBoxPwd.Clear();
                    MessageBox.Show("账号不能为空");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.textBoxPwd.Text))
                {
                    this.textBoxUser.Clear();
                    this.textBoxPwd.Clear();
                    MessageBox.Show("密码不能为空");
                }
                else
                {
                    u_dbConnection = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
                    u_dbConnection.Open();
                    //加一个保证不重用户名机制：
                    string sqlsel = String.Format("select count(*) from upiscores where UserName='{0}'", User);
                    SQLiteCommand comm = new SQLiteCommand(sqlsel, u_dbConnection);
                    long num = (long)comm.ExecuteScalar();
                    if (num > 0)
                    {
                        this.textBoxUser.Clear();
                        this.textBoxPwd.Clear();
                        u_dbConnection.Close();
                        MessageBox.Show("已存在的用户名");
                    }
                    else
                    {
                        string sql = "insert into upiscores(UserName,PassWording,UserIdentity)values" + "('" + User + "','" + Pwd + "','" + userIdentity + "')";
                        SQLiteCommand insert_command = new SQLiteCommand(sql, u_dbConnection);
                        insert_command.ExecuteNonQuery();
                        u_dbConnection.Close();
                        MessageBox.Show("添加成功");
                        this.Hide();
                        Admin ad = new Admin();
                        ad.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void textBoxPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.ShowDialog();
            this.Close();
        }
    }
}
