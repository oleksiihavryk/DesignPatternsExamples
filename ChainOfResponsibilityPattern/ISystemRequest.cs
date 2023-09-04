namespace ChainOfResponsibilityPattern;

internal interface ISystemRequest
{
    ISystemRequest SetNext(ISystemRequest request);
    string[] Handle(string[] except);
}