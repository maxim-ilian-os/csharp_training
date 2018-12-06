using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : HW_AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
                {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Gheader = GenerateRandomString(100),
                    Gfooter = GenerateRandomString(100)
                });
                }
            return groups;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void HW_GroupCreationTest(GroupData group)
        {
            /*GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };*/

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        /*[Test]
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
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }*/

        [Test]
        public void HW_BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a")
            {
                Gheader = "",
                Gfooter = ""
            };

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}