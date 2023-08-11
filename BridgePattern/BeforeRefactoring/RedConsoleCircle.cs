namespace BridgePattern.BeforeRefactoring;

internal class RedConsoleCircle : ConsoleCircle
{
    public ConsoleColor Color => ConsoleColor.Red;

    public override void Render()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        base.Render();
        Console.ForegroundColor = prevColor;
    }
}