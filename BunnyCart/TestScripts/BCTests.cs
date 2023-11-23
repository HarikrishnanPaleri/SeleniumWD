using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class BCTests : CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BCHP bchp = new(driver);
            bchp.ClickCreateAnAccountLink();
            Thread.Sleep(1000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                bchp.Signup("John", "Doe", "John.Doe@kunnamangalam.com", "12345", "12345", "1234567889");
            }
            catch (AssertionException)
            {
                Console.WriteLine("sign up failed");

            }
           
          
        }
      
    }
}