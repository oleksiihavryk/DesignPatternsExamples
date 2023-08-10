using AbstractFactoryPattern;

var person = new Person 
{
    Name = "Parash",
    Age = 22
};

/*Abstract factories - factories which can create multiple variations of one type of data.
 In this case there is two abstract factories which is both return one type of data IData.
 But this IData is only interface of data, in reality they are returns 
 classes implemented this IData interface. So XmlDataFactory returns XML string variation of 
 passed object and JsonDataFactory returns JSON string variation of passed object. */

var jsonFactory = CreateFactory(FactoryType.Json);
var xmlFactory = CreateFactory(FactoryType.Xml);

var jsonData = jsonFactory.CreateData(person);
var xmlData = xmlFactory.CreateData(person);

Console.WriteLine($"Json data:{Environment.NewLine}---------------------------------");
Console.WriteLine(jsonData.StringInterpretation);
Console.WriteLine("---------------------------------");

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