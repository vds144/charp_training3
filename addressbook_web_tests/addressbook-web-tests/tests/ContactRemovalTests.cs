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


            

            ContactData contact = new ContactData("Fistname", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.IsModifyContact();

            ContactData newData = new ContactData("Firstname", "qwe");

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Remove(0, newData);

            List<ContactData> newContact = app.Contacts.GetContactsLists();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);

        }
    }
}