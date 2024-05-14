using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PitangAutomation.PageModel.POM;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PitangAutomation.TestClasses.POM
{
    public class BooksPage : BasePage
    {
        private IWebElement GoToStoreButton => driver.FindElement(By.Id("gotoStore"));
        private IWebElement SearchBoxField => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("searchBox")));


        public BooksPage(IWebDriver driver) : base(driver)
        {
        }

        public void AccessBooksPage()
        {
            GoToStoreButton.Click();
        }

        public void FillSearchBookStore(string bookTitle)
        {
            SearchBoxField.SendKeys(bookTitle);
            Actions actions = new Actions(driver);
            actions.MoveToElement(SearchBoxField).Click().Perform();
        }

        
        public string ListBooksSearched()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("rt-tbody")));
            IReadOnlyList<IWebElement> bookRows = driver.FindElements(By.CssSelector(".rt-tbody .rt-tr"));
            var totalBooks = bookRows.Count();
            var totalSearchedBooks = new StringBuilder();

            foreach (IWebElement bookRow in bookRows)
            {

                IReadOnlyList<IWebElement> titleElements = bookRow.FindElements(By.CssSelector(".rt-td:nth-of-type(2) a"));

                // Se não houver mais elementos de título, interromper o loop
                if (titleElements.Count == 0)
                {
                    break;
                }
                // Capturar os campos "Title", "Author" e "Publisher" de cada livro
                string title = bookRow.FindElement(By.CssSelector(".rt-td:nth-of-type(2) a")).Text;
                string author = bookRow.FindElement(By.CssSelector(".rt-td:nth-of-type(3)")).Text;
                string publisher = bookRow.FindElement(By.CssSelector(".rt-td:nth-of-type(4)")).Text;

                // Exibir os dados capturados
                var searchedBook = $@"Livro {title} do autor {author} publicado por {publisher},
                foi encontrado entre os {totalBooks} resultados da pesquisa";

                totalSearchedBooks.AppendLine(searchedBook);

            }
            return totalSearchedBooks.ToString();

        }

    }
    
}
