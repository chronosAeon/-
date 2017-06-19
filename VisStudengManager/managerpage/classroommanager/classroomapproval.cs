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
    public partial class classroomapproval : Form
    {
        public classroomapproval()
        {
            InitializeComponent();
        }

        private void bindingNavigator2_RefreshItems(object sender, EventArgs e)
        {

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

        private void classroomapproval_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from studentclassrommapplicationTable";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "studentclassrommapplicationTable");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["studentclassrommapplicationTable"];
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;
            conn.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string value1 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string value2 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            string value3 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();

            string sql_delete = "delete from studentclassrommapplicationTable where clno='"+value1+"' and usedate='"+value2+"' and Period='"+value3+"' " ;
            SQLiteCommand delete_command = new SQLiteCommand(sql_delete, conn);
            delete_command.ExecuteNonQuery();
            string sql = "select * from studentclassrommapplicationTable";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "studentclassrommapplicationTable");
            this.dataGridView1.DataSource = ds.Tables["studentclassrommapplicationTable"];
            da.Update(ds.Tables["studentclassrommapplicationTable"]);
            MessageBox.Show("申请已驳回");
            conn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
                        SQLiteConnection conn = new SQLiteConnection( "Data Source=aao_Db.sqlite;Version=3;" );
                        conn.Open();
                        string sqlselect = "select * from studentclassrommapplicationTable ";
                        SQLiteCommand command1 = new SQLiteCommand(sqlselect, conn);
                        command1.ExecuteNonQuery();
                        string value0 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        string value1 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                        string value2 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                        string value3 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                        string value4 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                        string value5 = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

                        string sql_delete = "delete from studentclassrommapplicationTable where clno='" + value0 + "' and usedate='" + value2 + "' and Period='" + value4 + "' ";
                        SQLiteCommand delete_command = new SQLiteCommand(sql_delete, conn);
                        delete_command.ExecuteNonQuery();

                        string sqli = "insert into classroomborrowdata(clno,sno,usedate,Weekday ,Period ,Use ,Usestatus)values" + "('" + value0 + "','" + value1 + "','" + value2 + "','" + value3 + "','" + value4 + "','" + value5 + "','已审批' )";
                        SQLiteCommand command4 = new SQLiteCommand(sqli , conn);
                        command4.ExecuteNonQuery();
                        MessageBox.Show("审批成功");
                        conn.Close();
                        this.Hide();
                        classroomstate cl = new classroomstate();
                        cl.ShowDialog();
                        this.Close();
            
        
            }
            
                        
    }
}
