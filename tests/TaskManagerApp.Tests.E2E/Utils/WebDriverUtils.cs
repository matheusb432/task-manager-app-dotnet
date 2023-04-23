using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace TaskManagerApp.Tests.E2E.Utils
{
    internal static class WebDriverUtils
    {
        public static readonly string InitialUrl = "data:,";
        public static readonly double WaitTime = 5;
        public static readonly int TimeoutMs = 100;

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int? timeoutInMs = null)
        {
            Thread.Sleep(timeoutInMs ?? TimeoutMs);

            return new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime))
                      .Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void SetDriverScreenSize(IWebDriver driver, int width = 1366, int height = 768)
            => driver.Manage().Window.Size = new System.Drawing.Size(width, height);

        public static void MaximizeWindow(IWebDriver driver) => driver.Manage().Window.Maximize();

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

        public static INavigation Navigate(this IWebDriver driver, int waitTime, string urlMatch = "")
        {
            if (!string.IsNullOrEmpty(urlMatch)) UrlMatches(driver, waitTime, urlMatch);

            return driver.Navigate();
        }

        public static void AwaitDebounce(int sleepTime = 500) => Thread.Sleep(sleepTime);

        public static void UrlMatches(IWebDriver driver, int waitTime = 5, string urlMatch = "")
            => new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime))
                .Until(ExpectedConditions.UrlMatches(urlMatch));

        public static void WaitUntilRedirected(IWebDriver driver, string url)
            => UrlMatches(driver, 5, url);

        public static void NavigateToHome(this IWebDriver driver)
            => driver.Navigate().GoToUrl(PageUrls.HomeUrl);

        /// <summary>
        /// Utility method to scroll to the bottom of the page, needs an input to use the PageDown key since the JavascriptExecutor
        /// appears to not be working with the latest version of ChromeDriver
        /// </summary>
        /// <param name="el">Any input box element</param>
        public static void ScrollToBottom(IWebElement el)
        {
            el.SendKeys(Keys.PageDown);
            Thread.Sleep(500);
        }

        public static void ScrollToTop(IWebElement el)
        {
            el.SendKeys(Keys.PageUp);
            Thread.Sleep(500);
        }

        public static string RandomString(int length = 10, bool includeLetters = true, bool includeNumbers = true)
        {
            var rand = new Random();
            var chars = "";

            if (includeLetters) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (includeNumbers) chars += "0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        public static int RandInt(int min, int max)
        {
            var rand = new Random();

            return rand.Next(min + 1, max);
        }
    }
}