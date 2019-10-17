using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class HelperBase
	{
		protected IWebDriver driver;
		protected ApplicationManager manager;

		public HelperBase (ApplicationManager manager)
		{
			this.manager = manager;
			driver = manager.Driver;
		}

        public void Type(By Locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(Locator).Clear();
                driver.FindElement(Locator).SendKeys(text);
            }


        }

        public void Types(By Locators, string Firstname)
        {
            if (Firstname != null)
            {
                driver.FindElement(Locators).Clear();
                driver.FindElement(Locators).SendKeys(Firstname);
            }



        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}