using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace EnterpriseAutomation
{
    class TestBase
    {
        public IWebDriver driver;
        public static String baseUrl = "https://staginganalyzer.styleresearch.com/authentication/srlogin.aspx";
    }
}
