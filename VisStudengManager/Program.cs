using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisStudengManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //程序开始激活数据库
            upiData.upiDa();
            //用于重置upi数据库
           // upiData.upiDa1();

            aaodata.aaoDa();
            //用于重置aao数据库
           //  aaodata.aaoDa1();

            Data.readAllDataFromDb();
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Admin());
        }
    }
}
