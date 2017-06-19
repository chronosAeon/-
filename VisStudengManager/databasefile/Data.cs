using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
//version1.0正在完善数据库部分，此版本添加功能测试成功
namespace VisStudengManager
{  //Data类作为负责存储数据和模拟数据，目前可以从文本文档中按照格式读写，也可以直接调用模拟数据，数据部分包括增删改查
         //从数据类里面拿的数据返回的是StudentData[]但是在前端的使用却是string[],要么统一前后端数据使用格式，要么就在model里面从事数据处理。
    static class Data
    {
        //学生的模拟内存数据,由Data类的静态属性simdata类数组维护
        private static StudentData[] simdata;
        //查询得到的数据放这里
        public static StudentData[] studentTempdata = new StudentData[0];
        //控制模拟数据的最大的索引
         private static int max_index = -1;
        //文件访问路径
        private static string filepath = null;
        //控制数据读写类型,0为模拟数据，1为文本数据
        static int mode = 1;
        //数据库连接
        static SQLiteConnection sql_connection;
        static StudentData item;
        //将数据库所有数据读取到内存
        public static void readAllDataFromDb()
        {
            if (File.Exists(@"Student_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Student_Db.sqlite;Version=3;");
                sql_connection.Open();
                string sql = "select * from Student";
                SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //其实这个地方应该把添加在数据库的时候考虑完整性不能存在空
                    int num;
                    int age;
                    if (reader["student_num"] is DBNull)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = (int)reader["student_num"];
                    }
                    if (reader["age"] is DBNull)
                    {
                        age = 0;
                    }
                    else
                    {
                        age = (int)reader["age"];
                    }
                    if (reader["id"] is DBNull)
                    {
                        Console.WriteLine("no ok");
                    }
                    else
                    {
                        //这个地方不能像前面的一样(int)reader["id"]，不知道为什么！！！！！！
                        Console.WriteLine("id:" + int.Parse(reader["id"].ToString()));
                    }

                    string name = reader["name"].ToString();
                    string sex = reader["sex"].ToString();
                    string major = reader["major"].ToString();
                    string place = reader["Place_of_origin"].ToString();
                    string interest = reader["Interest"].ToString();
                    item = new StudentData(num, name, sex, age, major, place, interest);
                    Data.addSimulation(item);
                }
            }
            else
            {
                //创建数据库
                SQLiteConnection.CreateFile("Student_Db.sqlite");
                //获取数据库连接
                sql_connection = new SQLiteConnection("Data Source=Student_Db.sqlite;Version=3;");
                //打开数据库
                sql_connection.Open();
                //创建表的sql语句
                string sql = "Create table Student ( id   integer PRIMARY KEY  ,name varchar(20),student_num int,sex varchar(20),age int,major varchar(20),Place_of_origin varchar(20),Interest varchar(20))";
                //创建指令
                SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                //执行指令
                command.ExecuteNonQuery();
            }
        }

        public static void insertFromDb(StudentData data)
        {
            string sqlnsert = "insert into Student (name,student_num,sex,age,major,Place_of_origin,Interest) values" + "('" + data.name + "'," + data.student_num + ",'" + data.sex + "','" + data.age + "','" + data.major + "','" + data.Place_of_origin + "','" + data.major + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_connection);
            insert_command.ExecuteNonQuery();
        }
        //重载方便之后使用
        public static void insertFromDb(int student_num, string name, int age, string major, string place, string sex, string interest)
        {
            string sqlnsert = "insert into Student (name,student_num,sex,age,major,Place_of_origin,Interest) values" + "('" + name + "'," + student_num + ",'" + sex + "','" + age + "','" + major + "','" + place + "','" + major + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_connection);
            insert_command.ExecuteNonQuery();
        }
        //param 为行数目
        public static void deleteFormDb(int id)
        {
            string sql_delete = "delete from Student where id = " + id;
            SQLiteCommand delete_command = new SQLiteCommand(sql_delete, sql_connection);
            delete_command.ExecuteNonQuery();
        }
        //通过前端数据向后端数据库传递数据
        public static void updateAccoClient(StudentData[] simdata)
        {
            //清空表数据
            //string sql_clean = "TRUNCATE  TABLE  Student";
            string sql_clean = "delete from Student ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (StudentData item in simdata)
            {
                insertFromDb(item);
            }
        }
        public static StudentData[] getDataAll()
        {
            switch (mode)
            {
                case 0:
                    {
                        int total = max_index + 1;
                        return getFileDataNum(filepath, total);
                    }
                case 1:
                    {
                        int total = max_index + 1;
                        return getSimulationNum(total);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        public static StudentData[] getDataNum(int num)
        {
            switch (mode)
            {
                case 0:
                    {
                        return getFileDataNum(filepath, num);
                    }
                case 1:
                    {
                        return getSimulationNum(num);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        //文件数据传入路径和获取的条数
        private static StudentData[] getFileDataNum(string path, int num)
        {
            StudentData[] data = new StudentData[num];
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            int index = 0;
            while ((line = sr.ReadLine()) != null && index < num)
            {
                //例如罗伊，男被分割成了存有{"罗伊","男"}这个数组
                string[] key = line.Split(',');
                data[index] = new StudentData(int.Parse(key[0]), key[1], key[2], int.Parse(key[3]), key[4], key[5], key[6]);
                index++;
            }
            return data;
        }
        //初始化查询数据
        public static void setTemp(StudentData[] arr)
        {
            studentTempdata = new StudentData[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                studentTempdata[i] = new StudentData(arr[i]);
            }
        }
        //设置初始数据
        public static void setSimulation(StudentData[] arr)
        {
            max_index = arr.Length - 1;
            //simdata = new StudentData[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                simdata[i] = new StudentData(arr[i]);
            }
        }
        //添加一条数据
        public static void addSimulation(StudentData addsim)
        {
            if (max_index != -1)
            {
                StudentData[] replace = simdata;
                //simdata = new StudentData[3];
                simdata = new StudentData[max_index + 2];
                Data.setSimulation(replace);
                simdata[max_index + 1] = new StudentData(addsim);
                max_index += 1;
            }
            else
            {
                simdata = new StudentData[1];
                simdata[0] = new StudentData(addsim);
                max_index += 1;
            }
        }
        //添加多条数据
        public static void addSimulationNum(int num, StudentData[] addsim)
        {
            for (int i = 0; i < num; i++)
            {
                simdata[max_index + i + 1] = addsim[i];
            }
            max_index += num;
        }
        //更改数据,根据索引修改数据
        public static void modifySimulation(int index, StudentData data)
        {
            if (index <= 0 || index - 1 >= simdata.Length)
            {
                Console.WriteLine("您输入的索引错误");
            }
            else
            {
                simdata[index - 1] = new StudentData(data);
            }
        }
        //这个地方用的索引
        public static void delSimulation(int index)
        {
            //如果传入索引小于0或者索引是溢出最大值
            if (index < 0 || index > simdata.Length - 1)
            {

            }
            //如果数据长度大于1索引不是最大值
            else if (simdata.Length > 1 && index != simdata.Length - 1)
            {
                StudentData[] replace = new StudentData[simdata.Length - 1];
                for (int i = index; i < simdata.Length - 1; i++)
                {
                    //simdata[1] = simdata[2];
                    simdata[i] = simdata[i + 1];
                }
                for (int i = 0; i < simdata.Length - 1; i++)
                {
                    replace[i] = new StudentData(simdata[i]);
                }
                simdata = replace;
                max_index -= 1;
            }
            //数组长度为1
            else if (simdata.Length == 1)
            {
                //这里bug如果只有一个数据修改了，那个数据不会删掉，而是会出现0,0,null
                simdata[0] = new StudentData();
                max_index -= 1;
            }
            //如果删除最后一个
            else
            {
                StudentData[] replace = new StudentData[simdata.Length - 1];
                for (int i = 0; i < simdata.Length - 1; i++)
                {
                    replace[i] = new StudentData(simdata[i]);
                }
                simdata = replace;
                max_index -= 1;
            }
        }
        //查询
        public static void query()
        {

        }
        private static StudentData[] getSimulationNum(int num)
        {
            StudentData[] data = new StudentData[num];
            for (int index = 0; index < num; index++)
            {
                data[index] = simdata[index];
            }
            return data;
        }
    }
    
}
