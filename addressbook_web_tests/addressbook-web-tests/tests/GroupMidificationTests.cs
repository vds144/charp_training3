using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
   public class GroupMidificationTests : TestBase
    {

        [Test]
        public void GroupMidificationTest()
        {

            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";

            app.Groups.Mofify(1, newData);
        }
    }
}
