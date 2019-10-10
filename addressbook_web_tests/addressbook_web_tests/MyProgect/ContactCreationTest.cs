using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{

    [TestFixture]
    public class ContactCreationTests : TestBase
    {


        [Test]
        public void ContactCreationTest()
        {
            
            app.Auth.Login(new AccountData("admin", "secret"));
            ContactData group = new ContactData("Firstname");
            group.Middlename = "Middlename";
            group.Lastname = "Lastname";
            app.Contact
                .AddnewAccount(group)
                .CreateAccount()
              // app.Groups.ReturnToGroupsPage();
                .Logout();
        }
    }
}
