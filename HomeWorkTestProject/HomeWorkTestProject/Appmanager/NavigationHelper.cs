using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
           this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }
            //driver.Navigate().GoToUrl(manager.BaseURL + "addressbook/edit.php");
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void OpenGroupPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php" && IsElementPresent(By.Name("New group")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click(); 
        }

        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}