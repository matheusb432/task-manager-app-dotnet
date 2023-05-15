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
            // TODO create new user on initialization
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

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

            Console.WriteLine(date);

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
            driver.FindElementWithWait(By.Id("cTimesheetFormNote0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote0")).SendKeys("Test note");

            WebDriverUtils.ScrollToBottom(driver.FindElementWithWait(By.Id("cTimesheetFormNote0")));

            driver.FindElementWithWait(By.Id("cFormArrayAddNote")).Click();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormNote1")).SendKeys("Note 2");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTitle0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTitle0")).SendKeys("Task 1");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskComment0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskComment0")).SendKeys("Comment 1");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime0")).SendKeys("10:30");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskRating0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskRating0")).SendKeys("5");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskImportance0")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskImportance0")).SendKeys("3");

            WebDriverUtils.ScrollToBottom(driver.FindElementWithWait(By.Id("cTimesheetFormTaskImportance0")));

            driver.FindElementWithWait(By.Id("cFormArrayAddTask")).Click();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTitle1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTitle1")).SendKeys("Task 2");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskComment1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskComment1")).SendKeys("...");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).SendKeys("03:00");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).SendKeys("03:03");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskTime1")).SendKeys("03:30");
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskRating1")).Clear();
            driver.FindElementWithWait(By.Id("cTimesheetFormTaskRating1")).SendKeys("3");
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