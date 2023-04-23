using System.Text;

namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public class ProfileTests
    {
        private static IWebDriver _driver = null!;
        private StringBuilder _verificationErrors = null!;
        private static readonly string _baseURL = WebDriverUtils.DefaultUrl;

        public static readonly string ProfilesUrl = $"{_baseURL}/profiles";

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
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        [TestMethod]
        public void NavigateToProfiles_ShouldRedirectToProfilesPage()
        {
            _driver.Navigate().GoToUrl(_baseURL);
            _driver.FindElement(By.Id("cCardProfile")).Click();
            // TODO add better wait
            Thread.Sleep(100);
            Assert.AreEqual(ProfilesUrl, _driver.Url);
        }
    }
}