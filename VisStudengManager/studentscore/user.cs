using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager
{
    class user
    {
        private long Account;
        private String password;
        public user(long account,String password)
        {
            this.Account = account;
            this.password = password;
        }
        public void changePassword(String password)
        {
            this.password = password;
        }
        public bool equl (long acc,String pas)
        {
            if (this.Account == acc && this.password == pas)
            {
                return true;
            }
            else
                return false;
        }
    }
}
