using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.eCommerceFinalProject.Helpers
{
    internal class Wait
    {
        public static void WaitForElementPresent(IWebDriver driver, By TheElement)
        {
            //wait until the element can be seen on the webpage
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(TheElement).Displayed);
        }
    }
}
