namespace BridgePattern.AfterRefactoring;

internal abstract class ConsoleFigure
{
    protected IFigureColorRenderer FigureColor { get; set; }
    protected TextWriter TextWriter { get; set; }

    protected ConsoleFigure(IFigureColorRenderer figureColor)
        : this(figureColor, Console.Out)
    {
    }
    private ConsoleFigure(
        IFigureColorRenderer figureColor, 
        TextWriter textWriter)
    {
        FigureColor = figureColor;
        TextWriter = textWriter;
    }

    public virtual void Render()
        => FigureColor.RenderWithChangingForegroundColor(this.Draw);
    protected abstract void Draw();
}