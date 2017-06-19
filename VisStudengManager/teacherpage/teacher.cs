using System;
using System.Windows.Forms;
using VisStudengManager.teacherpage;

namespace VisStudengManager
{
    public partial class teacher : Form
    {
        public teacher()
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
            teacherupdataPwd te = new teacherupdataPwd();
            te.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //蔡雨池：实现账户的注销功能：
            if (MessageBox.Show("您确定要注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //清除所有数据并关闭程序：
                Application.Exit();
                //再次打开程序：
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

            }
        }
        //课程操作点击事件,包括对于教室的操作
        private void classOperate_click(object sender ,EventArgs e)
        {
            this.Hide();
            ClassFrom classForm = new ClassFrom(Admin.teacherNum);
            classForm.ShowDialog();
            this.Close();
        }
        //学生操作点击事件
        private void studentOperater_click(object sender , EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DIsplay display = new DIsplay();
            display.ShowDialog();
            this.Close();
        }
    }
}
