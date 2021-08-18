using OpenQA.Selenium;

namespace Framework
{
    class PricingCalculatorPage : AbstractPage
    {
        private static readonly string computerEngineButtonClassName = "md-ripple-container";

        private static readonly string numberOfInstancesXPath = "//*[@id='input_67']";

        private static readonly string operatingSystemXPath = "//*[@id='select_value_label_60']/span[2]";

        private static readonly string VMClassXPath = "//*[@placeholder='VM Class']";

        private static readonly string changeSeriesButtonXpath = "//*[@id='select_value_label_63']/span[2]";

        private static readonly string machineTypeXPath = "//*[@id='mainForm']/div[2]/div/md-card/md-card-content/div/div[1]/form/div[7]/div[1]/md-input-container";
        
        private static readonly string addGPUXPath = "//*[@id='mainForm']/div[2]/div/md-card/md-card-content/div/div[1]/form/div[8]/div[1]/md-input-container/md-checkbox/div[1]/div";

        private static readonly string numberOfGPUsButtonXPath = "//*[@id='select_value_label_429']/span[2]";

        private static readonly string GPUsTypeButtonXPath = "//*[@id='select_value_label_430']/span[2]";

        private static readonly string SSDTypeXPath = "//*[@id='mainForm']/div[2]/div/md-card/md-card-content/div/div[1]/form/div[11]/div[1]/md-input-container";

        private static readonly string LocateButtonXPath = "//*[@id='mainForm']/div[2]/div/md-card/md-card-content/div/div[1]/form/div[12]/div[1]/md-input-container";

        private static readonly string usageButtonXPath = "//*[@id='mainForm']/div[2]/div/md-card/md-card-content/div/div[1]/form/div[15]/div[1]/md-input-container";

        private IWebElement computerEngineButton;

        private IWebElement numberOfInstancesLine;

        private IWebElement operatingSystemField;

        private IWebElement VMClassLine;

        private IWebElement changeSeriesButton;

        private IWebElement machineTypeButton;

        private IWebElement addGPUField;

        private IWebElement numberOfGPUsButton;

        private IWebElement GPUsTypeButton;

        private IWebElement SSDTypeButton;

        private IWebElement locateButton;

        private IWebElement usageButton;

        private IWebElement addToEstimateButton;

        public PricingCalculatorPage(IWebDriver driver) : base(driver)
        {
            URL = "https://cloud.google.com/products/calculator?hl=en";
            computerEngineButton = driver.FindElement(By.ClassName(computerEngineButtonClassName));
            numberOfInstancesLine = driver.FindElement(By.XPath(numberOfInstancesXPath));
            operatingSystemField = driver.FindElement(By.XPath(operatingSystemXPath));
            VMClassLine = driver.FindElement(By.XPath(VMClassXPath));
            changeSeriesButton = driver.FindElement(By.XPath(changeSeriesButtonXpath));
            addToEstimateButton = driver.FindElement(By.PartialLinkText("Add to Estimate"));
        }

        public void doSomething()
        {
            computerEngineButton.Click();
            numberOfInstancesLine.SendKeys("4");
            operatingSystemField.Click();
            driver.FindElement(By.PartialLinkText("Free")).Click();
            VMClassLine.Click();
            driver.FindElement(By.PartialLinkText("Regular")).Click();
            changeSeriesButton.Click();
            driver.FindElement(By.LinkText("N1")).Click();
            machineTypeButton.Click();
            machineTypeButton = driver.FindElement(By.XPath(machineTypeXPath));
            addGPUField = driver.FindElement(By.XPath(addGPUXPath));
            SSDTypeButton = driver.FindElement(By.XPath(SSDTypeXPath));
            locateButton = driver.FindElement(By.XPath(LocateButtonXPath));
            driver.FindElement(By.PartialLinkText("30GB")).Click();
            addGPUField.Click();
            numberOfGPUsButton = driver.FindElement(By.XPath(numberOfGPUsButtonXPath));
            GPUsTypeButton = driver.FindElement(By.XPath(GPUsTypeButtonXPath));
            numberOfGPUsButton.Click();
            driver.FindElement(By.XPath("//*[@id='select_option_436']")).Click();
            GPUsTypeButton.Click();
            driver.FindElement(By.PartialLinkText("NVIDIA Tesla V100")).Click();
            SSDTypeButton.Click();
            driver.FindElement(By.PartialLinkText("2x375 GB")).Click();
            locateButton.Click();
            driver.FindElement(By.PartialLinkText("Frankfurt")).Click();
            usageButton = driver.FindElement(By.XPath(usageButtonXPath));
            usageButton.Click();
            driver.FindElement(By.PartialLinkText("1 Year")).Click();
            addToEstimateButton = driver.FindElement(By.PartialLinkText("Add to Estimate"));
            addToEstimateButton.Click();
            driver.FindElement(By.PartialLinkText("EMAIL ESTIMATE")).Click();
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys(Keys.Control + 't');
        }

        public void SendEmail(string email)
        {
            driver.FindElement(By.XPath("//*[@id='email_quote']")).Click(); // Emailestimate
            driver.FindElement(By.XPath("//*[@id='dialogContent_520']/form/md-content/div[3]/md-input-container/label")).SendKeys(email);
            driver.FindElement(By.XPath("//*[@id='dialogContent_520']/form/md-dialog-actions/button[1]")).Click();  // send email
        }
    }
}

//9. В новой вкладке открыть https://yopmail.com/ или аналогичный сервис для генерации временных email'ов
//10.Скопировать почтовый адрес сгенерированный в yopmail.com
//11. Вернуться в калькулятор, в поле Email ввести адрес из предыдущего пункта
//12. Нажать SEND EMAIL
//13. Дождаться письма с рассчетом стоимости и проверить что Total Estimated Monthly Cost в письме совпадает с тем, что отображается в калькуляторе 