Feature: TMPage related tests

Scenario: A. Create a new Time and Material Record 
Given user logs-in to TurnUp portal 
And user navigates to the time and material page 
When user creates a new time/materail record 
Then turnup potal should saves the new record 

Scenario Outline: B. Edit an existing Time and Material Record 
Given user logs-in to TurnUp portal 
And user navigates to the time and material page 
When user edits a new time/materail record 
Then turnup potal should saves the updated record 

Scenario: C. Delete an existing Time and Material Record 
Given user logs-in to TurnUp portal 
And user navigates to the time and material page 
When user deletes a new time/materail record 
Then turnup potal should delete the existing record 