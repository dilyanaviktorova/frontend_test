using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Pages
{
    public class IdeasEditPage : BasePage
    {

        public IdeasEditPage(IWebDriver driver) : base(driver) 
        { 
        }

        public string Url = BaseUrl + "/Ideas/Create";
        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement AddPicture => driver.FindElement(By.XPath("//input[@id='form3Example3c']"));
        public IWebElement DescribeField => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

     


    }

}
