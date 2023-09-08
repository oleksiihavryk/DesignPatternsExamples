using ResultNet;

namespace MediatorPattern.Interfaces;

internal interface IValidator<T>
{
    Result<T> Validate(T entity);
}