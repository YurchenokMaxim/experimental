using OpenQA.Selenium;
using System;

namespace Task10
{
    public class MainPageOfEmail : AbstractPage
    {
        private readonly static string exitButtonXPath = "/html/body/div[3]/div[1]/div/div[3]/div/div/a[3]";

        private static readonly string settingsButtonXPath = "//*[@id='ph-whiteline']/div/div[2]/div[2]/span[3]";

        private static readonly string writeLetterButtonXPath = "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";

        private static readonly string filterClassName = "select__control";

        private static readonly string unreadMessagesButtonId = "app-canvas";

        private static readonly string letterForAnswerClassName = "llc__container";

        private static readonly string sendButtonXPath = "/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[4]/div/div/div[1]/div[1]/span";

        private IWebElement unreadMessagesButton;

        private IWebElement settingsButton;

        private IWebElement exitButton;

        private IWebElement writeLetterButton;

        private IWebElement filter;

        private IWebElement letterForAnswer;

        private IWebElement sendButton;

        public MainPageOfEmail(IWebDriver driver) : base(driver)
        {
            IWebElement settingsButton = driver.FindElement(By.XPath(settingsButtonXPath));
            writeLetterButton = driver.FindElement(By.XPath(writeLetterButtonXPath));
        }

        /// <summary>
        /// This method change nickname.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param new nickname="newName"></param>
        /// <returns>message about success</returns>
        public string ChangeName(IWebDriver browser, string newName)
        {
            if(newName == string.Empty)
            {
                throw new Exception("New nickname does not exist");
            }
            settingsButton = browser.FindElement(By.XPath(settingsButtonXPath));
            settingsButton.Click();
            settingsButton = browser.FindElement(By.XPath(settingsButtonXPath));
            settingsButton.Click();
            SettingsPage settings = new SettingsPage(browser);
            return settings.ChangeNickname(newName);
        }

        /// <summary>
        /// This method exit from email.
        /// </summary>
        /// <returns>message about success</returns>
        public string ExitFromEmail()
        {
            IWebElement settingsButton = driver.FindElement(By.XPath(settingsButtonXPath));
            settingsButton.Click();
            exitButton = driver.FindElement(By.XPath(exitButtonXPath));
            exitButton.Click();
            return "Success in exit";
        }

        /// <summary>
        /// Send message.
        /// </summary>
        /// <param recipient="name"></param>
        /// <param text="message"></param>
        /// <returns>message about success</returns>
        public string SendMessage(string name, string message)
        {
            if ( name == string.Empty)
            {
                throw new Exception("Name of recipient does not exist");
            }
            if ( message== string.Empty)
            {
                throw new Exception("Message does not exist");
            }
            writeLetterButton.Click();
            SendLetterPage sendPage = new SendLetterPage(driver);
            return sendPage.SendMessage(name, message);
        }

        /// <summary>
        /// Answer to the unread message.
        /// </summary>
        /// <param text of answer="answer"></param>
        /// <returns>message about success</returns>
        public string AnswerMessage(string answer)
        {
            if (answer == string.Empty)
            {
                throw new Exception("Answer does not exist");
            }
            filter = driver.FindElement(By.ClassName(filterClassName));
            filter.Click();
            unreadMessagesButton = driver.FindElement(By.Id(unreadMessagesButtonId));
            unreadMessagesButton.Click();
            letterForAnswer = driver.FindElement(By.ClassName(letterForAnswerClassName));
            letterForAnswer.Click();
            sendButton = driver.FindElement(By.XPath(sendButtonXPath));
            sendButton.Click();

            AnswerForLetterPage answerPage = new AnswerForLetterPage(driver);
            answerPage.AnswerToMessage(answer);
            return "Successful answer";
        }
    }
}
