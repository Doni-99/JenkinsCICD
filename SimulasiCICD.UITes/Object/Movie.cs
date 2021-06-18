using OpenQA.Selenium;

namespace SimulasiCICD.UITes.Object
{
    public class Movie
    {
        private IWebDriver _driver;
        public Movie(IWebDriver driver){
            _driver = driver;
        }
        public IWebElement Title
        {
            get { return _driver.FindElement(By.Id(@"Title")); }
        }
        public IWebElement ReleaseDate
        {
            get { return _driver.FindElement(By.Id(@"ReleaseDate")); }
        }
        public IWebElement Genre
        {
            get { return _driver.FindElement(By.Id(@"Genre")); }
        }
        public IWebElement Price
        {
            get { return _driver.FindElement(By.Id(@"Price")); }
        }
    }
}
