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
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentupdataPwd udpwd =new studentupdataPwd();
            udpwd.ShowDialog();
            this.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确定要注销吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            Application.Exit();
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            stuclassroomapp st = new stuclassroomapp();
            st.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DIsplay display = new DIsplay();
            display.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            querystudyhall q = new querystudyhall();
            q.ShowDialog();
            this.Close();
        }
    }
}
