using BunnyCart.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchTests:CoreCodes
    {
        [Test]
        [TestCase("Water")]
        public void SearchProductAndAddToCart(string searchtext)
        {
            BCHP bchp = new(driver);
            var searchrespage = bchp?.TypeSearchInput(searchtext);
            Assert.That(searchtext.Contains(searchrespage?.GetFirstProductLink()));
            var productpage = searchrespage?.ClickFirstProductLink();
            Assert.That(searchtext.Equals(productpage?.GetProductTitleLabel()));
            productpage?.GetIncQtyLink();
            productpage?.ClickAddToCartButton();
            //
            Thread.Sleep(3000);


        }
    }
}
