using AbstractFactoryPattern;

var person = new Person()
{
    Name = "Parash",
    Age = 22
};

var jsonFactory = CreateFactory(FactoryType.Json);
var jsonData = jsonFactory.CreateData(person);

Console.WriteLine($"Json data:{Environment.NewLine}---------------------------------");
Console.WriteLine(jsonData.StringInterpretation);
Console.WriteLine("---------------------------------");

var xmlFactory = CreateFactory(FactoryType.Xml);
var xmlData = xmlFactory.CreateData(person);

Console.WriteLine($"Xml data:{Environment.NewLine}---------------------------------");
Console.WriteLine(xmlData.StringInterpretation);
Console.WriteLine("---------------------------------");


DataFactory CreateFactory(FactoryType type)
    => type switch
    {
        FactoryType.Json => new JsonDataFactory(),
        FactoryType.Xml => new XmlDataFactory(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
public enum FactoryType
{
    Json,
    Xml
}