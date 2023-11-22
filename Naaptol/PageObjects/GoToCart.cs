using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class GoToCart
    {
        IWebDriver? driver = null;
        public GoToCart(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Black-2.50']")]
        public IWebElement? Productdetail { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? GoCart { get; set; }



        public void SelectSize()
        {
            Productdetail.Click();
        }

        public void GoCartButtonClick()
        {
            GoCart.Click();
        }


    }
}
