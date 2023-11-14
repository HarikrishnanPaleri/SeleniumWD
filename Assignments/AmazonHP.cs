using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class AmazonHP 
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()

        {
           
            driver = new ChromeDriver(); //ChromeDriver initialization
            driver.Url = "https://www.amazon.com/";//Input for amazon url
            driver.Manage().Window.Maximize();// maximising the window

        }
        public void TitleTest()
        {
            //Thread.Sleep(1000);
            //Console.WriteLine("Title" + driver.Title);
            //Assert.That(driver.Title.Contains("Amazon"));
            //Console.WriteLine("Title test passsed");
            Thread.Sleep(2000); // Inducing a delay for page loading
            // string title = driver.Title;
            Console.WriteLine("Title:" + driver.Title); // printing the title
            //  Console.WriteLine(driver.Title);

            //Console.WriteLine("Title Length:" + driver.Title.Length);
            Assert.That(driver.Title.Contains("Amazon")); // checking if the title contains amazon in it
            Console.WriteLine("Title Test Passed"); //printing test result

        }
        public void OrganisationType()

        {
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains(".com"));// checking if the url contains .com in it
            Console.WriteLine("Oraganisation test passed");

        }

        public void Destruct() 
        {
            driver.Close(); // method for closing the tab
        }
    }
}
