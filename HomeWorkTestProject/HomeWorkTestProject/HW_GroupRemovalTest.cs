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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupPage();
            SelectGroup();
            RemoveGroup();
            ReturnToMainGroupPage();
            //LogOut();
        }        
    }
}