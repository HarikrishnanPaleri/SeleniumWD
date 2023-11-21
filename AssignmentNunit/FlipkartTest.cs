
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Drawing;

namespace AssignmentNunit
{
    internal class FlipkartTest:CoreCodes
    {
        [Test]
        [Order(1)]
        [Author("Harikrishnan", "hari444.paleri@gmail.com")]
        [Description("check for search")]
        public void SearchTest()
        {
            
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement searchinput = fluentWait.Until(dri => dri.FindElement(By.XPath("//input[@type='text']")));
            searchinput.SendKeys("laptops");
            searchinput.SendKeys(Keys.Enter);
            Assert.That(driver.Title.Contains("Laptops"));
            fluentWait.Until(dri => dri.FindElement(By.XPath("//div[@class='_2kHMtA'][1]"))).Click();
            Thread.Sleep(4000);
            List<string> lstWindow = driver.WindowHandles.ToList();
             driver.SwitchTo().Window(lstWindow[1]);
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [Test]
        [Order(2)]
        public void AddToCart()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement element = driver.FindElement(By.ClassName("_352bdz"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", element);
           
            IWebElement cart = fluentWait.Until(dri => dri.FindElement(By.XPath("//button[@class ='_2KpZ6l _2U9uOA _3v1-ww']")));
            cart.Click();
          

            Thread.Sleep(5000);
            IWebElement gotocart = fluentWait.Until(dri => dri.FindElement(By.ClassName("_3SkBxJ")));
            gotocart.Click();
            Thread.Sleep(2000);

            IWebElement placeorder = fluentWait.Until(dri => dri.FindElement(By.XPath("//button[@class ='_2KpZ6l _2ObVJD _3AWRsL']")));
            placeorder.Click();
            Thread.Sleep(2000);

            IWebElement emailInput = fluentWait.Until(dri => dri.FindElement(By.XPath("//input[@class='_2IX_2- _17N0em']")));
            emailInput.SendKeys("hari444.paleri@gmail.com");
            Thread.Sleep(3000);
            IWebElement continuebutton = fluentWait.Until(dri => dri.FindElement(By.XPath("//button[@class ='_2KpZ6l _20xBvF _3AWRsL']")));
            continuebutton.Click();
            Thread.Sleep(5000);


        }
    }
}
