using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SimulasiCICD.UITes
{
    public class TestClass: IDisposable
    {
        protected string appURL;
        protected IWebDriver driver;
        public TestClass()
        {
            //appURL = "https://localhost:5001";
            appURL = "https://rnd.praisindo.com/CICD";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions opt = new ChromeOptions();
                    opt.AddArgument("ignore-certificate-errors");
                    opt.AddArgument("headless");
                    driver = new ChromeDriver(opt);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
