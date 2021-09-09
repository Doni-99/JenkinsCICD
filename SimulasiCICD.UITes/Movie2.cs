using OpenQA.Selenium;
using Xunit;
namespace SimulasiCICD.UITes
{
    public class Movie2 : TestClass
    {
        Object.Movie oMovie;
        public Movie2(){
            oMovie = new Object.Movie(driver);
            appURL = "http://localhost:5000";
        }

        [Fact]
        public void AddMovie_InputDataMovie_kembaliKehalamanListMovieV2()
        {
            driver.Navigate().GoToUrl(appURL);

            driver.FindElement(By.XPath(@"/html/body/header/nav/div/div/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath(@"/html/body/div/main/p/a")).Click();

            //driver.FindElement(By.Id(@"Title")).SendKeys("Movie 1");
            oMovie.Title.SendKeys("Movie 1");
            oMovie.ReleaseDate.SendKeys("05/05/2020");
            oMovie.Genre.SendKeys("Genre");
            oMovie.Price.SendKeys("1000");

            driver.FindElement(By.XPath(@"/html/body/div/main/div[1]/div/form/div[5]/input")).Click();

            Assert.Equal("Index", driver.FindElement(By.XPath(@"/html/body/div/main/h1")).GetAttribute("innerHTML").ToString());
        }
        [Fact]
        public void ValidateIndextTitle()
        {
            driver.Navigate().GoToUrl(appURL);
            Assert.Equal("Home Page - SimulasiCICD", driver.Title);
        }
    }
}
