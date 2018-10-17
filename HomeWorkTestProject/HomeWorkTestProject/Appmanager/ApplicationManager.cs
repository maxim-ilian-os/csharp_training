using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> appMan = new ThreadLocal<ApplicationManager>();

        private  ApplicationManager()
        {
            //ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver();
            baseURL = "http://localhost/";
            //verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if(! appMan.IsValueCreated)
            {
                appMan.Value = new ApplicationManager();
            }
            return appMan.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public string BaseURL { get => baseURL; }

        //public LoginHelper Auth => loginHelper;

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator => navigator;

        public GroupHelper Group => groupHelper;

        public ContactHelper Contact => contactHelper;

       
    }
}