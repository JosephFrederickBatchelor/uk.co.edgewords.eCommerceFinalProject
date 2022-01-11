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
    internal class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement FirstName => driver.FindElement(By.Id("billing_first_name"));
        IWebElement LastName => driver.FindElement(By.Id("billing_last_name"));
        IWebElement Country => driver.FindElement(By.Id("select2-billing_country-container"));
        IWebElement CountryFeild => driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));
        IWebElement Address => driver.FindElement(By.Id("billing_address_1"));
        IWebElement City => driver.FindElement(By.Id("billing_city"));
        IWebElement Postcode => driver.FindElement(By.Id("billing_postcode"));
        IWebElement Phone => driver.FindElement(By.Id("billing_phone"));

        public CheckoutPage Checkout()
        {
            //clear and wite the relevant information into the input fields
            FirstName.Clear();
            FirstName.SendKeys("Joseph");

            LastName.Clear();
            LastName.SendKeys("Batchelor");

            Country.Click();
            CountryFeild.Clear();
            CountryFeild.SendKeys("United Kingdom");
            CountryFeild.SendKeys(Keys.Enter);

            Address.Clear();
            Address.SendKeys("54 Made Up Street");

            City.Clear();
            City.SendKeys("Neverland");

            Postcode.Clear();
            Postcode.SendKeys("WV16 4BB");

            Phone.Clear();
            Phone.SendKeys("0333 939 8884");
            return this;
        }

    }
}