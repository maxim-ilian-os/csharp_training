using System;
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
            appMan.Contact.Remove();
            //navigator.LogOut();
        }
    }
}