namespace BridgePattern.BeforeRefactoring;

internal class RedConsoleSquare : ConsoleSquare
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