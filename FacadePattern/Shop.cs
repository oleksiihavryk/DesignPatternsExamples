namespace FacadePattern;
internal class Shop : IShop
{
    private readonly List<User> _users = new List<User>();
    private readonly List<Slot> _slots = new List<Slot>();

    public User RegisterUser(string username, string? email = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);

        var user = new User { Email = email, Username = username, Money = 0m };
        _users.Add(user);
        return user;
    }
    public Slot RegisterSlot(User user, string name, decimal cost, string? description = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        if (_users.FirstOrDefault(u => ReferenceEquals(u, user)) is null)
            throw new ArgumentException(nameof(user));
        if (cost <= 0) throw new ArgumentException(nameof(cost));

        var product = new Product { Cost = cost, Description = description, 
            Name = name, Owner = user };
        var slot = new Slot { Product = product, IsSold = false };
        _slots.Add(slot);
        return slot;
    }
    public Transaction Buy(User user, Slot slot)
    {
        if (_users.FirstOrDefault(u => ReferenceEquals(u, user)) is null) 
            throw new ArgumentException(nameof(user));
        if (_slots.FirstOrDefault(s => ReferenceEquals(s, slot)) is null)
            throw new ArgumentException(nameof(slot));

        _slots.Remove(slot);
        return user.Buy(slot);
    }
}

internal interface IShop
{
    User RegisterUser(string username, string? email = null);
    Slot RegisterSlot(User user, string name, decimal cost, string? description = null);
    Transaction Buy(User user, Slot slot);
}