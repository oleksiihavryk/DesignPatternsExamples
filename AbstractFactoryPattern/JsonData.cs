namespace AbstractFactoryPattern;
internal class JsonData : IData
{
    public Guid Id { get; init; }
    public string StringInterpretation { get; init; }

    public JsonData(string data)
    {
        StringInterpretation = data;
        Id = Guid.NewGuid();
    }

    public override string ToString() => StringInterpretation;
}