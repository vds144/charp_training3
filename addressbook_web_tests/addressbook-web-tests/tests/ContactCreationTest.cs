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

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100)
                });
            }
            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
	public void ContactCreationTest(ContactData contact)
		{

            

            List<ContactData> oldContact = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

         
            Assert.AreEqual(oldContact.Count +1, app.Contacts.GetContactsCount());


            List<ContactData> newContact = app.Contacts.GetContactsLists();

            oldContact.Add(contact);

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }


    }
}
