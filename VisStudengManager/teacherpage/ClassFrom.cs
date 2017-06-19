using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;

namespace VisStudengManager.teacherpage
{
    public partial class ClassFrom : Form
    {
        private int tno;
        private BindingSource bs ;
        private SQLiteConnection conn;
        //数值为1为课程操作数值为2为表操作
        private int operatorType = 1;
        private string cno;
        private string lastValue;
        //获取ui线程上下文，方便通信
        SynchronizationContext m_SyncContext = null;
        public ClassFrom(int tno)
        {
            InitializeComponent();
            this.addtoBtn.Hide();
            this.searchDatagridView.Hide();
            m_SyncContext = SynchronizationContext.Current;
            this.tno = tno;
            this.bs = new BindingSource();
            this.conn = new SQLiteConnection();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "SELECT cno,cname,credit,category,deptno,clno FROM lessondata where tno = "+this.tno;
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "TeacherClass");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["TeacherClass"];
            this.TeacherClass.DataSource = bs;
            this.TeacherClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.TeacherClass.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.bindingNavigator1.BindingSource = bs;
            this.TeacherClass.AllowUserToAddRows = false;
            this.addItem.Enabled = false;
            this.delItem.Enabled = false;
            this.back.Hide();
            this.insertAddText.Enabled = false;
            this.insertAddText.TextChanged += new EventHandler(this.search);
            this.searchDatagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.searchDatagridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            conn.Close();
        }
        public void search(object sender,EventArgs e)
        {
            if(this.searchDatagridView.Visible == false)
            {
                this.searchDatagridView.Show();
            }
            if (this.addtoBtn.Visible == false)
            {
                this.addtoBtn.Show();
            }
            Thread t2 = new Thread(new ParameterizedThreadStart(searchMethod));
            t2.IsBackground = true;
            t2.Start(this.insertAddText.Text);
            //MessageBox.Show(this.insertAddText.Text);
        }

