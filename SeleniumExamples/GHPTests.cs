using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()

        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void InitializeEdgeDriver()

        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }

        

        public void TitleTest()
        {
            Thread.Sleep(2000);
            // string title = driver.Title;
            Console.WriteLine("Title:" + driver.Title);
          //  Console.WriteLine(driver.Title);

            Console.WriteLine("Title Length:" +driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test Passed");
        }
        public void  PageSourceandURLTest()
        {/*
            Console.WriteLine("Page Source :"+driver.PageSource);
            Console.WriteLine("Page Source Length :"+driver.PageSource.Length);
            Console.WriteLine(driver.Url); */
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("PSURL Test - Passed");
        }
        public void GStest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(5000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("GS Test - Passed");
        }
        public void GmailLinkTest()
        {

            driver.Navigate().Back();
            // driver.FindElement(By.LinkText("Gmail")).Click();
            driver.FindElement(By.PartialLinkText("ma")).Click();
            Thread.Sleep(5000);
            //string title = driver.Title;
            Assert.That(driver.Title.Contains("Gmail"));
           // Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail Link Test - Passed");

        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            // driver.FindElement(By.LinkText("Gmail")).Click();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(5000);
            //string title = driver.Title;
              Assert.That(driver.Title.Contains("Images"));
            //Assert.That(driver.Url.Contains("images"));
            Console.WriteLine("Images Link Test - Passed");
            

        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
           string loc= driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(5000);
           
            Assert.That(loc.Equals("India"));
          
            Console.WriteLine("Localization Test - Passed");

        }
        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("a[href*='youtube.com']")).Click();
            Thread.Sleep(4000);
            Assert.That(driver.Title.Contains("YouTube"));
        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}