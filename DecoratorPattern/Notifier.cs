namespace DecoratorPattern;

internal interface INotifier
{
    public void NotifyOn(object? obj, MessageEventArgs args);
}
internal class Notifier : INotifier
{
    public virtual void NotifyOn(object? obj, MessageEventArgs args)
    {
        Console.WriteLine("Message was caught by default notifier!");
        Console.WriteLine($"[{DateTime.Now:g}] {args.Message}");
    }
}
internal abstract class BaseNotifierDecorator : INotifier
{
    protected INotifier Notifier { get; set; }

    protected BaseNotifierDecorator(INotifier notifier)
    {
        Notifier = notifier;
    }

    public abstract void NotifyOn(object? obj, MessageEventArgs args);
}
internal class ConsoleNotifierDecorator : BaseNotifierDecorator
{
    public ConsoleNotifierDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void NotifyOn(object? obj, MessageEventArgs args)
    {
        Console.WriteLine("Message was caught by decorator of notifier.");       
        Notifier.NotifyOn(this, args);
    }
}