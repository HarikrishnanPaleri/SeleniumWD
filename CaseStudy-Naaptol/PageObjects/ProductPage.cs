using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_Naaptol.PageObjects
{
    internal class ProductPage
    {
        IWebDriver? driver = null;
        public ProductPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? searchProduct {  get; set; }

        public SearchedProductList searchProductType(string product)
        {
            searchProduct?.SendKeys(product);
            searchProduct?.SendKeys(Keys.Enter);
            return new SearchedProductList(driver);
        }
    }
}
