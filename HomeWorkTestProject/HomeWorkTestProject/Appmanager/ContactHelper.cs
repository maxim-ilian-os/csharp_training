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


            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Hometel);
            Type(By.Name("mobile"), contact.Mobiletel);
            Type(By.Name("email"), contact.E_mail);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bday + "\"" + "]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bmouth + "\"" + "]")).Click();
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("notes"), contact.Notes);
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