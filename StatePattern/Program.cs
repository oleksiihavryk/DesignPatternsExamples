using StatePattern;

/*
 The "State" pattern is a behavioral pattern which
 use composition to achieve a certain behavior.
 This pattern is allow to invoke different behaviour by unified interface 
 which depends of object who use this pattern.
*/

/*
 In this case, there is an object of the UIController class which is used inside 
 the IUIState interface which represents itself as a part of the "State" pattern.
*/
var ui = UIController.CreateDefault();
var app = new Application(ui);

app.Start();