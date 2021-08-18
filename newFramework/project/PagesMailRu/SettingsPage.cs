using OpenQA.Selenium;
using System;

namespace Task10
{
    public class SettingsPage : AbstractPage
    {
        private readonly static string nickNameId = "nickname";

        private readonly static string saveButtonXPath = "//*[@id='root']/div/div[3]/div/div/div/form/div/div[2]/button[1]";

        private IWebElement nickName;

        private IWebElement saveButton;

        public SettingsPage(IWebDriver driver) : base(driver)
        {
            nickName = driver.FindElement(By.Id(nickNameId));
            saveButton = driver.FindElement(By.XPath(saveButtonXPath));
        }

        /// <summary>
        /// This method change nickname.
        /// </summary>
        /// <param new nickname="newNickname"></param>
        /// <returns>message about success</returns>
        public string ChangeNickname(string newNickname)
        {
            if (newNickname == string.Empty)
            {
                throw new Exception("New nickname does not exist");
            }
            nickName.Clear();
            nickName.SendKeys(newNickname);
            saveButton.Click();
            return "Nickname successfuly changed";
        }
    }
}
