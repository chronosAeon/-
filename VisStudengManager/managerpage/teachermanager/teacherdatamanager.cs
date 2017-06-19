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
    public partial class teacherdatamanager : Form
    {
        public static string qlist1;
        public teacherdatamanager()
        {
            InitializeComponent();
            this.listBox2.DataSource = new String[] { "教师编号", "教师姓名", "教师职称", "教师身份证号", "教师院系" };
            this.listBox1.DataSource = new String[] { "教师号", "课程号" };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            management te = new management();
            te.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }   
        }

        private void teacherdatamanager_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from teacherdata";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "teacherdata");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["teacherdata"];
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.querylist2.Text == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                switch (this.listBox2.Text)
                {
                    case "教师编号":
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];
                            string sqlno = string.Format("select count(*) from teacherdata where tno='{0}'", this.querylist2.Text);
                            SQLiteCommand comm = new SQLiteCommand(sqlno, conn);
                            long num = (long)comm.ExecuteScalar(); 
                                if (num==0)
                                {
                                    this.querylist2.Clear();
                                    MessageBox.Show("未找到数据请重新查找");
                                }
                                else
                                {
                                    for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                    {
                                        if (this.querylist2.Text.Equals(this.dataGridView1.Rows[j].Cells[0].Value.ToString()))
                                        {
                                            this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                            MessageBox.Show("查询成功");
                                            break;
                                        }
                                    }
                                }
                                conn.Close();
                        }
                        break;

                    case "教师姓名":
                        {

                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];
                            string sqlno = string.Format("select count(*) from teacherdata where tname='{0}'", this.querylist2.Text);
                            SQLiteCommand comm = new SQLiteCommand(sqlno, conn);
                            long num = (long)comm.ExecuteScalar();
                            if (num == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }
                            else
                            {
                                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                {
                                    if (this.querylist2.Text.Equals(this.dataGridView1.Rows[j].Cells[1].Value.ToString()))
                                    {
                                        this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                        MessageBox.Show("查询成功");
                                        break;

                                    }



                                }
                            }
                            conn.Close();
                        }
                        break;
                    case "教师职称":
                        {


                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];
                            string sqlno = string.Format("select count(*) from teacherdata where title='{0}'", this.querylist2.Text);
                            SQLiteCommand comm = new SQLiteCommand(sqlno, conn);
                            long num = (long)comm.ExecuteScalar();
                            if (num == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }
                            else
                            {
                                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                {
                                    if (this.querylist2.Text.Equals(this.dataGridView1.Rows[j].Cells[4].Value.ToString()))
                                    {
                                        this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                    }
                                    
                                }
                            }
                            conn.Close();
                            
                        }
                        break;

                    case "教师身份证号":
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];
                            string sqlno = string.Format("select count(*) from teacherdata where tid='{0}'", this.querylist2.Text);
                            SQLiteCommand comm = new SQLiteCommand(sqlno, conn);
                            long num = (long)comm.ExecuteScalar();
                            if (num == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }
                            else
                            {
                                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                {

                                    
                                    if (this.querylist2.Text.Equals(this.dataGridView1.Rows[j].Cells[5].Value.ToString()))
                                    {
                                        this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                        MessageBox.Show("查询成功");

                                    }
                                }
                            }
                            conn.Close();
                        }
                        break;
                    case "教师院系":
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];
                            string sqlno = string.Format("select count(*) from teacherdata where deptno='{0}'", this.querylist2.Text);
                            SQLiteCommand comm = new SQLiteCommand(sqlno, conn);
                            long num = (long)comm.ExecuteScalar();
                            if (num == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }
                            else
                            {
                                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                {
                                    if (this.querylist2.Text.Equals(this.dataGridView1.Rows[j].Cells[3].Value.ToString()))
                                    {
                                        this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                                    }
                                }
                            }
                            conn.Close();
                        }
                        break;
                    
                    

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            qlist1 = this.querylist1.Text;
            if (this.querylist1.Text == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                switch (this.listBox1.Text)
                {
                    case "教师号":
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];

                            string sqlno1 = string.Format("select count(*) from teacherdata where tno='{0}'", this.querylist1.Text);
                            SQLiteCommand comm1 = new SQLiteCommand(sqlno1, conn);
                            long num1 = (long)comm1.ExecuteScalar();
                            string sqlno2 = string.Format("select count(*) from teachertimedata where tno='{0}'", this.querylist1.Text);
                            SQLiteCommand comm2 = new SQLiteCommand(sqlno2, conn);
                            long num2 = (long)comm2.ExecuteScalar();
                            if (num1 == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }
                            else if(num2==0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("该老师未开课");
                            }
                                 
                            else
                            {
                                MessageBox.Show("查询成功正在跳转");
                                this.Hide();
                                teachertimedatamanager te = new teachertimedatamanager();
                                te.ShowDialog();
                                this.Close();

                            }
                            conn.Close();
                        }
                        break;

                    case "课程号":
                        {
                            SQLiteConnection conn = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                            conn.Open();
                            string sql = "select * from teacherdata";
                            DataSet ds = new DataSet();
                            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                            da.Fill(ds, "teacherdata");
                            this.dataGridView1.DataSource = ds.Tables["teacherdata"];

                            string sqlno2 = string.Format("select count(*) from teachertimedata where cno='{0}'", this.querylist1.Text);
                            SQLiteCommand comm2 = new SQLiteCommand(sqlno2, conn);
                            long num2 = (long)comm2.ExecuteScalar();
                            if (num2 == 0)
                            {
                                this.querylist2.Clear();
                                MessageBox.Show("未找到数据请重新查找");
                            }


                            else
                            {
                                MessageBox.Show("查询成功正在跳转");
                                this.Hide();
                                teachertimedatamanager te = new teachertimedatamanager();
                                te.ShowDialog();
                                this.Close();

                            }
                            conn.Close();




                        }
                        break;

                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
