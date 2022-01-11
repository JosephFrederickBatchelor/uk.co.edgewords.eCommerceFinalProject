using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using uk.co.edgewords.eCommerceFinalProject.Helpers;

namespace uk.co.edgewords.eCommerceFinalProject.POMs
{
    internal class ItemSelectionPOM
    {
        private IWebDriver driver;

        public ItemSelectionPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement BeaniePurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=27']"));
        public IWebElement BeltPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=28']"));
        public IWebElement CapPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=29']"));
        public IWebElement HoodiePurchse => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=34']"));
        public IWebElement HoodieWithlogoPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=31']"));
        public IWebElement HoodieWithPocketPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=32']"));
        public IWebElement HoodieWithZipperPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=33']"));
        public IWebElement LongSleeveTeePurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=35']"));
        public IWebElement PoloPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=36']"));
        public IWebElement SunglassesPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=30']"));
        public IWebElement TshirtPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=37']"));
        public IWebElement VneckPurchase => driver.FindElement(By.XPath("//a[@href='/demo-site/shop/?add-to-cart=38']"));
        public IWebElement ViewCart => driver.FindElement(By.LinkText("View cart"));

        public ItemSelectionPOM ItemSelection(string Item)
        {
            switch (Item)
            {
                case "Beanie":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=27']"));
                    BeaniePurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;

                case "Belt":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=28']"));
                    BeltPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;

                case "Cap":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=29']"));
                    CapPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;

                case "Hoodie":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=34']"));
                    HoodiePurchse.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;

                case "Hoodie with Logo":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=31']"));
                    HoodieWithlogoPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Hoodie with Pocket":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=32']"));
                    HoodieWithPocketPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Hoodie with Zipper":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=33']"));
                    HoodieWithZipperPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Long Sleeve Tee":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=35']"));
                    LongSleeveTeePurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Polo":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=36']"));
                    PoloPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Sunglasses":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=30']"));
                    SunglassesPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Tshirt":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=37']"));
                    TshirtPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;
                
                case "Vneck Tshirt":
                    Wait.WaitForElementPresent(driver, By.XPath("//a[@href='/demo-site/shop/?add-to-cart=38']"));
                    VneckPurchase.Click();
                    Wait.WaitForElementPresent(driver, By.LinkText("View cart"));
                    ViewCart.Click();
                    break;

                default:
                    break;
            }
            return this;
        }
    }
}
