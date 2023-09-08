using MediatorPattern.Constants;
using MediatorPattern.Interfaces;
using ResultNet;

namespace MediatorPattern;

internal class MessageValidator : IMessageValidator
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;

    public MessageValidator(
        ILogger logger, 
        IUserRepository userRepository)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(userRepository);

        _logger = logger;
        _userRepository = userRepository;
    }

    public Result<Message> Validate(Message entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var errors = new List<ResultError>();
            _logger.Log("Initiate validation of message entity");

            if (UserIsNotRegistered(entity.To))
                errors.Add(new ResultError(
                    "Receiver is not registered in messenger.",
                    ValidationErrorCodes.ReceiverUnregistered));

            if (UserIsNotRegistered(entity.From))
                errors.Add(new ResultError(
                    "Sender is not registered in messenger.",
                    ValidationErrorCodes.SenderUnregistered));

            if (TextIsNullOrEmpty(entity.Text))
                errors.Add(new ResultError(
                    "Text of message is cannot be null or empty.",
                    ValidationErrorCodes.MessageTextInvalid));

            if (DateBiggerThanCurrentDate(entity.Date))
                errors.Add(new ResultError(
                    "Date of message sending is cannot be bigger than current date.",
                    ValidationErrorCodes.IncorrectMessageTime));

            if (errors.Any())
            {
                _logger.Log("Validation failure of message entity");
                return Result.Failure<Message>().WithErrors(errors.ToArray());
            }

            _logger.Log("Validating success of message entity");
            return entity;
        }
        catch
        {
            _logger.Log("Unknown error happen when trying to validate message entity");
            throw;
        }
    }

    private bool DateBiggerThanCurrentDate(DateTime entityDate) => entityDate > DateTime.Now;
    private bool TextIsNullOrEmpty(string text) => string.IsNullOrWhiteSpace(text);
    private bool UserIsNotRegistered(User user)
    {
        var registeredUser = _userRepository.GetUserById(user.Id);
        return registeredUser != user;
    }
}