using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]

	public class ContactModificationTests : ContactTestBase
    {
		[Test]
		public void ContactModificationTest()
		{
            

            ContactData contact = new ContactData("Firstname", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            

            ContactData newData = new ContactData("Firstname", "qwe");

            List<ContactData> oldContact = ContactData.GetAll();


            ContactData toBeModified = ContactData.GetAll().First();
            
            ContactData item = oldContact.Find(c => c.Id == toBeModified.Id);
                                 
            app.Contacts.ModifyContact(toBeModified, newData);



            List<ContactData> newContact = ContactData.GetAll();


            int i = oldContact.IndexOf(item);
            oldContact[i].Firstname = newData.Firstname;
            oldContact[i].Lastname = newData.Lastname;


            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
	}
}