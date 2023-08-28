namespace ProxyPattern;
internal class CacheTextDocument : ITextDocument
{
    private string? _cachedData;
    private readonly ITextDocument _textDocument;

    public string Name => _textDocument.Name;
    public string Data => _cachedData ??= _textDocument.Data;

    public CacheTextDocument(ITextDocument textDocument)
    {
        _textDocument = textDocument;
    }
}