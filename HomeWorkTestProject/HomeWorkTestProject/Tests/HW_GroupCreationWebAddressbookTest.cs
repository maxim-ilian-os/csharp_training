using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : HW_TestBase
    {
        [Test]
        public void HW_GroupCreationTest()
        {
            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin","secret"));
            appMan.Navigator.OpenGroupPage();
            appMan.Group.InitGroupeCreation();
            GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };
            appMan.Group.FillOutGroupData(group);
            appMan.Group.SubmitGroupCreation();
            appMan.Navigator.ReturnToMainGroupPage();
            //appMan.Navigator.LogOut();
        }
    }
}