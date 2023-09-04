namespace FlyweightPattern;
internal class Map
{
    public const int Height = 4;
    public const int Width = 6;

    private Particle[,] _particles;

    public Particle[,] Particles
    {
        get => _particles;
        set
        {
            if (value.GetLength(0) != Height
                && value.GetLength(1) != Width)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(Particles),
                    message: "Map height and width cannot be less or more than a 100 particles.");

            _particles = value;
        }
    }

    public void ReplaceParticle(int oldX, int oldY, int newX, int newY)
        => (_particles[newX, newY], _particles[oldY, oldX]) = (_particles[oldY, oldX], null);
}