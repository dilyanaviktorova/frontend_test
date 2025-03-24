using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Pages
{
    public class CreateIdeaPage : BasePage
    {
        public CreateIdeaPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Ideas/Create";


        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement AddPicture => driver.FindElement(By.XPath("//input[@id='form3Example3c']"));
        public IWebElement DescribeField => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement MainMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//ul//li"));
        public IWebElement TitleErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error']"));

        public IWebElement DescriptionErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Description field is required.']"));

        public IWebElement CreateIdeaButton => driver.FindElement(By.XPath("//a[@class='nav-link'  and text()='Create Idea']"));

        public void CreateNewIdea(string title, string imgUrl, string description) 
        { 
            TitleInput.SendKeys(title);
            AddPicture.SendKeys(imgUrl);
            DescribeField.SendKeys(description);
            CreateButton.Click();   
        }

        public void AssertErrorMessage()
        {
            Assert.True(MainMessage.Text.Equals("Unable to create new Idea!"), "The first");
            Assert.True(TitleErrorMessage.Text.Equals("The Title field is required."), "The second");
            Assert.That(DescriptionErrorMessage.Text, Is.EqualTo("The Description field is required."));

        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
