namespace ChainOfResponsibilityPattern;
internal class MoreThan10SymbolsRequest : SystemRequest
{
    public MoreThan10SymbolsRequest(System system) : base(system)
    {
    }

    public override string[] Handle(string[] except)
    {
        var nextExcept = System.GetStrings(s =>
            except.Contains(s) 
            || s.Length <= 10);

        return Next is null
            ? System.GetStrings(s => nextExcept.Contains(s) == false)
            : Next.Handle(nextExcept);
    }
}