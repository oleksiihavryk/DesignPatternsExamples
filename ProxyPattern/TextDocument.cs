using System.Text;

namespace ProxyPattern;
internal class TextDocument : ITextDocument
{
    private readonly string _path;

    public string Name { get; }
    public string Data => File.ReadAllText(_path, Encoding.UTF8);

    public TextDocument(string name)
    {
        Name = name;
        _path = $"../../../{Name}.txt";
        if (File.Exists(_path) == false)
        {
            File.Create(_path).Dispose();
            File.WriteAllLines(_path, new []{ "i love burgers", "and cheeseburgers too!" });
        }
    }
}