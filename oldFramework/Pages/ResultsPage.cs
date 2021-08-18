using OpenQA.Selenium;

namespace Framework
{
    class ResultsPage : AbstractPage
    {
        public ResultsPage(IWebDriver driver) : base(driver)
        {
            URL = "https://cloud.google.com/s/results?q=Google%20Cloud%20Platform%20Pricing%20Calculator";
        }

        public void openSomething(string search)
        {
            driver.FindElement(By.LinkText(search)).Click();
        }
    }
}
