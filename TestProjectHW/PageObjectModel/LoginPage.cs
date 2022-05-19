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
    public class LoginPageTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LoginPageTest(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement logInBtn => _driver.FindElement(By.CssSelector("div .button > span"));

        public void ClickLoginInBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logInBtn)).Click();
        }
    }
}
