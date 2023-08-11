namespace BridgePattern.BeforeRefactoring;

internal class ConsoleSquare : ConsoleFigure
{
    public override void Render()
    {
        TextWriter.WriteLine(",_________," + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|_________|");
    }
}