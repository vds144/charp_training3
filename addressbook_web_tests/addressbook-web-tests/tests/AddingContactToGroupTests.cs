﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll()[0];

            for (int i = 0; i < oldList.Count(); i++)
            {
                if (oldList[i].Id.Equals(contact.Id))
                {
                    contact = new ContactData("aaa", " sss");
                    app.Contacts.Create(contact);
                    contact.Id = app.Contacts.GetContactId();
                }
            }
            app.Contacts.AddContactToGroup(contact, group);
            oldList.Add(contact);
            List<ContactData> newList = group.GetContacts();
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestRemoveContactFromGroup()
        {
       

            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("aaa", "sss", "ddd"));
            }
            List<GroupData> groups = GroupData.GetAll();
            for (int i = 0; i < groups.Count(); i++)
            {
                GroupData group = groups[i];
               

                if (ContactData.GetAll().Count == 0)

                {
                    app.Contacts.Create(new ContactData("aaa", "sss"));
                    ContactData createdContact = ContactData.GetAll().First();
                    app.Contacts.AddContactToGroup(createdContact, group);
                }
               

                if (group.GetContacts().Count() == 0)
                {
                    app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
                }
                List<ContactData> oldList = group.GetContacts();
                ContactData contactToRemove = oldList[0];
                app.Contacts.RemoveContactFromGroup(contactToRemove, group);
                List<ContactData> newList = group.GetContacts();
                oldList.Remove(contactToRemove);
                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            }
        }
    }
}
