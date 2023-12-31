﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.PageObjects
{
    internal class Product
    {
        IWebDriver driver;
        public Product(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver)); ;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//ul[@class='sizeBox clearfix']//following::a[1]")]
        public IWebElement? SizeClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement? AddToCartClick { get; set; }

        //Act
        public void ClickSize()
        {
            SizeClick?.Click();
        }
        public void ClickAddToCart()
        {
            AddToCartClick?.Click();
        }
        public string GetTitle()
        {
            string titl = driver.Url;
            return titl;
        }
    }
}
