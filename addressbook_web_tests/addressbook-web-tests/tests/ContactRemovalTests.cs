using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {


            app.Contacts.IsModifyContact();

            ContactData contact = new ContactData("Fistname", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            

           ContactData newData = new ContactData("Firstname", "qwe");

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Remove(0);

            List<ContactData> newContact = app.Contacts.GetContactsLists();

            ContactData toBeRemoved = oldContact[0];

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);


            foreach (ContactData contacts in newContact)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }

        }
    }
}