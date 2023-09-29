/* So, the Strategy pattern is a pattern like the State pattern,
 * but strategy objects do not know about other strategy objects and 
 * they dynamical "swapping" depends on some external handler while in 
 * the State pattern state objects automatically inside themselves 
 * invoke or return other state object.
 */

using StrategyPattern;

//This is context object of the Strategy pattern.
var receiver = new DataReceiver();

/* This is a strategy object. The strategy of receiving data from this object is
 * just to get a constant string for a name property and one constant string
 * for a strings property of the Data class.
 */
var mockDataStrategy = new MockDataReceivingStrategy();

//By this property strategy is changing dynamically inside the context.
receiver.Strategy = mockDataStrategy;
var data1 = receiver.ReceiveData();

Console.WriteLine("Data which received from receiver with " +
                  "the MockDataReceivingStrategy class.");
ShowData(data1);

var storage = new Storage(new()
{
    Name = "Some storage data name", 
    Strings = new[] { "1", "2", "3" }
});
/* This is also a strategy object. The strategy of receiving data from this object is just
 * to get a Data object what contains inside of a storage which passed
 * through this object constructor.
 */
var storageDataStrategy = new StorageDataReceivingStrategy(storage);

receiver.Strategy = storageDataStrategy;
var data2 = receiver.ReceiveData();

Console.WriteLine("Data which received from receiver with " +
                  "the StorageDataReceivingStrategy class.");
ShowData(data2);
void ShowData(Data data)
{
    Console.Write($"Name: {data.Name} | Strings: [");
    var strings = data.Strings.ToArray();
    for (int i = 0; i < strings.Length; i++)
        Console.Write($"{strings[i]}{(i != strings.Length - 1 ? ", " : "")}");
    Console.WriteLine("].");
}

