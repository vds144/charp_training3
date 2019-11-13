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



        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();

            ClearGroupFilter();
            SelectContactall(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }



        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }


        private void SelectContactall(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }


        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }



        public ContactHelper SelectContact(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + i + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactPage();
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

        public ContactHelper Remove(int i)
        {
            manager.Navigator.GoToContactPage();

            SelectContact(i);
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

            SelectContact(i);
            InitContactModification(i + 2);
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
            ContactData newData = new ContactData("123", "456");
            Create(new ContactData("Firstname ", "lastname"));
        }





        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int i)
        {
            driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id="
               + id + "']")).Click();
            return this;
        }


        public ContactHelper OpenContactCard(int i)
        {
            driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
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
        public ContactData GetContactInformationFormTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
                        
            string allEmails = cells[4].Text;
           

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
               

            };


        }

        public ContactData GetContactInformationFormEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;

           Match m = new Regex(@"\d+").Match(text);
           return Int32.Parse(m.Value);
        }


        public ContactData GetContactInformationFromCard(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactCard(index);
            string allData = driver.FindElement(By.Id("content")).Text;
            return new ContactData(allData);
        }
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToAdd(contact.Id);
            DeleteContact();
            driver.SwitchTo().Alert().Accept();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }


    }
}