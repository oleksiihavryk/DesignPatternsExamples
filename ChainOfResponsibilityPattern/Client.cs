namespace ChainOfResponsibilityPattern;
internal class Client
{
    public string GetData(ISystemRequest request) => string.Join(
        separator: ',', 
        value: request.Handle(Array.Empty<string>()));
}