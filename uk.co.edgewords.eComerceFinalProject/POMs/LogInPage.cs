using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace uk.co.edgewords.eCommerceFinalProject.POMs
{
    public class LogInPage
    {
        private IWebDriver driver;

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Username => driver.FindElement(By.Id("username"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement Log_In => driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));

        public LogInPage LogIn(string username, string password) 
        {
            //log in to the ecommerce site with the username and password from the feature file
            Username.SendKeys(username);
            Password.SendKeys(password);
            Log_In.Click();
            return this;
        }

    }
}
