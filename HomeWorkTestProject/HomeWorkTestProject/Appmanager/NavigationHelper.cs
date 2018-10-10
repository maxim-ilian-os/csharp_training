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
            //driver.Navigate().GoToUrl(manager.BaseURL + "addressbook/edit.php");
            driver.Navigate().GoToUrl(baseURL + "addressbook/edit.php");
        }

        public void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        

       public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}