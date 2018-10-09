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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            ReturnToContactsMainPage();
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
            //driver.FindElement(By.CssSelector("#MassCB")).Click();
            DeleteContact();
            ReturnToContactsMainPage();
            //LogOut();
        }
    }
}