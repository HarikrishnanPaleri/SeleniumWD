using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BCHP
    {
        IWebDriver driver;
        public BCHP(IWebDriver? driver)
        {
            this.driver =driver?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How =How.Id, Using ="search")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }
        [FindsBy(How =How.XPath, Using ="//a[text() ='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAnAccountLink { get; set; }
        [FindsBy(How =How.Id, Using ="firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "popup-email_address")]
        private IWebElement? EmailInput { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }
       
        
        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? SignUpButton { get; set; }

        public void ClickCreateAnAccountLink()
        {
            CreateAnAccountLink?.Click();
        }

        public void Signup(string firstName, string lastName, string email, string pwd,string conpwd, string mbno)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            FirstNameInput?.SendKeys(firstName);
            LastNameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);

            ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordInput?.SendKeys(pwd);
            ConfirmPasswordInput?.SendKeys(conpwd);

            ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberInput?.SendKeys(mbno);
            Thread.Sleep(1000);
            SignUpButton?.Click();

        
        }
        static void ScrollIntoView(IWebDriver driver,IWebElement element)

        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public SearchResultsPage TypeSearchInput(string searchtext)
        {
            if(SearchInput== null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchtext);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
