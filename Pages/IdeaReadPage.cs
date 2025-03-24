using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Pages
{
    public class IdeaReadPage : BasePage
    {
        public IdeaReadPage(IWebDriver driver) : base(driver) 
        {
        }

        public string Url = BaseUrl + "/Ideas/Read";
        public IWebElement IdeaTitle => driver.FindElement(By.XPath("//h1[@class='mb-0 h4']"));
        public IWebElement IdeaDescription => driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));

    
    }
}
