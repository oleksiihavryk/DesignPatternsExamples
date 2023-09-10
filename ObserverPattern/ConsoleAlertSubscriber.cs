namespace ObserverPattern;
internal class ConsoleAlertSubscriber : ISubscriber
{
    public void NotifyOn() => Console.WriteLine("Alert!!! Some event happened!");
}