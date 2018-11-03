using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    [TestFixture]

    public class HW_GroupModificationTests : HW_AuthTestBase
    {
     [Test]

     public void HW_GroupModificationTest()
        {
            int indx = 0;
            GroupData newData = new GroupData("modified");
            //newData.Gfooter = "new1 footer";
            //newData.Gheader = "new1 header";
            newData.Gfooter = null;
            newData.Gheader = null;

            appMan.Group.IsGroupExist();
            List<GroupData> oldGroups = appMan.Group.GetGroupList();

            appMan.Group.Modify(indx, newData);
            //appMan.Group.Modify(newData);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups[indx].Gname = newData.Gname;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}