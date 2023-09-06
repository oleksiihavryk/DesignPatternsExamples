namespace CommandPattern;
internal class DeleteRepeatingInArrayCommand<T> : ICommand
{
    private readonly T[] _array;

    public DeleteRepeatingInArrayCommand(T[] array)
    {
        _array = array;
    }

    public void Execute()
    {
        var newArray = _array.Distinct().ToArray();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = default(T);
        }
        newArray.CopyTo(_array, 0);
    }
}