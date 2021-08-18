using OpenQA.Selenium;
using System.IO;
using System;
using NUnit.Framework;

namespace Task10
{
    /// <summary>
    /// Class for making a screenshots
    /// </summary>
    public class ScreenshotMaker
    {
        private const string wayToSave = ".//Screenshots/";

        /// <summary>
        /// Method that making screenshot.
        /// </summary>
        /// <param name="driver">The current state of the Selenium WebDriver object</param>
        public static void MakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(CreateFilename(), ScreenshotImageFormat.Jpeg);
        }

        /// <summary>
        /// Method for checking that way already exists.
        /// </summary>
        private static void CheckDirectory()
        {
            if (!Directory.Exists(wayToSave))
            {
                Directory.CreateDirectory(wayToSave);
            }
        }

        /// <summary>
        /// Method that creating a filename for picture.
        /// </summary>
        /// <returns>New unique name</returns>
        private static string CreateFilename()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string testName = TestContext.CurrentContext.Test.FullName;
            CheckDirectory();
            return wayToSave + testName + date + ".jpg";
        }
    }
}
