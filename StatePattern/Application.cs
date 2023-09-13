namespace StatePattern;
internal class Application
{
    private readonly IUIController _ui;

    public Application(IUIController ui)
    {
        _ui = ui;
    }

    public void Start()
    {
        _ui.Initiate();
    }
    public void Stop()
    {
        Environment.Exit(0);
    }
}