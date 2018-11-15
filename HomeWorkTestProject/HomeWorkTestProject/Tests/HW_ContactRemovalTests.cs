using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : HW_AuthTestBase
    {
        [Test]
        public void HW_ContactRemovalTest()
        {

            if (!appMan.Contact.IsContactTrue())
            {
                ContactData contact = new ContactData("Empty", "Contact");
                appMan.Contact.Create(contact); 
            }

                List<ContactData> oldContacts = appMan.Contact.GetContactList();
                appMan.Contact.Remove();
                List<ContactData> newContacts = appMan.Contact.GetContactList();
                oldContacts.RemoveAt(0);
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts.Count, newContacts.Count);
                Assert.AreEqual(oldContacts, newContacts);
        }
    }
}