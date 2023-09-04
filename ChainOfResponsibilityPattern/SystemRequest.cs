namespace ChainOfResponsibilityPattern;

internal abstract class SystemRequest : ISystemRequest
{
    protected System System { get; set; }
    protected ISystemRequest? Next { get; set; } = null;

    protected SystemRequest(System system)
    {
        System = system;
    }

    public ISystemRequest SetNext(ISystemRequest request)
    {
        Next = request;
        return this;
    }
    public abstract string[] Handle(string[] except);
}