namespace BridgePattern.BeforeRefactoring;

internal abstract class ConsoleFigure
{
    protected TextWriter TextWriter { get; set; }

    protected ConsoleFigure()
        : this(Console.Out)
    {
    }
    protected ConsoleFigure(TextWriter textWriter)
    {
        TextWriter = textWriter;
    }

    public abstract void Render();
}