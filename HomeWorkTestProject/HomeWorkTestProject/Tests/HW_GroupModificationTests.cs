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
            GroupData newData = new GroupData("new1");
            newData.Gfooter = "new1 footer";
            newData.Gheader = "new1 header";

            appMan.Group.Modify(0, newData);
            //appMan.Group.Modify(newData);
        }
    }
}