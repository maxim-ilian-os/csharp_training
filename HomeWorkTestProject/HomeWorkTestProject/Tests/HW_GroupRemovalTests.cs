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
            int indx = 0;

            if (!appMan.Group.IsGroupTrue())
            {
                GroupData group = new GroupData("Empty group");
                appMan.Group.Create(group);
            }
            
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Remove(indx);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.RemoveAt(indx);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroups[indx].Id);
            }
        }
    }
}