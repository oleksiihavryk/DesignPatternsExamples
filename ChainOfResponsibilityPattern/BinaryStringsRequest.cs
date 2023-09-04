namespace ChainOfResponsibilityPattern;
internal class BinaryStringsRequest : SystemRequest
{
    public BinaryStringsRequest(System system) 
        : base(system)
    {
    }

    public override string[] Handle(string[] except)
    {
        var nextExcept = System.GetStrings(s => 
            s.All(c => c is not '0' or '1') 
            || s.Length == 0 
            || except.Contains(s));

        return Next is null 
            ? System.GetStrings(s => nextExcept.Contains(s) == false) 
            : Next.Handle(nextExcept);
    }
}