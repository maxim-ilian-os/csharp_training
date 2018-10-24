using NUnit.Framework;
using OpenQA.Selenium;
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
            newCont.Middlename = "Stepanovich";
            newCont.Nickname = "Kolodynski";
            newCont.Title = "Kozak";
            newCont.Company = "Zaporozhskaya Siczh";
            newCont.Address = "Dnepro, Zaporozhskaya Siczh";
            newCont.Hometel = "5-12-25";
            newCont.Mobiletel = "5-12-25";
            newCont.E_mail = "ataman@paper.org";
            newCont.Bday = "20";
            newCont.Bmouth = "March";
            newCont.Byear = "1639";
            newCont.Notes = "He played an important role in the Battle of Poltava";

            appMan.Contact.Modify(newCont);
        }
    }
}
