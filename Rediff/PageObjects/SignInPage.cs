using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
   
    internal class SignInPage
       
    {
        IWebDriver driver;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id, Using ="login1")]
        public IWebElement?UserNameText { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "remember")]
        public IWebElement? RememberCheckbox { get; set; }

        [FindsBy(How = How.Name, Using = "proceed")]
        public IWebElement? SigninButton { get; set; }

        public void TypeUserName(string un)
        {
            UserNameText?.SendKeys(un);
        }
        public void TypePassword(string pwd)
        {
            UserNameText?.SendKeys(pwd);
        }
        public void ClickRememberMeCheckbox()
        {
            RememberCheckbox?.Click();
        }
        public void ClickSignIn()
        {
            SigninButton?.Click();
        }
    }
}
