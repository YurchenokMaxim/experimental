using OpenQA.Selenium;

namespace Framework
{
    class Steps
    {
        public string Work()
        {
            IWebDriver driver = (IWebDriver)DriverSingleton.GetDriver("chrome");
            driver.Navigate().GoToUrl("https://cloud.google.com/");
            MainPage firstPage = new MainPage(driver);
            firstPage.FindSomething("Google Cloud Platform Pricing Calculator");
            ResultsPage secondPage = new ResultsPage(driver);
            secondPage.openSomething("Google Cloud Platform Pricing Calculator");
            PricingCalculatorPage thirdPage = new PricingCalculatorPage(driver);
            thirdPage.doSomething();
            YopmailPage fourthPage = new YopmailPage(driver);
            User user = fourthPage.CreateNewPostalAddressAndReturnName();
            IWebElement firstCommand = driver.FindElement(By.TagName("body"));
            firstCommand.SendKeys(Keys.Control + Keys.Shift + Keys.Tab);
            thirdPage.SendEmail(user.GetLogin());
            IWebElement secondCommand = driver.FindElement(By.TagName("body"));
            secondCommand.SendKeys(Keys.Control + Keys.Shift + Keys.Tab);
            return fourthPage.GetCost();
        }
    }
}