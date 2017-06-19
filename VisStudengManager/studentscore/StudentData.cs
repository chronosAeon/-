using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisStudengManager
{
    //内存中的模拟数据模型
    class StudentData
    {
        public int student_num
        {
            set;
            get;
        }
        public string name
        {
            set;
            get;
        }
        public string sex
        {
            set;
            get;
        }
        public int age
        {
            set;
            get;
        }
        public string major
        {
            set;
            get;
        }
        public string Place_of_origin
        {
            set;
            get;
        }
        public string Interest
        {
            set;
            get;
        }
        

        public StudentData()
        {
            this.student_num = 0;
            this.name = null;
            this.sex = null;
            this.age = 0;
            this.major = null;
            this.Place_of_origin = null;
            this.Interest = null;
            
        }
        public StudentData(int num, string name, string sex, int age, string major, string place, string interest)
        {
            this.student_num = num;
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.major = major;
            this.Place_of_origin = place;
            this.Interest = interest;
            
        }
        
        //这个地方有强制转换，但是没有确定是否是按照数据模型排版输入有可能出现崩溃或者乱码，最好做一个安全判断机制(没做)
        //首先split的分割会有一个判断机制，其次，对于是int属性的值放入了string是无法强制转换的，和前面的menu菜单一样的问题，只不过前面解决了，最好重新封装一个函数可以把这个判断机制封装一遍就可以复用，这样从整体来说会比较好一些
        public StudentData(ArrayList list)
        {
            this.student_num = (int)list[0];
            this.name = (string)list[1];
            this.sex = (string)list[2];
            this.age = (int)list[3];
            this.major = (string)list[4];
            this.Place_of_origin = (string)list[5];
            this.Interest = (string)list[6];
        }
        public StudentData(string[] list)
        {
            //这里是正在改的地方，要添加返回到添加界面的位置
            try
            {
                int.Parse(list[0]);
                int.Parse(list[3]);
            }
            catch (Exception)
            {
                Console.WriteLine("学号或年龄不会有字母，别骗我读书少");
                Thread.Sleep(2000);
            }
            this.student_num = int.Parse(list[0]);
            this.name = list[1];
            this.sex = list[2];
            this.age = int.Parse(list[3]);
            this.major = list[4];
            this.Place_of_origin = list[5];
            this.Interest = list[6];
        }
        public StudentData(StudentData data)
        {
            this.student_num = data.student_num;
            this.name = data.name;
            this.sex = data.sex;
            this.age = data.age;
            this.major = data.major;
            this.Place_of_origin = data.Place_of_origin;
            this.Interest = data.Interest; 
        }
        public bool Equals(StudentData student)
        {
            if (this.student_num == student.student_num && this.age == student.age && this.major.Equals(student.major) && this.Place_of_origin.Equals(student.Place_of_origin) && this.sex.Equals(student.sex) && this.name.Equals(student.name) && this.Interest.Equals(student.Interest))
            {
                return true;
            }

            else return false;
        }
    }
}
