// define CLASSIC or BUILDIN to get your wanted implementation 
#define BUILDIN 

using ObserverPattern;
/*
 * Observer pattern have a build-in implementation in c# language.
 * In this example, I show you a classical and build-in implementations of this pattern.
 */



//There is a classical OOP implementation of this pattern without any argument.
var counter = new Counter();

Console.WriteLine($"Counter: {counter.Count}");

var obs1 = new KeyPressObserver();
var cis1 = new CounterIncrementerSubscriber(counter);
var cas1 = new ConsoleAlertSubscriber();

obs1.AddSubscriber(cis1);
obs1.AddSubscriber(cas1);
#if CLASSIC
while (true)
{
    Console.ReadKey();
    obs1.Notify();
    Console.WriteLine($"Counter: {counter.Count}");
}

#endif
//This is a in-build c# language implementation of the Observer pattern.
var obs2 = new BuildInObserverExample();

obs2.Observer += (_, _) => counter.Increment();
obs2.Observer += (_, _) => Console.WriteLine("Alert!!! Some event happened!");
#if BUILDIN
while (true)
{
    Console.ReadKey();
    obs2.Notify();
    Console.WriteLine($"Counter: {counter.Count}");
}

#endif

class BuildInObserverExample
{
    public event EventHandler<EventArgs> Observer;

    public void Notify() => Observer(null, EventArgs.Empty);
}