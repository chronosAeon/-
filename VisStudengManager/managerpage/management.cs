using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisStudengManager
{
    public partial class management : Form
    {
        public management()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator ad = new Administrator();
            ad.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            teacherdatamanager te = new teacherdatamanager();
            te.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            classroommanage cl = new classroommanage();
            cl.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentmanagement st = new studentmanagement();
            st.ShowDialog();
            this.Close();
        }
    }
}
