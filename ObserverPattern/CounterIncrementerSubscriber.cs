namespace ObserverPattern;
internal class CounterIncrementerSubscriber : ISubscriber
{
    public Counter Counter { get; set; }

    public CounterIncrementerSubscriber(Counter counter)
    {
        Counter = counter;
    }

    public void NotifyOn() => Counter.Increment();
}