using OpenQA.Selenium.DevTools.V117.DOM;
using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
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
        [Test, Order(2), Category("Regression Test")]
        public void SignInTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }

            var signInPage = homepage.SignInLinkClick();
            Thread.Sleep(2000);
            signInPage.TypeUserName("hagsgvhx");
            signInPage.TypePassword("hasjx");
            signInPage.ClickRememberMeCheckbox();
            Assert.False(signInPage?.RememberCheckbox?.Selected);
            Thread.Sleep(3000);
            signInPage?.ClickSignIn();
            Assert.True(true);
        }

        }
    }
    

