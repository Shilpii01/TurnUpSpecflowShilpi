using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupSpecflow.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver cdriver, string code, string description, string price)
        {
            //Click on the Create new button for creating a new record in the time & materials module
            IWebElement createnewbutton = cdriver.FindElement(By.XPath("//a[contains(text(),'Create New')]"));
            createnewbutton.Click();

            //Select the type code 

            IWebElement tnmoption = cdriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            tnmoption.Click();
            Thread.Sleep(1000);

            IWebElement tmoption = cdriver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            tmoption.Click();

            //Enter the code in the Code textbox
            IWebElement codetxtbox = cdriver.FindElement(By.Id("Code"));
            codetxtbox.SendKeys(code);

            // Enter description in the description textbox
            IWebElement descriptiontxtbox = cdriver.FindElement(By.Id("Description"));
            descriptiontxtbox.SendKeys(description);


            //Enter the price per unit for the new record
            IWebElement pricetxtbox = cdriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricetxtbox.SendKeys(price);

            //Click on the Save button 
            IWebElement savebutton = cdriver.FindElement(By.Id("SaveButton"));
            savebutton.Click();

            Thread.Sleep(6000);
        }

        public void verifyCreatedRecord( IWebDriver cdriver, string code)
        {
            //Check whether the new record is created successfully 
            IWebElement lastpagebutton = cdriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();

            IWebElement newrecord = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
                Assert.That(newrecord.Text == code , "No record found");

                cdriver.Quit();


        }

            
        
        public void EditTimeRecord(IWebDriver cdriver , string updatedcode, string updateddescription, string updatedprice)
        {
            // Go to last Page 
            IWebElement lastpagebutton = cdriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();

            //Edit the new created record
            IWebElement editbutton = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editbutton.Click();

            //Edit the type code to material from time
            IWebElement editTypecode = cdriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            editTypecode.Click();
            Thread.Sleep(1000);

            IWebElement edit1Typecode = cdriver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            edit1Typecode.Click();

            //Edit the code textbox 
            IWebElement editcodetextbox = cdriver.FindElement(By.Id("Code"));
            editcodetextbox.Clear();
            editcodetextbox.SendKeys(updatedcode);

            //Edit the description textbox
            IWebElement editdescriptiontextbox = cdriver.FindElement(By.Id("Description"));
            editdescriptiontextbox.Clear();
            editdescriptiontextbox.SendKeys(updateddescription);
            Thread.Sleep(2000);

            //Edit price textbox
            IWebElement editpriceoverlappingtag = cdriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpricetextbox = cdriver.FindElement(By.Id("Price"));
            editpriceoverlappingtag.Click();
            editpricetextbox.Clear();
            editpriceoverlappingtag.Click();

            editpricetextbox.SendKeys(updatedprice);

            //Download the edited record 
            IWebElement downloadbutton = cdriver.FindElement(By.Id("downloadButton"));
            downloadbutton.Click();

            //Save the edited record
            IWebElement editsavebutton = cdriver.FindElement(By.Id("SaveButton"));
            editsavebutton.Click();

            Thread.Sleep(4000);
        }

        public void verifyUpdatedRecord(IWebDriver cdriver, string updatedcode)
        {
            //Check if the last record is edited successfully 
            IWebElement endpagebutton = cdriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            endpagebutton.Click();

            IWebElement editedrecord = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(editedrecord.Text == updatedcode, "record has not been edited");
            cdriver.Quit();
        }





        public void DeleteTimeRecord(IWebDriver cdriver)
        {
            // Go to last Page 
            IWebElement lastpagebutton = cdriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();

            //Delete the last created record
            IWebElement deletebutton = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletebutton.Click();
            cdriver.SwitchTo().Alert().Accept();

            //Check if the record is deleted
            IWebElement endpgbutton = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            endpgbutton.Click();

            Thread.Sleep(2000);
        }

        public void verifyDeletedRecord(IWebDriver cdriver)
        {
            IWebElement deletedrecord = cdriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
                Assert.That(deletedrecord.Text != "Edited code", "record has not been deleted ");
                cdriver.Quit();

        }

            
        
    }
}
