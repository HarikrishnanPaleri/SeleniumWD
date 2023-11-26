using OpenQA.Selenium.DevTools.V117.DOM;
using CaseStudy_Naaptol.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using OpenQA.Selenium;

namespace Naaptol.TestScripts
{
    [TestFixture]
    internal class UserManagementTest :CoreCodes
    {
        //        [Test]
        //        [Order(0)]
        //        [Category("smoke test")]
        //        public void CreateAccountLinkTesr()
        //        {
        //           var homepage = new RediffHomePage(driver);
        //            driver.Navigate().GoToUrl("https://www.rediff.com/");
        //            homepage.CreateAccountLinkClick();
        //            Assert.That(driver.Url.Contains("register"));
        //;        }
        //        [Test]
        //        [Order(1)]
        //        [Category("smoke test")]
        //        public void SignInLinkTesr()
        //        {
        //            var homepage = new RediffHomePage(driver);
        //            driver.Navigate().GoToUrl("https://www.rediff.com/");
        //            homepage.SignInLinkClick();
        //            Assert.That(driver.Url.Contains("login"));

        //        }
        //[Test,Order(1),Category("Regression Test")]
        //public void CreateAccountTest()
        //{
        //    var homepage = new RediffHomePage(driver);
        //    if(!driver.Url.Equals("https://www.rediff.com/"))
        //    {
        //        driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    }

        //    var createAccountPage =   homepage.CreateAccountClick();
        //    Thread.Sleep(2000);
        //    createAccountPage.FullNameType("hcsajh");
        //    createAccountPage.RediffmailType("hvsxhab@gmail.com");
        //    createAccountPage.CheckAvailabilityBtnClick();
        //    Thread.Sleep(2000);
        //    createAccountPage.CreateMyAccountBtnClick();

        //}
        [Test, Order(1), Category("Regression Test")]
        public void SearchTest()
        {
            var homepage = new ProductPage(driver);

          var productsearchp =  homepage.searchProductType("eyewear");
          var SelectProd = productsearchp.SelectSearchedProductClick();
            Thread.Sleep(5000);
            List<string> lstWindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lstWindow[1]);
            SelectProd.SelectSize();
            SelectProd.GoCartButtonClick();
            Thread.Sleep(2000);
            string url = productsearchp.GetTitle();
            Assert.That(url, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'LRG4)')]")).GetAttribute("href")));



        }

        }
    }
    

