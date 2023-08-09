namespace ProtoPattern;
internal class User : IPrototype<User>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Platform { get; set; }
    public string Contacts { get; set; }
    

    public User Clone()
    {
        return new User
        {
            Id = Id,
            Name = Name,
            Age = Age,
            Platform = Platform,
            Contacts = Contacts,
        };
    }
}