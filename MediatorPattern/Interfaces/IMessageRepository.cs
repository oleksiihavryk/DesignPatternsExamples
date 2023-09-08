namespace MediatorPattern.Interfaces;

internal interface IMessageRepository
{
    IEnumerable<Message> GetMessagesForReceiver(User user);
    IEnumerable<Message> GetMessagesForSender(User user);
    void SaveMessage(Message message);
    void DeleteMessage(Message message);
}