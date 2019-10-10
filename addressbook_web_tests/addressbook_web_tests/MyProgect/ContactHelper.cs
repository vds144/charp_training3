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
        private ApplicationManager applicationManager;

        public ContactHelper(IWebDriver driver) 
            : base(driver)
        {
         
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        // public ContactHelper(ApplicationManager applicationManager);

        public IWebDriver driver { get; private set; }

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

        internal ContactHelper AddnewAccount(object group)
        {
            throw new NotImplementedException();
        }

        public ContactHelper CreateAccount()
        {
            // Create Account
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public static implicit operator ContactHelper(LoginHelper v)
        {
            throw new NotImplementedException();
        }
    }
}
