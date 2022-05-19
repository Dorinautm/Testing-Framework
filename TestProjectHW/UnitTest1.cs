using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using TestProjectHW.Base;
using TestProjectHW.PageObjectModel;

namespace TestProjectHW
{
    public class UnitTest1 : BaseSet
    {
        [Test]
        public void SuccsessfulLogin()
        {
            LoginPageTest logInPage = new LoginPageTest(driver, wait);
            logInPage.ClickLoginInBtn();

            EmailPageTest emailPage = new EmailPageTest(driver, wait);
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextBtn();

            PasswordPageTest pwdPage = new PasswordPageTest(driver, wait);
            pwdPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            pwdPage.PressNextBtn();
            //Thread.Sleep(2000);
            pwdPage.ConfirmPassword();
        }
        [Test]
        public void SuccessfullCreateTask()
        {
            SuccsessfulLogin();

            HomePageTest homePage = new HomePageTest(driver, wait);
            homePage.PressTaskBtn();

            TaskPageTest taskPage = new TaskPageTest(driver, wait);
            taskPage.IsBtnDisplayed();
            taskPage.CheckBtnName("Add Task");
            taskPage.PressAddTaskBtn();
            taskPage.CheckBtnSaveDisabled();
            taskPage.AddSubject("Test for Selenium");
            taskPage.SelectStatus();
            Thread.Sleep(2000);
            taskPage.SelectPriority();
            taskPage.SelectValidDeadline();
            taskPage.SaveTask();
            Thread.Sleep(2000);
            taskPage.AssertSuccesMessage("Activity Task has been successfully created.");
        }

        [Test]
        public void SuccessfullLogOut()
        {
            SuccsessfulLogin();

            HomePageTest homePage = new HomePageTest(driver, wait);
            homePage.CheckPageTitle("advance - Amdaris");
            homePage.LogOut();
            homePage.CheckLogoutBtnPopup("Log out");
            homePage.ConfirmLogout();
            homePage.NavigateBack("You signed out of your account");
        }
        [Test]
        public void CancelLogout()
        {
            SuccsessfulLogin();

            HomePageTest homePage = new HomePageTest(driver, wait);
            homePage.LogOut();
            homePage.CancelLogout();
        }
        [Test]
        public void FilterTaskByAssignedTo()
        {
            SuccsessfulLogin();

            HomePageTest homePage = new HomePageTest(driver, wait);
            homePage.PressTaskBtn();
            TaskPageTest taskPage = new TaskPageTest(driver, wait);           
            taskPage.FilterByName("Dorina Balaur");
            
        }
    }
}