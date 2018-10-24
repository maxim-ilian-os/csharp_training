using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    [TestFixture]

    public class HW_LoginTests : HW_TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            //prepare
            appMan.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            appMan.Auth.Login(account);

            //verification
            Assert.IsTrue(appMan.Auth.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            //prepare
            appMan.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "123");
            appMan.Auth.Login(account);

            //verification
            Assert.IsFalse(appMan.Auth.IsLoggedIn(account));
        }
    }
}
