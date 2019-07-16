using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Drawing;
//using SRE.AuthenticationProviders;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;

namespace EnterpriseAutomation.Tests
{
    
    [TestFixture(Author = "Suraj Kumar")]
    class SeleniumTest : TestBase.TestBase
    {
        [Ignore("")]
        [Test]
        public void DownloadReport()
        {
            //driver = new ChromeDriver("C:\\Softwares\\chromedriver_win32");
            driver = new ChromeDriver("\\Drivers");

            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            IWebElement inputUserName = driver.FindElement(By.XPath("//*[@id='ctl00_bodyContentPlaceholder_UserLogin_UserName']"));
            inputUserName.Clear();

            //HighlightElement.highLight(driver, inputUserName);
            //Thread.Sleep(2000);
            inputUserName.SendKeys("suraj.kumar@styleanalytics.com");
            //Thread.Sleep(2000);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id='ctl00_bodyContentPlaceholder_UserLogin_Password']"));
            inputPassword.Clear();
            //Thread.Sleep(2000);
            //HighlightElement.highLight(driver, inputPassword);
            inputPassword.SendKeys("Test12345!");
            //Thread.Sleep(2000);

            IWebElement btnLogin = driver.FindElement(By.XPath("//*[@id='ctl00_bodyContentPlaceholder_UserLogin_LoginButton']"));
            btnLogin.Click();

            IWebElement menuPortfolioReports = driver.FindElement(By.Id("hlPortfolioReports"));
            menuPortfolioReports.Click();

            IWebElement graphStyleSkyline = driver.FindElement(By.XPath("//*[@id='pagePane0_divBlock0']"));
            //IWebElement graphStyleSkyline = driver.FindElement(By.XPath("//*[@id='pagePane0_divBlock2']"));

            Thread.Sleep(2000);
            Bitmap scrShot = Utils.Utilities.GetElementScreenShort(driver, graphStyleSkyline);
            String currentTime = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            scrShot.Save("D:\\enterprise automation\\graph_" + currentTime + ".png", System.Drawing.Imaging.ImageFormat.Png);


            IWebElement menuHamburger = driver.FindElement(By.XPath("//*[@id='rhsHamb']"));
            menuHamburger.Click();
            Thread.Sleep(3000);

            IWebElement menuHambugerDownload = driver.FindElement(By.XPath("//*[@class='menuOptionText'] [contains(text(),'Download')]"));
            menuHambugerDownload.Click();

            By locIframe = By.XPath("//iframe[@name='radWindowStyleExposureSettings']");
            driver.SwitchTo().Frame(driver.FindElement(locIframe));

            String templateName = "Default Excel Report";

            driver.FindElement(By.XPath("//*[@id='ctl00_mainContentPlaceHolder_txtFilter']")).SendKeys(templateName);

            driver.FindElement(By.XPath("//*[@id='ctl00_mainContentPlaceHolder_cmdFilter_input']")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//a[text()='" + templateName + "']")).Click();

            driver.SwitchTo().DefaultContent();

            //            driver.Close();


        }
        
        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        public void Enterprise_Web_LoginTest()
        {

            driver = new ChromeDriver();

            //driver = new InternetExplorerDriver();

            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            PageObject.LoginPage loginPage = new PageObject.LoginPage(driver);

            loginPage.inputUserName("suraj.kumar@styleanalytics.com");
            loginPage.inputPassword("Test12345!");
            loginPage.clickLogin();
            
        }

        [Ignore("")]
        [Test]
        [Category("Regression")]
        public void Enterprise_Web_LoginTest2()
        {

            driver = new ChromeDriver("C:\\Softwares\\chromedriver_win32");
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            PageObject.LoginPage loginPage = new PageObject.LoginPage(driver);

            loginPage.inputUserName("suraj.kumar@styleanalytics.com");
            loginPage.inputPassword("Test12345!");
            loginPage.clickLogin();

        }


    //    [Ignore("")]
    //    [Test]
    //    public async Task Enterprise_API_Test1()
    //    {
    //        var baseAddress = "http://devapi.styleanalytics.com:9010/EnterpriseDataServiceRest";
    //        var userName = "Rajesh.Solasa@StyleResearch.com";
    //        var apiResource = Uri.EscapeUriString($"{baseAddress}/{userName}/Currencies");

    //        EnterpriseHmacParameters hmacParams = new EnterpriseHmacParameters()
    //        {
    //            UserName = userName,
    //            ResourceId = apiResource,
    //            HttpMethod = "GET",
    //            UserSecretKey = "70dae6b9-c9ea-4895-a87d-339baabc1923"
    //        };

    //        //Generating token for authorization....
    //        EnterpriseHmacTokenGenerator tokenProvider = new EnterpriseHmacTokenGenerator(Algorithm.SHA512, Encoding.UTF8);
    //        var hmacToken = tokenProvider.GenerateToken(hmacParams);

    //        //Create the http client
    //        var client = new HttpClient { BaseAddress = new Uri(baseAddress), Timeout = new TimeSpan(0, 0, 180) };
    //        client.DefaultRequestHeaders.Clear();
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        //client.DefaultRequestHeaders.Add("Accept", "application/json");

    //        //client.DefaultReRequestHeaders.Add("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(hmacToken))
    //            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", hmacToken);

    //        //Execute the http method using the client
    //        HttpResponseMessage response = await client.GetAsync(apiResource);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var result = response.Content.ReadAsStringAsync().Result;
    //            Console.WriteLine(result);
    //            //Console.ReadKey();
    //            var result1 = response.Content.ReadAsStringAsync().Result;

    //            Assert.IsNotNull(result);
    //        }

    //    }
    //    [Ignore("")]
    //    [Test]
    //    public void moveFilesToFolder()
    //    {
    //        // To copy all the files in one directory to another directory.
    //        // Get the files in the source folder. (To recursively iterate through
    //        // all subfolders under the current directory, see
    //        // "How to: Iterate Through a Directory Tree.")
    //        // Note: Check for target path was performed previously
    //        //       in this code example.
    //        String sourcePath = "D:\\enterprise automation\\downloads";
    //        String targetPath = "D:\\enterprise automation\\downloads_done";
    //        String fileName, destFile;
    //        if (System.IO.Directory.Exists(sourcePath))
    //        {
    //            string[] files = System.IO.Directory.GetFiles(sourcePath);

    //            // Copy the files and overwrite destination files if they already exist.

    //            int a = files.Length;
    //            Console.WriteLine("number of files at destination folder :"+a);

    //            foreach (string s in files)
    //            {
    //                try
    //                {
    //                    // Use static Path methods to extract only the file name from the path.
    //                    fileName = System.IO.Path.GetFileName(s);
    //                    destFile = System.IO.Path.Combine(targetPath, fileName);
    //                    System.IO.File.Copy(s, destFile, true);
    //                    System.IO.File.Delete(s);
    //                    //System.IO.File.Move(s, destFile);
    //                }
    //                catch(System.IO.IOException e)
    //                {
    //                    Console.WriteLine(e.Message);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Source path does not exist!");
    //        }

    //        // Keep console window open in debug mode.
    //        Console.WriteLine("Press any key to exit.");

    //    }
    //    [Ignore("")]
    //    // wait for the new file to download and parse the report name
    //    [Test]
    //    public void findDownloadedReportName()
    //    {
    //        String sourcePath = "D:\\enterprise automation\\downloads";
    //        String fileName;
    //        if (System.IO.Directory.Exists(sourcePath))
    //        {
    //            string[] files = System.IO.Directory.GetFiles(sourcePath);

    //            // Copy the files and overwrite destination files if they already exist.
    //            int a = files.Length;
    //            if(files.Length == 1)
    //            {
    //                fileName = files[0].ToString();
    //                Console.WriteLine(fileName);
    //            }
    //            else if (files.Length > 1)
    //            {
    //                Console.WriteLine("more than one repots found ...");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Source path does not exist!");
    //        }
    //        // Keep console window open in debug mode.
    //        Console.WriteLine("Press any key to exit.");
    //    }
    //}

        //[Test]
        //public async Task Enterprise_RestSharp_Test1()
        //{
        //    var baseAddress = "http://devapi.styleanalytics.com:9010/EnterpriseDataServiceRest";
        //    var userName = "Rajesh.Solasa@StyleResearch.com";
        //    var apiResource = Uri.EscapeUriString($"{baseAddress}/{userName}/Currencies");

        //    EnterpriseHmacParameters hmacParams = new EnterpriseHmacParameters()
        //    {
        //        UserName = userName,
        //        ResourceId = apiResource,
        //        HttpMethod = "GET",
        //        UserSecretKey = "70dae6b9-c9ea-4895-a87d-339baabc1923"
        //    };


        //    //Generating token for authorization....
        //    EnterpriseHmacTokenGenerator tokenProvider = new EnterpriseHmacTokenGenerator(Algorithm.SHA512, Encoding.UTF8);
        //    var hmacToken = tokenProvider.GenerateToken(hmacParams);

        //    //create RestSharp client and POST request object
        //    var client = new RestClient(baseAddress);
        //    client.ClearHandlers();
        //    var request = new RestRequest(Method.GET);

        //    //add GetToken() API method parameters
        //    request.AddHeader("Accept", "application/json");
        //    request.AddHeader("Authorization", "token " + hmacToken);

        //    IRestResponse getResponse = client.Execute(request);

        //    Console.WriteLine(getResponse.Content);


}
