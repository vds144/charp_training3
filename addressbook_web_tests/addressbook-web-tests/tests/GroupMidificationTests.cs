using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
   public class GroupMidificationTests : AuthTestBase
    {

        [Test]
        public void GroupMidificationTest()
        {
            app.Groups.IsModifyGroup();

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

           
            app.Groups.Mofify(0, newData);
        }
    }
}
