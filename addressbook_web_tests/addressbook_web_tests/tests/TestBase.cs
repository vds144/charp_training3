using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;



        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();

            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));

            ContactData group = new ContactData("Firstname");
            group.Middlename = "Middlename";
            group.Lastname = "Lastname";
                       
            //contactHelper = new LoginHelper(driver);
        }

        [TearDown]
        protected void TeardownTest()
        {

            app.Stop();
        }
    }
}
