using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
//SQLite demo
//SQLite官网下载数据库和framework框架所需要的SQLite文件
//在引用里面添加这些文件
//如果出现cpu架构不匹配，则在项目属性里面把自己的cpu改成x64，即可正常使用
namespace Db
{
    class Program
    {
        SQLiteConnection m_dbConnection;
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            Program program = new Program();
            //连接数据库，获取连接标志m_dbConnection
            program.connectToDatabase();
            //创建表
            program.createTable();
            //插入数据
            program.insert();
            //获取数据
            program.select();
            Console.Read();
        }
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        void createTable()
        {   
            string sql = "Create table scores (name varchar(20),score int)";
            SQLiteCommand command = new SQLiteCommand(sql,m_dbConnection);
            command.ExecuteNonQuery();
        }
        void insert()
        {
            string sql = "insert into scores(name,score) values ('roy',100)";
           

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            

            command.ExecuteNonQuery();

        }
        void select()
        {
            string sql = "select * from scores";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.Write("name:" + reader["name"] + "\nscore:" + reader["score"]);
              
            }
        }
    }
}
