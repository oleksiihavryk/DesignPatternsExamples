using System.Diagnostics;
using System.Runtime.CompilerServices;
using ProxyPattern;

/*
 * The proxy pattern and decorator pattern are similar in structure,
 * but they have different purposes of usage.
 * Decorator pattern is change or extend functionality of decorable object,
 * otherwise Proxy pattern is add new functionality before or after execution
 * of object which get through proxy.
 * In this example we adding cache functionality to class of our application which read data from
 * text document.
 */

var textDocument = new TextDocument("text1");
var cachedTextDocument = new CacheTextDocument(new TextDocument("text2"));

var handles = typeof(Application).GetMethods().Select(m => m.MethodHandle);
foreach (var handle in handles)
    RuntimeHelpers.PrepareMethod(handle);

var res1 = Application.GetTimeOfExecutionDefaultVersion(textDocument);
var res2 = Application.GetTimeOfExecutionCachedVersion(cachedTextDocument);

Console.WriteLine($"Time of execution default version - {res1} milliseconds");
Console.WriteLine($"Time of execution cached version - {res2} milliseconds");
if (res2 < res1)
Console.WriteLine("Caching mechanism is work!");

internal static class Application
{
    private static readonly object _lockObj = new object();
    private static readonly Stopwatch _timer = new Stopwatch();
    private static readonly int ExecNumber = 1000;

    public static long GetTimeOfExecutionCachedVersion(CacheTextDocument cacheTextDocument)
    {
        long res = 0;
        lock (_lockObj)
        {
            _timer.Start();
            int i = ExecNumber;
            while (i-- > 0) Console.WriteLine(cacheTextDocument.Data);
            _timer.Stop();
            res = _timer.ElapsedMilliseconds;
            Console.Clear();
            _timer.Reset();
        }
        return res;
    }
    public static long GetTimeOfExecutionDefaultVersion(TextDocument textDocument)
    {
        long res = 0;
        lock (_lockObj)
        {
            _timer.Start();
            int i = ExecNumber;
            while (i-- > 0) Console.WriteLine(textDocument.Data);
            _timer.Stop();
            res = _timer.ElapsedMilliseconds;
            Console.Clear();
            _timer.Reset();
        }
        return res;
    }
}
