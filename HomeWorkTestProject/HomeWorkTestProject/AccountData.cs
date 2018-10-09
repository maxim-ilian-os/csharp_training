using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            set
            {
                username = value;
            }
            get
            {
                return username;
            }
        }

        public string Password
        {
            set
            {
                password = value;
            }

            get
            {
                return password;
            }
        }
    }
}
