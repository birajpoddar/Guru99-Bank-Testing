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
    [TestFixture("IE")]
    [TestFixture("Firefox")]
    [TestFixture("Chrome")]
    [TestFixture("Android")]
    [TestFixture("iPhone")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Remote : Local
    {
        DesiredCapabilities capability;
        public Remote(string Browser):base()
        {
            switch(Browser)
            {
                case "IE":
                    capability = DesiredCapabilities.InternetExplorer();
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "10");
                    capability.SetCapability("browser", "IE");
                    capability.SetCapability("browser_version", "11.0");
                    break;
                case "Firefox":
                    capability = DesiredCapabilities.Firefox();
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "10");
                    capability.SetCapability("browser", "Firefox");
                    capability.SetCapability("browser_version", "52.0 beta");
                    break;
                case "Chrome":
                    capability = DesiredCapabilities.Chrome();
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "10");
                    capability.SetCapability("browser", "Chrome");
                    capability.SetCapability("browser_version", "56.0");
                    break;
                case "Android":
                    capability = DesiredCapabilities.Android();
                    capability.SetCapability("browserName", "android");
                    capability.SetCapability("platform", "ANDROID");
                    capability.SetCapability("device", "Google Nexus 5");
                    break;
                case "iPhone":
                    capability = DesiredCapabilities.IPhone();
                    capability.SetCapability("browserName", "iPhone");
                    capability.SetCapability("platform", "MAC");
                    capability.SetCapability("device", "iPhone 6S Plus");
                    break;
            }
            //capability = DesiredCapabilities.Firefox();
            capability.SetCapability("server", "hub-cloud.browserstack.com");
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
