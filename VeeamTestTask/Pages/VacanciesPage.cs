using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace VeeamTestTask.Pages
{
    public class VacanciesPage : CorePage
    {
        private static readonly string BaseUrl = "https://careers.veeam.ru/vacancies";

        #region WebElements

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Построй карьеру с Veeam')]")]
        private IWebElement Header { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Все отделы')]")]
        private IWebElement Departments { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Все языки')]")]
        private IWebElement Languages { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "card-no-hover")]
        private IList<IWebElement> Vacancies { get; set; }
        
        [FindsBy(How = How.Id, Using = "cookiescript_injected")]
        private IWebElement Cookies { get; set; }
        
        [FindsBy(How = How.Id, Using = "cookiescript_accept")]
        private IWebElement CookiesAcceptButton { get; set; }

        #endregion
        
        public VacanciesPage Invoke()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
            return this;
        }

        public bool IsVacanciesPageOpened()
        {
            return Header.Displayed;
        }

        public VacanciesPage SelectDepartment(string department)
        {
            CookiesAcceptButton.Click();
            Departments.Click();
            var element = Departments.FindElement(By.XPath($"//*[contains(text(),'{department}')]"));
            element.Click();
            return this;
        }
        
        public VacanciesPage SelectLanguage(string language)
        {
            Languages.Click();
            var element = Languages.FindElement(By.XPath($"//*[contains(text(),'{language}')]"));
            element.Click();
            return this;
        }

        public int CountVacancies()
        {
            return Vacancies.Count;
        }
    }
}