using MediatorPattern.Interfaces;

namespace MediatorPattern;

internal class MessageRepository : IMessageRepository
{
    private readonly List<Message> _messages = new List<Message>();
    private readonly ILogger _logger;

    public MessageRepository(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<Message> GetMessagesForReceiver(User user)
        => _messages.Where(m => m.To == user);
    public IEnumerable<Message> GetMessagesForSender(User user)
        => _messages.Where(m => m.From == user);
    public void SaveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messages.Add(message);
        _logger.Log("Message is saved in message repository");
    }
    public void DeleteMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messages.Remove(message);
        _logger.Log("Message is deleted from message repository");
    }
}