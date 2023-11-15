using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()

        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
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
            Thread.Sleep(1000);
            // string title = driver.Title;
            Console.WriteLine("Title:" + driver.Title);
            //  Console.WriteLine(driver.Title);

            Console.WriteLine("Title Length:" + driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title Test Passed");
        }
        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Test Passed");
        }

        public void SearchProductTest() 
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title)) && (driver.Url.Contains("mobiles")));
            Console.WriteLine("Search test passed");

        }
        public void ReloadHomePage()
        {
            
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);

        }
        public void TodaysDealTest()
        {
          IWebElement todaysdeals =  driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null) 
            {
                throw new NoSuchElementException("Today's Deals link not present");
            }
            todaysdeals.Click();
            Thread.Sleep(4000);
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            
            Console.WriteLine("Today's Deal's Test Passed");
         
        }
        public void SignInAccListTest()
        {
           IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello, Signin is not present");
            }
           IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (hellosignin == null)
            {
                throw new NoSuchElementException("Hello, Account & Lists is not present");
            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello, Sign in is present-Pass");
            Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Account & Lists is present - Pass");

        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");//search for mobile phones
            //Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();//submit button
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();//clicking checkbox
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);//checking if box is selected 
            Console.WriteLine("Motorola is selected");
           
            
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"p_89/BLU\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/BLU\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Blu is selected");

        }
        public void SortBySelectTest()
        {
            IWebElement sortby = driver.FindElement(By.ClassName("a-native-dropdown.a-declarative"));
            SelectElement sortbyselect = (SelectElement)sortby;
            sortbyselect.SelectByValue("1");
            Thread.Sleep(5000);
            Console.WriteLine(sortbyselect.SelectedOption);
        }



           // a-native-dropdown a-declarative

        public void Destruct()
        {
            driver.Close();
        }
    }
}
