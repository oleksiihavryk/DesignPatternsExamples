namespace BridgePattern.AfterRefactoring;

internal interface IFigureColorRenderer
{
    public ConsoleColor Color { get; }

    public void RenderWithChangingForegroundColor(Action action);
}