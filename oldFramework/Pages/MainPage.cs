using OpenQA.Selenium;

namespace Framework
{
    public class MainPage : AbstractPage
    {
        private static readonly string searchLineClassName = "devsite-searchbox";

        private IWebElement searchLine;

        public MainPage(IWebDriver driver): base(driver)
        {
            URL = "https://cloud.google.com/";
            searchLine = driver.FindElement(By.ClassName(searchLineClassName));
        }

        public void FindSomething(string elementName)
        {
            searchLine.Click();
            searchLine = driver.FindElement(By.ClassName(searchLineClassName));
            searchLine.SendKeys(elementName); //Google Cloud Platform Pricing Calculator
            searchLine.SendKeys(Keys.Enter);
        }
    }
}
