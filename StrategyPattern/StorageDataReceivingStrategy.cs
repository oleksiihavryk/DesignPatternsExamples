namespace StrategyPattern;
internal class StorageDataReceivingStrategy : IDataReceivingStrategy
{
    private readonly Storage _storage;
    
    public Data Data => _storage.Get();

    public StorageDataReceivingStrategy(Storage storage)
    {
        _storage = storage;
    }
}