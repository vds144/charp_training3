﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Modify(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(0);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;

        }

        public void IsModifyGroup()
        {
            if (IsElementPresent(By.ClassName("group")))
            {
                return;
            }
            Create(new GroupData("qqq"));
        }

        private List<GroupData> groupCache = null;

        public GroupHelper ModifyById(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.CssSelector("span.group"));
        }


        public GroupHelper CreateIfNotExist()
        {
            manager.Navigator.GoToGroupsPage();

            if (IsGroupExist() == false)
            {
                GroupData data = new GroupData("aaa")
                {
                    Header = "bbb",
                    Footer = "ccc"
                };

                Create(data);
            }

            return this;
        }


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i ++)
                {
                    if (i<shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                 
                }
            }

            return new List<GroupData>(groupCache);
        }
    

        public int GetGroupCount()
        {
          return  driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            
                SelectGroup(0); 
                RemoveGroup();
                ReturnToGroupsPage();
            return this;
        }



        public GroupHelper Create(GroupData group)
		{
			manager.Navigator.GoToGroupsPage();

			InitGroupCreation();
			FillGroupForm(group);
			SubmitGroupCreation();
			ReturnToGroupsPage();
			return this;
		}



		public GroupHelper InitGroupCreation()
		{
			driver.FindElement(By.Name("new")).Click();
			return this;
		}

		public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Header);

            return this;
        }



        public GroupHelper SubmitGroupCreation()
		{
			driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
			return this;
		}
		public GroupHelper ReturnToGroupsPage()
		{
			driver.FindElement(By.LinkText("group page")).Click();
			return this;
		}

		public GroupHelper SelectGroup(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
			return this;
		}

        public GroupHelper SelectGroup(String Id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value= '"+Id+"'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
		{
			driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
		}
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
