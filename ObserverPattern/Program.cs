using ObserverPattern;
/*
 * Observer pattern have a build-in implementation in c# language.
 * In this example, I show you a classical and build-in implementations of this pattern.
 */



var counter = new Counter();

var cis = new CounterIncrementerSubscriber(counter);
var cas = new ConsoleAlertSubscriber();

//There is a classical OOP implementation of this pattern without any argument.
var oh1 = new ClassicImplementationKeyDownListener();
oh1.AddHandler(cis);
oh1.AddHandler(cas);

//This is a in-build c# language implementation of the Observer pattern.
var oh2 = new BuildInImplementationKeyDownListener();

//In this parameter of EventHandler constructor can be also
//a method with EventHandler delegate signature.
var cisHandler = new EventHandler<EventArgs>((_, _) => cis.NotifyOn());
var casHandler = new EventHandler<EventArgs>((_, _) => cas.NotifyOn());

oh2.Observer += cisHandler;
oh2.Observer += casHandler;

oh1.StartListeningAsync();
Console.WriteLine("Now working a classical example of the observer pattern. " +
                  "Minimal working time: 10s.");
await Task.Delay(10000);
await oh1.StopListeningAsync();
Console.WriteLine("Working of a first example is stopped.");

var classicalButtonPressed = counter.Count;
Console.WriteLine($"Count of pressing buttons: {classicalButtonPressed}");

oh1.RemoveHandler(cis);
oh1.RemoveHandler(cas);

Console.WriteLine("Now working a build-in implementation example of the observer pattern. " +
                  "Minimal working time: 10s.");
oh2.StartListeningAsync();
await Task.Delay(10000);
await oh2.StopListeningAsync();
Console.WriteLine("Working of a second example is stopped.");

Console.WriteLine($"Count of pressing buttons: {counter.Count - classicalButtonPressed}");