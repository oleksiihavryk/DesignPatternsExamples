namespace MediatorPattern.Interfaces;

internal interface IMessenger
{
    User RegisterUser(User user);
    void DeleteUser(User user);
    Message SendMessage(User from, User to, string text);
    IEnumerable<Message> GetReceivedMessagesForUser(User user);
    IEnumerable<Message> GetSendedMessagesForUser(User user);
}