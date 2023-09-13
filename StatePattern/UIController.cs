namespace StatePattern;

internal class UIController : IUIController
{
    private IUIState? _state;

    public UIController(IUIState state)
    {
        _state = state;
    }

    public static UIController CreateDefault() => new(
        new MainUIState());

    

    public void Initiate()
    {
        IUIState? state;

        do
        {
            state = _state?.GetNext();
            _state = state;
        } while (_state is not null);
    }
}