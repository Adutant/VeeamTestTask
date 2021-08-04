using NUnit.Framework;
using VeeamTestTask.Pages;

namespace VeeamTestTask.Tests
{
    [SetUpFixture]
    public class SetupFixture
    {
        [OneTimeTearDown]
        public void DisposeDriver()
        {
            Browser.CloseDriver();
        }
    }
}