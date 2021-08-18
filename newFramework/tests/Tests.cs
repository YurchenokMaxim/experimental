using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using CategoryAttribute = NUnit.Framework.CategoryAttribute;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;
using NUnit.Framework.Interfaces;

namespace Task10
{

    //	файлы с тестовыми данным для разных окружений(как минимум 2)

    //	Добавить логирование используя библиотеку NLog.Использовать различные уровни логирования(Error, Info, etc.)

    //	Фреймворк должен иметь возможность запуска с Jenkins и параметризацией браузера, тест suite, environment, cборка проекта -
    //  MS Build.Результаты тестов должны быть на графике джобы, скриншоты должны быть заархивированны как артефакты

    [TestFixture]
    public class Tests : EntryPoint
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == ResultState.Failure.Status)
            {
                ScreenshotMaker.MakeScreenshot(driver);
            }
            driver.Quit();
        }

        [Test]
        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount1@mail.ru", "Y)ppiiklPB13")]
        [TestCase("experimentalaccount2@mail.ru", "tPTTRkpyt42#")]
        public void PositiveTestOfComeInToEmail(string login, string password)
        {
            ComeInToEmail(driver, login, password);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            Assert.AreEqual(result, login);
        }

        [Test]
        [Category("All")]
        [Category("Smoke")]
        [TestCase("", "tPTTRkpyt42")]
        [TestCase("experimentalaccount2@mail.ru", "")]
        public void NegativeTestOfComeInToEmail(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Login or password does not exist");
            }
        }

        [Test]
        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount", "Y)ppiiklPB13")]
        public void NegativeTestOfComeInToEmailNoSuchElementException(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("element not interactable\n"));
            }
        }

        [Test]
        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount2@mail.ru", "tPTTRkpyt42")]
        public void NegativeTestOfComeInToEmailNotInteractableException(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("no such element"));
            }
        }

        [Test]
        [Category("All")]
        public void PositiveTestOfSendLetter()
        {
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            ComeInToEmail(driver, name1, password1);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            SendMessage(driver, name2, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, name2, password2);
            string result = GetMessageOfLetter(driver, "Максим Юрченок");

            Assert.AreEqual("Something", result);
        }

        [Test]
        [Category("All")]
        public void PositiveTestOfChangeNickname()
        {
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            ComeInToEmail(driver, name1, password1);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            SendMessage(driver, name2, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, name2, password2);
            AnswerMessage(driver, "Maxim Yurchenok");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, name1, password1);
            string result = GetMessageOfLetter(driver, "Максим Юрченок");
            ChangeNickname(driver, result);
            result = (driver.FindElement(By.XPath("//*[@id='nickname']"))).GetAttribute("Value");
            Assert.AreEqual("Maxim Yurchenok", result);
        }
    }
}