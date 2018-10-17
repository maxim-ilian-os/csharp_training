using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    [SetUpFixture]
    public class HW_TestSuiteFixture
    {
        
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager appMan = ApplicationManager.GetInstance();

            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin", "secret"));

        }
        
        /*[TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }*/

    }

}
