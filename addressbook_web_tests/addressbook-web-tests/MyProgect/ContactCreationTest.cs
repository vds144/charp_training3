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
			
			app.Navigator.GoToAddNewPage();
			app.Contacts.InitNewContactCreation();
			ContactData contact = new ContactData("Firstname");
			contact.Middlename = "Middlename";
			contact.Lastname = "Lastname";
			app.Contacts.FillContactForm(contact);
			app.Contacts.SubmitContactCreation();
			app.Navigator.ReturnToContactPage();
		}
	}
}
