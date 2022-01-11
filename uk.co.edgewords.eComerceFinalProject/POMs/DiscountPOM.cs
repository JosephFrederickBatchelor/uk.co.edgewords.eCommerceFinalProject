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
    internal class DiscountPOM
    {
        private IWebDriver driver;

        public DiscountPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement CostElement => driver.FindElement(By.XPath("//tr[@class='cart-subtotal']/td/span[@class='woocommerce-Price-amount amount']"));
        public IWebElement DiscountElement => driver.FindElement(By.XPath("//tr[@class='cart-discount coupon-edgewords']/td/span[@class='woocommerce-Price-amount amount']"));
        public IWebElement ShippingElement => driver.FindElement(By.XPath("//tr[@class='shipping']/td/span[@class='woocommerce-Price-amount amount']"));
        public IWebElement OverallElement => driver.FindElement(By.XPath("//tr[@class='order-total']/td/strong/span[@class='woocommerce-Price-amount amount']"));

        //get the relevant information and return it to the step definitions to be asserted
        public decimal CostCheck(decimal Cost)
        {
            string StrCost = CostElement.Text;
            StrCost = StrCost.Replace("£", "");
            Cost = Convert.ToDecimal(StrCost);
            Console.WriteLine(Cost);
            return Cost;
        }
        public decimal DiscountCheck(decimal Discount)
        {
            string StrDiscount = DiscountElement.Text;
            StrDiscount = StrDiscount.Replace("£", "");
            Discount = Convert.ToDecimal(StrDiscount);
            Console.WriteLine(Discount);
            return Discount;
        }
        public decimal ShippingCheck(decimal ShippingCost)
        {
            string StrShippingCost = ShippingElement.Text;
            StrShippingCost = StrShippingCost.Replace("£", "");
            ShippingCost = Convert.ToDecimal(StrShippingCost);
            Console.WriteLine(ShippingCost);
            return ShippingCost;
        }
        public decimal OverallCheck(decimal OverallCost)
        {
            string StrOverallCost = OverallElement.Text;
            StrOverallCost = StrOverallCost.Replace("£", "");
            OverallCost = Convert.ToDecimal(StrOverallCost);
            Console.WriteLine(OverallCost);
            return OverallCost;
        }
    }
}
