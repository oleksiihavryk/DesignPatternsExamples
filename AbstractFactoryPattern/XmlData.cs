namespace AbstractFactoryPattern;

internal class XmlData : IData
{
    public Guid Id { get; init; }
    public string StringInterpretation { get; init; }

    public XmlData(string data)
    {
        StringInterpretation = data;
        Id = Guid.NewGuid();
    }

    public override string ToString() => StringInterpretation;
}