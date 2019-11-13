using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
   public class GroupMidificationTests : GroupTestBase
    {

        [Test]
        public void GroupMidificationTest()
        {
                    
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.IsModifyGroup();
            
            List<GroupData> oldGroups = GroupData.GetAll();
            ;
            GroupData oldData = oldGroups[0];

            GroupData toBeModified = oldGroups[0];
            app.Groups.ModifyById(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

           foreach (GroupData group in newGroups)

            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
