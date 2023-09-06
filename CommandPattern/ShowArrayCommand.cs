namespace CommandPattern;
internal class ShowArrayCommand<T> : ICommand
{
    private readonly T[] _array;

    public ShowArrayCommand(T[] array)
    {
        _array = array;
    }

    public void Execute()
    {
        foreach (var i in _array)
            Console.WriteLine(i);
    }
}