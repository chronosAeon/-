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
    public partial class classroommanage : Form
    {
        public classroommanage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            management ma = new management();
            ma.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            classroomstate cl = new classroomstate();
            cl.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            classroomapproval cl = new classroomapproval();
            cl.ShowDialog();
            this.Close();
        }
    }
}
