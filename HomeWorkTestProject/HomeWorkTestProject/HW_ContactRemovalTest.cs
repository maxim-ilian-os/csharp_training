﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace HW_WebAddressbookTests
 {
        [TestFixture]
        public class ContactRemovalTests
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"I:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void HW_ContactRemovalTest()
            {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            //SelectContactTDelete(38);
            //driver.FindElement .find_element_by_css_selector("#div2 > input[type='checkbox']").click()
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
            //driver.FindElement(By.CssSelector("#MassCB")).Click();
            DeleteContact();
            //ReturnToContactsMainPage();
        }

        private void ReturnToContactsMainPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }

        private void SelectContactTDelete(int contaciID)
        {
            driver.FindElement(By.Id("\""+ contaciID + "\"")).Click();
            //driver.FindElement(By.Id("37")).Click();
            acceptNextAlert = true;
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/edit.php");
            //driver.FindElement(By.LinkText("home")).Click();
            //
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.LinkText("home")).Click();            
        }

        private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
}