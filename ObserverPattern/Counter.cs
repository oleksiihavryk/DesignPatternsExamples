namespace ObserverPattern;
internal class Counter
{
    public int Count { get; private set; } = default;

    public void Increment() => Count++;
}