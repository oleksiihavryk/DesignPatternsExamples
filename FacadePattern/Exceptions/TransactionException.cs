namespace FacadePattern.Exceptions;

public class TransactionException : Exception
{
    public override string Message => base.Message ??
                                      "Transaction currently is unavailable to perform. " +
                                      "Check inner exceptions to get more details about error.";

    public TransactionException(string? message = null)
        : base(message)
    {
    }
    public TransactionException(string? message, Exception? inner = null)
        : base(message, inner)
    {
    }
}