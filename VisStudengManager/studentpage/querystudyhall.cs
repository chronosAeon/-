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
    public partial class querystudyhall : Form
    {
        public querystudyhall()
        {
            InitializeComponent();
            this.listBox1.DataSource = new String[] { "1-2节课", "3-4节课", "5-6节课", "7-8节课", "9-10节课" };
            this.listBox2.DataSource = new String[] { "1", "2", "3" };
            this.listBox3.DataSource = new String[] { "E1A", "E1B" };
        }

        private void querystudyhall_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string value1 = this.listBox3.Text;
            string value2 = this.listBox2.Text;
            string sql1 = "select clno from classroomdata where bno='"+value1+"' and floor='"+value2+"'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(sql1, conn);
            DataSet ds1 = new DataSet();
            sda.Fill(ds1,"classsroomnumber");
            string sql = String.Format("select count(*) from classroomdata where bno='" + value1 + "' and floor='" + value2 + "'");
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            long num = (long)comm.ExecuteScalar();
            string value5 = this.listBox1.Text;
            string sqldelete = "delete from emptyclassroom";
            SQLiteCommand commanddele = new SQLiteCommand(sqldelete, conn);
            commanddele.ExecuteNonQuery();
            for (int i = 0; i < num; i++)
            {
                string sql3 = String.Format("select count(Usestatus) from classroomborrowdata where clno='" + ds1.Tables["classsroomnumber"].Rows[i][0] + "'");
                SQLiteCommand command3 = new SQLiteCommand(sql3, conn);
                long status = (long)command3.ExecuteScalar();
                if(status>1)
                {
                    string sqlinsert = "insert into emptyclassroom(clno,usedate,period,Usestatus)values('" + ds1.Tables["classsroomnumber"].Rows[i][0] + "','" + System.DateTime.Now.ToString("d") + "','" + value5 + "',' 已被占用 ')";
                    SQLiteCommand command2 = new SQLiteCommand(sqlinsert, conn);
                    command2.ExecuteNonQuery();
                
                }
                else
                {
                    string sqlinsert = "insert into emptyclassroom(clno,usedate,period,Usestatus)values('" + ds1.Tables["classsroomnumber"].Rows[i][0] + "','" + System.DateTime.Now.ToString("d") + "','" + value5 + "',' 无人使用 ')";
                    SQLiteCommand command2 = new SQLiteCommand(sqlinsert, conn);
                    command2.ExecuteNonQuery();
                }
            }
            string sql2 = "select * from emptyclassroom";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql2, conn);
            DataSet ds2 = new DataSet();
            da.Fill(ds2, "emptyclassroom");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds2.Tables["emptyclassroom"];
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            student st = new student();
            st.ShowDialog();
            this.Close();
        }
    }
}
