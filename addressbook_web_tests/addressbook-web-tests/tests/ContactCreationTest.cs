using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : AuthTestBase
    {
 
	[Test]
	public void ContactCreationTest()
		{

            

            ContactData contact = new ContactData("Firstname", "Test");

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames.Add(contact);

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames.Add(contact);

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);

        }


    }
}
