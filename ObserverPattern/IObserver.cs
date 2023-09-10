namespace ObserverPattern;
internal interface IObserver
{
    public void AddSubscriber(ISubscriber subscriber);
    public void RemoveSubscriber(ISubscriber subscriber);
    public void Notify();
}