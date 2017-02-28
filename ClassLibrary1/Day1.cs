using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99TestFrameworkDay1
{
    [TestFixture]
    public class Day1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://demo.guru99.com/v4/");
            driver.Manage().Window.Maximize();
        }

        [TestCase("mngr68233", "mYdApAs")]
        public void TestLogin(string UserName, string Pass)
        {

        }

        [TearDown]
        public void Exit()
        {
            driver.Quit();
        }
    }
}
