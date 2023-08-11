namespace BridgePattern.AfterRefactoring;

internal class RedFigureColorRenderer : IFigureColorRenderer
{
    public ConsoleColor Color => ConsoleColor.Red;
    
    public void RenderWithChangingForegroundColor(Action action)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        action();
        Console.ForegroundColor = prev;
    }
}