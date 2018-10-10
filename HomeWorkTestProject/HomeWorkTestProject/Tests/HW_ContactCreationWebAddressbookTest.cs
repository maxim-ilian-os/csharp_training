using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : HW_TestBase
    {
        [Test]
        public void HW_ContactCreatoinTest()
        {
            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin", "secret"));
            appMan.Contact.SubmitContactCreation();
            ContactData contact = new ContactData("Ivan", "Mazepa");
            contact.Middlename = "Stepanovich";
            contact.Nickname = "Kolodynski";
            contact.Title = "Kozak";
            contact.Company = "Zaporozhskaya Siczh";
            contact.Address = "Dnepro, Zaporozhskaya Siczh";
            contact.Hometel = "5-12-25";
            contact.Mobiletel = "5-12-25";
            contact.E_mail = "ataman@paper.org";
            contact.Bday = "20";
            contact.Bmouth = "March";
            contact.Byear = "1639";
            contact.Notes = "He played an important role in the Battle of Poltava";
            appMan.Contact.FillOutContactData(contact);
            appMan.Contact.SubmitContactCreation();
            appMan.Navigator.ReturnToMainContactsPage();
            //navigator.LogOut();
        }
    }
}