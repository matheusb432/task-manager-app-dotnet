using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace TaskManagerApp.Tests.E2E.Utils
{
    internal static class WebDriverUtils
    {
        public static readonly string InitialUrl = "data:,";
        public static readonly string DefaultUrl = "http://localhost:4200/";
        public static readonly string HomeUrl = $"{DefaultUrl}/home";
        public static readonly double WaitTime = 5;
        public static readonly int TimeoutMs = 100;

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int? timeoutInMs = null)
        {
            Thread.Sleep(timeoutInMs ?? TimeoutMs);

            return new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime))
                      .Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void SetDriverScreenSize(IWebDriver driver, int width = 1920, int height = 1080)
            => driver.Manage().Window.Size = new System.Drawing.Size(width, height);

        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}