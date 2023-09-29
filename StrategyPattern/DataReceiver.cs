namespace StrategyPattern;
internal class DataReceiver
{
    public IDataReceivingStrategy Strategy { private get; set; }

    public Data ReceiveData() => Strategy.Data;
}