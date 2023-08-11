namespace BridgePattern.AfterRefactoring;
internal class DefaultFigureColorRenderer : IFigureColorRenderer
{
    public ConsoleColor Color => Console.ForegroundColor;

    public void RenderWithChangingForegroundColor(Action action)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        action();
        Console.ForegroundColor = prev;
    }
}