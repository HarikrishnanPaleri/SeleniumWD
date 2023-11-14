using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignments
{
    internal class YahooDiwali
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()

        {
            driver = new ChromeDriver(); // Initialize ChromeDriver
            driver.Url = "https://www.google.com"; //input for google search engine
            driver.Manage().Window.Maximize();//maximising the window
            driver.Navigate().GoToUrl("https://www.yahoo.com");// url to go to the yahoo page
            Thread.Sleep(2000);// inducing a delay of 2 seconds
            driver.Navigate().Back();// method to go back to homepage
            driver.Navigate().GoToUrl("https://www.yahoo.com");
            Thread.Sleep(2000);
            driver.Navigate().Back();


        }

        public void GStest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb")); //finding the searchbox in the google page by using the id for search box
            searchinputtextbox.SendKeys("What's new for Diwali 2023");// inputing the search text
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));//finding the google search button
            gsbutton.Click();// clicking google search
            Thread.Sleep(3000);
            Assert.That(driver.Title.Contains("Diwali 2023")); // checking if the search result title contains if diwali 2023
            Console.WriteLine("Search Test passed"); //displaying result
            driver.Navigate().Refresh();// method for refreshing the page
            
        }
        public void destruct()
        {
            driver.Close();
        }
    }
}
