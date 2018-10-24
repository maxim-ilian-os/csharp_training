using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class HW_AuthTestBase : HW_TestBase
    {

        [SetUp]
        public void SetupLogin()
        {
            appMan.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
