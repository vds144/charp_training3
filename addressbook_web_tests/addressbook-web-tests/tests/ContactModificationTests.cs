using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]

	public class ContactModificationTests : AuthTestBase
    {
		[Test]
		public void ContactModificationTest()
		{
            

            ContactData contact = new ContactData("Firstname", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.IsModifyContact();

            ContactData newData = new ContactData("Firstname", "qwe");

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Modify(0,newData);

            List<ContactData> newContact = app.Contacts.GetContactsLists();

            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].Lastname = newData.Lastname;


            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
	}
}