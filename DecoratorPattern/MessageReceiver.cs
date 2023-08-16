namespace DecoratorPattern;
internal class MessageReceiver
{
    private readonly INotifier _notifier;

    public EventHandler<MessageEventArgs>? MessageReceived { get; set; }

    private MessageReceiver(INotifier notifier)
    {
        _notifier = notifier;
    }

    public static MessageReceiver CreateReceiver(INotifier notifier)
    {
        var res = new MessageReceiver(notifier);
        res.MessageReceived += notifier.NotifyOn;
        return res;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("Message is passed to receiver!");
        MessageReceived?.Invoke(this, new MessageEventArgs { Message = message });
    }
}