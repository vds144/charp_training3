using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTest : TestBase
    {
 
	[Test]
	public void ContactCreationTests()
		{
			
			
			ContactData contact = new ContactData("Firstname");
			contact.Middlename = "Middlename";
			contact.Lastname = "Lastname";

            
            app.Contacts.Create(contact);

		}

        [Test]
        public void EmptyContactCreationTests()
        {

            
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";

            app.Contacts.Create(contact);

        }
    }
}
