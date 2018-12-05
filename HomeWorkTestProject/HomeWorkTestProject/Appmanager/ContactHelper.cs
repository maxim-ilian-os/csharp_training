using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert = true;
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Modify(ContactData newCont)
        {
            //IsContactExist();
            SelectContactModify();
            FillOutContactData(newCont);
            SubmitContactModify();
            contactCache = null;
            return this;
        }

        public ContactData GetContactInformationFromTable(int indx)
        {
            ReturnToMainContactsPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[indx]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }
        
       
        public ContactData GetContactInformationFromDetails(int indx)
        {
            ReturnToMainContactsPage();
            InitContactDetails(indx);

            string textData = driver.FindElement(By.XPath(@"//div[@id='content']")).Text;
            System.Diagnostics.Debug.WriteLine("Debug Information --> textData  = " + textData);
            string[] splittedAllData = textData.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);

            string[] fullNameAndAddress = splittedAllData[0].Split(new[] { "\r\n" }, StringSplitOptions.None);
            string fullName = fullNameAndAddress[0];
            string address = (fullNameAndAddress.Length > 1) ? fullNameAndAddress[4] : "";

            //string allTel = splittedAllData.Length > 1 ? GetAllTel(splittedAllData[1]) : "";
            string allTel = splittedAllData.Length > 1 ? GetTel(splittedAllData[1]) : "";
            string[] fio  = fullName.Split(new[] { ' ' }, StringSplitOptions.None);
            string firsname = fio[0];
            string lastname = fio[2];

            return new ContactData(firsname, lastname)
            {
                FullName = fullName,
                Address = address,
                AllPhones = allTel
            };
        }

        public ContactData GetContactInformationFromEditForm(int indx)
        {
            ReturnToMainContactsPage();
            InitContactModification(indx);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomeTel = homePhone,
                MobileTel = mobilePhone,
                WorkTel = workPhone,
                E_mail = email,
                E_mail2 = email2,
                E_mail3 = email3
            }; 
        }

        public void InitContactModification(int indx)
        {
            driver.FindElements(By.Name("entry"))[indx]
            .FindElements(By.TagName("td"))[7]
            .FindElement(By.TagName("a")).Click();
        }

        private void InitContactDetails(int indx)
        {
            driver.FindElements(By.Name("entry"))[indx]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper Create(ContactData contact)          
        {
            InitContactCreation();
            FillOutContactData(contact);
            SubmitContactCreation();
            ReturnToMainContactsPage();
            contactCache = null;
            return this;
        }

        
        public ContactHelper Remove()
        {
            // IsContactExist();
            ReturnToMainContactsPage();
            SelectContact();
            DeleteContact();
            contactCache = null;
            //ReturnToMainContactsPage();
            return this;
        }

        public List<ContactData> GetContactList()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));

                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.CssSelector("td"));

                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                    //System.Diagnostics.Debug.WriteLine("Debug Information --> cells[2].Text = " + cells[2].Text + " cells[1].Text = " + cells[1].Text );
                }
            }
            return new List<ContactData>(contactCache);
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
            Type(By.Name("home"), contact.HomeTel);
            Type(By.Name("mobile"), contact.MobileTel);
            Type(By.Name("email"), contact.E_mail);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bday + "\"" + "]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.CssSelector("option[value=" + "\"" + contact.Bmouth + "\"" + "]")).Click();
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("notes"), contact.Notes);
            contactCache = null;
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
            contactCache = null;
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

        public bool IsContactTrue()
        {
            ReturnToMainContactsPage();
            if (IsElementPresent(By.CssSelector("img[alt=\"Edit\"]")))
            {
                return true;
            }
            return false;
        }

        public ContactHelper IsContactExist()
        {
            ReturnToMainContactsPage();
            if (!IsElementPresent(By.CssSelector("img[alt=\"Edit\"]")))
            {
                InitContactCreation();
                ContactData contact = new ContactData("Ivan", "Mazepa");
                FillOutContactData(contact);
                SubmitContactCreation();
                ReturnToMainContactsPage();
            }
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

        public int GetNumberOfResults()
        {
            string text=  driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

       
        private String GetTel(string telFromDetails)
        {
            
                if (telFromDetails == null || telFromDetails == "")
                {
                    return "";
                }
            //telFromDetails.Split(new[] { "\r\n" })
            string[] tels = telFromDetails.Split(new[] { "\r\n" }, StringSplitOptions.None);
            string tel1 = Regex.Replace(tels[0], "[ HM:-]", "");
            string tel2 = Regex.Replace(tels[1], "[ HM:-]", "");
            return tel1 + "\r\n" + tel2;
        }
    }
}     