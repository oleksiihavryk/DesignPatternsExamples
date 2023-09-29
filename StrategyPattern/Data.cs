namespace StrategyPattern;
internal class Data
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Strings { get; set; } = Enumerable.Empty<string>();
}