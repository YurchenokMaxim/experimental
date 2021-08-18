using System;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static WebDriverManager.DriverManager GetDriver(string nameOfBrowser)
        {
            if (driver == null)
            {
                switch (nameOfBrowser.ToLower())
                {
                    case "chrome":
                        {
                            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                            ChromeDriver driver = new ChromeDriver();
                            break;
                        }
                    case "firefox":
                        {
                            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                            FirefoxDriver driver = new FirefoxDriver();
                            break;
                        }
                    default:
                        {
                            throw new Exception("Wrong name of browser");
                        }
                }
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
                driver.Manage().Window.Maximize();
            }
            return (WebDriverManager.DriverManager)driver;
        }

        public static void DriverQuit()
        {
            driver.Quit();
            driver = null;
        }
    }
}
