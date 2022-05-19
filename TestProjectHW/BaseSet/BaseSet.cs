using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHW.Base
{
    public class BaseSet
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArgument("--start-maximized");
            options.AddArguments("--testing");
            options.AddArguments("--disable-translate");
            options.AddArguments("--disable-plugins");
            options.AddArguments("--suppress-message-center-popups");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/login");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }
        [TearDown]
        public void Teardown()
        {
            driver.Close();
            //inchide instanta la driver
            driver.Quit();
        }
    }
}
