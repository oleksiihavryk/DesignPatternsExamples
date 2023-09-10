namespace ObserverPattern;
internal class KeyPressObserver : IObserver
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void AddSubscriber(ISubscriber subscriber) => _subscribers.Add(subscriber);
    public void RemoveSubscriber(ISubscriber subscriber) => _subscribers.Remove(subscriber);
    public void Notify()
    {
        foreach (var s in _subscribers)
            s.NotifyOn();
    }
}