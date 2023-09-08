using MediatorPattern.Interfaces;

namespace MediatorPattern;
internal class User
{
    private readonly IMessenger _messenger;

    private User(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public static User RegisterUser(
        IMessenger messenger,
        string username)
    {
        var user = new User(messenger) { Username = username };
        messenger.RegisterUser(user);
        return user;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }

    public IEnumerable<Message> ReceivedMessages => 
        _messenger.GetReceivedMessagesForUser(this);
    public IEnumerable<Message> SentMessages => 
        _messenger.GetSendedMessagesForUser(this);

    public Message SendMessageTo(User user, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return _messenger.SendMessage(this, user, text);
    }
}