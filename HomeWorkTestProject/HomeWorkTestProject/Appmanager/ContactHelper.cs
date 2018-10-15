using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Modify(ContactData newCont)
        {

            ReturnToMainContactsPage();
            SelectContactModify();
            FillOutContactData(newCont);
            SubmitContactModify();
            
            return this;
        }

        public ContactHelper Create(ContactData contact)          
        {
            //manager.Navigator.OpenHomePage();

            InitContactCreation();
            FillOutContactData(contact);
            SubmitContactCreation();
            ReturnToMainContactsPage();
            return this;
        }

        
        public ContactHelper Remove()
        {
            ReturnToMainContactsPage();
            SelectContact();
            DeleteContact();
            ReturnToMainContactsPage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillOutContactData(ContactData contact)
        {

            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Hometel);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobiletel);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.E_mail);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bday + "\"" + "]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bmouth + "\"" + "]")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }

        public ContactHelper SelectContactTDelete(int contaciID)
        {
            driver.FindElement(By.Id("\"" + contaciID + "\"")).Click();
            acceptNextAlert = true;
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
            //driver.FindElement(By.CssSelector("#MassCB")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper ReturnToMainContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            return this;
        }

        public ContactHelper SelectContactModify()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            //iver.FindElement(By.XPath("(//input[@name='edit'])[1]")).Click();

            return this;
        }

        string CloseAlertAndGetItsText()
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