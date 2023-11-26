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
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);        
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test Passed");
        }

       // [Ignore("other")]
        [Test]
        [Order(11)]
        public void GStest()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "//InputData.xlsx";
            Console.WriteLine(excelFilePath);
            List<ExcelData>excelDataList =ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"Text : {excelData.SearchText}");
                IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
                searchinputtextbox.SendKeys(excelData.SearchText);
                Thread.Sleep(5000);
                IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
                gsbutton.Click();
                Assert.That(driver.Title,Is.EqualTo(excelData.SearchText+ "-Google Search"));
                Console.WriteLine("GS Test - Passed");
            }
        }
        [Ignore("other")]
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
