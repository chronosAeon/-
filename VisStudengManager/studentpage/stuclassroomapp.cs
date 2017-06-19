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
    public partial class stuclassroomapp : Form
    {
        public stuclassroomapp()
        {
            InitializeComponent();
            this.listBox1.DataSource = new String[] { "1-2节课", "3-4节课","5-6节课","7-8节课","9-10节课" };

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); 
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            student st = new student();
            st.ShowDialog();
            this.Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuclassroomapp_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select clno,classroomdata.bno,floor,bname from classroomdata,buildingdata WHERE classroomdata.bno=buildingdata.bno";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "classroomdata");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["classroomdata"];
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //日期判断
            string clno = this.textBoxclno.Text;
            string sno = this.textBoxsno.Text;
            string usedate = this.dateTimePicker1.Text;          
            string Weekday = this.textBoxweek.Text;
            string Period = this.listBox1.Text;
            string Use = this.textBoxUse.Text;
            if (string.IsNullOrEmpty(this.textBoxclno.Text))
            {
                MessageBox.Show("请完成所有信息的填写");
            
            }
            else if (string.IsNullOrEmpty(this.textBoxsno.Text))
            {
                MessageBox.Show("请完成所有信息的填写");
            
            }
            else if (string.IsNullOrEmpty(this.dateTimePicker1.Text))
            {
                MessageBox.Show("请完成所有信息的填写");
            }
            else if (string.IsNullOrEmpty(this.textBoxweek.Text))
            {
                MessageBox.Show("请完成所有信息的填写");
            }
            else if (string.IsNullOrEmpty(this.listBox1.Text))
            {
                MessageBox.Show("请完成所有信息的填写");

            }
            else if (string.IsNullOrEmpty(this.textBoxUse.Text))
            {
                MessageBox.Show("请完成所有信息的填写");
            }

            else
            {

                SQLiteConnection u_dbConnection = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
                u_dbConnection.Open();
                string sqlselect1 = String.Format("select count(*) from classroomdata where clno='{0}'", clno);
                SQLiteCommand commsel = new SQLiteCommand(sqlselect1, u_dbConnection);
                long num1 = (long)commsel.ExecuteScalar();
                if (num1 == 0)
                {
                    MessageBox.Show("不存在的教室");
                }
                else
                {
                    string sqlcount = String.Format("select count(*) from classroomborrowdata where clno='{0}' and usedate='{1}' and  Period='{2}'  ", clno, usedate, Period);
                    SQLiteCommand comm = new SQLiteCommand(sqlcount, u_dbConnection);
                    long num = (long)comm.ExecuteScalar();
                    if (num > 0)
                    {
                        MessageBox.Show("该教室在该时间段已被占用");
                    }
                    else
                    {
                        string sql = "insert into studentclassrommapplicationTable(clno,sno,usedate,Weekday ,Period ,Use)values" + "('" + clno + "','" + sno + "','" + usedate + "','" + Weekday + "','" + Period + "','" + Use + "')";
                        SQLiteCommand insert_command = new SQLiteCommand(sql, u_dbConnection);
                        insert_command.ExecuteNonQuery();
                        MessageBox.Show("申请已经发出");
                        //this.Hide();
                        //student st = new student();
                        //st.ShowDialog();
                        //this.Close();
                    }
                }
                u_dbConnection.Close();
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.textBoxweek.Text = this.dateTimePicker1.Value.DayOfWeek.ToString();
        }

        private void textBoxweek_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            string value = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            this.textBoxclno.Text = value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string value1 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string value2 = this.dateTimePicker1.Text;
            string value3 = this.listBox1.Text;
            string sqldelete = "delete from emptyclassroom";
            SQLiteCommand commanddele = new SQLiteCommand(sqldelete, conn);
            commanddele.ExecuteNonQuery();
            string sqlcount = String.Format("select count(*) from classroomborrowdata where clno='{0}' and usedate='{1}' and  Period='{2}'  ", value1, value2, value3);
            SQLiteCommand comm = new SQLiteCommand(sqlcount, conn);
            long num = (long)comm.ExecuteScalar();
            if (num > 0)
            {
                string sqlinsert = "insert into emptyclassroom(clno,usedate,period,Usestatus)values('" + value1 + "','" + value2 + "','" + value3 + "',' 已被占用 ')";
                SQLiteCommand command = new SQLiteCommand(sqlinsert, conn);
                command.ExecuteNonQuery();
                string sql = "select* from emptyclassroom";
                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds, "emptyclassroom");
                BindingSource bs = new BindingSource();
                bs.DataSource = ds.Tables["emptyclassroom"];
                this.dataGridView1.DataSource = bs;
                this.dataGridView1.AllowUserToAddRows = false;
            }
            else
            {
                string sqlinsert = "insert into emptyclassroom(clno,usedate,period,Usestatus)values('" + value1 + "','" + value2 + "','" + value3 + "',' 无人使用 ')";
                SQLiteCommand command = new SQLiteCommand(sqlinsert, conn);
                command.ExecuteNonQuery();
                string sql = "select* from emptyclassroom";
                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds, "emptyclassroom");
                BindingSource bs = new BindingSource();
                bs.DataSource = ds.Tables["emptyclassroom"];
                this.dataGridView1.DataSource = bs;
                this.dataGridView1.AllowUserToAddRows = false;
            }
            conn.Close();
        }

        private void textBoxclno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select clno,classroomdata.bno,floor,bname from classroomdata,buildingdata WHERE classroomdata.bno=buildingdata.bno";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "classroomdata");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["classroomdata"];
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();
        }
    }
}
