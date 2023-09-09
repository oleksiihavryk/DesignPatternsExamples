using System.Collections;

namespace MementoPattern;
internal class NumbersStorage : IOriginator, ICollection<int>
{
    private List<int> _numbers;

    public NumbersStorage()
        : this(Array.Empty<int>())
    {
    }
    public NumbersStorage(IEnumerable<int> numbers)
    {
        _numbers = numbers.Distinct().ToList();
    }

    public int Count => _numbers.Count;
    public bool IsReadOnly => false;

    public IMemento Save() => new NumbersStorageMemento(this, new List<int>(_numbers));
    public void Add(int item)
    {
        if (_numbers.Contains(item) == false)
            _numbers.Add(item);
    }
    public void Clear() => _numbers.Clear();
    public bool Contains(int item) => _numbers.Contains(item);
    public void CopyTo(int[] array, int arrayIndex) => _numbers.CopyTo(array, arrayIndex);
    public bool Remove(int item) => _numbers.Remove(item);
    public IEnumerator<int> GetEnumerator() => _numbers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class NumbersStorageMemento : IMemento
    {
        private readonly NumbersStorage _numbersStorage;
        private readonly List<int> _state;

        public NumbersStorageMemento(
            NumbersStorage numbersStorage, 
            List<int> state)
        {
            _numbersStorage = numbersStorage;
            _state = state;
        }

        public void Restore() => _numbersStorage._numbers = _state;
    }
}