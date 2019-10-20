using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTest : AuthTestBase
    {
 
	[Test]
	public void ContactCreationTests()
		{
			
			
			ContactData contact = new ContactData("Firstname");
			contact.Middlename = "Middlename";
			contact.Lastname = "Lastname";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void EmptyContactCreationTests()
        {

            
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

        }

        [Test]
        public void BadNameContactCreationTests()
        {


            ContactData contact = new ContactData("a'a");
            contact.Middlename = "";
            contact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

        }
    }
}
