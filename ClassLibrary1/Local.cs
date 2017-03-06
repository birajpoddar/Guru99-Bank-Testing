using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;
using OpenQA.Selenium.Support.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace Guru99TestFramework
{
    [TestFixture]
    public class Local
    {
        public IWebDriver driver;
        Screenshot ss;
        bool acceptNextAlert = false;
        By element;

        public Local()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            //driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://demo.guru99.com/v4/");
            //driver.Manage().Window.Maximize();
        }

        [TestCase("mngr68233", "mYdApAs")]
        public void TestLogin(string UserName, string Password)
        {
            /// <summary>
            /// Verifies if the Element is Present
            /// Sets the User Name if the element is present
            /// </summary>
            element= By.Name("uid");
            if (!IsElementPresent(element))            
                Assert.Fail("User ID Text Box doesn't EXIST");
           
            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(UserName);

            /// <summary>
            /// Verifies if the Element is Present
            /// Sets the Password if the element is present
            /// </summary>
            element = By.Name("password");
            if (!IsElementPresent(element))
                Assert.Fail("Password Text Box doesn't EXIST");

            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(Password);

            /// <summary>
            /// Verifies if the Element is Present
            /// Clicks the LOGIN button if the element is present
            /// </summary>
            element = By.Name("btnLogin");
            if (!IsElementPresent(element))
                Assert.Fail("Login Button doesn't EXIST");

            driver.FindElement(element).Click();            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.00);
            
            //driver.SwitchTo().Alert().Dismiss();
            //driver

            /// <summary>
            /// If Alert is present than close it and continue TEST
            /// </summary>
            if (IsAlertPresent())
                CloseAlertAndGetItsText();

            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));

            /// <summary>
            /// Verifies if LOGIN is succesful
            /// </summary>
            element = By.CssSelector("tr.heading3 > td");
            if (!IsElementPresent(element))
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\Developer\Desktop\Selenium C#\ClassLibrary1\Screenshots\Error.png", ScreenshotImageFormat.Png);
                Assert.Fail("Authentication field doesn't EXIST");
            }

            
            Assert.AreEqual("Manger Id : " + UserName, driver.FindElement(element).Text);
        }

        [TearDown]
        public void Exit()
        {
            //if(result.)
            driver.Quit();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = false;
            }
        }

        //private 
    }
}
