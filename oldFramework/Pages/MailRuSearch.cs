using OpenQA.Selenium;

namespace Framework
{
    class MailRuSearch : AbstractPage
    {
        public MailRuSearch(IWebDriver driver) : base(driver)
        {
            URL = "https://mail.ru/";
        }
    }
}
