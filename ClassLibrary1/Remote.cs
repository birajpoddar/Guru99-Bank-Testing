using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace Guru99TestFramework
{
    [TestFixture("Firefox")]
    [TestFixture("Chrome")]
    [TestFixture("Andoid")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Remote : Local
    {
        DesiredCapabilities capability;
        public Remote(string Browser):base()
        {
            switch(Browser)
            {
                case "Firefox":
                    capability = DesiredCapabilities.Firefox();
                    break;
                case "Chrome":
                    capability = DesiredCapabilities.Chrome();
                    break;
                case "Android":
                    capability = DesiredCapabilities.Android();
                    break;

            }
            //capability = DesiredCapabilities.Firefox();
            capability.SetCapability("browserstack.user", "birajpoddar1");
            capability.SetCapability("browserstack.key", "3fCuqYBKJUo4t2Jgc5ep");
            capability.SetCapability("browserstack.debug", "true");
            driver = new RemoteWebDriver(
                new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
        }

        //[TestCase("mngr68233", "mYdApAs")]
        //public void TestLogin(string UserName, string Password)
            

    }
}
