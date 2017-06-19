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
    public partial class Administrator : Form
    {
        
        
     


        public Administrator()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string userna = this.textBoxusername.Text;
            SQLiteConnection conn=new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
            conn.Open();
            string sqlsel = string.Format("select count(*) from upiscores where UserName='{0}'", userna);
            SQLiteCommand comm=new SQLiteCommand(sqlsel,conn);
            long num = (long)comm.ExecuteScalar(); 
 
            if(string.IsNullOrEmpty(this.textBoxusername.Text))
            {
                MessageBox.Show("请输入查询账号");
            }
            else
            {
                if(num>0)
                {
                    for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                    {
                        
                        string sql = "select * from upiscores";
                        DataSet ds = new DataSet();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                        da.Fill(ds, "upiscores");
                        this.dataGridView1.DataSource = ds.Tables["upiscores"];

                        if (this.textBoxusername.Text.Equals(this.dataGridView1.Rows[j].Cells[0].Value.ToString()))
                        {
                            this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                            MessageBox.Show("查询成功");
                            break;
                        }

                        

                    }
                    
                }
                else
                {

                    this.textBoxusername.Clear();
                    MessageBox.Show("未找到");
                  
                }
            }
            conn.Close();
                     
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=user_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from upiscores";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "upiscores");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["upiscores"];
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();
        }

        private void bindingNavigatorSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }   
        }

        private void textBoxusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tun = this.textBoxusername.Text;
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=user_Db.sqlite;Version=3;";
            conn.Open();

            if (this.textBoxusername.Text.Trim() == Admin.userName)
            {
                MessageBox.Show("禁止删除");
            }
            else
            {
                //先删除数据，再刷新展示：
                string sql_delete = "delete from upiscores where UserName = " + "('" + tun + "')";
                SQLiteCommand delete_command = new SQLiteCommand(sql_delete, conn);
                delete_command.ExecuteNonQuery();
                string sql = "select * from upiscores";
                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds, "upiscores");
                this.dataGridView1.DataSource = ds.Tables["upiscores"];
                this.textBoxusername.Clear();
                MessageBox.Show("删除成功");
            }
            conn.Close();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            useradd useradd = new useradd();
            useradd.ShowDialog();
            this.Close();

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            updatauser1 up = new updatauser1();
            up.ShowDialog();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=user_Db.sqlite;Version=3;";
            conn.Open();


            if (this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2 ].Value.ToString() == "管理员")
            {
                MessageBox.Show("禁止删除");
            }
            else
            {

            


            string value = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string sql_delete = "delete from upiscores where UserName = " + "'" + value + "'";
            SQLiteCommand delete_command = new SQLiteCommand(sql_delete, conn);
            delete_command.ExecuteNonQuery();
            string sql = "select * from upiscores";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "upiscore");
            this.dataGridView1.DataSource = ds.Tables["upiscore"];
            da.Update(ds.Tables["upiscore"]);
            MessageBox.Show("删除成功");
               }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=user_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from upiscores";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "upiscore");
            this.dataGridView1.DataSource = ds.Tables["upiscore"];
            da.Update(ds.Tables["upiscore"]);
            conn.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            management ma = new management();
            ma.ShowDialog();
            this.Close();
        }
    }
}
