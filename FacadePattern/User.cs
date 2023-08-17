namespace FacadePattern;
internal class User
{
    public string Username { get; set; }
    public string? Email { get; set; }
    public decimal Money { get; set; }

    public Transaction Buy(Slot slot)
    {
        return Transaction.CreateTransaction(slot, this);
    }

    public override string ToString()
        => $"{Username}{(Email is null ? "" : $" {Email}")} and have {Money:C}";
}