        public void searchMethod(object data)
        {
            string datastr = data as string;
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "SELECT sno,sname FROM studentdata WHERE sno like '" + datastr + "%'";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "Student");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["Student"];
            m_SyncContext.Post(SetTextSafePost,bs);
            conn.Close();
        }
        //线程通信通知主线程更改UI
        private void SetTextSafePost(object bs)
        {
            this.searchDatagridView.DataSource = bs;
        }

        private void row_click(object sender,EventArgs e)
        {
            //找到当前的课程号去找学生信息
            MessageBox.Show("ok");
            MessageBox.Show(this.TeacherClass.CurrentRow.Cells[0].Value.ToString());
            this.cno = this.TeacherClass.CurrentRow.Cells[0].Value.ToString();
            this.back.Show();
            string currentCno = this.TeacherClass.CurrentRow.Cells[0].Value.ToString();
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "SELECT sno,sname,deptno,sid FROM studentdata WHERE sno In (SELECT sno FROM soc where cno = " + "'"+currentCno+"')";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "StudentClass");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["StudentClass"];
            this.TeacherClass.DataSource = bs;
            this.bindingNavigator1.BindingSource = bs;

            this.addItem.Enabled = true;
            this.delItem.Enabled = true;
            this.TeacherClass.RowHeaderMouseDoubleClick -= this.row_click;
            conn.Close();
            operatorType = 2;
        }
        //只有绑定的是学生数据的datagridview才有这个事件
        private void addItem_Click(object sender, EventArgs e)
        {
            if(operatorType==2)
            {
                this.insertAddText.Enabled = true;
            }
            //conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            //conn.Open();
            //MessageBox.Show(this.TeacherClass.CurrentCell.Value.ToString());
            
            //operateText标明修改字段，格式如下,修改字段，修改前的值，修改后的值，cname,数学,高数
            //sno是必须在student列表中，采用多线程进行动态查询
            //string sql = "insert into StudentApplication (tno,cno,sno,operate,operateText,status) values(" + this.tno + "," + "'" + this.cno + "'," + "'" +"?"  + "'" + ",'add'" + ",'" + "add this item" + "'" + ",'审批中'" + ")";
            //MessageBox.Show(TeacherClass.CurrentRow.Cells[0].Value.ToString());
            //SQLiteCommand com = new SQLiteCommand(sql, conn);
            //com.ExecuteNonQuery();
            //conn.Close();
            //MessageBox.Show("学生添加发送审批");
            //MessageBox.Show("添加");
        }
        //只有绑定的是学生数据的datagridview才有这个事件
        private void delItem_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            MessageBox.Show(this.TeacherClass.CurrentCell.Value.ToString());
            //operateText标明修改字段，格式如下,修改字段，修改前的值，修改后的值，cname,数学,高数
            //sno是必须在student列表中，采用多线程进行动态查询
            string sql = "insert into StudentApplication (tno,cno,sno,operate,operateText,status) values(" + this.tno + "," + "'" + this.cno + "'," + "'" + this.TeacherClass.CurrentRow.Cells[0].Value.ToString() + "'" + ",'del'" + ",'" + "del this item" + "'" + ",'审批中'" + ")";
            MessageBox.Show(TeacherClass.CurrentRow.Cells[0].Value.ToString());
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("学生删除发送审批");
            MessageBox.Show("删除");
        }

        private void editstart_event(object sender, EventArgs e)
        {
            //编辑开始是要对当前是在编辑教室还是学生做判断，再把编辑后的值发给审批，还原编辑前的值，一旦管理员批准就操作当前表修改数据。
            MessageBox.Show("start");
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            lastValue = this.TeacherClass.CurrentCell.Value.ToString();
            MessageBox.Show(lastValue);
            conn.Open();
            conn.Close();
        }
        private void editend_event(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("是否提交修改审批?", "提交", messButton);
            if(dr == DialogResult.OK)
            {
                //当前操作为课程审批
                if (operatorType == 1)
                {
                    conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
                    conn.Open();
                    MessageBox.Show(this.TeacherClass.CurrentCell.Value.ToString());
                    //operateText标明修改字段，格式如下,修改字段，修改前的值，修改后的值，cname,数学,高数
                    string sql = "insert into ClassApplication (tno,cno,operate,operateText,status) values(" + this.tno + "," + "'" + TeacherClass.CurrentRow.Cells[5].Value.ToString() + "'" + ",'edit'" + ",'" + this.TeacherClass.Columns[this.TeacherClass.CurrentCell.ColumnIndex].HeaderCell.Value.ToString() + "," + this.lastValue + "," + this.TeacherClass.CurrentCell.Value.ToString() +"'" + ",'审批中'" + ")";
                    MessageBox.Show(TeacherClass.CurrentRow.Cells[5].Value.ToString());
                    SQLiteCommand com = new SQLiteCommand(sql,conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("修改发送审批");
                }
                //当前操作为学生审批
                else
                {
                    conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
                    conn.Open();
                    MessageBox.Show(this.TeacherClass.CurrentCell.Value.ToString());
                    //operateText标明修改字段，格式如下,修改字段，修改前的值，修改后的值，cname,数学,高数
                    string sql = "insert into StudentApplication (tno,cno,sno,operate,operateText,status) values(" + this.tno + "," + "'" + this.cno + "'," + "'" + this.TeacherClass.CurrentRow.Cells[0].Value.ToString() +"'" + ",'edit'" + ",'" + this.TeacherClass.Columns[this.TeacherClass.CurrentCell.ColumnIndex].HeaderCell.Value.ToString() + "," + this.lastValue + "," + this.TeacherClass.CurrentCell.Value.ToString() + "'" + ",'审批中'" + ")";
                    MessageBox.Show(TeacherClass.CurrentRow.Cells[0].Value.ToString());
                    SQLiteCommand com = new SQLiteCommand(sql, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("学生修改发送审批");
                }

            }
            else
            {
                return;
            }
            MessageBox.Show("end");
        }
       

        private void back_Click(object sender, EventArgs e)
        {
            this.cno = "";
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "SELECT cno,cname,credit,category,deptno,clno FROM lessondata where tno = " + this.tno;
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds, "TeacherClass");
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables["TeacherClass"];
            this.TeacherClass.DataSource = bs;
            this.TeacherClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.TeacherClass.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.bindingNavigator1.BindingSource = bs;
            this.TeacherClass.AllowUserToAddRows = false;
            this.addItem.Enabled = false;
            this.delItem.Enabled = false;
            this.TeacherClass.RowHeaderMouseDoubleClick += this.row_click;
            conn.Close();
            this.back.Hide();
            operatorType = 1;
            this.insertAddText.Enabled = false;
            this.searchDatagridView.DataSource = null;
            this.searchDatagridView.Hide();
            this.addtoBtn.Hide();

        }

        private void addtoBtn_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=aao_Db.sqlite;Version=3;";
            conn.Open();
            string sql = "insert into StudentApplication (tno,cno,sno,operate,operateText,status) values(" + this.tno + "," + "'" + this.cno + "'," + "'" + this.searchDatagridView.CurrentRow.Cells[0].Value.ToString() + "'" + ",'add'" + ",'" + "add this sno" + "'" + ",'审批中'" + ")";
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("学生添加发送审批");
        }
    }
}
