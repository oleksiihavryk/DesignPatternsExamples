namespace MementoPattern;
internal class History
{
    private readonly IOriginator _originator;
    private readonly Stack<IMemento> _backMementos = new Stack<IMemento>();
    private readonly Stack<IMemento> _onwardMementos = new Stack<IMemento>();

    public History(IOriginator originator)
    {
        _originator = originator;
    }

    public IMemento? Current { get; private set; }
    public IEnumerable<IMemento> CurrentHistory
    {
        get
        {
            var total = new List<IMemento>();

            foreach (var m in _backMementos)
                total.Add(m);
            foreach (var m in _onwardMementos)
                total.Add(m);

            return total;
        }
    }

    public void UpToDate()
    {
        for (int i = 0; i < _onwardMementos.Count; i++) Forward();
    }
    public void Back()
    {
        if (_backMementos.TryPop(out var memento))
        {
            if (Current is not null) _onwardMementos.Push(Current);
            Current = memento;
            Current?.Restore();
        }
    }
    public void Forward()
    { 
        if (_onwardMementos.TryPop(out var memento))
        {
            if (Current is not null) _backMementos.Push(Current);
            Current = memento;
            Current?.Restore();
        }
    }
    public void MakeSave()
    {
        var memento = _originator.Save();
        if (Current is not null) _backMementos.Push(Current);
        Current = memento;
        _onwardMementos.Clear();
    }
}