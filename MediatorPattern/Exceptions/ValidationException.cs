using System.Collections;
using MediatorPattern.Constants;

namespace MediatorPattern.Exceptions;
internal class ValidationException : Exception
{
    private readonly string[] _errors;

    public ValidationException(
        string[] errors,
        string? message = null)
        : this(errors, message, null)
    {
    }
    public ValidationException(
        string[] errors,
        string? message,
        Exception? inner)
        : base(message, inner)
    {
        _errors = errors;
    }

    public override IDictionary Data => new Dictionary<string, string[]>()
    {
        ["Errors"] = _errors,
    };
    public override string Message => base.Message ?? ExceptionDefaultMessages.ValidationException;
}