namespace ChainOfResponsibilityPattern;
internal class System
{
    private readonly string[] _strings;

    public System(string[] strings)
    {
        _strings = strings;
    }

    public string[] GetStrings(Func<string, bool> predicate)
        => _strings.Where(predicate).ToArray();
}