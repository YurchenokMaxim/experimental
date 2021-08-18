using OpenQA.Selenium;

namespace Framework
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        
        protected static readonly double waitSeconds = 10;

        protected string URL;

        public void openPage()
        {
            driver.Navigate().GoToUrl(URL);
        }
            
        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
