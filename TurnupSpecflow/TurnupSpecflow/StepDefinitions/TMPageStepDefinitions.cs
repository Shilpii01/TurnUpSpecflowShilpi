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

        [When(@"user creates a new time/materail record")]
        public void WhenUserCreatesANewTimeMaterailRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.CreateTimeRecord(cdriver);
        }

        [Then(@"turnup potal should saves the new record")]
        public void ThenTurnupPotalShouldSavesTheNewRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.verifyCreatedRecord(cdriver);
        }

        [When(@"user edits a new time/materail record")]
        public void WhenUserEditsANewTimeMaterailRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.EditTimeRecord(cdriver);
        }

        [Then(@"turnup potal should saves the updated record")]
        public void ThenTurnupPotalShouldSavesTheUpdatedRecord()
        {
            TMPage tmPageobj = new TMPage();
            tmPageobj.verifyUpdatedRecord(cdriver);
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
