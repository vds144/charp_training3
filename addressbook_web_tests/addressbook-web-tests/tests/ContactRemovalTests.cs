using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {


            

            ContactData contact = new ContactData("Fistname", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            

            

            List<ContactData> oldContact = ContactData.GetAll();


            ContactData toBeRemoved = ContactData.GetAll().First();

            ContactData item = oldContact.Find(c => c.Id == toBeRemoved.Id);

            app.Contacts.Remove(toBeRemoved);

            

            List<ContactData> newContactNames = ContactData.GetAll();


            int i = oldContact.IndexOf(item);
            oldContact.RemoveAt(i);



            foreach (ContactData newContact in newContactNames)
            {
                Assert.AreNotEqual(newContact.Id, toBeRemoved.Id);
            }

        }
    }
}