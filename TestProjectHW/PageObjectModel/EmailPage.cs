using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHW.PageObjectModel
{
    public class EmailPageTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public EmailPageTest(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement _emailField => _driver.FindElement(By.XPath("//input[@type='email']"));
        private IWebElement _nextBtn => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void WriteEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_emailField)).SendKeys(email);
        }
        public void PressNextBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_nextBtn)).Click();
        }
    }
}
