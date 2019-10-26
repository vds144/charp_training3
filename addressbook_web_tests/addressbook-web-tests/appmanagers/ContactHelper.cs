using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
	public class ContactHelper : HelperBase
	{
        public bool acceptNextAlert { get; private set; }

        public ContactHelper(ApplicationManager manager) : base (manager)
		{
		}


        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsLists()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                List<IWebElement> contacts = new List<IWebElement>();

                ICollection<IWebElement> records = driver.FindElements(By.Name("entry"));

                foreach (IWebElement record in records)
                {
                    contacts = record.FindElements((By.TagName("td"))).ToList();
                    contactCache.Add(new ContactData(contacts[2].Text, contacts[1].Text)
                    {
                        Id = record.FindElement(By.Name("selected[]")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactsCount()
        {
           return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper Remove(int i, ContactData newData)
        {
            manager.Navigator.GoToContactPage();

            SelectContact(i + 2);
            acceptNextAlert = true;
            DeleteContact();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.FindElement(By.CssSelector("div.msgbox"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            ReturnToContactPage();
            return this;
        }


        public ContactHelper Create(ContactData contact)

        {
            
            manager.Navigator.GoToAddNewPage();


            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }



        public ContactHelper Modify(int i, ContactData newData)
        {
            manager.Navigator.GoToContactPage();

            SelectContact(i + 2);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public void IsModifyContact()
        {
            if (IsElementPresent(By.ClassName("center")))
            {
                return;
            }
            ContactData newData = new ContactData("123","456");
            Create(new ContactData("qwe","asd"));
        }



        public ContactHelper SelectContact(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + i + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public bool IsContactsExist()
        {
            return IsElementPresent(By.XPath("//img[@alt='Edit']"));

        }

        public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
		}
		public ContactHelper FillContactForm(ContactData contact)
        {

            Types(By.Name("firstname"), contact.Firstname);
            Types(By.Name("middlename"), contact.Middlename);
            Types(By.Name("lastname"), contact.Lastname);


            return this;



        }

        public ContactHelper InitNewContactCreation()
		{
			driver.FindElement(By.Name("firstname")).Click();
            return this;
		}
        private string CloseAlertAndGetItsText()
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
