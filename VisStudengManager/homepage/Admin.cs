using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;



namespace VisStudengManager
{
    public partial class Admin : Form
    {
        public static string userName, passwording, userIdentity;
        public static int teacherNum = 1;
        static SQLiteConnection u_dbConnection;
        public Admin()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            //蔡雨池：关于登陆模块的实现：
            //提取保护对象text的数据以备后用
            userName = txtUser.Text;
            passwording = txtPwd.Text;
            userIdentity = "";

            foreach (Control ctl in groupBox1.Controls)
            {
                RadioButton rad = (RadioButton)ctl;
                if (rad.Checked) 
                userIdentity = rad.Text;
            }

            try
            {
                if (string.IsNullOrEmpty(this.txtUser.Text))
                {
                    if (string.IsNullOrEmpty(this.txtPwd.Text))
                    {
                        this.txtUser.Clear();
                        this.txtPwd.Clear();
                        MessageBox.Show("请输入账号以及密码");
                    }
                    else
                    {
                        this.txtUser.Clear();
                        this.txtPwd.Clear();
                        MessageBox.Show("请输入账号");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.txtPwd.Text))
                    {
                        this.txtUser.Clear();
                        this.txtPwd.Clear();
                        MessageBox.Show("请输入密码");
                    }
                    else
                    {

                        //获取数据库连接
                        u_dbConnection = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
                        //打开数据库
                        u_dbConnection.Open();
                        //count(*)查询所有表的记录数
                        string sql = String.Format("select count(*) from upiscores where UserName='{0}' and PassWording='{1}' and  UserIdentity='{2}'", userName, passwording, userIdentity);
                        SQLiteCommand comm = new SQLiteCommand(sql, u_dbConnection);
                        long num = (long)comm.ExecuteScalar();
                        if (num > 0)
                        {
                            switch (userIdentity)
                            {
                                case "管理员":
                                    this.Hide();
                                    management ma = new management();
                                    ma.ShowDialog();
                                    this.Close();
                                    break;

                                case "学生":
                                    this.Hide();
                                    student st = new student();
                                    st.ShowDialog();
                                    this.Close();
                                    break;

                                case "教师":
                                    this.Hide();
                                    teacher te = new teacher();
                                    te.ShowDialog();
                                    this.Close();
                                    break;

                            }
                        }
                        else
                        {
                            this.txtUser.Clear();
                            this.txtPwd.Clear();
                            MessageBox.Show("用户名，密码或身份错误");
                        }
                        u_dbConnection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }
        
                
            }
           

        private void custom_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
            this.Close();
        }

        private void register_Click(object sender, EventArgs e)
        {
            this.Hide();
           sign sign = new sign();
            sign.ShowDialog();
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
          

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
