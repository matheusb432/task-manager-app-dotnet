using SeleniumExtras.WaitHelpers;

namespace TaskManagerApp.Tests.E2E.Utils
{
    internal static class WebDriverUtils
    {
        public static readonly string InitialUrl = "data:,";

        public static readonly double WaitTime = 5;

        /// <summary>
        /// Waits for an element to be clickable before trying to find it, this extension method serves to prevent
        /// stale element reference exceptions and wait for API calls on elements that depend on external data
        /// </summary>
        /// <param name="driver">The webdriver</param>
        /// <param name="by">The element locator</param>
        /// <param name="timeoutInMs">A timeout before the driver tries to get the method</param>
        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int timeoutInMs = 1)
        {
            Thread.Sleep(timeoutInMs);

            return GetWait(driver, WaitTime)
                      .Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void SetDriverScreenSize(IWebDriver driver, int width = 1366, int height = 768)
            => driver.Manage().Window.Size = new System.Drawing.Size(width, height);

        public static void MaximizeWindow(IWebDriver driver) => driver.Manage().Window.Maximize();

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            var wait = GetWait(driver);
            bool elementNotExists = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));

            return !elementNotExists;
        }

        public static INavigation Navigate(this IWebDriver driver, int waitTime, string urlMatch = "")
        {
            if (!string.IsNullOrEmpty(urlMatch)) UrlMatches(driver, waitTime, urlMatch);

            return driver.Navigate();
        }

        public static void AwaitDebounce(int sleepTime = 500) => Thread.Sleep(sleepTime);

        public static void UrlMatches(IWebDriver driver, int waitTime = 5, string urlMatch = "")
            => GetWait(driver, waitTime)
                .Until(ExpectedConditions.UrlMatches(urlMatch));

        public static void WaitUntilRedirected(IWebDriver driver, string url)
            => UrlMatches(driver, 5, url);

        public static WebDriverWait GetWait(IWebDriver driver, double? waitSeconds = null)
            => new(driver, TimeSpan.FromSeconds(waitSeconds ?? WaitTime));

        public static void NavigateToHome(this IWebDriver driver)
            => driver.Navigate().GoToUrl(PageUrls.HomeUrl);

        public static IWebDriver ResetDriver(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();

            return new ChromeDriver();
        }

        public static IWebDriver InitializeTest(IWebDriver driver, bool withAuth = true)
        {
            if (!driver.Url.Equals(InitialUrl))
            {
                driver = ResetDriver(driver);
                MaximizeWindow(driver);
            }
            if (withAuth) Authenticate(driver);
            else driver.NavigateToHome();

            return driver;
        }

        public static string GetUrlWithoutParams(IWebDriver driver)
        {
            var url = driver.Url;
            var uri = new Uri(url);

            if (uri == null) return string.Empty;

            return uri.GetLeftPart(UriPartial.Path);
        }

        public static void WaitForUrlChange(this IWebDriver driver)
        {
            var currentUrl = driver.Url;

            GetWait(driver).Until(d => !d.Url.Equals(currentUrl));
        }

        public static string GetQueryParam(IWebDriver driver, string paramKey)
        {
            var url = driver.Url;
            var uri = new Uri(url);

            if (uri == null) return string.Empty;

            return System.Web.HttpUtility.ParseQueryString(uri.Query).Get(paramKey) ?? string.Empty;
        }

        public static void Authenticate(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrls.LoginUrl);
            AuthTests.LoginFlow(driver);
            WaitUntilRedirected(driver, PageUrls.HomeUrl);
        }

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