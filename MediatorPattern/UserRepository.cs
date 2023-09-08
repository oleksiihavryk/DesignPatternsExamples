using MediatorPattern.Interfaces;

namespace MediatorPattern;

internal class UserRepository : IUserRepository
{
    private readonly ILogger _logger;
    private readonly List<User> _users = new List<User>();

    public UserRepository(ILogger logger)
    {
        _logger = logger;
    }

    public User GetUserById(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id)
                   ?? throw new ArgumentException(nameof(id));
        _logger.Log($"Get user by identifier: {id}");
        return user;
    }
    public User Register(User user)
    {
        if (user.Id == Guid.Empty || _users.Any(u => u.Id == user.Id))
            user.Id = Guid.NewGuid();

        _users.Add(user);
        _logger.Log("User is added to repository");

        return user;
    }
    public void Delete(User user)
    {
        _users.Remove(user);
        _logger.Log("User is removed from repository");
    }
}