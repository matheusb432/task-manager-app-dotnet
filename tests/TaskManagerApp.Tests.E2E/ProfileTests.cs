namespace TaskManagerApp.Tests.E2E
{
    [TestClass]
    public class ProfileTests
    {
        private static IWebDriver _driver = null!;
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
            _driver = WebDriverUtils.InitializeTest(_driver);

            _driver.Navigate(5, PageUrls.HomeUrl).GoToUrl(PageUrls.ProfilesUrl);
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

        [TestMethod]
        public void CreateProfile_WithValidData_ShouldCreateProfile()
        {
            var nameBy = By.Id("cProfileFormName");
            var name = CreateProfileFlow(_driver, nameBy);

            var nameInput = _driver.FindElementWithWait(nameBy);

            Assert.IsNotNull(nameInput);
            Assert.AreEqual(nameInput.GetAttribute("value"), name);
        }

        [TestMethod]
        public void CreateAndUpdateProfile_WithValidData_ShouldUpdateCreatedProfile()
        {
            var nameBy = By.Id("cProfileFormName");
            var updatedName = UpdateProfileFlow(_driver, nameBy);

            var nameInput = _driver.FindElementWithWait(nameBy);

            Assert.IsNotNull(nameInput);
            Assert.AreEqual(nameInput.GetAttribute("value"), updatedName);
        }

        [TestMethod]
        public void CreateAndDeleteProfile_WithValidData_ShouldDeleteCreatedProfile()
        {
            var nameBy = By.Id("cProfileFormName");
            var name = CreateProfileFlow(_driver, nameBy);

            DeleteProfile(_driver);

            SearchProfileList(_driver, name);

            var elementExists = _driver.ElementExists(By.Id("cTableEditIcon0"));

            Assert.IsFalse(elementExists);
        }

        public static string CreateProfileFlow(IWebDriver _driver, By nameBy)
        {
            _driver.FindElementWithWait(By.Id("cProfilesButtonCreate")).Click();

            var name = FillProfileForm(_driver, nameBy);

            SubmitProfile(_driver);

            GoToEditProfile(_driver, name);

            return name;
        }

        public static string UpdateProfileFlow(IWebDriver _driver, By nameBy)
        {
            var name = CreateProfileFlow(_driver, nameBy);

            const string updateSuffix = " -- EDIT";
            var updatedName = name + updateSuffix;
            _driver.FindElementWithWait(nameBy).SendKeys(updateSuffix);

            SubmitProfile(_driver);
            GoToEditProfile(_driver, updatedName);

            return updatedName;
        }

        public static void SubmitProfile(IWebDriver _driver)
        {
            var submitBtn = _driver.FindElementWithWait(By.Id("cProfileFormSubmit"));
            WebDriverUtils.ScrollToBottom(submitBtn);
            submitBtn.Click();
            _driver.FindElementWithWait(By.Id("cModalConfirmConfirm")).Click();
        }

        public static void DeleteProfile(IWebDriver _driver)
        {
            var deleteBtn = _driver.FindElementWithWait(By.Id("cProfileFormDelete"));
            WebDriverUtils.ScrollToBottom(deleteBtn);
            deleteBtn.Click();
            _driver.FindElementWithWait(By.Id("cModalConfirmConfirm")).Click();
        }

        public static void GoToEditProfile(IWebDriver _driver, string name)
        {
            SearchProfileList(_driver, name);

            var icon = _driver.FindElementWithWait(By.Id("cTableEditIcon0"));
            WebDriverUtils.ScrollToTop(_driver.FindElementWithWait(By.Id("cProfilesButtonCreate")));
            icon.Click();
        }

        public static string FillProfileForm(IWebDriver _driver, By nameBy)
        {
            var name = WebDriverUtils.RandomString(20, true, false);

            _driver.FindElementWithWait(nameBy).SendKeys(name);
            _driver.FindElementWithWait(By.Id("cProfileFormTimeTarget")).SendKeys("15:30");
            _driver.FindElementWithWait(By.Id("cProfileFormTasksTarget")).SendKeys("5");
            _driver.FindElementWithWait(By.Id("cProfileFormPriority")).SendKeys("2");

            var typeSelect = _driver.FindElementWithWait(By.Id("cProfileFormType"));
            WebDriverUtils.ScrollToBottom(typeSelect);
            typeSelect.Click();

            _driver.FindElementWithWait(By.Id("cProfileFormTypeOption1")).Click();

            return name;
        }

        public static void SearchProfileList(IWebDriver _driver, string name)
        {
            _driver.FindElementWithWait(By.Id("cProfileListNameFilter")).Clear();
            _driver.FindElementWithWait(By.Id("cProfileListNameFilter")).SendKeys(name);
            _driver.FindElementWithWait(By.Id("cProfileListNameFilter")).SendKeys(Keys.Enter);
        }
    }
}