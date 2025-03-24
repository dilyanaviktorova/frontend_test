using examPrepFrontEndTestingPart1.Pages;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Tests
{
    public class IdeaCenterTest : BaseTest
    {
        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;

        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {

           createIdeaPage.CreateIdeaButton.Click();

           createIdeaPage.CreateNewIdea("", "", "");

           createIdeaPage.AssertErrorMessage();
        }


        [Test, Order(2)]
        public void CreateIdeaWithValidDataTest()
        {
            lastCreatedIdeaTitle = "Idea " + GenerateRandomString(5);
            lastCreatedIdeaDescription = "Description " + GenerateRandomString(5);

            createIdeaPage.CreateIdeaButton.Click();

            createIdeaPage.CreateNewIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

             var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

             wait.Until(driver => driver.Url == myIdeasPage.Url);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Is not correct your URL");

            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Descriptions not match");
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        {
            myIdeasPage.MyIdeasButton.Click();
            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideaReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Title wrong");
            Assert.That(ideaReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description wrong");

        }

        [Test, Order(4)]
        public void EditIdeaTitleTest()
        {
            myIdeasPage.MyIdeasButton.Click();
            myIdeasPage.EditButtonLastIdea.Click();

            string updatedTitle = "Change Title:" + lastCreatedIdeaTitle;


            ideaEditPage.TitleInput.Clear();
            ideaEditPage.TitleInput.SendKeys(updatedTitle);   
            ideaEditPage.EditButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
     .Until(d => d.Url == myIdeasPage.Url);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL problem again");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideaReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(updatedTitle), "TITLE wrong");

        }

        [Test, Order(5)]
        public void EditIdeaDescriptionTest()
        {
            myIdeasPage.MyIdeasButton.Click();
            myIdeasPage.EditButtonLastIdea.Click();

            string updatedDescription = "Change Description:" + lastCreatedIdeaDescription;


            ideaEditPage.DescribeField.Clear();
            ideaEditPage.DescribeField.SendKeys(updatedDescription);

            ideaEditPage.EditButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
    .Until(d => d.Url == myIdeasPage.Url);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL problem again");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideaReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(updatedDescription), "TITLE wrong");

        }

        [Test, Order(6)]
        public void DeleteLastIdeaTest()
        {
            myIdeasPage.MyIdeasButton.Click();
            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIDeaDeleted = myIdeasPage.IdeasCards.All(card => card.Text.Contains(lastCreatedIdeaDescription));

            Assert.IsFalse(isIDeaDeleted, "Idea is not deleted");


        }


    }
}
