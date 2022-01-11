using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using uk.co.edgewords.eCommerceFinalProject.POMs;
using uk.co.edgewords.eCommerceFinalProject.Helpers;

namespace uk.co.edgewords.eCommerceFinalProject.Hooks
{
    [Binding]
    internal class Hooks
    {
        public static IWebDriver driver;
        public static decimal Cost;
        public static decimal OverallCost;
        public static decimal ShippingCost;
        public static decimal Discount;
        [BeforeScenario]
        public void Setup()
        {
            //open a chrome browser and go to the emcommerce site
            driver = new ChromeDriver();
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void CleanUp()
        {
            //close the browser
            driver.Quit();
        }
    }
}
