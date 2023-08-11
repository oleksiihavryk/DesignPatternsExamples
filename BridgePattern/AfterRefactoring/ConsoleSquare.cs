namespace BridgePattern.AfterRefactoring;

internal class ConsoleSquare : ConsoleFigure
{
    public ConsoleSquare(IFigureColorRenderer figureColor)
        : base(figureColor)
    {
    }

    protected override void Draw()
    {
        TextWriter.WriteLine(",_________," + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|         |" + Environment.NewLine +
                             "|_________|");
    }
}