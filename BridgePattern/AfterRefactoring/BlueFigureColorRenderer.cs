namespace BridgePattern.AfterRefactoring;
internal class BlueFigureColorRenderer : IFigureColorRenderer
{
    public ConsoleColor Color => ConsoleColor.Blue;

    public void RenderWithChangingForegroundColor(Action action)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        action();
        Console.ForegroundColor = prev;
    }
}