using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    [TestFixture]
    internal class GHPtests: CoreCodes
    {
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);        
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test Passed");
        }
        [Test]
        [Order(11)]
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
        [Test]
        public void AllLinksStatusTest() 
        {
         List<IWebElement>allLinks = driver.FindElements(By.TagName("a")).ToList();
         foreach(var link in allLinks) 
            {
               string url    = link.GetAttribute("href");
                if(url ==null)
                {
                    Console.WriteLine("Url is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                        Console.WriteLine(url + "is working");
                    else
                        Console.WriteLine(url + "is not working");
                }
            }
        }

    }
}
