namespace MediatorPattern;
internal struct Message
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public User From { get; set; }
    public User To { get; set; }
}