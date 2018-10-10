using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : HW_TestBase
    {
        [Test]
        public void HW_ContactRemovalTest()
        {
            appMan.Navigator.OpenHomePage();
            appMan.Auth.Login(new AccountData("admin", "secret"));
            appMan.Navigator.ReturnToMainContactsPage();
            appMan.Contact.SelectContact();
            appMan.Contact.DeleteContact();
            appMan.Navigator.ReturnToMainContactsPage();
            //navigator.LogOut();
        }
    }
}