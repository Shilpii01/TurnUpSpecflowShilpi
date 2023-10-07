using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnupSpecflow.Pages;
using TurnupSpecflow.Utilities;

namespace TurnupSpecflow.StepDefinitions
{
    [Binding]
    public class TMPageStepDefinitions: CommonDriver
    {
        [Given(@"user logs-in to TurnUp portal")]
        public void GivenUserLogs_InToTurnUpPortal()
        {
            cdriver = new ChromeDriver();

            //LoginPage object initialization and definition
            Loginpage loginPageobj = new Loginpage();
            loginPageobj.LoginActions(cdriver);

            //HomePage object initialization and definition
            
            
        }

        [Given(@"user navigates to the time and material page")]
        public void GivenUserNavigatesToTheTimeAndMaterialPage()
        {
            Homepage homePageobj = new Homepage();
            homePageobj.GoToTMPage(cdriver);
           
            
        }

        [When(@"user creates a new time/materail record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewTimeMaterailRecord(string code, string description, string price)
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.CreateTimeRecord(cdriver, code, description, price);
        }

        [Then(@"turnup potal should saves the new record '([^']*)'")]
        public void ThenTurnupPotalShouldSavesTheNewRecord(string code)
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.verifyCreatedRecord(cdriver, code);
            
        }

        [When(@"user edits a new time/materail record '([^']*)''([^']*)' '([^']*)'")]
        public void WhenUserEditsANewTimeMaterailRecord(string updatedcode, string updateddescription, string updatedprice)
        {
            {
                TMPage tmPageobj = new TMPage();
                tmPageobj.EditTimeRecord(cdriver, updatedcode, updateddescription, updatedprice);
            }
        }


        [Then(@"turnup potal should saves the updated record '([^']*)'")]
        public void ThenTurnupPotalShouldSavesTheUpdatedRecord(string updatedcode)
            {
            TMPage tmPageobj = new TMPage();
            tmPageobj.verifyUpdatedRecord(cdriver , updatedcode);
             }
        

        [When(@"user deletes a new time/materail record")]
        public void WhenUserDeletesANewTimeMaterailRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.DeleteTimeRecord(cdriver);
        }

        [Then(@"turnup potal should delete the existing record")]
        public void ThenTurnupPotalShouldDeleteTheExistingRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.verifyDeletedRecord(cdriver);
        }
    }
}
