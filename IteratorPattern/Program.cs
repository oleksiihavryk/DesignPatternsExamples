/*
 * Iterator pattern like a "Command" and many other behavioral patterns build-in for C# language.
 * Almost all collection in .NET framework class library have interface IEnumerable
 * such as List<T>, Stack<T>, Queue<T>, Dictionary<TKEy, TValue> and ect.
 */
var list = new List<int> { 1, 2, 3, 100 };

//There is IEnumerator interface is Iterator pattern.
Console.WriteLine("Build-in FCL implementation of Iterator pattern.");
var enumerator = list.GetEnumerator();
try
{
    int num;
    while (enumerator.MoveNext())
    {
        num = enumerator.Current;
        Console.WriteLine(num);
    } 
}
finally
{
    enumerator.Dispose();
}
//or just use build-in foreach loop (same code when compiled as previous)
Console.WriteLine("foreach loop.");
foreach (var item in list)
    Console.WriteLine(item);

