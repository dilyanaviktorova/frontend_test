using examPrepFrontEndTestingPart1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public CreateIdeaPage createIdeaPage;   
        public MyIdeasPage myIdeasPage; 
        public IdeaReadPage ideaReadPage;
        public IdeasEditPage ideaEditPage;  


        [OneTimeSetUp]

        public void OneTimeSetUp()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disabled-search-engine");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login("examPrep1Demo@mail.com", "123456");

            createIdeaPage = new CreateIdeaPage(driver);
            myIdeasPage = new MyIdeasPage(driver);
            ideaReadPage = new IdeaReadPage(driver);
            ideaEditPage = new IdeasEditPage(driver);
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            driver.Quit();  
            driver.Dispose();

        }

        public string GenerateRandomString(int length)
        {
            const string chars = "asdadasfa";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
