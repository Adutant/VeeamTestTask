using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VeeamTestTask.Pages
{
    public static class Browser
    {
        private static IWebDriver _driver = null;

        /// <summary>
        /// Возвращает WebDriver    
        /// Если Driver создан, и браузер открыт – возвращаем ссылку на него.  
        /// Если Driver еще не инициализирован – создает новый инстанс WebDriver'а
        /// </summary>
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    var options = new ChromeOptions();
                    //отключаем "chrome is being controlled by automated test software disable"
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddExcludedArgument("enable-automation");
                    _driver = new ChromeDriver(options);
                }
                return _driver;
            }
        }

        /// <summary>
        /// Закрывает инстанс WebDriver и окно браузера
        /// </summary>
        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}