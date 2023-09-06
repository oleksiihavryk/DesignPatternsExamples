using CommandPattern;
using System;

//Command pattern is pattern for operating methods with unified signature as an objects.
var array = new[] { "1", "2", "3", "3", "3" };
var copyArray = new string[array.Length];
array.CopyTo(copyArray, 0);

//This pattern have an implementation in c# language.

//This is an old way of using command pattern with the implementation of a single executing.
Console.WriteLine("This is an old way of using command pattern " +
                  "with the implementation of a single executing");

var deleteRepeating = new DeleteRepeatingInArrayCommand<string>(array);
var show = new ShowArrayCommand<string>(array);

Console.WriteLine("Old array: ");
show.Execute();

Console.WriteLine("Delete all repeating elements in array!");
deleteRepeating.Execute();

Console.WriteLine("New array: ");
show.Execute();

//This is a modern way of using command pattern with the implementation of a single execution.
Console.WriteLine("This is a modern way of using command pattern with " +
                  "the implementation of a single execution."); ;

var deleteRepeatingLambda = () =>
{
    var newArray = copyArray.Distinct().ToArray();
    for (int i = 0; i < copyArray.Length; i++)
    {
        copyArray[i] = default;
    }
    newArray.CopyTo(copyArray, 0);

};
var showLambda = () =>
{
    foreach (var i in copyArray)
        Console.WriteLine(i);
};


Console.WriteLine("Old array: ");
showLambda.Invoke();

Console.WriteLine("Delete all repeating elements in array!");
deleteRepeatingLambda();

Console.WriteLine("New array: ");
showLambda();