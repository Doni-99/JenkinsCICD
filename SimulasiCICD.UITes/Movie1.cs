using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SimulasiCICD.UITes
{
    public class Movie1: IDisposable
    {
        private string appURL;
        private IWebDriver driver;
        public Movie1()
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

        [Fact]
        public void addMovie_MenuMovie_True()
        {
            driver.Navigate().GoToUrl(appURL);

            driver.FindElement(By.XPath(@"/html/body/header/nav/div/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath(@"/html/body/div/main/p/a")).Click();
            //Form Moive
            driver.FindElement(By.Id("Title")).SendKeys("New Movie");
            driver.FindElement(By.Id("ReleaseDate")).SendKeys("06/03/2021");
            driver.FindElement(By.Id("Genre")).SendKeys("Action");
            driver.FindElement(By.Id("Price")).SendKeys("10000");
            
            driver.FindElement(By.XPath(@"/html/body/div/main/div[1]/div/form/div[5]/input")).Click();

            Assert.Equal("Index - SimulasiCICD", driver.Title.ToString());
        }

        public void Dispose()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
