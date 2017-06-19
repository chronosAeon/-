using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace VisStudengManager
{

    public partial class DIsplay : Form
    {
        
        BindingSource bs;
        public DIsplay()
        {

            InitializeComponent();
        }
        private void DIsplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (DialogResult.OK == MessageBox.Show("你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            //{
            //    this.FormClosing -= new FormClosingEventHandler(this.DIsplay_FormClosing);
            //    //为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
            //    //从表格数据拿数据,放置到前端数据源
            //    bs = (BindingSource)this.dataGridView1.DataSource;
            //    //保存修改数据
            //    Data.updateAccoClient(Data.getDataAll());
            //    //最好用这个exitThread()，用exit如果返回再打开会出现弹出两次对话框的情况，因为Application。exit
            //    Application.ExitThread();
            //    /*Application.Exit();*///退出整个应用程序
            //}
            //else
            //{
            //    e.Cancel = true;  //取消关闭事件
            //}
        }
        private void DIsplay_Load(object sender, EventArgs e)
        {
            if (Admin.userIdentity=="管理员")
            {
                this.addBtn.Enabled = true;
                this.deleteBtn.Enabled = true;
                this.queryBtn.Enabled = true;
                this.modify.Enabled = true;
            }
            else if (Admin.userIdentity == "教师")
            {
                this.addBtn.Enabled = true;
                this.deleteBtn.Enabled = true;
                this.queryBtn.Enabled = true;
                this.modify.Enabled = true;
            }
             if (Admin.userIdentity == "学生")
            {
                
                this.queryBtn.Enabled = true;
                
            }



            bs = new BindingSource();
            bs.DataSource = Data.getDataAll();
            //这个是给下一条和下一页做数据绑定
            this.bindingNavigator1.BindingSource = bs;
            this.dataGridView1.DataSource = bs;
            for (int i = 0; i < Data.studentTempdata.Length; i++)
            {
                for (int j = 0; j < Data.getDataAll().Length; j++)
                {
                    if (Data.studentTempdata[i].Equals(Data.getDataAll()[j]))
                    {
                        this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add add = new Add();
            add.ShowDialog();
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //rowNum就是索引
            int rowNum = this.dataGridView1.CurrentRow.Index;
            Data.delSimulation(rowNum);
            //不采用同时删掉数据库数据和前端数据的方法，每次进行这种删除后前端的行数更新了，而后端数据并没有更新
            //解决方案：1.采用每次前端作删除的操作时，同时以前端数据为基准进行对数据更新。
            //2.采用算法规避这个问题，持久化存贮一个数组存储删除数据的行号，当前删除的行大于等于多少行就会多加几就是它的id，这个可能存在算法bug需要多测试，但是这个方法极大程度的减少了数据库的耗时操作。
            //Data.deleteFormDb(rowNum+1);
            //现有的前端数据传入数据进行后台同步
            Data.updateAccoClient(Data.getDataAll());
            bs.DataSource = Data.getDataAll();
            this.dataGridView1.DataSource = bs;

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (Admin.userIdentity == "管理员")
            {
                this.Hide();
               management  menu = new management();
                menu.ShowDialog();
                this.Close();
            }
            else if (Admin.userIdentity == "教师")
            {
                this.Hide();
                teacher menu = new teacher();
                menu.ShowDialog();
                this.Close();
            }
            else if (Admin.userIdentity == "学生")
            {
                this.Hide();
                student menu = new student();
                menu.ShowDialog();
                this.Close();
            }

            else 
            {
                this.Hide();
                MainMenu menu = new MainMenu();
                menu.ShowDialog();
                this.Close();
            }
            
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            query query = new query();
            query.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void modify_Click(object sender, EventArgs e)
        {

            //从表格数据拿数据,放置到前端数据源
            bs = (BindingSource)this.dataGridView1.DataSource;
            //保存修改数据
            Data.updateAccoClient(Data.getDataAll());
            MessageBox.Show("保存成功");
        
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        



        //private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Add add = new Add();
        //    add.ShowDialog();
        //    this.Close();
        //}

        //private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        //{
        //    this.bs.MoveNext();
        //}

        //private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        //{
        //    this.bs.MovePrevious();
        //}
    }
}
