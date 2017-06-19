using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager
{
    static class administator
    {
        public static bool isAdmin = false;
        static private List<user> user = new List<user>();
        static public void Add (user use)
        {
            user.Add(use);
        }
        static public bool search(user use)
        {
            if(user.Contains(use))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public bool success(long acc, string pas)
        {
            for(int i =0;i<user.Count;i++)
            {
                if (user[i].equl(acc, pas))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
