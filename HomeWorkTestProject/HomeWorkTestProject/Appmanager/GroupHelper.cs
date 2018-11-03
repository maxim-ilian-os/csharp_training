using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGroupeCreation();
            FillOutGroupData(group);
            SubmitGroupCreation();
            ReturnToMainGroupPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.OpenGroupPage();
          //IsGroupExist();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper Remove()
        {
            manager.Navigator.OpenGroupPage();
          //IsGroupExist();
            SelectGroup();
            RemoveGroup();
            ReturnToMainGroupPage();
            return this;
        }

        public GroupHelper Remove(int indx)
        {
            manager.Navigator.OpenGroupPage();
          //IsGroupExist();
            SelectGroup(indx);
            RemoveGroup();
            ReturnToMainGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {

          //driver.FindElement(By.XPath("(//input[@name='delete'])[1]")).Click();
          //driver.FindElement(By.XPath("(//input[@name='delete'])")).Click();
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        
     // public GroupHelper Modify(int v, GroupData newData)
        public GroupHelper Modify(GroupData newData)
        {
            manager.Navigator.OpenGroupPage();
          //IsGroupExist();
            SelectGroup();
            InitGroupeModification();
            FillOutGroupData(newData);
            SubmitGroupModification();
            ReturnToMainGroupPage();
            return this;
        }

        public GroupHelper Modify(int indx, GroupData newData)
        {
            manager.Navigator.OpenGroupPage();
          //IsGroupExist();
            SelectGroup(indx);
            InitGroupeModification();
            FillOutGroupData(newData);
            SubmitGroupModification();
            ReturnToMainGroupPage();
            return this;
        }

        public GroupHelper IsGroupExist()
        {
            manager.Navigator.OpenGroupPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                InitGroupeCreation();
                GroupData group = new GroupData("Empty Group");
                FillOutGroupData(group);
                SubmitGroupCreation();
                
            }
            return this;
        }

        public bool IsGroupTrue()
        {
            manager.Navigator.OpenGroupPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return true;

            }
            return false;
        }

        public GroupHelper InitGroupeCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

            public GroupHelper FillOutGroupData(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Gname);
            Type(By.Name("group_header"), group.Gheader);
            Type(By.Name("group_footer"), group.Gfooter);
            return this;
        }

       public GroupHelper SelectGroup()
        {
          //driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int indx)
        {
            int count = driver.FindElements(By.XPath("//input[@name='selected[]']")).Count;
            if (indx <= 0)
            {
                driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            }
            else
            {
                if (count == 1)
                {
                    driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (indx + 1) + "]")).Click();
                }
            }
                 return this;
        }

        public GroupHelper ReturnToMainGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupeModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}