using OpenQA.Selenium;
using System;
using System.Threading;

namespace Task10
{
    public class EntryPoint
    {
        /// <summary>
        /// This method log in to email and returning message about success.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param your name or login="name"></param>
        /// <param password="password"></param>
        /// <returns></returns>
        public static string ComeInToEmail(IWebDriver browser, string name, string password)
        {
            if (name == String.Empty || password == String.Empty)
            {
                throw new Exception("Login or password does not exist");
            }
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            browser.Navigate().GoToUrl("https://mail.ru/");
            IWebElement MailBoxName = browser.FindElement(By.XPath("//*[@id='mailbox']/form[1]/div[1]/div[2]/input"));
            MailBoxName.SendKeys(name);
            IWebElement PasswordButton = browser.FindElement(By.XPath("//*[@id='mailbox']/form[1]/button[1]"));
            PasswordButton.Click();
            IWebElement EntryPassword = browser.FindElement(By.XPath("//*[@id='mailbox']/form[1]/div[2]/input"));
            EntryPassword.SendKeys(password);
            IWebElement EntryButton = browser.FindElement(By.XPath("//*[@id='mailbox']/form[1]/button[2]"));
            EntryButton.Click();
            return "Success";
        }

        /// <summary>
        /// This method will exit from email.
        /// </summary>
        /// <param main page of email="mainPage"></param>
        /// <returns></returns>
        public static string ExitFromEmail(MainPageOfEmail mainPage)
        {
            if (mainPage == null)
            {
                throw new Exception("Main page does not exist");
            }
            return mainPage.ExitFromEmail();
        }

        /// <summary>
        /// This method sending messages.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param name of recipient="name"></param>
        /// <param message that will send="message"></param>
        /// <returns></returns>
        public static string SendMessage(IWebDriver browser, string name, string message)
        {
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            if (name == string.Empty)
            {
                throw new Exception("Name of recipient does not exist");
            }
            if (message == string.Empty)
            {
                throw new Exception("Message does not exist");
            }
            browser.FindElement(By.XPath("//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a")).Click();
            SendLetterPage sendPage = new SendLetterPage(browser);
            return sendPage.SendMessage(name, message);
        }

        /// <summary>
        /// This method answer to unread letter.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param answer message="answer"></param>
        /// <returns></returns>
        public static string AnswerMessage(IWebDriver browser, string answer)
        {
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            if (answer == string.Empty)
            {
                throw new Exception("Answer message does not exist");
            }
            IWebElement filter = browser.FindElement(By.ClassName("select__control"));
            filter.Click();
            filter = browser.FindElement(By.Id("app-canvas"));
            filter.Click();
            IWebElement letterForAnswer = browser.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div[1]/div/div/div/a[1]"));
            letterForAnswer.Click();
            IWebElement sendButton = browser.FindElement(By.XPath("//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[4]/div/div/div[1]/div[1]/span/span"));
            sendButton.Click();

            AnswerForLetterPage answerPage = new AnswerForLetterPage(browser);
            return answerPage.AnswerToMessage(answer);
        }

        /// <summary>
        /// This method chanding Nickname.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param new name="newName"></param>
        /// <returns></returns>
        public static string ChangeNickname(IWebDriver browser, string newName)
        {
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            if (newName == string.Empty)
            {
                throw new Exception("New nickname does not exist");
            }
            IWebElement settingsButton = browser.FindElement(By.XPath("//*[@id='ph-whiteline']/div/div[2]/div[2]/span[3]"));
            settingsButton.Click();
            IWebElement personalDataButton = browser.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[3]/div/div/a[1]"));
            personalDataButton.Click();
            SettingsPage settings = new SettingsPage(browser);
            return settings.ChangeNickname(newName);
        }

        /// <summary>
        /// This method get text from message by author.
        /// </summary>
        /// <param web driver="browser"></param>
        /// <param name of author of message="nameOfAuthor"></param>
        /// <returns></returns>
        public static string GetMessageOfLetter(IWebDriver browser, string nameOfAuthor)
        {
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            if (nameOfAuthor == string.Empty)
            {
                throw new Exception("Name of author does not exist");
            }
            IWebElement letterForAnswer = browser.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div[1]/div/div/div/a[1]"));
            letterForAnswer.Click();
            OpenLetterPage openLetterPage = new OpenLetterPage(browser);
            return openLetterPage.GetTextOfLetter(nameOfAuthor);
        }

        static void Main(string[] args)
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            Console.WriteLine(ComeInToEmail(browser, name1, password1));
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            Console.WriteLine(SendMessage(browser, name2, "Something"));
            Thread.Sleep(2000);
            Console.WriteLine(ExitFromEmail(mainPage));
            Console.WriteLine(ComeInToEmail(browser, name2, password2));
            Console.WriteLine(AnswerMessage(browser, "Answer"));
            Console.WriteLine(ExitFromEmail(mainPage));
            Console.WriteLine(ComeInToEmail(browser, name1, password1));
            string result = GetMessageOfLetter(browser, "Максим Юрченок");
            Console.WriteLine(ChangeNickname(browser, "Maxim Yurchenok"));

            Console.WriteLine("FINISH");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}