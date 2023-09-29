namespace StrategyPattern;
internal class Storage
{
    private Data _data;

    public Storage(Data data)
    {
        ArgumentNullException.ThrowIfNull(data);

        _data = data;
    }
    public Storage()
    {
    }

    public Data Get() => _data ?? throw new InvalidOperationException(
        message: "There is no data in this storage.");
    public void Save(Data data) => _data = data;

}