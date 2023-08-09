using Newtonsoft.Json;

namespace AbstractFactoryPattern;

internal class JsonDataFactory : DataFactory
{
    public override JsonData CreateData<T>(T obj) where T: class
    {
        var json = JsonConvert.SerializeObject(obj);
        return new JsonData(json);
    }
}