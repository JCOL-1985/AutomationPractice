using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice
{
    public class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement SearchBar => _driver.FindElement(By.Name("q"));
        private IWebElement SearchButton => _driver.FindElement(By.XPath("//button[@aria-label='Icono de búsqueda']"));
        private IWebElement SearchFilterSmarphoneBrand => _driver.FindElement(By.XPath("(//*[@class='dib b dark-gray f4 lh-copy tl w-100 pv3'])[6]"));
        private IWebElement SearchFilterSmarphoneBrandWait => _driver.FindElement(By.XPath("//button[@aria-label='Ordenar por Más relevantes']"));
        private IWebElement SearchFilterSmarphoneBrandMovistar => _driver.FindElement(By.XPath("(//*[@class='w_K0Ci'])[1]"));
        private IWebElement SearchFilterSmarphoneBrandMovistarResult => _driver.FindElement(By.XPath("//button[@aria-label='Remove filter Motorola']"));
        private IList<IWebElement> ValidateResulSmarphone => _driver.FindElements(By.XPath("//*[@class='w-100 h-100 z-1 hide-sibling-opacity  absolute']"));
        // Fridge
        private IWebElement SearchFilterFridgeBrand => _driver.FindElement(By.XPath("(//*[@class='dib b dark-gray f4 lh-copy tl w-100 pv3'])[6]"));
        private IWebElement SearchFilterFringeBrandMabe => _driver.FindElement(By.XPath("(//*[@class='w__dg8'])[3]"));
        private IWebElement SearchFilterFringeBrandMabeAgregar => _driver.FindElement(By.XPath("(//button[@class='w_eEg0 w_OoNT w_4QgR pointer bn sans-serif b ph2 flex items-center justify-center w-auto shadow-1'])[1]"));
        private IWebElement SearchFilterShoppingCard => _driver.FindElement(By.XPath("//*[@class='ld ld-Cart mr1 white']"));
        //Delete fridge shoppin card
        private IWebElement DeleteFilterShoppingCard => _driver.FindElement(By.XPath("//button[@class='w_eEg0 w_KJ_i w_w8Y1 bn black sans-serif pa0 bg-transparent underline tc f6 w5 mr4 mr5 pa1']"));
        private IList<IWebElement> ValidateDeleteResult => _driver.FindElements(By.XPath("//*[@class='f2 mid-gray ml1']"));


        public void Search(string search)
        {
            _wait.Until(_d => SearchBar.Displayed);
            SearchBar.Clear();
            SearchBar.Click();
            SearchBar.SendKeys(search);
        }
        public void Searching()
        {
            SearchButton.Click();
           
        }
        public void SearchSmarphone()
        {
            _wait.Until(_d => SearchFilterSmarphoneBrandWait.Displayed);
            SearchFilterSmarphoneBrand.Click();
            SearchFilterSmarphoneBrandMovistar.Click();
            _wait.Until(_d => SearchFilterSmarphoneBrandMovistarResult.Displayed);

        } 
        public bool validateResultSmarphone()
        {
            bool validation = true;

            foreach (var item in ValidateResulSmarphone)
            {
                if (!item.Text.Contains("Motorola"))
                {
                    Console.WriteLine($"El siguiente elemento fue encontrado en la pagina: {item.Text},y no cumple con los parámetros de búsqueda");
                    validation = false;
                    break;
                }
            }
            return validation;
            
        }
        public void SearchFridge()
        {
            SearchFilterFridgeBrand.Click();
            SearchFilterFringeBrandMabe.Click();
            SearchFilterFringeBrandMabeAgregar.Click();
            SearchFilterShoppingCard.Click();
        }
        public void DeleteShoppingCard()
        {
            SearchFilterShoppingCard.Click();
            DeleteFilterShoppingCard.Click();
        }
        public bool validateDeleteResult()
        {
            bool validation = true;

            foreach (var item in ValidateDeleteResult)
            {
                if (!item.Text.Contains("0"))
                {
                    Console.WriteLine($"El siguiente elemento fue encontrado en la pagina: {item.Text},y no cumple con los parámetros de búsqueda");
                    validation = false;
                    break;
                }
            }
            return validation;

        }
    }


}
