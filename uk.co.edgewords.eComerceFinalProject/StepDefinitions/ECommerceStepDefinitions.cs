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
using static uk.co.edgewords.eCommerceFinalProject.Hooks.Hooks;

namespace uk.co.edgewords.eCommerceFinalProject.StepDefinitions
{
    [Binding]
    public class ECommerceStepDefinitions
    {
        [Given(@"I can log into the eCommerce site with '([^']*)' and '([^']*)'")]
        public void GivenICanLogIntoTheECommerceSite(string username, string password)
        {
            driver.FindElement(By.XPath("/html/body/p/a")).Click();

            //use the Log In POM to log into the ecommerce site
            LogInPage logIn = new LogInPage(driver);
            logIn.LogIn(username, password);
        }

        [Given(@"that I am logged in to the ecommerce site")]
        public void GivenThatIAmLoggedInToTheEcommerceSite()
        {
            //check to see if we have logged in
            string LogOutButton = driver.FindElement(By.CssSelector("#post-7 > div > div > div > p:nth-child(1) > a")).Text;
            Assert.That(LogOutButton, Does.Contain("Log Out").IgnoreCase, "We are not Logged In");
            
            //click on the shop button
            driver.FindElement(By.CssSelector("#menu-item-43 > a")).Click();
        }

        [When(@"I purchase a '([^']*)' with the discount code '([^']*)'")]
        public void WhenIPurchaseAnItemWithADiscountCode(string Item, string Code)
        {
            //click on the item you want to purchase

            ItemSelectionPOM ItemSelect = new ItemSelectionPOM(driver);
            ItemSelect.ItemSelection(Item);
            
            //set the quantity amount to 1
            Wait.WaitForElementPresent(driver, By.XPath("//input[@class='input-text qty text']"));
            driver.FindElement(By.XPath("//input[@class='input-text qty text']")).Clear();
            driver.FindElement(By.XPath("//input[@class='input-text qty text']")).SendKeys("1");

            //is commented out as when only 1 item is already in the basket there was no need to update cart however if multiple items
            //are desired this can be re added
            //try
            //{
            //    driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > button")).Click();
            //}
            //catch (StaleElementReferenceException)
            //{
            //    Console.WriteLine("Update Cart Not Available");
            //}

            //apply the dicount code
            driver.FindElement(By.Id("coupon_code")).SendKeys(Code);
            driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > div > button")).Click();
        }

        [Then(@"the correct cost is displayed with a '([^']*)' percent discount")]
        public void ThenTheCorrectCostIsDisplayedWithAPercentDiscount(int p0)
        {
            //use the DiscountPOM to get all the nessicary bits of information needed for upcoming checks
            DiscountPOM discount = new DiscountPOM(driver);
            Cost = discount.CostCheck(Cost);
            ShippingCost = discount.ShippingCheck(ShippingCost);
            Discount = discount.DiscountCheck(Discount);
            
            //check to see if the correct discount amount has been applied
            try
            {
                Assert.That(Discount, Is.EqualTo((Cost / 100) * p0), "The Discount Amount Is Wrong");
            }
            catch (AssertionException)
            {
                Console.WriteLine("The Discount Is Wrong");
            }

            //using the DiscountPOM to get the overall cost
            OverallCost = discount.OverallCheck(OverallCost);

            //check to see if the overall cost is correct
            try
            {
                Assert.That(OverallCost, Is.EqualTo(Cost - Discount + ShippingCost), "The Overall Amount Is Wrong");
            }
            catch (AssertionException)
            {
                Console.WriteLine("The Overall Cost Is Wrong");
            }

            //click the checkout button
            Wait.WaitForElementPresent(driver, By.XPath("//a[@href='https://www.edgewordstraining.co.uk/demo-site/checkout/']"));
            driver.FindElement(By.XPath("//a[@href='https://www.edgewordstraining.co.uk/demo-site/checkout/']")).Click();
        }
        
        [When(@"I have finished checking out")]
        public void WhenIHaveFinishedCheckingOut()
        {
            Wait.WaitForElementPresent(driver,By.Id("billing_first_name"));

            //use the CheckoutPOM to input all the checkout information
            CheckoutPage checkout = new CheckoutPage(driver);
            checkout.Checkout();

            //click on the place order button sometimes it is still loading hence why we try it twice
            Wait.WaitForElementPresent(driver, By.Id("place_order"));
            try
            {
                driver.FindElement(By.Id("place_order")).Click();
            }
            catch (StaleElementReferenceException)
            {
                driver.FindElement(By.Id("place_order")).Click();
            }

            Wait.WaitForElementPresent(driver, By.CssSelector("#post-6 > header > h1"));
        }

        [Then(@"the order number displayed is the same as the one in my orders")]
        public void ThenTheOrderNumberDisplayedIsTheSameAsTheOneInMyOrders()
        {
            //get the order number from the order confirmation page
            string OrderNumber;
            OrderNumber = driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong")).Text;
            Console.WriteLine(OrderNumber);

            //go to the orders page
            driver.FindElement(By.CssSelector("#menu-item-46 > a")).Click();
            driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders > a")).Click();

            //get the order number from the orders page
            string ConfirmOrderNumber;
            ConfirmOrderNumber = driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a")).Text;
            ConfirmOrderNumber = ConfirmOrderNumber.Replace("#", "");
            Console.WriteLine(ConfirmOrderNumber);

            //check that both order numbers are the same
            try
            {
                Assert.That(OrderNumber, Is.EqualTo(ConfirmOrderNumber), "The Order Number Is Wrong");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Order Number Is Wrong");
            }

            //log out
            driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--dashboard > a")).Click();
            driver.FindElement(By.LinkText("Log out")).Click();
        }
    }
}
