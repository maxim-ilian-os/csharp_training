using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : HW_AuthTestBase
    {
        [Test]
        public void HW_GroupRemovalTest()
        {
            //appMan.Navigator.OpenGroupPage();
            appMan.Group.Remove();
            //appMan.Navigator.LogOut();
        }
    }
}