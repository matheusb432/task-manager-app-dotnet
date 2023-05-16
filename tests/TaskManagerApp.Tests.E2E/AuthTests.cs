using TaskManagerApp.Tests.E2E.Models;

namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public sealed class AuthTests
    {
        private static IWebDriver _driver = null!;
        private const string _testUserName = "test_user";
        private const string _testUserPassword = "AaBb_123456";
        private const string _failPassword = "---";

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
            _driver.Quit();
            _driver.Dispose();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _driver = WebDriverUtils.InitializeTest(_driver, false);
        }

        [TestCleanup]
        public void CleanupTest() { }

        [TestMethod]
        public void Login_WithValidData_ShouldLoginAndRedirectHome()
        {
            LoginFlow(_driver);

            Assert.AreEqual(PageUrls.HomeUrl, _driver.Url);
        }

        [TestMethod]
        public void Login_WithInvalidData_ShouldNotRedirect()
        {
            FailedLoginFlow(_driver);
            Assert.AreEqual(PageUrls.LoginUrl, _driver.Url);
        }

        [TestMethod]
        public void LoginAndLogout_ShouldRedirectToLogin()
        {
            LoginFlow(_driver);
            Assert.AreEqual(PageUrls.HomeUrl, _driver.Url);

            LogoutFlow(_driver);
            Assert.AreEqual(PageUrls.LoginUrl, _driver.Url);
        }

        [TestMethod]
        public void SignupAndLogoutAndLogin_ShouldRedirectToLogin()
        {
            var signup = SignupFlow(_driver);
            Assert.AreEqual(PageUrls.HomeUrl, _driver.Url);

            LogoutFlow(_driver);
            Assert.AreEqual(PageUrls.LoginUrl, _driver.Url);

            LoginFlow(_driver, LoginForm.FromSignup(signup));
            Assert.AreEqual(PageUrls.HomeUrl, _driver.Url);
        }

        public static SignupForm SignupFlow(IWebDriver _driver)
        {
            var userName = WebDriverUtils.RandomString();
            var password = WebDriverUtils.RandomString() + "aA_1";
            var email = WebDriverUtils.RandomString(5) + "@example.com";
            var signup = SignupForm.AsValid("test user", userName, password, email);

            _driver.Navigate().GoToUrl(PageUrls.SignupUrl);

            _driver.FindElementWithWait(By.Id("cSignupFormUserName")).Clear();
            _driver.FindElementWithWait(By.Id("cSignupFormUserName")).SendKeys(signup.UserName);
            _driver.FindElementWithWait(By.Id("cSignupFormPassword")).Clear();
            _driver.FindElementWithWait(By.Id("cSignupFormPassword")).SendKeys(signup.Password);
            _driver.FindElementWithWait(By.Id("cSignupFormName")).Clear();
            _driver.FindElementWithWait(By.Id("cSignupFormName")).SendKeys(signup.Name);
            _driver.FindElementWithWait(By.Id("cSignupFormEmail")).Clear();
            _driver.FindElementWithWait(By.Id("cSignupFormEmail")).SendKeys(signup.Email);
            _driver.FindElementWithWait(By.Id("cSignupFormConfirmPassword")).Clear();
            _driver
                .FindElementWithWait(By.Id("cSignupFormConfirmPassword"))
                .SendKeys(signup.ConfirmPassword);
            _driver.FindElementWithWait(By.Id("cSignupSubmit")).Click();

            WebDriverUtils.WaitUntilRedirected(_driver, PageUrls.HomeUrl);

            return signup;
        }

        public static void LoginFlow(IWebDriver _driver, LoginForm? login = null)
        {
            login ??= LoginForm.AsValid(_testUserName, _testUserPassword);
            var password = login.Password;

            _driver.Navigate().GoToUrl(PageUrls.LoginUrl);
            _driver.FindElementWithWait(By.Id("cLoginFormUserNameOrEmail")).Clear();
            _driver
                .FindElementWithWait(By.Id("cLoginFormUserNameOrEmail"))
                .SendKeys(login.UserNameOrEmail);
            _driver.FindElementWithWait(By.Id("cLoginFormPassword")).Clear();
            _driver.FindElementWithWait(By.Id("cLoginFormPassword")).SendKeys(login.Password);
            _driver.FindElementWithWait(By.Id("cLoginSubmit")).Click();

            if (password != _failPassword)
                WebDriverUtils.WaitUntilRedirected(_driver, PageUrls.HomeUrl);
        }

        public static void FailedLoginFlow(IWebDriver _driver)
        {
            LoginFlow(_driver, LoginForm.AsValid(_testUserName, _failPassword));
        }

        public static void LogoutFlow(IWebDriver _driver)
        {
            _driver.FindElementWithWait(By.Id("cMainHeaderLogout")).Click();
            _driver.FindElementWithWait(By.Id("cModalConfirmConfirm")).Click();
            WebDriverUtils.WaitUntilRedirected(_driver, PageUrls.LoginUrl);
        }
    }
}
