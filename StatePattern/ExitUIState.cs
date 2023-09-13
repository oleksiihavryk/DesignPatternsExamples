namespace StatePattern;
internal class ExitUIState : IUIState
{
    public IUIState? GetNext()
    {
        Console.Clear();
        Console.WriteLine("Goodbye!");
        return null;
    }
}