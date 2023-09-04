using System.Drawing;

namespace FlyweightPattern;
internal class ParticleInfo
{
    public ConsoleColor Color { get; }
    public string Character { get; }

    public ParticleInfo()
    {
    }
    public ParticleInfo(ConsoleColor color, string character)
    {
        Color = color;
        Character = character;
    }
}