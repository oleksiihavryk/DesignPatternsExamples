namespace AbstractFactoryPattern;
internal abstract class DataFactory
{
    public abstract IData CreateData<T>(T obj) where T: class;
}