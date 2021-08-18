using OpenQA.Selenium;

namespace Framework
{
    class YopmailPage : AbstractPage
    {
        private static readonly string createNewAddressButtonXPath = "//*[@id='listeliens']/a[1]";

        IWebElement createNewAddressButton;

        public string EmailAddress;

        public YopmailPage(IWebDriver driver) : base(driver)
        {
            URL = "https://yopmail.com/";
            createNewAddressButton = driver.FindElement(By.XPath(createNewAddressButtonXPath));
        }

        public User CreateNewPostalAddressAndReturnName()
        {
            createNewAddressButton.Click();
            EmailAddress = driver.FindElement(By.XPath("//*[@id='egen']")).Text;
            return new User(EmailAddress);
        }

        public string GetCost()
        {
            return driver.FindElement(By.XPath("//*[@id='mail']/div/div/table/tbody/tr[2]/td/table/tbody/tr[2]/td[2]/h3")).Text;
        }
    }
}
