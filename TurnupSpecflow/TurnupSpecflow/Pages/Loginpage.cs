using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupSpecflow.Pages
{
    public class Loginpage
    {
        public void LoginActions(IWebDriver cdriver)
        {
            cdriver.Manage().Window.Maximize();

            //Launch turnup portal and navigate to login page 
            cdriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

            //Identify Username textbox and enter valid username
            IWebElement usernametxtbox = cdriver.FindElement(By.Id("UserName"));
            usernametxtbox.SendKeys("hari");

            //Identify password textbox and enter valid password
            IWebElement passwordtxtbox = cdriver.FindElement(By.Id("Password"));
            passwordtxtbox.SendKeys("123123");

            //Identify login button and click on the button
            IWebElement loginbutton = cdriver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginbutton.Click();
        }
    }
}
