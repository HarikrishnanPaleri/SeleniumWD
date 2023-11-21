using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    [TestFixture]
    internal class LinkedinTests : CoreCodes
    {
        [Test]
        [Author("Harikrishnan", "hari444.paleri@gmail.com")]
        [Description("check for valid login")]
        [Category("Regression Testing")]
        public void LoginTest()
        {
            // driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(3);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            // IWebElement emailInput = wait.Until(dri =>dri.FindElement(By.Id("session_key")));
            // IWebElement passwordInput = wait.Until(dri=>dri.FindElement(By.Id("session_password")));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement emailInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));
            emailInput.SendKeys("adithyan@kattumukk.com");
            passwordInput.SendKeys("12345");
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        //[Test]
        //[Author("Harikrishnan", "hari444.paleri@gmail.com")]
        //[Description("check for invalid login")]
        //[Category("Smoke Testing")]

        //public void Login2TestWithInvalidCredentials()
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element Not Found";
        //    IWebElement emailInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));
        //    emailInput.SendKeys("adithyan@kattumukk.com");
        //    passwordInput.SendKeys("12345");
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);
        //    Thread.Sleep(1000);
        //    emailInput.SendKeys("xyc@kattumukk.com");
        //    passwordInput.SendKeys("56779");
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);
        //    Thread.Sleep(1000);
        //    emailInput.SendKeys("iaoosj@sskks.com");
        //    passwordInput.SendKeys("87892");
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        // Thread.Sleep(1000);
        // }
        void ClearForm(IWebElement element)
        {
            element.Clear();


        }
        //[Test]
        //[Author("aaa", "aaa@gmail.com")]
        //[Description("check for invalid login")]
        //[Category("Regression Testing")]
        //[TestCase("adithyan@kattumukk.com","12345")]
        //[TestCase("xyc@kattumukk.com", "56779")]
        //[TestCase("iaoosj@sskks.com", "87892")]
        //public void Login3TestWithInvalidCredentials(string email, string password)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element Not Found";
        //    IWebElement emailInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));
        //    emailInput.SendKeys(email);
        //    passwordInput.SendKeys(password);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);
        //}
        [Test]
        [Author("aaa", "aaa@gmail.com")]
        [Description("check for invalid login")]
        [Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void Login3TestWithInvalidCredentials(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement emailInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            TakeScreenshot();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type ='submit']")));
            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//button[@type ='submit']"))) ;
            ClearForm(emailInput);
            ClearForm(passwordInput);
        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {

                new object[] { "abc@xyz.com", "12345" },
                new object[] { "def@xyz.com", "5678" }
            };
        }
      
    }
}