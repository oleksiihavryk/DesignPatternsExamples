using FacadePattern.Exceptions;

namespace FacadePattern;
internal class Transaction
{
    private const string SlotIsSoldMessage = "The buyer cannot purchase a slot " +
                                             "as it has already been sold.";
    private const string NotEnoughMoneyMessage = "Buyer has not enough money to purchase a slot.";

    private readonly object _lockObj = new object();

    public Slot Slot { get; set; }
    public User Buyer { get; set; }

    private Transaction(Slot slot, User buyer)
    {
        ArgumentNullException.ThrowIfNull(slot);
        ArgumentNullException.ThrowIfNull(buyer);

        Slot = slot;
        Buyer = buyer;
    }

    public static (bool IsPerformed, Transaction? Transaction) TryCreateTransaction(
        Slot slot, 
        User buyer)
    {
        try
        {
            var transaction = CreateTransaction(slot, buyer);
            return (true, transaction);
        }
        catch (TransactionException)
        {
            return (false, null);
        }
    }
    public static Transaction CreateTransaction(Slot slot, User buyer)
    {
        var transaction = new Transaction(slot, buyer);
        transaction.Perform();
        return transaction;
    }

    private void Perform()
    {
        lock (_lockObj)
        {
            if (Buyer.Money < Slot.Product.Cost) 
                throw new TransactionException(NotEnoughMoneyMessage);
            if (Slot.IsSold) 
                throw new TransactionException(SlotIsSoldMessage);

            Buyer.Money -= Slot.Product.Cost;
            Slot.Product.Owner.Money += Slot.Product.Cost;
            Slot.IsSold = true;
        }
    }

    public override string ToString()
        => $"{Buyer.Username} buy a slot with product - {Slot.Product.Name} from {Slot.Product.Owner.Username} by {Slot.Product.Cost:C}";
}