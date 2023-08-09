namespace ProtoPattern;
internal class FacebookUsersDataStorage
{
    private readonly User _userProto = new User()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Age = 0,
        Contacts = string.Empty,
        Platform = "Facebook",
    };
    private readonly List<User> _users = new List<User>();

    public IEnumerable<User> UsersInformation => _users.Select(u => u.Clone());

    public User? GetUser(Guid id) => _users.FirstOrDefault(u => u.Id == id);
    public User AddUser(string name, int age, string contacts)
    {
        var newUser = _userProto.Clone();

        newUser.Id = Guid.NewGuid();
        newUser.Name = name;
        newUser.Age = age;
        newUser.Contacts = contacts;

        _users.Add(newUser);

        return newUser;
    }
    public bool RemoveUser(Guid id)
    {
        var user = GetUser(id);
        return _users.Remove(user ?? new User());
    }
}