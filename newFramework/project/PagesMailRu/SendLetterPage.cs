using OpenQA.Selenium;
using System;

namespace Task10
{
    public class SendLetterPage : AbstractPage
    {
        private readonly static string recipientLineXPath = "/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[2]/div/div/div[1]/div/div[2]/div/div/label/div/div/input";

        private readonly static string messageLineXPath = "/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]";

        private readonly static string sendButtonXPath = "/html/body/div[15]/div[2]/div/div[2]/div[1]/span[1]/span";

        private IWebElement recipientLine;

        private IWebElement messageLine;

        private IWebElement sendButton;

        public SendLetterPage(IWebDriver driver) : base(driver)
        {
            recipientLine = driver.FindElement(By.XPath(recipientLineXPath));
            messageLine = driver.FindElement(By.XPath(messageLineXPath));
            sendButton = driver.FindElement(By.XPath(sendButtonXPath));
        }

        /// <summary>
        /// This method send message.
        /// </summary>
        /// <param recipient="name"></param>
        /// <param text of letter="message"></param>
        /// <returns>message about success</returns>
        public string SendMessage(string name, string message)
        {
            if (name == string.Empty)
            {
                throw new Exception("Name of recipient does not exist");
            }
            if (message == string.Empty)
            {
                throw new Exception("Answer message does not exist");
            }
            recipientLine.SendKeys(name);
            messageLine.SendKeys(message);
            sendButton.Click();
            return "Successful dispatch";
        }
    }
}
