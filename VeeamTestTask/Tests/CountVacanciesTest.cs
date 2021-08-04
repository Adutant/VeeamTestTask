using NUnit.Framework;
using VeeamTestTask.Pages;

namespace VeeamTestTask.Tests
{
    [TestFixture]
    public class CountVacanciesTest
    {
        private readonly VacanciesPage _vacanciesPage = new VacanciesPage();

        [TestCase("Разработка продуктов", "Английский", 6)]
        public void CountVacancies(string department, string language, int expectedCount)
        {
            _vacanciesPage.Invoke();
            
            Assert.IsTrue(_vacanciesPage.IsVacanciesPageOpened(), "Page isn't opened");

            _vacanciesPage
                .SelectDepartment(department)
                .SelectLanguage(language);

            var vacanciesCount = _vacanciesPage.CountVacancies();
            Assert.AreEqual(expectedCount, vacanciesCount, "Count of vacancies isn't correct");
        }
    }
}