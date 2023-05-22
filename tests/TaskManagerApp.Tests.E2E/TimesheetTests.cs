namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public sealed class TimesheetTests
    {
        private static IWebDriver _driver = null!;
        public static readonly string Url = PageUrls.ProfilesUrl;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _driver = new ChromeDriver();

            WebDriverUtils.MaximizeWindow(_driver);
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

            _driver.Navigate(5, PageUrls.HomeUrl).GoToUrl(PageUrls.TimesheetsUrl);
        }

        [TestCleanup]
        public void CleanupTest() { }

        [TestMethod]
        public void CreateTimesheet_WithValidData_ShouldCreateTimesheet()
        {
            CreateTimesheetFlow(_driver);

            if (!_driver.Url.Contains(PageUrls.TimesheetDetailsUrl))
            {
                WebDriverUtils.WaitForUrlChange(_driver);
            }

            var url = WebDriverUtils.GetUrlWithoutParams(_driver);

            Assert.AreEqual(url, PageUrls.TimesheetDetailsUrl);
        }

        public static string CreateTimesheetFlow(IWebDriver _driver)
        {
            GoToCreateTimesheet(_driver);
            var date = WebDriverUtils.GetQueryParam(_driver, "date");

            FillTimesheetForm(_driver);

            SubmitTimesheet(_driver);

            GoToEditTimesheetViaCreateRedirection(_driver, date);

            return date;
        }

        public static void SubmitTimesheet(IWebDriver _driver)
        {
            var submitBtn = _driver.FindElementWithWait(By.Id("cTimesheetFormSubmit"));
            WebDriverUtils.ScrollToBottom(submitBtn);
            submitBtn.Click();
            _driver.FindElementWithWait(By.Id("cModalConfirmConfirm")).Click();

            WebDriverUtils.WaitForUrlChange(_driver);
        }

        public static void FillTimesheetForm(IWebDriver driver)
        {
            driver.FindElementWithWait(By.Id("cTimesheetFormNote0Note")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote0Note")).SendKeys("Test note");

            WebDriverUtils.ScrollToBottom(driver.FindElementWithWait(By.Id("cTimesheetFormNote0")));

            driver.FindElementWithWait(By.Id("cFormArrayAddNote")).Click();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote1Note")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote1Note")).SendKeys("Note 2");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Title")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Title")).SendKeys("Task 1");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Comment")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Comment")).SendKeys("Comment 1");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Time")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Time")).SendKeys("10:30");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Rating")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Rating")).SendKeys("5");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Importance")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask0Importance")).SendKeys("3");

            WebDriverUtils.ScrollToBottom(
                driver.FindElementWithWait(By.Id("cTimesheetFormTask0Importance"))
            );

            driver.FindElementWithWait(By.Id("cFormArrayAddTask")).Click();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Title")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Title")).SendKeys("Task 2");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Comment")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Comment")).SendKeys("...");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).SendKeys("03:00");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).SendKeys("03:03");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Time")).SendKeys("03:30");
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Rating")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTask1Rating")).SendKeys("3");
        }

        public static void GoToCreateTimesheet(IWebDriver driver, string date = "")
        {
            var urlSuffix = string.IsNullOrEmpty(date) ? "" : $"?date={date}";
            driver.Navigate().GoToUrl($"{PageUrls.TimesheetsUrl}/create{urlSuffix}");
        }

        public static void GoToEditTimesheetViaCreateRedirection(IWebDriver driver, string date)
        {
            GoToCreateTimesheet(driver, date);
        }
    }
}
