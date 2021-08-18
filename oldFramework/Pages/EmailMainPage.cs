using OpenQA.Selenium;

namespace Framework
{
    class EmailMainPage : AbstractPage
    {
        public EmailMainPage(IWebDriver driver) : base(driver)
        {
            URL = "https://e.mail.ru/inbox/?back=1";
        }
    }
}
