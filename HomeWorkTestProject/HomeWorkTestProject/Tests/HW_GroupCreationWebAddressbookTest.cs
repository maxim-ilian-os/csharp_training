using NUnit.Framework;
using System.Collections.Generic;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : HW_AuthTestBase
    {
        [Test]
        public void HW_GroupCreationTest()
        {
            GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void HW_EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Gheader = "",
                Gfooter = ""
            };

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}