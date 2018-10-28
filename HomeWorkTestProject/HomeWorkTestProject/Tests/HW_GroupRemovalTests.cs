using System;
using System.Collections.Generic;
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
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            //appMan.Group.Remove();
            appMan.Group.Remove(0);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}