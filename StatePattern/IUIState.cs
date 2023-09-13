namespace StatePattern;

internal interface IUIState
{
    public IUIState? GetNext();
}