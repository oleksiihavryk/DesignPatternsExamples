namespace BridgePattern.BeforeRefactoring;

internal class BlueConsoleSquare : ConsoleSquare
{
    public ConsoleColor Color => ConsoleColor.Blue;

    public override void Render()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        base.Render();
        Console.ForegroundColor = prevColor;
    }
}