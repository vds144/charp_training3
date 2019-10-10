using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        
        public ContactHelper(ApplicationManager manager)
              : base(manager)
        {
        }

        public ContactHelper GoToGroupsPage()
             
        {

            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public ContactHelper Logout()
        {
            // Logout
            driver.FindElement(By.LinkText("Logout")).Click();
        return this;

    }

        public ContactHelper CreateAccount()

        {
            // Create Account
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper AddnewAccount(ContactData group)
        {
            // Add new Account
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(group.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(group.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(group.Lastname);
            return this;
        }
    }
}
