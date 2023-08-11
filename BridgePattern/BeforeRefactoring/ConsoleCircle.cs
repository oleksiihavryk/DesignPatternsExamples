namespace BridgePattern.BeforeRefactoring;

internal class ConsoleCircle : ConsoleFigure
{
    public override void Render()
    {
        TextWriter.WriteLine(
            "                   *** ### ### ***\r\n               *##                 ##*\r\n           *##                         ##*\r\n        *##                               ##*\r\n      *##                                   ##*\r\n    *##                                       ##*\r\n   *##                                         ##*\r\n  *##                                           ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n *##                                             ##*\r\n  *##                                           ##*\r\n   *##                                         ##*\r\n    *##                                       ##*\r\n      *##                                   ##*\r\n        *#                                ##*\r\n           *##                         ##*\r\n               *##                 ##*\r\n                   *** ### ### ***");
    }
}