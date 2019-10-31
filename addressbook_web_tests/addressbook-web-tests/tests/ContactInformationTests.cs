using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFormTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFormEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void GetContactInformationFromCard()
        {
            ContactData fromCard = app.Contacts.GetContactInformationFromCard(0);
            ContactData fromForm = app.Contacts.GetContactInformationFormEditForm(0);
            Assert.AreEqual(fromCard.AllData, fromForm.AllData);
        }
    }
}
