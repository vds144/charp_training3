﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {

        [TearDown]

        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = app.Contacts.GetContactsLists();
                List<ContactData> fromDB = ContactData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}