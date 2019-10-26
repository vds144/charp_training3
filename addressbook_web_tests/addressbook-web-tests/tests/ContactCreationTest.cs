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

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

         
            Assert.AreEqual(oldContact.Count +1, app.Contacts.GetContactsCount());


            List<ContactData> newContact = app.Contacts.GetContactsLists();

            oldContact.Add(contact);

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContact = app.Contacts.GetContactsLists();

            oldContact.Add(contact);

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);

        }


    }
}
