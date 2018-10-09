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
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            OpenGroupPage();
            InitGroupeCreation();
            GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };
            FillOutGroupData(group);
            SubmitGroupCreation();
            ReturnToMainGroupPage();
            //LogOut();
        }
    }
}