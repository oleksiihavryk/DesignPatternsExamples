using SingletonPattern;

/*Singleton, object which instance is created only one in application.
 in this case, QuizApp instance is instance of whole mini application.
 Obviously if this objects would be more than one, you can have some major 
 errors in working of app.*/
var singleton = QuizApp.Instance;
singleton.Start();