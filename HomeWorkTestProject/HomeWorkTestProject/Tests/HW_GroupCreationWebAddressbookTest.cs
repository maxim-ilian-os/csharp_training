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
            GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };
            
            appMan.Group.Create(group);
            //appMan.Navigator.LogOut();
        }

        [Test]
        public void HW_EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Gheader = "",
                Gfooter = ""
            };
            appMan.Group.Create(group);
           //appMan.Navigator.LogOut();
        }
    }
}