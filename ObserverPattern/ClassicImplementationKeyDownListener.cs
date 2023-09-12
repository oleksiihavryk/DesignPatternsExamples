namespace ObserverPattern;
internal class ClassicImplementationKeyDownListener
{
    private readonly KeyPressObserver _observer = new KeyPressObserver();
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
    public void AddHandler(ISubscriber subscriber)
        => _observer.AddSubscriber(subscriber);
    public void RemoveHandler(ISubscriber subscriber)
        => _observer.RemoveSubscriber(subscriber);

    private async Task ListenAsync()
        => await Task.Factory.StartNew(() =>
        {
            while (_isListening)
            {
                Console.ReadKey();
                _observer.Notify();
            }
        });
}