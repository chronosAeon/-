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
    public partial class classroomstate : Form
    {
        public classroomstate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            classroommanage cl = new classroommanage();
            cl.ShowDialog();
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

        private void classroomstate_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from classroomborrowdata";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "classroomborrowdata");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["classroomborrowdata"];
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string value1 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string value2 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            string value3 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();

            string sql_delete = "delete from classroomborrowdata where clno='" + value1 + "' and usedate='" + value2 + "' and Period='" + value3 + "' ";
            SQLiteCommand delete_command = new SQLiteCommand(sql_delete, conn);
            delete_command.ExecuteNonQuery();

            string sql = "select * from classroomborrowdata";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "classroomborrowdata");
            this.dataGridView1.DataSource = ds.Tables["classroomborrowdata"];
            da.Update(ds.Tables["classroomborrowdata"]);
            MessageBox.Show("记录已删除");
            conn.Close();
        }
    }
}
