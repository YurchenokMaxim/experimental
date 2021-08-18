using OpenQA.Selenium;

namespace Framework
{
    class MailPage : AbstractPage
    {
        public MailPage(IWebDriver driver) : base(driver)
        {
            URL = "https://mail.ru/";
        }
    }
}
