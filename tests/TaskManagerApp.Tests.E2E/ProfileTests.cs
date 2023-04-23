using System.Text;
using TaskManagerApp.Tests.E2E.Utils;

namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public class ProfileTests
    {
        private static IWebDriver _driver = null!;
        private StringBuilder _verificationErrors = null!;
        public static readonly string Url = PageUrls.ProfilesUrl;

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
            _driver.Dispose();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _verificationErrors = new StringBuilder();
            _driver.NavigateToHome();
            _driver.Navigate(5, PageUrls.HomeUrl).GoToUrl(PageUrls.ProfilesUrl);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        [TestMethod]
        public void CreateProfile_WithValidData_ShouldCreateProfile()
        {
            _driver.FindElementWithWait(By.Id("cProfilesButtonCreate")).Click();

            var name = FillProfileForm(_driver);

            _driver.FindElementWithWait(By.Id("cProfileFormSubmit")).Click();
            _driver.FindElementWithWait(By.Id("cModalConfirmConfirm")).Click();

            var createdIcon = _driver.FindElementWithWait(By.Id("cTableDuplicateIcon1"));
            WebDriverUtils.ScrollToTop(_driver.FindElementWithWait(By.Id("cProfilesButtonCreate")));
            // TODO add IDs to list icons
            createdIcon.Click();

            // TODO add assertion after implementing list search logic
            Assert.IsTrue(true);
        }

        public static string FillProfileForm(IWebDriver _driver)
        {
            var name = WebDriverUtils.RandomString(20, true, false);
            
            _driver.FindElementWithWait(By.Id("cProfileFormName")).SendKeys(name);
            _driver.FindElementWithWait(By.Id("cProfileFormTimeTarget")).SendKeys("15:30");
            _driver.FindElementWithWait(By.Id("cProfileFormTasksTarget")).SendKeys("5");
            _driver.FindElementWithWait(By.Id("cProfileFormPriority")).SendKeys("2");

            var typeSelect = _driver.FindElementWithWait(By.Id("cProfileFormType"));
            WebDriverUtils.ScrollToBottom(typeSelect);
            typeSelect.Click();

            _driver.FindElementWithWait(By.Id("cProfileFormTypeOption1")).Click();

            return name;
        }
    }
}