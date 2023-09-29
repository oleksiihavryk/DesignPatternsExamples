namespace StrategyPattern;
internal class MockDataReceivingStrategy : IDataReceivingStrategy
{
    public const string MockDataName = "mock_name";
    public const string MockDataString = "mock_string1";

    public Data Data => new() { Name = MockDataName, Strings = new [] { MockDataString } };
}