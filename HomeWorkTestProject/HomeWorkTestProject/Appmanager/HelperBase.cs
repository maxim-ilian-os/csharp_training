using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HW_WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}