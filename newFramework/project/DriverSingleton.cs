using System;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NLog;

namespace Task10
{
    public class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static WebDriverManager.DriverManager GetDriver(string nameOfBrowser)
        {
            if (driver == null)
            {
                switch (nameOfBrowser.ToLower())
                {
                    case "chrome":
                        {
                            logger.Info("The Chrome installed");
                            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                            ChromeDriver driver = new ChromeDriver();
                            break;
                        }
                    case "firefox":
                        {
                            logger.Info("The Firefox installed");
                            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                            FirefoxDriver driver = new FirefoxDriver();
                            break;
                        }
                    default:
                        {
                            logger.Info("The Chrome installed");
                            Console.WriteLine("The default browser is Chrome");
                            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                            ChromeDriver driver = new ChromeDriver();
                            break;
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
