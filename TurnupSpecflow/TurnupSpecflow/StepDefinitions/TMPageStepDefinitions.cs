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
        Homepage homePageobj = new Homepage();
        Loginpage loginPageobj = new Loginpage();
        TMPage tmPageobj = new TMPage();


        [Given(@"user logs-in to TurnUp portal")]
         public void GivenUserLogs_InToTurnUpPortal()
         {
            cdriver = new ChromeDriver();

            //LoginPage object initialization and definition
           
            loginPageobj.LoginActions(cdriver);

            //HomePage object initialization and definition
            
            
         }

        [Given(@"user navigates to the time and material page")]
        public void GivenUserNavigatesToTheTimeAndMaterialPage()
        {
          
            homePageobj.GoToTMPage(cdriver);
           
            
        }

        [When(@"user creates a new time/materail record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewTimeMaterailRecord(string code, string description, string price)
        {
            
            tmPageobj.CreateTimeRecord(cdriver, code, description, price);
        }

        [Then(@"turnup potal should saves the new record '([^']*)'")]
        public void ThenTurnupPotalShouldSavesTheNewRecord(string code)
        {
           
            tmPageobj.verifyCreatedRecord(cdriver, code);
            
        }

        [When(@"user edits a new time/materail record '([^']*)''([^']*)' '([^']*)'")]
        public void WhenUserEditsANewTimeMaterailRecord(string updatedcode, string updateddescription, string updatedprice)
        {
            {
               
                tmPageobj.EditTimeRecord(cdriver, updatedcode, updateddescription, updatedprice);
            }
        }


        [Then(@"turnup potal should saves the updated record '([^']*)'")]
        public void ThenTurnupPotalShouldSavesTheUpdatedRecord(string updatedcode)
            {
            
            tmPageobj.verifyUpdatedRecord(cdriver , updatedcode);
             }
        

        [When(@"user deletes a new time/materail record")]
        public void WhenUserDeletesANewTimeMaterailRecord()
        {
          
            tmPageobj.DeleteTimeRecord(cdriver);
        }

        [Then(@"turnup potal should delete the existing record")]
        public void ThenTurnupPotalShouldDeleteTheExistingRecord()
        {
           
            tmPageobj.verifyDeletedRecord(cdriver);
        }
    }
}
