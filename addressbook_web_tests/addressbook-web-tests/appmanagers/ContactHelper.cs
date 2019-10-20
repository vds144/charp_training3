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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToContactPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));

            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
             return contacts;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.GoToContactPage();

            SelectContact(1);
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
            manager.Navigator.ReturnToContactPage();
            return this;
        }



        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToContactPage();

            SelectContact(1);
            InitContactModification();
           FillContactForm(newData);
            SubmitContactModification();
          //ReturnToContactPage();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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
            return this;
        }

        public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
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
