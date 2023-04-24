namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public class HomeTests
    {
        private static IWebDriver _driver = null!;
        public static readonly string Url = PageUrls.HomeUrl;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _driver = new ChromeDriver();

            WebDriverUtils.SetDriverScreenSize(_driver);
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _driver = WebDriverUtils.InitializeTest(_driver);
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

        [TestMethod]
        public void Navigate_WithCards_ShouldRedirectToPages()
        {
            NavigateCard(_driver, "cCardTimesheet", PageUrls.TimesheetsUrl);
            NavigateCard(_driver, "cCardProfile", PageUrls.ProfilesUrl);
            NavigateCard(_driver, "cCardMetric", PageUrls.MetricsUrl);

            WebDriverUtils.WaitUntilRedirected(_driver, Url);
            Assert.AreEqual(Url, _driver.Url);
        }

        [TestMethod]
        public void Navigate_WithNavItems_ShouldRedirectToPages()
        {
            NavigateNavItem(_driver, "cNavItemsButtonTimesheets", PageUrls.TimesheetsUrl);
            NavigateNavItem(_driver, "cNavItemsButtonProfiles", PageUrls.ProfilesUrl);
            NavigateNavItem(_driver, "cNavItemsButtonMetrics", PageUrls.MetricsUrl);

            WebDriverUtils.WaitUntilRedirected(_driver, Url);
            Assert.AreEqual(Url, _driver.Url);
        }

        public static void NavigateCard(IWebDriver _driver, string elementId, string expectedUrl)
        {
            _driver.FindElementWithWait(By.Id(elementId)).Click();
            WebDriverUtils.WaitUntilRedirected(_driver, expectedUrl);
            Assert.AreEqual(expectedUrl, _driver.Url);
            _driver.NavigateToHome();
        }

        public static void NavigateNavItem(IWebDriver _driver, string elId, string expectedUrl)
        {
            NavigateCard(_driver, elId, expectedUrl);
        }
    }
}