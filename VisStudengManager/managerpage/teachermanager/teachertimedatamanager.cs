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
    public partial class teachertimedatamanager : Form
    {
        public teachertimedatamanager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            teacherdatamanager te = new teacherdatamanager();
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

        private void teachertimedatamanager_Load(object sender, EventArgs e)
        {
           SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "select * from teachertimedata";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "teachertimedata");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["teachertimedata"];
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.AllowUserToAddRows = false;


            for (int j = 0; j < this.dataGridView1.Rows.Count; j++)

            {
                if (teacherdatamanager.qlist1.Equals(this.dataGridView1.Rows[j].Cells[0].Value.ToString()))
                {
                    this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;


                }
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (teacherdatamanager.qlist1.Equals(this.dataGridView1.Rows[i].Cells[2].Value.ToString()))
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;


                }
            }


            
            conn.Close();
        }
    }
}
