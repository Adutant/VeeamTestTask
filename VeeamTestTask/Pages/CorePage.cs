using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace VeeamTestTask.Pages
{
    public abstract class CorePage
    {
        protected static IWebDriver Driver { get { return Browser.Driver; } }
        
        protected CorePage()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}