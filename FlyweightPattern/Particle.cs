namespace FlyweightPattern;
internal class Particle
{
    private readonly Map _map;
    private readonly Coordinate _coordinate;

    public int X
    {
        get => _coordinate.X;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(X), 
                    message: "Coordinate value cannot be less than 0");

            _map.ReplaceParticle(X, Y, value, Y);
        }
    }
    public int Y
    {
        get => _coordinate.Y;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(Y),
                    message: "Coordinate value cannot be less than 0");

            _map.ReplaceParticle(X, Y, X, value);
        }
    }
    public ParticleInfo Info { get; set; }

    public Particle(Map map)
    {
        _map = map;
    }
    public Particle(Map map, ParticleInfo info, Coordinate coordinate)
    {
        _map = map;
        Info = info;
        _coordinate = coordinate;
    }
}