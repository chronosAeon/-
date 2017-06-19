using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager
{
    //这个模块嵌入的前端代码应该删掉，还未删完
    //Model类作为模块功能部分
    class Model
    {
        public StudentData[] getShowData()
        {
            StudentData[] list = Data.getDataAll();
            return list;
        }
        public void addData(StudentData data)
        {
            Data.addSimulation(data);
        }
        public void addDataNum(StudentData[] list)
        {
            Data.addSimulationNum(list.Length, list);
        }
        public StudentData[] getAllData()
        {
            return Data.getDataAll();
        }
        public void queryByName(String inputname)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i <Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputname.Equals(Data.getDataAll()[i].name))
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputname.Equals(Data.getDataAll()[i].name))
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryBySex(String inputSex)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputSex.Equals(Data.getDataAll()[i].sex))
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputSex.Equals(Data.getDataAll()[i].sex))
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryByInterest(String inputInterest)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputInterest.Equals(Data.getDataAll()[i].Interest))
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputInterest.Equals(Data.getDataAll()[i].Interest))
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryByMajor(String inputMajor)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputMajor.Equals(Data.getDataAll()[i].major))
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputMajor.Equals(Data.getDataAll()[i].major))
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryByPlace(String inputPlace)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputPlace.Equals(Data.getDataAll()[i].Place_of_origin))
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputPlace.Equals(Data.getDataAll()[i].Place_of_origin))
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryByNum(int inputNum)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputNum == Data.getDataAll()[i].student_num)
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputNum == Data.getDataAll()[i].student_num)
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void queryByAge(int inputAge)
        {
            int sum = 0;
            //遍历data数据
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                //根据所选的属性name找到所匹配的项目
                if (inputAge == Data.getDataAll()[i].age)
                {
                    //先找到匹配数
                    sum++;
                }
            }
            //实例化匹配数等大的数组
            StudentData[] arr = new StudentData[sum];
            int index = 0;
            //把所有匹配的数据放入arr数组
            for (int i = 0; i < Data.getDataAll().Length; i++)
            {
                if (inputAge == Data.getDataAll()[i].age)
                {
                    arr[index] = Data.getDataAll()[i];
                    index++;
                }
            }
            Data.setTemp(arr);
        }
        public void sort(StudentData[] data)
        {
            if (data.Length != 0)
            {
                for (int i = 0; i < data.Length - 1; i++)
                {
                    for (int j = 0; j < data.Length - 1; j++)
                    {
                        if (data[j].student_num > data[j + 1].student_num)
                        {
                            StudentData max = new StudentData(data[j]);
                            data[j] = new StudentData(data[j + 1]);
                            data[j + 1] = new StudentData(max);
                        }
                    }
                }
                //为什么明明是引用进来了改了应该就可以了还是要添加这一句才能修改静态数据,感觉下一句可以不要但是，却必须要.
                Data.setSimulation(data);
            }
            else
            {
                Console.WriteLine("没有数据请添加数据");
            }
        }
    }
}
