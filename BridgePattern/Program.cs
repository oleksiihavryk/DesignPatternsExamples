using BridgePattern.BeforeRefactoring;
using Refactored = BridgePattern.AfterRefactoring;

/*
 So, we have some base abstract class ConsoleFigure.
 This class is intended for rendering Figures on system.
 And we creating some specific classes, ConsoleCircle and ConsoleSquare
*/
var circle = new ConsoleCircle();
var square = new ConsoleSquare();

Console.WriteLine("Circle");
circle.Render();
Padding();
Console.WriteLine("Square");
square.Render();
Padding();

/*
 * So, all works perfect. And we want to create some specific colored shapes.
 * We want create blue and red circles and squares so
 * just lets simply inherit all our shapes and create blue and red variations of it.
*/
var redCircle = new RedConsoleCircle();
var blueCircle = new BlueConsoleCircle();
var redSquare = new RedConsoleSquare();
var blueSquare = new BlueConsoleSquare();

Console.WriteLine("Red circle");
redCircle.Render();
Padding();
Console.WriteLine("Blue circle");
blueCircle.Render();
Padding();
Console.WriteLine("Red square");
redSquare.Render();
Padding();
Console.WriteLine("Blue square");
blueSquare.Render();
Padding();

/*
 Wow, now there is so many classes, and if we want to add some new feature to
 this classes there will be even much and much more. This is called as "explosion of classes".
 For remove this issue we need refactor our code. I create new folder - "After refactoring" 
 which demonstrate how classes will be look after refactoring. 
 Now we do all what we do previous but with new refactored classes.
*/

//This is bridge for providing rendering circle without changing color.
var defColor = new Refactored.DefaultFigureColorRenderer();
//This is bridge for providing rendering blue circle.
var blueColor = new Refactored.BlueFigureColorRenderer();
//This is bridge for providing rendering red circle.
var redColor = new Refactored.RedFigureColorRenderer();

var refactoredCircle = new Refactored.ConsoleCircle(defColor);
var refactoredSquare = new Refactored.ConsoleSquare(defColor);

Console.WriteLine("Refactored circle");
refactoredCircle.Render();
Padding();
Console.WriteLine("Refactored square");
refactoredSquare.Render();
Padding();

var refactoredRedCircle = new Refactored.ConsoleCircle(redColor);
var refactoredBlueCircle = new Refactored.ConsoleCircle(blueColor);
var refactoredRedSquare = new Refactored.ConsoleSquare(redColor);
var refactoredBlueSquare = new Refactored.ConsoleSquare(blueColor);

Console.WriteLine("Refactored red circle");
refactoredRedCircle.Render();
Padding();
Console.WriteLine("Refactored blue circle");
refactoredBlueCircle.Render();
Padding();
Console.WriteLine("Refactored red square");
refactoredRedSquare.Render();
Padding();
Console.WriteLine("Refactored blue square");
refactoredBlueSquare.Render();
Padding();

/*
 So, if you properly look at structure of our refactored code, bridge is liquidate
 "explosion of classes" issue in our code by making class structure more "elastic" 
 to changing color of our figures.
*/

void Padding()
{
    Console.WriteLine("\n\n\n\n\n\n\n");
}
