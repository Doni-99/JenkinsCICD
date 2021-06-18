using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SimulasiCICD.UITes
{
    public class Movies : IDisposable
    {
        #region "Variable & Property"
        private IWebElement Title
        {
            get { return driver.FindElement(By.Id(@"Title")); }
        }
        private IWebElement ReleaseDate
        {
            get { return driver.FindElement(By.Id(@"ReleaseDate")); }
        }
        private IWebElement Genre
        {
            get { return driver.FindElement(By.Id(@"Genre")); }
        }
        private IWebElement Price
        {
            get { return driver.FindElement(By.Id(@"Price")); }
        }
        string Env = "Prod";
        private string appURL;
        private IWebDriver driver;
        #endregion
        public Movies()
        {
            if (Env.Equals("Dev"))
                appURL = "https://localhost:5001";
            else
                appURL = "https://rnd.praisindo.com/CICD";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions opt = new ChromeOptions();
                    opt.AddArgument("ignore-certificate-errors");
                    if (!Env.Equals("Dev"))
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

        [Fact]
        public void AddMovie_InputDataMovie_kembaliKehalamanListMovie()
        {
            driver.Navigate().GoToUrl(appURL);

            driver.FindElement(By.XPath(@"/html/body/header/nav/div/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath(@"/html/body/div/main/p/a")).Click();

            //driver.FindElement(By.Id(@"Title")).SendKeys("Movie 1");
            Title.SendKeys("Movie 1");
            ReleaseDate.SendKeys("05/05/2020");
            Genre.SendKeys("Genre");
            Price.SendKeys("1000");

            driver.FindElement(By.XPath(@"/html/body/div/main/div[1]/div/form/div[5]/input")).Click();

            Assert.Equal("Index", driver.FindElement(By.XPath(@"/html/body/div/main/h1")).GetAttribute("innerHTML").ToString());
        }

        public void Dispose()
        {
            //if (!Env.Equals("Dev"))
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
