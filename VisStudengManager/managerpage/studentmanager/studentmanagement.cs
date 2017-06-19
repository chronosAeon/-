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
    public partial class studentmanagement : Form
    {
        public studentmanagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DIsplay display = new DIsplay();
            display.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            management ma = new management();
            ma.ShowDialog();
            this.Close();
        }
    }
}
