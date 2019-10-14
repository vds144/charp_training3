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
	public class ContactHelper : HelperBase
	{		
	
		public ContactHelper(ApplicationManager manager) : base (manager)
		{
		}
		public void SubmitContactCreation()
		{
			driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
		}
		public void FillContactForm(ContactData contact)
		{
			driver.FindElement(By.Name("firstname")).Clear();
			driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
			driver.FindElement(By.Name("middlename")).Click();
			driver.FindElement(By.Name("middlename")).Clear();
			driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
			driver.FindElement(By.Name("lastname")).Click();
			driver.FindElement(By.Name("lastname")).Clear();
			driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
			driver.FindElement(By.Name("nickname")).Click();
			driver.FindElement(By.Name("nickname")).Clear();
			driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
			

		}
		public void InitNewContactCreation()
		{
			driver.FindElement(By.Name("firstname")).Click();
		}
	}
}
