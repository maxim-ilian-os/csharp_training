using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{

    [TestFixture]
    public class HW_ContactInformationTest : HW_AuthTestBase    
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = appMan.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = appMan.Contact.GetContactInformationFromEditForm(0);

            //verific
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }

        [TestCase]
        public void TestContactDetails()
        {
            ContactData fromTable = appMan.Contact.GetContactInformationFromTable(0);
            ContactData fromDetails = appMan.Contact.GetContactInformationFromDetails(0);
            
            //verific
            Assert.AreEqual(fromDetails, fromTable);
            Assert.AreEqual(fromDetails.Address, fromTable.Address);
            Assert.AreEqual(fromDetails.AllPhones, fromTable.AllPhones);
           }
    }
}
