using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : HW_TestBase
    {
        [Test]
        public void HW_GrroupRemovalTest()
        {
            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin", "secret"));
            appMan.Navigator.OpenGroupPage();
            appMan.Group.SelectGroup();
            appMan.Group.RemoveGroup();
            appMan.Navigator.ReturnToMainGroupPage();
            //appMan.Navigator.LogOut();
        }
    }
}