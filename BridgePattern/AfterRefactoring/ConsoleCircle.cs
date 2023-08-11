namespace BridgePattern.AfterRefactoring;

internal class ConsoleCircle : ConsoleFigure
{
    public ConsoleCircle(IFigureColorRenderer figureColor) 
        : base(figureColor)
    {
    }

    protected override void Draw()
    {
        TextWriter.WriteLine(
            "                   *** ### ### ***\r\n               *##                 ##*\r\n           *##                         ##*\r\n        *##                               ##*\r\n      *##                                   ##*\r\n    *##                                       ##*\r\n   *##                                         ##*\r\n  *##                                           ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n  *##                                           ##*\r\n   *##                                         ##*\r\n    *##                                       ##*\r\n      *##                                   ##*\r\n        *#                                ##*\r\n           *##                         ##*\r\n               *##                 ##*\r\n                   *** ### ### ***");
    }
}