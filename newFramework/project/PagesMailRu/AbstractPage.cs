using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task10
{
    public abstract class AbstractPage
    {
        private static readonly int waitTime = 10;

        public WebDriverWait wait { get; private set; }

        public IWebDriver driver { get; protected set; }

        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(waitTime));
        }
    }
}