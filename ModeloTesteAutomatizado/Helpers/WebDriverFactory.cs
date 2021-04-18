using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace ModeloTesteAutomatizado.Helpers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(WebDriverEnum webDriverEnum, string urlRemoteWebDriver = null)
        {
            string path = @"WebDrivers\";

            switch (webDriverEnum)
            {
                case WebDriverEnum.Chrome:
                    return new ChromeDriver(path, new ChromeOptions());

                case WebDriverEnum.HeadlessChrome:

                    ChromeOptions opt = new ChromeOptions();
                    opt.AddArgument("--headless");
                    return  new ChromeDriver(opt);

                case WebDriverEnum.RemoteWebDriverChrome:
                    var remoteWebDrive = new RemoteWebDriver(new Uri(urlRemoteWebDriver), new ChromeOptions());
                    return remoteWebDrive;

                case WebDriverEnum.Firefox:
                    return new FirefoxDriver(path, new FirefoxOptions());

                case WebDriverEnum.HeadlessFirefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--headless");
                    return new FirefoxDriver(path, firefoxOptions);

                default:
                    throw new Exception("Invalid WebDriverEnum.");
            }
        }
    }
}
