using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    [TestFixture]

    public class HW_ContactModificationTests : HW_AuthTestBase
    {
        [Test]

        public void HW_ContactModificationTest()
        {
            ContactData newCont = new ContactData("First name", "Last name");

            appMan.Contact.Modify(newCont);
        }
    }
}
