namespace MediatorPattern.Interfaces;

internal interface IUserRepository
{
    User GetUserById(Guid id);
    User Register(User user);
    void Delete(User user);
}