using MediatorPattern.Exceptions;
using MediatorPattern.Interfaces;
using ResultNet;

namespace MediatorPattern;

internal class Messenger : IMessenger
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;
    private readonly IMessageValidator _messageValidator;
    private readonly ILogger _logger;

    public Messenger()
        : this(new Logger())
    {
    }

    public Messenger(ILogger logger)
        : this(logger, new UserRepository(logger))
    {
    }
    public Messenger(ILogger logger, IUserRepository userRepository)
        : this(
            logger,
            new MessageRepository(logger),
            userRepository,
            new UserValidator(logger),
            new MessageValidator(logger, userRepository))
    {
    }
    public Messenger(
        ILogger logger,
        IMessageRepository messageRepository, 
        IUserRepository userRepository,
        IUserValidator userValidator,
        IMessageValidator messageValidator)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(messageRepository);
        ArgumentNullException.ThrowIfNull(userRepository);
        ArgumentNullException.ThrowIfNull(userValidator);
        ArgumentNullException.ThrowIfNull(messageValidator);

        _logger = logger;
        _messageRepository = messageRepository;
        _userRepository = userRepository;
        _userValidator = userValidator;
        _messageValidator = messageValidator;
    }

    public User RegisterUser(User user)
    {
        try
        {
            var validationResult = _userValidator.Validate(user);

            if (validationResult.IsFailure())
                throw new ValidationException(validationResult.Errors
                    .Select(e => e.Message)
                    .ToArray());

            _logger.Log("Initiate registration of user in messenger");
            var registeredUser = _userRepository.Register(user);
            _logger.Log("User is registered successfully");
            return registeredUser;
        }
        catch 
        {
            _logger.Log("Unknown error occurred in text while registering user");
            throw;
        }
    }
    public void DeleteUser(User user)
    {
        try
        {
            _logger.Log("Initiate deletion of user from messenger");
            _userRepository.Delete(user);
            _logger.Log("User is deleted successfully");
        }
        catch
        {
            _logger.Log("Unknown error occurred in text while deleting user");
            throw;
        }
    }
    public Message SendMessage(User from, User to, string text)
    {
        try
        {
            _logger.Log(
                "Initiate sending message from one to another user from messenger");
            var message = new Message()
            {
                From = from,
                To = to,
                Text = text,
                Date = DateTime.Now
            };

            var validationResult = _messageValidator.Validate(message);

            if (validationResult.IsFailure())
                throw new ValidationException(validationResult.Errors
                    .Select(e => e.Message)
                    .ToArray());

            _messageRepository.SaveMessage(message);
            _logger.Log("User is send message successfully");
            return message;
        }
        catch
        {
            _logger.Log("Unknown error occurred in text while sending message");
            throw;
        }
    }
    public IEnumerable<Message> GetReceivedMessagesForUser(User user)
    {
        try
        {
            _logger.Log(
                "Initiate request of received messages from messenger");
            var messages = _messageRepository.GetMessagesForReceiver(user);
            _logger.Log("Received messages is successfully requested from messenger");
            return messages;
        }
        catch
        {
            _logger.Log(
                "Unknown error occurred in text while requesting received messages");
            throw;
        }
    }
    public IEnumerable<Message> GetSendedMessagesForUser(User user)
    {
        try
        {
            _logger.Log(
                "Initiate request of received messages from messenger");
            var messages = _messageRepository.GetMessagesForSender(user);
            _logger.Log("Received messages is successfully requested from messenger");
            return messages;
        }
        catch
        {
            _logger.Log(
                "Unknown error occurred in text while requesting received messages");
            throw;
        }
    }
}