namespace ObserverPattern;
internal class BuildInImplementationKeyDownListener
{
    public event EventHandler<EventArgs> Observer;

    private bool _isListening = false;
    private Task? _currentTask;

    public async Task StartListeningAsync()
    {
        _isListening = true;
        _currentTask ??= ListenAsync();
        await Task.CompletedTask;
    }
    public async Task StopListeningAsync()
    {
        _isListening = false;
        if (_currentTask is not null)
        {
            await _currentTask;
            _currentTask = null;
        }
    }

    private async Task ListenAsync()
        => await Task.Factory.StartNew(() =>
        {
            while (_isListening)
            {
                Console.ReadKey();
                Observer(this, EventArgs.Empty);
            }
        });
}