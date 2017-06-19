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
    class aaodata
    {
        static SQLiteConnection t_dbConnection;

        public static void aaoDa()
        {
            if (File.Exists(@"aao_Db.sqlite"))
            {
            }
            else
            {
                createNewteacherDatabase();
                connectToteacherDatabase();

                createteacherTable();
                createteachertimeTable();
                createlessonTable();
                createstudentTable();
                createdepartmentTable();
                createbuildingTable();
                createclassroomTable();
                createclassrommborrowdata();
                createstudentclassrommapplicationTable();
                createemptyclassrommborrowdata();

                fillclassroomTable();
                fillbuildingTable();
                fillclassroomstatuTable();
                fillcreatestudentclassrommapplicationTable();
                fillteacherTable();
                fillteachertimeTable();
                closeteacherDatabase();
            }
        }

        public static void aaoDa1()
        {

            createNewteacherDatabase();
            connectToteacherDatabase();

            createteacherTable();
            createteachertimeTable();
            createlessonTable();
            createstudentTable();
            createdepartmentTable();
            createbuildingTable();
            createclassroomTable();
            createclassrommborrowdata();
            createstudentclassrommapplicationTable();
            createemptyclassrommborrowdata();

            fillclassroomTable();
            fillbuildingTable();
            fillclassroomstatuTable();
            fillcreatestudentclassrommapplicationTable();
            fillteacherTable();
            fillteachertimeTable();
            closeteacherDatabase();



        }

        public static void createNewteacherDatabase()
        {
            SQLiteConnection.CreateFile("aao_Db.sqlite");
        }

        public static void connectToteacherDatabase()
        {
            t_dbConnection = new SQLiteConnection("Data Source=aao_Db.sqlite;Version=3;");
            t_dbConnection.Open();

        }

        public static void closeteacherDatabase()
        {
            t_dbConnection.Close();
        }

        public static void createteacherTable()
        {
            string sql = "create table teacherdata(tno varchar(20) PRIMARY KEY, tname varchar(20),sex varchar(20),deptno varchar(20),title varchar(20),tid vacher(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createteachertimeTable()
        {
            string sql = "create table teachertimedata(tno varchar(20) , clno varchar(10),cno varchar(20) ,weekday varchar(20) ,period varchar(20) )";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createlessonTable()
        {
            string sql = "create table lessondata(cno varchar(20) ,cname varchar(20),credit varchar(20),category varchar(20),deptno varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createstudentTable()
        {
            string sql = "create table studentdata(sno varchar(20) ,sname varchar(20),deptno varchar(20),sid varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createdepartmentTable()
        {
            string sql = "create table departmentdata(deptno varchar(20) , deptname varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createbuildingTable()
        {
            string sql = "create table buildingdata(bno varchar(20) , bname varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery(); 
        }

        public static void createclassroomTable()
        {
            string sql = "create table classroomdata (clno varchar(20) , bno varchar(20),floor varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createclassrommborrowdata()
        {
            string sql = "create table classroomborrowdata(clno varchar(20) , sno varchar(20),usedate varchar(20),Weekday varchar(20),Period varchar(20),Use varchar(20),Usestatus varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void createstudentclassrommapplicationTable()
        {
            string sql = "create table studentclassrommapplicationTable(clno varchar(20) , sno varchar(20),usedate varchar(20),Weekday varchar(20),Period varchar(20),Use varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();  
        }

        public static void createemptyclassrommborrowdata()
        {
            string sql = "create table emptyclassroom(clno varchar(20),usedate varchar(20),Period varchar(20),Usestatus varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void fillclassroomTable()
        {
            string sql = "insert into classroomdata(clno,bno,floor)values('E1A101','E1A','1')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1A102','E1A','1')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1A201','E1A','2')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1A202','E1A','2')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1A301','E1A','3')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1A302','E1A','3')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B101','E1B','1')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B102','E1B','1')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B201','E1B','2')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B202','E1B','2')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B301','E1B','3')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomdata(clno,bno,floor)values('E1B302','E1B','3')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            

        }

        public static void fillbuildingTable()
        {
            string sql = "insert into buildingdata(bno,bname)values('E1A','东区1教A栋')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into buildingdata(bno,bname)values('E1B','东区1教B栋')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            
        }

        public static void fillclassroomstatuTable()
        {
            string sql = "insert into classroomborrowdata(clno,sno,usedate,Weekday ,Period ,Use ,Usestatus)values('2A205','s2015','2017年6月','周3','上午1-2节课','班会','已审批')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomborrowdata(clno,sno,usedate,Weekday ,Period ,Use ,Usestatus)values('2A205','s2015','2017年6月','周4','上午1-2节课','班会','已审批')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into classroomborrowdata(clno,sno,usedate,Weekday ,Period ,Use ,Usestatus)values('2A205','s2015','2017年6月','周5','上午1-2节课','班会','已审批')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void fillcreatestudentclassrommapplicationTable()
        {
            string sql = "insert into studentclassrommapplicationTable(clno,sno,usedate,Weekday ,Period ,Use)values('1','s2015','2017年5月','周3','上午1-2节课','班会')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into studentclassrommapplicationTable(clno,sno,usedate,Weekday ,Period ,Use)values('3','s2015','2017年5月','周4','上午1-2节课','班会')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into studentclassrommapplicationTable(clno,sno,usedate,Weekday ,Period ,Use)values('2','s2015','2017年5月','周5','上午1-2节课','班会')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void fillteacherTable()
        {
            string sql = "insert into teacherdata(tno,tname,sex,deptno,title,tid)values('1','张三','男','信息科学与技术学院','教授','5111021')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teacherdata(tno,tname,sex,deptno,title,tid)values('2','李四','男','地球物理学院','副教授','5111022')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teacherdata(tno,tname,sex,deptno,title,tid)values('3','王五','女','地球科学学院','讲师','5111023')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void fillteachertimeTable()
        {
            string sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('1','2A205','1','周一','上午1-2节课')";
            SQLiteCommand command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('1','2A205','1','周三','上午1-2节课')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('1','2A205','1','周五','上午1-2节课')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('2','2A205','3','周一','上午1-2节课')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('2','2A205','5','周五','上午1-2节课')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into teachertimedata(tno,clno,cno,weekday,period)values('2','2A205','7','周六','上午1-2节课')";
            command = new SQLiteCommand(sql, t_dbConnection);
            command.ExecuteNonQuery();

        }



        
    }
}
