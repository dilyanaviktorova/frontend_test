﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPrepFrontEndTestingPart1.Pages
{
    public class BasePage
    {

        protected IWebDriver driver;

        protected WebDriverWait wait;

        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";


        public BasePage(IWebDriver driver)
        { 
            this.driver = driver;   
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement HomeLink => driver.FindElement(By.XPath("//img[@class='rounded-circle']"));

        public IWebElement IdeaCenterButton => driver.FindElement(By.XPath("//a[@class='nav-link']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2']"));

        public IWebElement SignUpForFreeButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3']"));

        public IWebElement MyProfileButton => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Profile']"));

        public IWebElement MyIdeasButton => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Ideas']"));

      

        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3']"));

    }
}
