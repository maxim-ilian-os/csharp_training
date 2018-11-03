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

            appMan.Contact.IsContactExist();

            List<ContactData> oldContacts = appMan.Contact.GetContactList();
            appMan.Contact.Remove();

            List<ContactData> newContacts = appMan.Contact.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
            //navigator.LogOut();
        }
    }
}