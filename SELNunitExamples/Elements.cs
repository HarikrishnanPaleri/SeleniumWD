using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    [TestFixture]
    internal class Elements:CoreCodes
    {
       
        [Test]
        [Ignore("other")]
        public void TestFormElementsMethod() 
        {
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);
            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Doe");
            Thread.Sleep(2000);
            /*
            List<IWebElement> expandcollapse = driver.FindElements(By.XPath("//span[text()='Check Box']//parent::li")).ToList();
                foreach(var item in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);
            */
            IWebElement emailFileld = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailFileld.SendKeys("John.Doe@gmail.com");
            Thread.Sleep(2000);
            IWebElement gendeRadio = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            gendeRadio.Click();
            Thread.Sleep(4000);
            IWebElement mobileNumberField = driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("1234567890");
            Thread.Sleep(2000);
            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);
            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);

            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("2023");
            Thread.Sleep(2000);

            IWebElement dobDay = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--020']"));
            dobDay.Click();
            Thread.Sleep(2000);

            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            subjectsField.SendKeys("Biology");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement hobbiesCheck = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-1']//following::label"));
            hobbiesCheck.Click();
            Thread.Sleep(2000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Pictures\\Camera Roll\\Capture.png");
            


            Thread.Sleep(2000);

            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("Tvm");
            Thread.Sleep(2000);
            

        }
        [Test]
        [Ignore("other")]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window handle" +parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(int i =0;i<3;i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }

            List<string>lstWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach(var handle in lstWindow)
            {
                Console.WriteLine("switching to window" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("navogating to google");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
                lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is" + alertText);
            Thread.Sleep(2000);
            simpleAlert.Accept();
            

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(2000);
            element.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert is"+confirmationAlert.Text);
            Thread.Sleep(2000);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(2000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText = promptAlert.Text;
            Console.WriteLine("Alert text is" + alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(2000);
            promptAlert.Accept();



        }
    }
}
;