using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


//蔡雨池建立的关于账号密码数据库：

namespace VisStudengManager
{
     class upiData
    {
        static SQLiteConnection u_dbConnection;

        public static void  upiDa()
        {
            if (File.Exists(@"user_Db.sqlite"))
            {
            }
            else
            {
                createNewDatabase();
                connectToDatabase();
                createTable();
                fillTable();
                closeDatabase();
            } 

            //createNewDatabase();
            //connectToDatabase();
            //createTable();
            //fillTable();

        }
        public static void upiDa1()
        {


            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();

        }

        public static void createNewDatabase()
        {
            SQLiteConnection.CreateFile("user_Db.sqlite");
        }

        public static void connectToDatabase()
        {
            u_dbConnection = new SQLiteConnection("Data Source=user_Db.sqlite;Version=3;");
            u_dbConnection.Open();
        }

        public static void closeDatabase()
        {
   
            u_dbConnection.Close();
        }


   
        public static  void createTable()
        {
            string sql = "create table upiscores(UserName varchar(24) PRIMARY KEY, PassWording varchar(24),UserIdentity varchar(24))";
            SQLiteCommand command = new SQLiteCommand(sql, u_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void fillTable()
        {
            string sql = "insert into upiscores(UserName,PassWording,UserIdentity)values('1','1','管理员')";
            SQLiteCommand command = new SQLiteCommand(sql, u_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into upiscores(UserName,PassWording,UserIdentity)values('2','2','学生')";
            command = new SQLiteCommand(sql, u_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into upiscores(UserName,PassWording,UserIdentity)values('3','3','教师')";
            command = new SQLiteCommand(sql, u_dbConnection);
            command.ExecuteNonQuery();
        }

        
     }
}
