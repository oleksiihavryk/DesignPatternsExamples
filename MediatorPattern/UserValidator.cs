using MediatorPattern.Constants;
using MediatorPattern.Interfaces;
using ResultNet;

namespace MediatorPattern;

internal class UserValidator : IUserValidator
{
    private readonly ILogger _logger;

    public UserValidator(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
    }

    public Result<User> Validate(User entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var errors = new List<ResultError>();
            _logger.Log("Initiate validation of user entity");

            if (UsernameIsNullOrEmpty(entity))
                errors.Add(new ResultError(
                    "Username is cannot be null or empty.",
                    ValidationErrorCodes.UsernameInvalid));

            if (errors.Any())
            {
                _logger.Log("Validation failure of message entity");
                return Result.Failure<User>().WithErrors(errors.ToArray());
            }

            _logger.Log("Validating success of user entity");
            return entity;
        }
        catch
        {
            _logger.Log("Unknown error happen when trying to validate user entity");
            throw;
        }
    }

    private bool UsernameIsNullOrEmpty(User entity)
        => string.IsNullOrWhiteSpace(entity.Username);
}