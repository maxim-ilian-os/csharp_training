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
        public static IEnumerable<ContactData> RandomContactDataProvider()
            {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 2; i++)
                {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Middlename = GenerateRandomString(10),
                    Nickname = GenerateRandomString(10),
                    Title = GenerateRandomString(15),
                    Company = GenerateRandomString(15),
                    Address = GenerateRandomString(10) +" , " + GenerateRandomString(10),
                    HomeTel = GenerateRandomString(8),
                    MobileTel = GenerateRandomString(11),
                    E_mail = GenerateRandomString(7) +"@"+ GenerateRandomString(5)+"."+ GenerateRandomString(3),
                    Notes = GenerateRandomString(15)
                });
            }
             return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void HW_RandomContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = appMan.Contact.GetContactList();
            appMan.Contact.Create(contact);
            
            List<ContactData> newContacts = appMan.Contact.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

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
            contact.Bmonth = "March";
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
            contact.Bmonth = "";
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