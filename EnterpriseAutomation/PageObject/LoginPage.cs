using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAutomation.PageObject
{
    class LoginPage
    {
        public IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_bodyContentPlaceholder_UserLogin_UserName']")]
        public IWebElement UserName;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_bodyContentPlaceholder_UserLogin_Password']")]
        public IWebElement UserPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_bodyContentPlaceholder_UserLogin_LoginButton']")]
        public IWebElement LoginButton;


        public void inputUserName(String userName)
        {
            UserName.Clear();
            UserName.SendKeys(userName);
        }

        public void inputPassword(String password)
        {
            UserPassword.Clear();
            UserPassword.SendKeys(password);
        }

        public void clickLogin()
        {
            LoginButton.Click();
        }
    }
}
