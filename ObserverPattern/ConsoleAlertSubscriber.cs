namespace ObserverPattern;
internal class ConsoleAlertSubscriber : ISubscriber
{
    public void NotifyOn() => Console.WriteLine(" <- WOW! This button is pressed!!!");
}