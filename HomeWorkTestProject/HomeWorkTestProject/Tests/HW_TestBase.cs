using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    public class HW_TestBase
    {       
        protected ApplicationManager appMan;
                
        [SetUp]
        public void SetupTest()
        {
            appMan = new ApplicationManager();

            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appMan.Stop();
        }
    }
}