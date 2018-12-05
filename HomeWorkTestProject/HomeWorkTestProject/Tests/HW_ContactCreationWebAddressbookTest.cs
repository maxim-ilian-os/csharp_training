using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : HW_AuthTestBase
    {
        [Test]
        public void HW_ContactCreatoinTest()
        {
            ContactData contact = new ContactData("Ivan", "Mazepa");
            contact.Middlename = "Stepanovich";
            contact.Nickname = "Kolodynski";
            contact.Title = "Kozak";
            contact.Company = "Zaporozhskaya Siczh";
            contact.Address = "Dnepro, Zaporozhskaya Siczh";
            contact.HomeTel = "5-12-25";
            contact.MobileTel = "5-12-25";
            contact.E_mail = "ataman@paper.org";
            contact.Bday = "20";
            contact.Bmouth = "March";
            contact.Byear = "1639";
            contact.Notes = "He played an important role in the Battle of Poltava";
            
            List<ContactData> oldContact = appMan.Contact.GetContactList();
            appMan.Contact.Create(contact);
            List<ContactData> newContact = appMan.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);            
        }

        [Test]
        public void HW_EmptyContactCreatoinTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.HomeTel = "";
            contact.MobileTel = "";
            contact.E_mail = "";
            contact.Bday = "";
            contact.Bmouth = "";
            contact.Byear = "";
            contact.Notes = "";

            List<ContactData> oldContact = appMan.Contact.GetContactList();
            appMan.Contact.Create(contact);
            List<ContactData> newContact = appMan.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
          //navigator.LogOut();
        }
    }
}