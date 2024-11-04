using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography.X509Certificates;

namespace AutomationPractice
{
    public class Tests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
          _driver = new ChromeDriver ();_driver.Navigate().GoToUrl("https://www.walmart.com.mx/inicio");
          _driver.Manage().Window.Maximize();
          _homePage = new HomePage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test, Order(1)]
        public void Test1()
        {
            _homePage.Search("");
            Assert.That(_driver.Title, Does.Contain("Haz tus compras por internet | Walmart tienda en línea"));
        }
        [Test,Order(2)]
        public void Smarphone()
        {
            _homePage.Search("Smarphone");
            _homePage.Searching();
            _homePage.SearchSmarphone();
            Assert.That(_homePage.validateResultSmarphone, Is.EqualTo(true));
        }
        [Test,Order(3)]
        public void SearchFridge()
        {
            _homePage.Search("refrigerador");
            _homePage.Searching();
            _homePage.SearchFridge();
            Assert.That(_driver.Title, Does.Contain("walmart.com.mx/cart"));

        }
        public void DeleteShoppingCard()
        {
            _homePage.Search("");
            Assert.That(_homePage.validateDeleteResult, Is.EqualTo(true));
        }
    }
}